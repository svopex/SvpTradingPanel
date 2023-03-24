using Mt5Api;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SvpTradingPanel
{
	public partial class FormTradingPanel : Form
	{
		public FormTradingPanel()
		{
			InitializeComponent();
		}

		private void RefreshData(Orders orders)
		{
			string currency = SvpMT5.Instance.AccountCurrency();
			var sumOfUnits = Math.Abs(orders.Select(x => x.Units).Sum());
			var rrr = orders.Select(x => ((Math.Abs(x.OpenPrice - x.PT)) / (Math.Abs(x.OpenPrice - x.SL))) / sumOfUnits * Math.Abs(x.Units)).Sum();
			var loss = orders.Select(x => Math.Abs(x.OpenPrice - x.SL) * Math.Abs(x.Units)).Sum() / SvpMT5.Instance.SymbolPoint() * SvpMT5.Instance.SymbolTradeTickValue();
			var profit = orders.Select(x => Math.Abs(x.OpenPrice - x.PT) * Math.Abs(x.Units)).Sum() / SvpMT5.Instance.SymbolPoint() * SvpMT5.Instance.SymbolTradeTickValue();
			labelRrr.Text = "RRR: " + Math.Round(rrr, 2);
			labelLoss.Text = "Loss:" + +Math.Round(loss, 2) + " " + currency;
			labelProfit.Text = "Profit:" + +Math.Round(profit, 2) + " " + currency;
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
					double actualPrice = SvpMT5.Instance.GetActualPrice();

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

		private double? GetPositionSize(bool buy)
		{
			Orders marketOrders = SvpMT5.Instance.GetMarketOrders();
			Orders pendingOrders = SvpMT5.Instance.GetPendingOrders();
			bool result =
				(Double.TryParse(textBoxPositionSize.Text, out double positionSize) // Je validni velikost pozice v textboxu?
				&& (positionSize * 0.1 > 0) // Je validni velikost pozice v textboxu?
				&& ((IsPossibleBuy(marketOrders, pendingOrders) && buy) || (IsPossibleSell(marketOrders, pendingOrders) && !buy)) // Pokud je jiz otevrena pozice, nova pozice musi byt stejnejo typu (buy/sell).
				);
			if (result)
			{
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

		private void BuySell603010(bool buy)
		{
			double? positionSize = GetPositionSize(buy);
			double? price = GetPrice(buy);
			if (positionSize != null && price != null)
			{
				if (checkBoxPendingOrder.Checked)
				{
					SvpMT5.Instance.CreatePendingOrderSlPtPercent(price.Value, positionSize.Value * 0.6, 1, GetTpDistanceByOrderSize(60));
					SvpMT5.Instance.CreatePendingOrderSlPtPercent(price.Value, positionSize.Value * 0.3, 1, GetTpDistanceByOrderSize(30));
					SvpMT5.Instance.CreatePendingOrderSlPtPercent(price.Value, positionSize.Value * 0.1, 1, GetTpDistanceByOrderSize(10));
				}
				else
				{
					SvpMT5.Instance.CreateMarketOrderSlPtPercent(positionSize.Value * 0.6, 1, GetTpDistanceByOrderSize(60));
					SvpMT5.Instance.CreateMarketOrderSlPtPercent(positionSize.Value * 0.3, 1, GetTpDistanceByOrderSize(30));
					SvpMT5.Instance.CreateMarketOrderSlPtPercent(positionSize.Value * 0.1, 1, GetTpDistanceByOrderSize(10));
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
					SvpMT5.Instance.CreatePendingOrderSlPtPercent(price.Value, positionSize.Value * 0.5, 1, GetTpDistanceByOrderSize(50));
					SvpMT5.Instance.CreatePendingOrderSlPtPercent(price.Value, positionSize.Value * 0.4, 1, GetTpDistanceByOrderSize(40));
					SvpMT5.Instance.CreatePendingOrderSlPtPercent(price.Value, positionSize.Value * 0.1, 1, GetTpDistanceByOrderSize(10));
				}
				else
				{
					SvpMT5.Instance.CreateMarketOrderSlPtPercent(positionSize.Value * 0.5, 1, GetTpDistanceByOrderSize(50));
					SvpMT5.Instance.CreateMarketOrderSlPtPercent(positionSize.Value * 0.4, 1, GetTpDistanceByOrderSize(40));
					SvpMT5.Instance.CreateMarketOrderSlPtPercent(positionSize.Value * 0.1, 1, GetTpDistanceByOrderSize(10));
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
					SvpMT5.Instance.CreatePendingOrderSlPtPercent(price.Value, positionSize.Value * 0.6, 1, GetTpDistanceByOrderSize(100));
					SvpMT5.Instance.CreatePendingOrderSlPtPercent(price.Value, positionSize.Value * 0.4, 1, GetTpDistanceByOrderSize(40));
				}
				else
				{
					SvpMT5.Instance.CreateMarketOrderSlPtPercent(positionSize.Value * 0.6, 1, GetTpDistanceByOrderSize(100));
					SvpMT5.Instance.CreateMarketOrderSlPtPercent(positionSize.Value * 0.4, 1, GetTpDistanceByOrderSize(40));
				}
				JoinSl();
			}
		}

		private double GetTpDistanceByUnit(Orders orders, double unit)
		{
			// Aby nebyly vsechny TP ve stejne vzdalenosti, pocitam vzdalenost TP podle velikosti pozice.
			// Nejvetsi pozice ma nejblizsi TP.
			double maxUnit = orders.Max(x => x.Units);
			return 0.7 + Math.Abs(maxUnit - unit) * 3;
		}

		private double GetTpDistanceByOrderSize(int percent)
		{
			// Aby nebyly vsechny TP ve stejne vzdalenosti, pocitam vzdalenost TP podle velikosti pozice.
			// Nejvetsi pozice ma nejblizsi TP.
			return 0.7 + Math.Abs((double)percent - 100) / 100;
		}

		private void BuySellPercent(bool buy, int percent)
		{
			double? positionSize = GetPositionSize(buy);
			double? price = GetPrice(buy);
			if (positionSize != null && price != null)
			{
				if (checkBoxPendingOrder.Checked)
				{
					SvpMT5.Instance.CreatePendingOrderSlPtPercent(price.Value, positionSize.Value * percent / 100, 1, GetTpDistanceByOrderSize(percent));
				}
				else
				{
					SvpMT5.Instance.CreateMarketOrderSlPtPercent(positionSize.Value * percent / 100, 1, GetTpDistanceByOrderSize(percent));
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
				orders = SvpMT5.Instance.GetPendingOrders();
				double idealPrice = IdealMaximumPrice(orders);
				foreach (var order in orders)
				{
					order.OpenPrice = idealPrice + (idealPrice * movement);
					SvpMT5.Instance.ModifyPendingOrder(order);
				}
			}
			else
			{
				orders = SvpMT5.Instance.GetMarketOrders();
				double idealSl = IdealMaximumSlPrice(orders);
				foreach (var order in orders)
				{
					order.SL = idealSl + (idealSl * movement);
					SvpMT5.Instance.SetPositionSlAndPt(order);
				}
				if (!orders.Any())
				{
					orders = SvpMT5.Instance.GetPendingOrders();
					idealSl = IdealMaximumSlPrice(orders);
					foreach (var order in orders)
					{
						order.SL = idealSl + (idealSl * movement);
						SvpMT5.Instance.SetOrderSlAndPt(order);
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
				orders = SvpMT5.Instance.GetPendingOrders();
				double idealPrice = IdealMaximumPrice(orders);
				foreach (var order in orders)
				{
					order.OpenPrice = idealPrice - (idealPrice * movement);
					SvpMT5.Instance.ModifyPendingOrder(order);
				}
			}
			else
			{
				orders = SvpMT5.Instance.GetMarketOrders();
				double idealSl = IdealMaximumSlPrice(orders);
				foreach (var order in orders)
				{
					order.SL = idealSl - (idealSl * movement);
					SvpMT5.Instance.SetPositionSlAndPt(order);
				}
				if (!orders.Any())
				{
					orders = SvpMT5.Instance.GetPendingOrders();
					idealSl = IdealMaximumSlPrice(orders);
					foreach (var order in orders)
					{
						order.SL = idealSl - (idealSl * movement);
						SvpMT5.Instance.SetOrderSlAndPt(order);
					}
				}
			}
			RefreshData(orders);
		}

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
			double priceAfterJoin = PriceAfterJoin(orders); // Pokud ceny jsou vsechny stejne, vrati se hodnota tohoto stejneho SL, jinak se vraci nula.
			foreach (var order in orders)
			{
				if (priceAfterJoin == 0)
				{
					order.OpenPrice = idealMinimumPrice;
				}
				else
				{
					order.OpenPrice = priceAfterJoin;
				}
				SvpMT5.Instance.ModifyPendingOrder(order);
			}
			return orders.Any();
		}

		private bool JoinSl(Orders orders, bool position)
		{
			double idealMinimumSl = IdealMaximumSlPrice(orders); // Minimalni SL (je nejdale od ceny).
			double slPriceAfterJoin = SlPriceAfterJoin(orders); // Pokud SL jsou vsechny stejne, vrati se hodnota tohoto stejneho SL, jinak se vraci nula.
			foreach (var order in orders)
			{
				if (slPriceAfterJoin == 0)
				{
					order.SL = idealMinimumSl;
				}
				else
				{
					order.SL = slPriceAfterJoin;
				}
				if (position)
				{
					SvpMT5.Instance.SetPositionSlAndPt(order);
				}
				else
				{
					SvpMT5.Instance.SetOrderSlAndPt(order);
				}
			}
			return orders.Any();
		}

		private void JoinSl()
		{
			if (checkBoxMovePendingOrder.Checked)
			{
				Orders orders = SvpMT5.Instance.GetPendingOrders();
				JoinPrice(orders);
			}
			else
			{
				Orders orders = SvpMT5.Instance.GetMarketOrders();
				if (!JoinSl(orders, true))
				{
					orders = SvpMT5.Instance.GetPendingOrders();
					JoinSl(orders, false);
				}
				RefreshData(orders);
			}
		}

		private void buttonSlUpMax_Click(object sender, EventArgs e)
		{
			SlUp(0.0025);
		}

		private void buttonSlDownMax_Click(object sender, EventArgs e)
		{
			SlDown(0.0025);
		}

		private void buttonSlUp_Click(object sender, EventArgs e)
		{
			SlUp(0.001);
		}

		private void buttonSlDown_Click(object sender, EventArgs e)
		{
			SlDown(0.001);
		}

		private void buttonJoinSl_Click(object sender, EventArgs e)
		{
			JoinSl();
		}

		private void buttonSlUpMini_Click(object sender, EventArgs e)
		{
			SlUp(0.00025);
		}

		private void buttonSlDownMini_Click(object sender, EventArgs e)
		{
			SlDown(0.00025);
		}

		private void checkBoxAlwaysOnTop_CheckedChanged(object sender, EventArgs e)
		{
			this.TopMost = checkBoxAlwaysOnTop.Checked;
		}

		private void buttonOrderBuy1_Click(object sender, EventArgs e)
		{
			BuySell603010(true);
		}

		private void buttonOrderSell1_Click(object sender, EventArgs e)
		{
			BuySell603010(false);
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
				labelConnected.Text = "*****";
				labelConnected.ForeColor = Color.Green;
			}
			else
			{
				labelConnected.Text = "-----";
				labelConnected.ForeColor = Color.Red;
			}
		}

		private void FormTradingPanel_Load(object sender, EventArgs e)
		{
			this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);

			bool connected = SvpMT5.Instance.Connect();
			ShowLabelConnected(connected);

			checkBoxMovePendingOrder.Checked = false;
			checkBoxPendingOrder.Checked = false;
			textBoxPrice.Enabled = false;

			textBoxPositionSize.Text = "0.5";
			checkBoxAlwaysOnTop.Checked = true;

			this.TopMost = true;

			if (connected)
			{
				Orders orders = SvpMT5.Instance.GetMarketOrders();
				RefreshData(orders);
			}
		}

		private void buttonCloseAll_Click(object sender, EventArgs e)
		{
			Orders orders = SvpMT5.Instance.GetMarketOrders();
			foreach (var order in orders)
			{
				SvpMT5.Instance.CloseOrder(order.Id);
			}
			SvpMT5.Instance.OrdersCloseAll();
		}

		private void timerRefreshLabels_Tick(object sender, EventArgs e)
		{
			bool connected = SvpMT5.Instance.isConnected();
			ShowLabelConnected(connected);
			if (!connected)
			{
				SvpMT5.Instance.Disconnect();
				SvpMT5.Instance.Connect();
			}
		}

		private void checkBoxPendingOrder_CheckedChanged(object sender, EventArgs e)
		{
			textBoxPrice.Enabled = checkBoxPendingOrder.Checked;
		}

		private void buttonSetTp_Click(object sender, EventArgs e)
		{
			Orders orders = SvpMT5.Instance.GetMarketOrders();
			if (orders.Any())
			{
				foreach (var order in orders)
				{
					SvpMT5.Instance.SetPositionSlAndPtPercent(order, 0, GetTpDistanceByUnit(orders, Math.Abs(order.Units)));
				}
				RefreshData(orders);
			}
			else
			{
				orders = SvpMT5.Instance.GetPendingOrders();
				foreach (var order in orders)
				{
					SvpMT5.Instance.SetPendingOrderSlAndPtPercent(order, 0, GetTpDistanceByUnit(orders, Math.Abs(order.Units)));
				}
				RefreshData(orders);
			}
		}
	}
}
