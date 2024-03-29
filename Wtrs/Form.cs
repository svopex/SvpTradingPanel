﻿using Mt5Api;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utils;

namespace Wtrs
{
	public partial class Form : System.Windows.Forms.Form
	{
		public Form()
		{
			InitializeComponent();
		}

		private double SymbolPoint { get; set; }
		private double SymbolTradeTickValue { get; set; }
		private int SymbolDigits { get; set; }
		private const double Risk = 0.005;

		private void RefreshData()
		{
			Orders orders = MetatraderInstance.Instance.GetMarketOrders();
			string currency = MetatraderInstance.Instance.AccountCurrency();
			var sumOfUnits = Math.Abs(orders.Select(x => x.Units).Sum());
			var rrr = orders.Select(x => ((Math.Abs(x.OpenPrice - x.PT)) / (Math.Abs(x.OpenPrice - x.SL))) / sumOfUnits * Math.Abs(x.Units)).Sum();
			var loss = orders.Select(x => Math.Abs(x.OpenPrice - x.SL) * Math.Abs(x.Units)).Sum() / MetatraderInstance.Instance.SymbolPoint() * MetatraderInstance.Instance.SymbolTradeTickValue();
			var profit = orders.Select(x => Math.Abs(x.OpenPrice - x.PT) * Math.Abs(x.Units)).Sum() / MetatraderInstance.Instance.SymbolPoint() * MetatraderInstance.Instance.SymbolTradeTickValue();
			labelRrr.Text = "RRR: " + Math.Round(rrr, 2);
			labelLoss.Text = "Loss: " + Math.Round(loss, 2) + " " + currency;
			labelProfit.Text = "Profit: " + Math.Round(profit, 2) + " " + currency;

			var WtrsAtr5 = MetatraderInstance.Instance.WtrsAtr(5);
			var WtrsAtr10 = MetatraderInstance.Instance.WtrsAtr(10);
			labelAtr.Text = "Atr5: " + Math.Round(WtrsAtr5, 2).ToString() + "   Atr10: " + Math.Round(WtrsAtr10, 2).ToString();
		}

		private void Form_Load(object sender, EventArgs e)
		{
			bool connected = MetatraderInstance.Connect();

			ShowLabelConnected(false);

			timer.Interval = 1000;
			timer.Enabled = true;

			labelAtr.Text = String.Empty;

			this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);

			this.Text = "SvpTradingPanel - " + Utilities.StrategyName;
		}

		public void ShowLabelConnected(bool connected)
		{
			if (connected)
			{
				labelConnected.Text = "**********";
				labelConnected.ForeColor = Color.Green;
			}
			else
			{
				labelConnected.Text = "----------";
				labelConnected.ForeColor = Color.Red;
			}
		}

		private void timer_Tick(object sender, EventArgs e)
		{
			bool connected = MetatraderInstance.IsConnected();
			if (connected)
			{
				connected = MetatraderInstance.Instance.IsConnected();
				if (connected)
				{
					try
					{
						SymbolPoint = MetatraderInstance.Instance.SymbolPoint();
						SymbolTradeTickValue = MetatraderInstance.Instance.SymbolTradeTickValue();
						SymbolDigits = MetatraderInstance.Instance.SymbolLotStepDigits();

						RefreshData();
					}
					catch { }
				}
				else
				{
					MetatraderInstance.Instance.Disconnect();
					MetatraderInstance.Instance.Connect();
				}
			}
			ShowLabelConnected(connected);
		}

		private double RoundPrice(int symbolDigits, double number)
		{
			//int digits = MetatraderInstance.Instance.SymbolDigits();
			//int digits = MetatraderInstance.Instance.SymbolLotStepDigits();
			double value = Math.Round(number, symbolDigits);
			return value;
		}

		private void buttonBuy_Click(object sender, EventArgs e)
		{
			if (!MetatraderInstance.Instance.IsOpenPosition())
			{
				var wtrsLow = MetatraderInstance.Instance.WtrsLow();
				var actualAskPrice = MetatraderInstance.Instance.GetActualAskPrice();
				var actualBidPrice = MetatraderInstance.Instance.GetActualBidPrice();
				var spread = actualAskPrice - actualBidPrice;
				var WtrsAtr5 = MetatraderInstance.Instance.WtrsAtr(5);

				// Long calculation
				var longDifferenceBetweenSLAndActualPrice = actualAskPrice - (wtrsLow - spread); // Ask price, protoze na ni jsem nakupoval a na ni bude ztrata
				var longPositionSize = MetatraderInstance.Instance.AccountEquity() * Risk / (longDifferenceBetweenSLAndActualPrice / SymbolPoint * SymbolTradeTickValue);
				var longSlPrice = wtrsLow - spread;
				var longTpPrice = actualBidPrice + WtrsAtr5; // ASK price, protoze na ni prodavampri shortu				

				MetatraderInstance.Instance.CreateMarketOrderSlPt(RoundPrice(SymbolDigits, longPositionSize), RoundPrice(SymbolDigits, longSlPrice), RoundPrice(SymbolDigits, longTpPrice));
				
				var WtrsAtr10 = MetatraderInstance.Instance.WtrsAtr(10);
				var longTpPrice2 = actualBidPrice + WtrsAtr10; // ASK price, protoze na ni prodavampri shortu

				MetatraderInstance.Instance.CreateMarketOrderSlPt(RoundPrice(SymbolDigits, longPositionSize), RoundPrice(SymbolDigits, longSlPrice), RoundPrice(SymbolDigits, longTpPrice2));
			}
		}

		private void buttonSell_Click(object sender, EventArgs e)
		{
			if (!MetatraderInstance.Instance.IsOpenPosition())
			{
				var wtrsHigh = MetatraderInstance.Instance.WtrsHigh();
				var actualAskPrice = MetatraderInstance.Instance.GetActualAskPrice();
				var actualBidPrice = MetatraderInstance.Instance.GetActualBidPrice();
				var spread = actualAskPrice - actualBidPrice;
				var WtrsAtr5 = MetatraderInstance.Instance.WtrsAtr(5);

				// Short calculation
				var shortDifferenceBetweenSLAndActualPrice = wtrsHigh + spread - actualBidPrice; // Bid price, protoze na ni jsem nakupoval a na ni bude ztrata
				var shortPositionSize = MetatraderInstance.Instance.AccountEquity() * Risk / (shortDifferenceBetweenSLAndActualPrice / SymbolPoint * SymbolTradeTickValue);
				var shortSlPrice = wtrsHigh + spread; //(wtrsHigh - actualBidPrice) + spread + actualBidPrice;
				var shortTpPrice = actualAskPrice - WtrsAtr5; // ASK price, protoze na ni prodavam pri shortu
				
				MetatraderInstance.Instance.CreateMarketOrderSlPt(RoundPrice(SymbolDigits, -shortPositionSize), RoundPrice(SymbolDigits, shortSlPrice), RoundPrice(SymbolDigits, shortTpPrice));

				var WtrsAtr10 = MetatraderInstance.Instance.WtrsAtr(10);
				var shortTpPrice2 = actualAskPrice - WtrsAtr10; // ASK price, protoze na ni prodavam pri shortu

				MetatraderInstance.Instance.CreateMarketOrderSlPt(RoundPrice(SymbolDigits, -shortPositionSize), RoundPrice(SymbolDigits, shortSlPrice), RoundPrice(SymbolDigits, shortTpPrice2));
			}
		}

		private void buttonCloseAll_Click(object sender, EventArgs e)
		{
			Orders orders = MetatraderInstance.Instance.GetMarketOrders();
			foreach (var order in orders)
			{
				MetatraderInstance.Instance.CloseMarketOrder(order.Id);
			}
			orders = MetatraderInstance.Instance.GetPendingOrders();
			foreach (var order in orders)
			{
				MetatraderInstance.Instance.ClosePendingOrder(order.Id);
			}
		}
	}
}
