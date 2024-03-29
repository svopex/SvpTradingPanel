﻿using Mt5Api;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Net.Http;
using System.Runtime.Remoting.Messaging;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utils;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace SvpTradingPanel
{
	public partial class FormTradingPanel : Form
	{
		private const int SlToBeAutomationProgressIncrementConstant = 20;
		private bool SlToBeAutomation { get; set; }
		private Orders SlToBeAutomationOrders { get; set; }

		private enum SlTypeEnum
		{
			Monitoring,
			BreakEven,
			Half
		}

		private SlTypeEnum SlToBeAutomationType { get; set; }

		public FormTradingPanel()
		{
			InitializeComponent();
		}

		private void RefreshLabelSlLoss()
		{
			string currency = MetatraderInstance.Instance?.AccountCurrency();
			if (currency != null)
			{
				labelSlLoss.Text = "Full SL loss: " + Math.Round(RiskValue() * GetTrackBarPositionUsingPercent() / 100, 2) + " " + currency;
			}
		}

		private void RefreshData(Orders orders)
		{
			string currency = MetatraderInstance.Instance.AccountCurrency();
			var sumOfUnits = Math.Abs(orders.Select(x => x.Units).Sum());
			var rrr = orders.Select(x => ((Math.Abs(x.OpenPrice - x.PT)) / (Math.Abs(x.OpenPrice - x.SL))) / sumOfUnits * Math.Abs(x.Units)).Sum();
			var loss = orders.Select(x => Math.Abs(x.OpenPrice - x.SL) * Math.Abs(x.Units)).Sum() / MetatraderInstance.Instance.SymbolPoint() * MetatraderInstance.Instance.SymbolTradeTickValue();
			var profit = orders.Select(x => Math.Abs(x.OpenPrice - x.PT) * Math.Abs(x.Units)).Sum() / MetatraderInstance.Instance.SymbolPoint() * MetatraderInstance.Instance.SymbolTradeTickValue();
			labelRrr.Text = "RRR: " + Math.Round(rrr, 2);
			labelLoss.Text = "Loss: " + Math.Round(loss, 2) + " " + currency;
			labelProfit.Text = "Profit: " + Math.Round(profit, 2) + " " + currency;
			RefreshLabelSlLoss();
			labelSymbol.Text = MetatraderInstance.Instance.Symbol;
		}

		private double? GetPrice(bool buy)
		{
			if (Double.TryParse(textBoxPrice.Text, out double price))
			{
				return price;
			}
			else
			{
				if (checkBoxPendingOrder.Checked)
				{
					double actualPrice = MetatraderInstance.Instance.GetActualPrice();

					// Pending order vytvor v idealni vzdalenosti od ceny, pokud cena neni zadana.
					if (buy)
					{
						return actualPrice - (actualPrice * 0.01);
					}
					else
					{
						return actualPrice + (actualPrice * 0.01);
					}
				}
				else
				{
					// Market order
					return 0;
				}
			}
		}

		private double RoundPrice(double number)
		{
			//int digits = MetatraderInstance.Instance.SymbolDigits();
			int digits = MetatraderInstance.Instance.SymbolLotStepDigits();
			double value = Math.Round(number, digits);
			return value;
		}

		private double RiskValue()
		{
			// na uctu mam pouze 1/4 toho, co chci obchodovat, kvuli mozne kradezi. Pouzivam paku.			
			double accountEquity = Utilities.AccountEquity == 0 ? MetatraderInstance.Instance.AccountEquity() : Utilities.AccountEquity;
			return accountEquity * Utilities.BrokerMarginEquityCoefficient * Utilities.RiskToTrade;
		}

		private double? GetPositionSize(bool buy)
		{
			Orders marketOrders = MetatraderInstance.Instance.GetMarketOrders();
			Orders pendingOrders = MetatraderInstance.Instance.GetPendingOrders();
			bool result =
				(Double.TryParse(textBoxSlDistance.Text, out double positionSize) // Je validni velikost pozice v textboxu?
				&& (positionSize * 0.1 > 0) // Je validni velikost pozice v textboxu?
				&& ((IsPossibleBuy(marketOrders, pendingOrders) && buy) || (IsPossibleSell(marketOrders, pendingOrders) && !buy)) // Pokud je jiz otevrena pozice, nova pozice musi byt stejnejo typu (buy/sell).
				);
			if (result)
			{
				// tick size misto velikosti pozice				
				var symbolTradeTickValue = MetatraderInstance.Instance.SymbolTradeTickValue();
				positionSize = RiskValue() / (positionSize * symbolTradeTickValue);
				
				if (!buy)
				{
					positionSize = -positionSize;
				}
				return positionSize;
			}
			else
			{
				return null;
			}
		}

		private void BuySell403030(bool buy)
		{
			double? positionSize = GetPositionSize(buy);
			double? price = GetPrice(buy);
			if (positionSize != null && price != null)
			{
				if (checkBoxPendingOrder.Checked)
				{
					MetatraderInstance.Instance.CreatePendingOrderSlPtPercent(price.Value, CalculatePosition(positionSize.Value, 0.4), 1, GetTpDistanceByOrderSize(50));
					MetatraderInstance.Instance.CreatePendingOrderSlPtPercent(price.Value, CalculatePosition(positionSize.Value, 0.3), 1, GetTpDistanceByOrderSize(35));
					MetatraderInstance.Instance.CreatePendingOrderSlPtPercent(price.Value, CalculatePosition(positionSize.Value, 0.3), 1, GetTpDistanceByOrderSize(20));
				}
				else
				{
					MetatraderInstance.Instance.CreateMarketOrderSlPtPercent(CalculatePosition(positionSize.Value, 0.4), 1, GetTpDistanceByOrderSize(50));
					MetatraderInstance.Instance.CreateMarketOrderSlPtPercent(CalculatePosition(positionSize.Value, 0.3), 1, GetTpDistanceByOrderSize(35));
					MetatraderInstance.Instance.CreateMarketOrderSlPtPercent(CalculatePosition(positionSize.Value, 0.3), 1, GetTpDistanceByOrderSize(20));
				}
				JoinSl();
			}
		}

		private void BuySell504010(bool buy)
		{
			double? positionSize = GetPositionSize(buy);
			double? price = GetPrice(buy);
			if (positionSize != null && price != null)
			{
				if (checkBoxPendingOrder.Checked)
				{
					MetatraderInstance.Instance.CreatePendingOrderSlPtPercent(price.Value, CalculatePosition(positionSize.Value, 0.5), 1, GetTpDistanceByOrderSize(50));
					MetatraderInstance.Instance.CreatePendingOrderSlPtPercent(price.Value, CalculatePosition(positionSize.Value, 0.4), 1, GetTpDistanceByOrderSize(40));
					MetatraderInstance.Instance.CreatePendingOrderSlPtPercent(price.Value, CalculatePosition(positionSize.Value, 0.1), 1, GetTpDistanceByOrderSize(10));
				}
				else
				{
					MetatraderInstance.Instance.CreateMarketOrderSlPtPercent(CalculatePosition(positionSize.Value, 0.5), 1, GetTpDistanceByOrderSize(50));
					MetatraderInstance.Instance.CreateMarketOrderSlPtPercent(CalculatePosition(positionSize.Value, 0.4), 1, GetTpDistanceByOrderSize(40));
					MetatraderInstance.Instance.CreateMarketOrderSlPtPercent(CalculatePosition(positionSize.Value, 0.1), 1, GetTpDistanceByOrderSize(10));
				}
				JoinSl();
			}
		}

		private void BuySell6040(bool buy)
		{
			double? positionSize = GetPositionSize(buy);
			double? price = GetPrice(buy);
			if (positionSize != null && price != null)
			{
				if (checkBoxPendingOrder.Checked)
				{
					MetatraderInstance.Instance.CreatePendingOrderSlPtPercent(price.Value, CalculatePosition(positionSize.Value, 0.6), 1, GetTpDistanceByOrderSize(100));
					MetatraderInstance.Instance.CreatePendingOrderSlPtPercent(price.Value, CalculatePosition(positionSize.Value, 0.4), 1, GetTpDistanceByOrderSize(40));
				}
				else
				{
					MetatraderInstance.Instance.CreateMarketOrderSlPtPercent(CalculatePosition(positionSize.Value, 0.6), 1, GetTpDistanceByOrderSize(100));
					MetatraderInstance.Instance.CreateMarketOrderSlPtPercent(CalculatePosition(positionSize.Value, 0.4), 1, GetTpDistanceByOrderSize(40));
				}
				JoinSl();
			}
		}

		private double GetTpDistanceByUnit(Orders orders, double unit)
		{
			// Aby nebyly vsechny TP ve stejne vzdalenosti, pocitam vzdalenost TP podle velikosti pozice.
			// Nejvetsi pozice ma nejblizsi TP.
			double maxUnit = orders.Max(x => Math.Abs(x.Units));
			return 0.7 + Math.Abs(maxUnit - Math.Abs(unit)) * 3;
		}

		private double GetTpDistanceByOrderSize(int percent)
		{
			// Aby nebyly vsechny TP ve stejne vzdalenosti, pocitam vzdalenost TP podle velikosti pozice.
			// Nejvetsi pozice ma nejblizsi TP.
			return 0.7 + Math.Abs((double)percent - 100) / 100;
		}

		double CalculatePositionPercent(double positionSize, int percent)
		{
			return RoundPrice((positionSize * percent / 100) * (GetTrackBarPositionUsingPercent() / 100));		
		}

		double CalculatePosition(double positionSize, double x)
		{
			return RoundPrice((positionSize * x) * (GetTrackBarPositionUsingPercent() / 100));
		}

		private void BuySellPercent(bool buy, int percent)
		{
			double? positionSize = GetPositionSize(buy);
			double? price = GetPrice(buy);
			if (positionSize != null && price != null)
			{
				if (checkBoxPendingOrder.Checked)
				{
					MetatraderInstance.Instance.CreatePendingOrderSlPtPercent(price.Value, CalculatePositionPercent(positionSize.Value, percent), 1, GetTpDistanceByOrderSize(percent));
				}
				else
				{
					MetatraderInstance.Instance.CreateMarketOrderSlPtPercent(CalculatePositionPercent(positionSize.Value, percent), 1, GetTpDistanceByOrderSize(percent));
				}
				JoinSl();
			}
		}

		private bool IsPossibleBuy(Orders marketOrders, Orders pendingOrders)
		{
			return (!marketOrders.Any() && !pendingOrders.Any()) || IsExistingPositionBuy(marketOrders) || IsExistingPositionBuy(pendingOrders);
		}

		private bool IsPossibleSell(Orders marketOrders, Orders pendingOrders)
		{
			return (!marketOrders.Any() && !pendingOrders.Any()) || IsExistingPositionSell(marketOrders) || IsExistingPositionSell(pendingOrders);
		}

		/// <summary>
		/// Je pozice buy nebo sell?
		/// </summary>
		private bool IsExistingPositionSell(Orders orders)
		{
			return orders.Any() && orders[0].Units <= 0;
		}

		/// <summary>
		/// Je pozice buy nebo sell?
		/// </summary>
		private bool IsExistingPositionBuy(Orders orders)
		{
			return orders.Any() && orders[0].Units >= 0;
		}

		private double IdealMaximumSlPrice(Orders orders)
		{
			if (orders.Any())
			{
				if (IsExistingPositionBuy(orders))
				{
					return orders.Where(x => x.SL > 0).Min(x => x.SL);
				}
				else
				{
					return orders.Max(x => x.SL);
				}
			}
			return 0;
		}

		private double IdealMaximumPrice(Orders orders)
		{
			if (orders.Any())
			{
				if (IsExistingPositionBuy(orders))
				{
					return orders.Where(x => x.OpenPrice > 0).Min(x => x.OpenPrice);
				}
				else
				{
					return orders.Max(x => x.OpenPrice);
				}
			}
			return 0;
		}

		private void SlUp(double movement)
		{
			Orders orders;
			if (checkBoxMovePendingOrder.Checked)
			{
				orders = MetatraderInstance.Instance.GetPendingOrders();
				double idealPrice = IdealMaximumPrice(orders);
				foreach (var order in orders)
				{
					order.OpenPrice = idealPrice + (idealPrice * movement);
					MetatraderInstance.Instance.ModifyPendingOrder(order);
				}
			}
			else
			{
				orders = MetatraderInstance.Instance.GetMarketOrders();
				double idealSl = IdealMaximumSlPrice(orders);
				foreach (var order in orders)
				{
					order.SL = idealSl + (idealSl * movement);
					MetatraderInstance.Instance.SetPositionSlAndPt(order);
				}
				if (!orders.Any())
				{
					orders = MetatraderInstance.Instance.GetPendingOrders();
					idealSl = IdealMaximumSlPrice(orders);
					foreach (var order in orders)
					{
						order.SL = idealSl + (idealSl * movement);
						MetatraderInstance.Instance.SetOrderSlAndPt(order);
					}
				}
			}
			RefreshData(orders);
		}

		private void SlDown(double movement)
		{
			Orders orders;
			if (checkBoxMovePendingOrder.Checked)
			{
				orders = MetatraderInstance.Instance.GetPendingOrders();
				double idealPrice = IdealMaximumPrice(orders);
				foreach (var order in orders)
				{
					order.OpenPrice = idealPrice - (idealPrice * movement);
					MetatraderInstance.Instance.ModifyPendingOrder(order);
				}
			}
			else
			{
				orders = MetatraderInstance.Instance.GetMarketOrders();
				double idealSl = IdealMaximumSlPrice(orders);
				foreach (var order in orders)
				{
					order.SL = idealSl - (idealSl * movement);
					MetatraderInstance.Instance.SetPositionSlAndPt(order);
				}
				if (!orders.Any())
				{
					orders = MetatraderInstance.Instance.GetPendingOrders();
					idealSl = IdealMaximumSlPrice(orders);
					foreach (var order in orders)
					{
						order.SL = idealSl - (idealSl * movement);
						MetatraderInstance.Instance.SetOrderSlAndPt(order);
					}
				}
			}
			RefreshData(orders);
		}

		/// <summary>
		/// Pokud je nejaka limit order na nejakem miste, chceme prednostne, 
		/// aby nova cena se nastavila na jiz existujici cenu.Teprve potom
		/// chceme, aby se nastavila nejdale od ceny (IdealMaximumPrice).
		/// </summary>
		private double PriceAfterJoin(Orders orders)
		{
			if (orders.Any())
			{
				if (orders.Count() == 2)
				{
					// Pokud jsou jenom dva obchody, dej SL k tomu prvnimu z nich (podle order id).
					return orders.OrderBy(x => x.Id).First().OpenPrice;
				}
				else
				{
					// Dej SL na misto, kde jsou jiz minimalne dva obchody spolu (predpokladam, ze jsou po joinu).
					for (int i = 0; i < orders.Count; i++)
					{
						double sameValue = orders[i].OpenPrice;
						for (int j = 1; j < orders.Count; j++)
						{
							if (i != j && sameValue == orders[j].OpenPrice)
							{
								return orders[i].OpenPrice;
							}
						}
					}
				}
			}
			return 0;
		}

		/// <summary>
		/// Pokud je nejaky SL na nejakem miste, chceme prednostne, 
		/// aby novy SL se nastavil na jiz existujici cenu. Teprve potom
		/// chceme, aby se nastavil nejdale od ceny (IdealMaximumPrice).
		/// </summary>
		private double SlPriceAfterJoin(Orders orders)
		{
			if (orders.Any())
			{
				if (orders.Count() == 2)
				{
					// Pokud jsou jenom dva obchody, dej SL k tomu prvnimu z nich (podle order id).
					return orders.OrderBy(x => x.Id).First().SL;
				}
				else
				{
					// Dej SL na misto, kde jsou jiz minimalne dva obchody spolu (predpokladam, ze jsou po joinu).
					for (int i = 0; i < orders.Count; i++)
					{
						double sameValue = orders[i].SL;
						for (int j = 1; j < orders.Count; j++)
						{
							if (i != j && sameValue == orders[j].SL)
							{
								return orders[i].SL;
							}
						}
					}
				}
			}
			return 0;
		}

		private bool JoinPrice(Orders orders)
		{
			double idealMinimumPrice = IdealMaximumPrice(orders); // Minimalni cena (je nejdale od ceny).
			double priceAfterJoin = PriceAfterJoin(orders); 
			foreach (var order in orders)
			{
				double oldOpenPrice = order.OpenPrice;
				if (priceAfterJoin == 0)
				{
					order.OpenPrice = idealMinimumPrice;
				}
				else
				{
					order.OpenPrice = priceAfterJoin;
				}
				if (oldOpenPrice != order.OpenPrice)
				{
					MetatraderInstance.Instance.ModifyPendingOrder(order);
				}
			}
			return orders.Any();
		}

		private bool JoinSl(Orders orders, bool position)
		{
			double idealMinimumSl = IdealMaximumSlPrice(orders); // Minimalni SL (je nejdale od ceny).
			double slPriceAfterJoin = SlPriceAfterJoin(orders); 
			foreach (var order in orders)
			{
				double previousSl = order.SL;
				if (slPriceAfterJoin == 0)
				{
					order.SL = idealMinimumSl;
				}
				else
				{
					order.SL = slPriceAfterJoin;
				}
				if (previousSl != order.SL)
				{
					if (position)
					{
						MetatraderInstance.Instance.SetPositionSlAndPt(order);
					}
					else
					{
						MetatraderInstance.Instance.SetOrderSlAndPt(order);
					}
				}
			}
			return orders.Any();
		}

		private void JoinSl()
		{
			if (checkBoxMovePendingOrder.Checked)
			{
				Orders orders = MetatraderInstance.Instance.GetPendingOrders();
				JoinPrice(orders);
			}
			else
			{
				Orders orders = MetatraderInstance.Instance.GetMarketOrders();
				if (!JoinSl(orders, true))
				{
					orders = MetatraderInstance.Instance.GetPendingOrders();
					JoinSl(orders, false);
				}
				RefreshData(orders);
			}
		}

		private void buttonSlUpMax_Click(object sender, EventArgs e)
		{
			SlUp(0.00125);
		}

		private void buttonSlDownMax_Click(object sender, EventArgs e)
		{
			SlDown(0.00125);
		}

		private void buttonSlUp_Click(object sender, EventArgs e)
		{
			SlUp(0.0005);
		}

		private void buttonSlDown_Click(object sender, EventArgs e)
		{
			SlDown(0.0005);
		}

		private void buttonJoinSl_Click(object sender, EventArgs e)
		{
			JoinSl();
		}

		private void buttonSlUpMini_Click(object sender, EventArgs e)
		{
			SlUp(0.000125);
		}

		private void buttonSlDownMini_Click(object sender, EventArgs e)
		{
			SlDown(0.000125);
		}

		private void checkBoxAlwaysOnTop_CheckedChanged(object sender, EventArgs e)
		{
			this.TopMost = checkBoxAlwaysOnTop.Checked;
		}

		private void buttonOrderBuy1_Click(object sender, EventArgs e)
		{
			BuySell403030(true);
		}

		private void buttonOrderSell1_Click(object sender, EventArgs e)
		{
			BuySell403030(false);
		}

		private void buttonOrderBuy2_Click(object sender, EventArgs e)
		{
			BuySell6040(true);
		}

		private void buttonOrderSell2_Click(object sender, EventArgs e)
		{
			BuySell6040(false);
		}

		private void buttonOrderBuy3_Click(object sender, EventArgs e)
		{
			BuySell504010(true);
		}

		private void buttonOrderSell3_Click(object sender, EventArgs e)
		{
			BuySell504010(false);
		}

		private void buttonBuy100_Click(object sender, EventArgs e)
		{
			BuySellPercent(true, 100);
		}

		private void buttonBuy60_Click(object sender, EventArgs e)
		{
			BuySellPercent(true, 60);
		}

		private void buttonBuy30_Click(object sender, EventArgs e)
		{
			BuySellPercent(true, 30);
		}

		private void buttonBuy10_Click(object sender, EventArgs e)
		{
			BuySellPercent(true, 10);
		}

		private void buttonSell100_Click(object sender, EventArgs e)
		{
			BuySellPercent(false, 100);
		}

		private void buttonSell60_Click(object sender, EventArgs e)
		{
			BuySellPercent(false, 60);
		}

		private void buttonSell30_Click(object sender, EventArgs e)
		{
			BuySellPercent(false, 30);
		}

		private void buttonSell10_Click(object sender, EventArgs e)
		{
			BuySellPercent(false, 10);
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
				labelConnected.Text = "-----------";
				labelConnected.ForeColor = Color.Red;
			}
		}

		private void buttonCloseAll_Click(object sender, EventArgs e)
		{
			DialogResult dialogResult = MessageBox.Show("Do you really close all orders?", "SvpTradePanel", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
			if (dialogResult == DialogResult.Yes)
			{
				SlToBeAutomation = false;

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
				//MetatraderInstance.Instance.CloseAllPendingOrders();
			}
		}

		private void checkBoxPendingOrder_CheckedChanged(object sender, EventArgs e)
		{
			textBoxPrice.Enabled = checkBoxPendingOrder.Checked;
		}

		private void buttonSetTp_Click(object sender, EventArgs e)
		{
			Orders orders = MetatraderInstance.Instance.GetMarketOrders();
			if (orders.Any())
			{
				foreach (var order in orders)
				{
					MetatraderInstance.Instance.SetPositionSlAndPtPercent(order, 0, GetTpDistanceByUnit(orders, Math.Abs(order.Units)));
				}
				RefreshData(orders);
			}
			else
			{
				orders = MetatraderInstance.Instance.GetPendingOrders();
				foreach (var order in orders)
				{
					MetatraderInstance.Instance.SetPendingOrderSlAndPtPercent(order, 0, GetTpDistanceByUnit(orders, Math.Abs(order.Units)));
				}
				RefreshData(orders);
			}
		}

		private void FormTradingPanel_Load(object sender, EventArgs e)
		{
			checkBoxBlink.Checked = true;

			this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);

			bool connected = MetatraderInstance.Connect();
			ShowLabelConnected(connected);

			checkBoxMovePendingOrder.Checked = false;
			checkBoxPendingOrder.Checked = false;
			textBoxPrice.Enabled = false;

			textBoxSlDistance.Text = String.Empty; //"0.5";
			checkBoxAlwaysOnTop.Checked = true;

			this.TopMost = true;
			
			SlToBeAutomation = false;
			progressBarSlToBeAutomation.Value = 0;
			progressBarSlToHalfAutomation.Value = 0;
			progressBarSlPtMonitoring.Value = 0;

			trackBarPositionUsing.Value = Utils.Utilities.TrackBarPositionUsing;
			trackBarPositionUsing_ValueChanged(null, null);

			timerRefreshLabels.Interval = 1000;

			this.Text = "SvpTradingPanel - " + (String.IsNullOrWhiteSpace(Utilities.StrategyName) ? "strategy name not defined" : Utilities.StrategyName) + ", " + (Utilities.AccountEquity == 0 ? String.Empty : Utilities.AccountEquity + ", ") + Utilities.RiskToTrade * 100 + "%, " + Utilities.BrokerMarginEquityCoefficient + "x";
		}

		private void CallHue(bool Pt)
		{
			try
			{
				using (var client = new HttpClient())
				{
					string url;
					if (Pt)
					{
						url = "http://localhost/huePt";
					}
					else
					{
						url = "http://localhost/hueSl";
					}
					var body = "This is the body of the request.";
					var content = new StringContent(body);
					var response = client.PostAsync(url, content).GetAwaiter().GetResult();
				}
			}
			catch (Exception) { }
		}

		// Po ukonceni prvniho TP se posune SL na BE u vsech obchodu.
		private void SlAutomation()
		{
			if (SlToBeAutomation)
			{
				switch (SlToBeAutomationType)
				{
					case SlTypeEnum.Monitoring:
						if (progressBarSlPtMonitoring.Value == 100)
						{
							progressBarSlPtMonitoring.Value = 0;
						}
						else
						{
							progressBarSlPtMonitoring.Value += SlToBeAutomationProgressIncrementConstant;
						}
						break;
					case SlTypeEnum.BreakEven:
						if (progressBarSlToBeAutomation.Value == 100)
						{
							progressBarSlToBeAutomation.Value = 0;
						}
						else
						{
							progressBarSlToBeAutomation.Value += SlToBeAutomationProgressIncrementConstant;
						}
						break;
					case SlTypeEnum.Half:
						if (progressBarSlToHalfAutomation.Value == 100)
						{
							progressBarSlToHalfAutomation.Value = 0;
						}
						else
						{
							progressBarSlToHalfAutomation.Value += SlToBeAutomationProgressIncrementConstant;
						}
						break;
				}

				Orders orders = MetatraderInstance.Instance.GetMarketOrders(true);

				if (SlToBeAutomationOrders.Count != orders.Count)
				{
					Task.Delay(5000); // Cekani na pripadne uzavreni vsech pozic.

					orders = MetatraderInstance.Instance.GetMarketOrders(true);

					foreach (var instrument in SlToBeAutomationOrders.Select(x => x.Instrument).Distinct())
					{
						var slToBeAutomationOrdersByInstrument = SlToBeAutomationOrders.Where(x => x.Instrument == instrument).ToList();
						var ordersByInstrument = MetatraderInstance.Instance.GetMarketOrders(true).Where(x => x.Instrument == instrument).ToList();

						if (slToBeAutomationOrdersByInstrument.Count() > ordersByInstrument.Count())
						{
							(string instrument, double profit)? result = MetatraderInstance.Instance.GetLatestProfit(instrument);
							if (result != null)
							{
								if (checkBoxBlink.Checked)
								{
									CallHue(result.Value.profit >= 0);
								}
							}

							if (SlToBeAutomationType == SlTypeEnum.BreakEven && (ordersByInstrument.Count > 0))
							{
								foreach (var order in ordersByInstrument)
								{
									order.SL = order.OpenPrice;
									try
									{
										MetatraderInstance.Instance.SetPositionSlAndPt(order);
									}
									catch
									{
										// nothing to do.
									}									
								}
							}

							if (SlToBeAutomationType == SlTypeEnum.Half && (ordersByInstrument.Count > 0))
							{
								foreach (var order in ordersByInstrument)
								{
									if (order.Units > 0)
									{
										order.SL = order.OpenPrice - (order.OpenPrice - order.SL) / 2;
									}
									else
									{
										order.SL = order.OpenPrice + (order.SL - order.OpenPrice) / 2;
									}

/*
									// Nejde pouzit v pripade 3 obchodu, kdy pri druhem prodeji by se nastavil nesmyslny SL.
									// Proto pouzivame polovicni SL.
									if (result != null && result.Value.profit >= 2)
									{
										var symbolTradeTickValue = MetatraderInstance.Instance.SymbolTradeTickValue();
										double distance = ((result.Value.profit / MetatraderInstance.Instance.SymbolTradeTickValue()) * MetatraderInstance.Instance.SymbolPoint()) / ordersByInstrument.Sum(x => Math.Abs(x.Units));
*/

									try
									{
										MetatraderInstance.Instance.SetPositionSlAndPt(order);
									}
									catch
									{
										// nothing to do.
									}
								}
							}
						}
					}

					SlToBeAutomationOrders = MetatraderInstance.Instance.GetMarketOrders(true);
				}

				if (!SlToBeAutomationOrders.Any())
				{
					SlToBeAutomation = false;
				}
			}
			if (SlToBeAutomation)
			{
				switch (SlToBeAutomationType)
				{
					case SlTypeEnum.Monitoring:
						progressBarSlToBeAutomation.Value = 0;
						progressBarSlToHalfAutomation.Value = 0;
						break;
					case SlTypeEnum.BreakEven:
						progressBarSlToHalfAutomation.Value = 0;
						progressBarSlPtMonitoring.Value = 0;
						break;
					case SlTypeEnum.Half:
						progressBarSlToBeAutomation.Value = 0;
						progressBarSlPtMonitoring.Value = 0;
						break;
				}
			}
			else
			{
				progressBarSlToBeAutomation.Value = 0;
				progressBarSlPtMonitoring.Value = 0;
				progressBarSlToHalfAutomation.Value = 0;
			}
		}

		private void timerRefreshLabels_Tick(object sender, EventArgs e)
		{
			bool connected = MetatraderInstance.IsConnected();
			if (connected)
			{
				connected = MetatraderInstance.Instance.IsConnected();
				if (connected)
				{
					try
					{
						Orders orders = MetatraderInstance.Instance.GetMarketOrders();
						if (!orders.Any())
						{
							orders = MetatraderInstance.Instance.GetPendingOrders();
						}
						RefreshData(orders);

						SlAutomation();
					}
					catch (Exception ex)
					{
						Logger.WriteLineError(ex.ToString());
					}
				}
				else
				{
					MetatraderInstance.Instance.Disconnect();
					MetatraderInstance.Instance.Connect();
				}
			}
			ShowLabelConnected(connected);
		}

		private double GetTrackBarPositionUsingPercent()
		{
			return trackBarPositionUsing.Value;
/*
			switch (trackBarPositionUsing.Value)
			{
				case 0: return 10;
				case 1: return 25;
				case 2: return 50;
				case 3: return 75;
				case 4: return 100;
				case 5: return 125;
				case 6: return 150;
				case 7: return 175;
				case 8: return 200;
				case 9: return 225;
				case 10: return 250;
				default: throw new Exception();
			}
*/
		}

		private void trackBarPositionUsing_ValueChanged(object sender, EventArgs e)
		{
			labelPositionUsingPercent.Text = GetTrackBarPositionUsingPercent().ToString() + " %";
			RefreshLabelSlLoss();
		}

		private void buttonSlToBeAutomation_Click(object sender, EventArgs e)
		{
			SlToBeAutomation = !SlToBeAutomation;

			SlToBeAutomationOrders = MetatraderInstance.Instance.GetMarketOrders(true);

			SlToBeAutomationType = SlTypeEnum.BreakEven;
		}

		private void buttonSlToHalfAutomation_Click(object sender, EventArgs e)
		{
			SlToBeAutomation = !SlToBeAutomation;

			SlToBeAutomationOrders = MetatraderInstance.Instance.GetMarketOrders(true);

			SlToBeAutomationType = SlTypeEnum.Half;
		}

		private void buttonSlPtMonitoring_Click(object sender, EventArgs e)
		{
			SlToBeAutomation = !SlToBeAutomation;

			SlToBeAutomationOrders = MetatraderInstance.Instance.GetMarketOrders(true);

			SlToBeAutomationType = SlTypeEnum.Monitoring;
		}

		private void buttonEquity_Click(object sender, EventArgs e)
		{
			FormEquity formEquity = new FormEquity();
			formEquity.MainWindowTopMost = checkBoxAlwaysOnTop.Checked;
			formEquity.ShowDialog();
		}
	}
}
