using System.Collections.Generic;
using System.Runtime.Serialization;
using Utils;
using xAPI.Codes;
using xAPI.Commands;
using xAPI.Sync;

namespace Xtb
{
	public partial class Form1 : Form
	{
		private const int SlToBeAutomationProgressIncrementConstant = 20;
		private bool SlToBeAutomation { get; set; }
		private bool SlToBeAutomationMoveSlEnabled { get; set; }
		private List<Order>? SlToBeAutomationOrders { get; set; }

		public Form1()
		{
			InitializeComponent();
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

		private void buttonBuy631_Click(object sender, EventArgs e)
		{
			Buy(0.6, 0.3, 0.1);
		}
		private void buttonSell631_Click(object sender, EventArgs e)
		{
			Sell(0.6, 0.3, 0.1);
		}

		private void buttonBuy541_Click(object sender, EventArgs e)
		{
			Buy(0.5, 0.4, 0.1);
		}

		private void buttonSell541_Click(object sender, EventArgs e)
		{
			Sell(0.5, 0.4, 0.1);
		}

		private void buttonBuy64_Click(object sender, EventArgs e)
		{
			Buy(0.6, 0.4, 0);
		}

		private void buttonSell64_Click(object sender, EventArgs e)
		{
			Sell(0.6, 0.4, 0);
		}

		private void Buy(double p1, double p2, double p3)
		{
			DisableSlToBeAutomation();

			double limitPrice;
			if (Double.TryParse(textBoxLimitPrice.Text, out limitPrice))
			{
				double slDistance;
				if (Double.TryParse(textBoxSlDistance.Text, out slDistance))
				{
					XtbApi xtbApi = new XtbApi(textBoxSymbol.Text, slDistance);
					xtbApi.BuyLimit(limitPrice, p1 * GetTrackBarPositionUsingPercent() / 100, p2 * GetTrackBarPositionUsingPercent() / 100, p3 * GetTrackBarPositionUsingPercent() / 100);
				}
			}
			else
			{
				double slDistance;
				if (Double.TryParse(textBoxSlDistance.Text, out slDistance))
				{
					XtbApi xtbApi = new XtbApi(textBoxSymbol.Text, slDistance);
					xtbApi.Buy(p1 * GetTrackBarPositionUsingPercent() / 100, p2 * GetTrackBarPositionUsingPercent() / 100, p3 * GetTrackBarPositionUsingPercent() / 100);
				}
			}
			JoinSl();
		}

		private void Sell(double p1, double p2, double p3)
		{
			DisableSlToBeAutomation();

			double limitPrice;
			if (Double.TryParse(textBoxLimitPrice.Text, out limitPrice))
			{
				double slDistance;
				if (Double.TryParse(textBoxSlDistance.Text, out slDistance))
				{
					XtbApi xtbApi = new XtbApi(textBoxSymbol.Text, slDistance);
					xtbApi.SellLimit(limitPrice, p1 * GetTrackBarPositionUsingPercent() / 100, p2 * GetTrackBarPositionUsingPercent() / 100, p3 * GetTrackBarPositionUsingPercent() / 100);
				}
			}
			else
			{
				double slDistance;
				if (Double.TryParse(textBoxSlDistance.Text, out slDistance))
				{
					XtbApi xtbApi = new XtbApi(textBoxSymbol.Text, slDistance);
					xtbApi.Sell(p1 * GetTrackBarPositionUsingPercent() / 100, p2 * GetTrackBarPositionUsingPercent() / 100, p3 * GetTrackBarPositionUsingPercent() / 100);
				}
			}
			JoinSl();
		}

		private void RefreshTexts()
		{
			if (!String.IsNullOrWhiteSpace(textBoxSymbol.Text))
			{
				XtbApi xtbApi = new XtbApi(textBoxSymbol.Text, 0);
				(double, double) result = xtbApi.CalculateProfit();
				var accountCurrency = xtbApi.GetAccountCurrency();
				string fullSl = "Full SL loss: " + Math.Round(xtbApi.GetRisk() * GetTrackBarPositionUsingPercent() / 100, 2) + " " + accountCurrency;
				labelRRR.Text = $"Symbol: {textBoxSymbol.Text}\r\nRRR: {Math.Round(result.Item1 / result.Item2, 2)}\r\nProfit: {Math.Round(result.Item1, 2)} {accountCurrency}\r\nLoss: {Math.Round(result.Item2, 2)} {accountCurrency}\r\n{fullSl}";
			}
		}

		private void buttonCalculate_Click(object sender, EventArgs e)
		{
			DisableSlToBeAutomation();
			RefreshTexts();
		}

		private void buttonSlToBe_Click(object sender, EventArgs e)
		{
			SlToBeAutomation = !SlToBeAutomation;
			if (!SlToBeAutomation)
			{
				DisableSlToBeAutomation();
			}
			SlToBeAutomationMoveSlEnabled = true;
			XtbApi xtbApi = new XtbApi(textBoxSymbol.Text, 0);
			SlToBeAutomationOrders = xtbApi.GetMarketOrders(true);
		}

		private void buttonSlPtMonitoring_Click(object sender, EventArgs e)
		{
			SlToBeAutomation = !SlToBeAutomation;
			if (!SlToBeAutomation)
			{
				DisableSlToBeAutomation();
			}
			SlToBeAutomationMoveSlEnabled = false;
			XtbApi xtbApi = new XtbApi(textBoxSymbol.Text, 0);
			SlToBeAutomationOrders = xtbApi.GetMarketOrders(true);
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			timerRefreshTexts.Enabled = false;

			DisableSlToBeAutomation();
			timer.Interval = 1000;

			this.TopMost = true;
			checkBoxAlwaysOnTop.Checked = true;

			checkBoxMovePendingOrder.Checked = false;

			this.Text = "XTB - " + Utilities.XtbComment + ", " + Utilities.XtbUserId + ", " + Utilities.XtbServerType.Description + ", " + Utilities.XtbRiskInPercent * 100 + "%, " + Utilities.XtbBrokerMarginEquityCoefficient + "x";
		}

		private void DisableSlToBeAutomation()
		{
			SlToBeAutomation = false;
			progressBarSlPtMonitoring.Value = 0;
			progressBarSlToBe.Value = 0;
		}

		private void timer_Tick(object sender, EventArgs e)
		{
			if (SlToBeAutomation)
			{
				if (SlToBeAutomationMoveSlEnabled)
				{
					if (progressBarSlToBe.Value == 100)
					{
						progressBarSlToBe.Value = 0;
					}
					else
					{
						progressBarSlToBe.Value += SlToBeAutomationProgressIncrementConstant;
					}
				}
				else
				{
					if (progressBarSlPtMonitoring.Value == 100)
					{
						progressBarSlPtMonitoring.Value = 0;
					}
					else
					{
						progressBarSlPtMonitoring.Value += SlToBeAutomationProgressIncrementConstant;
					}
				}

				XtbApi xtbApi = new XtbApi(textBoxSymbol.Text, 0);
				xtbApi.Init();

				var orders = xtbApi.GetMarketOrders(true);

				if (SlToBeAutomationOrders!.Count != orders.Count)
				{
					Task.Delay(5000); // Cekani na pripadne uzavreni vsech pozic.

					foreach (var instrument in SlToBeAutomationOrders.Select(x => x.Instrument).Distinct())
					{
						var slToBeAutomationOrdersByInstrument = SlToBeAutomationOrders.Where(x => x.Instrument == instrument).ToList();
						var ordersByInstrument = xtbApi.GetMarketOrders(true).Where(x => x.Instrument == instrument).ToList();

						if (slToBeAutomationOrdersByInstrument.Count() > ordersByInstrument.Count())
						{
							(string instrument, double profit)? result = xtbApi.GetLatestProfit(instrument!);
							if (result != null)
							{
								CallHue(result.Value.profit > 0);
							}

							if (SlToBeAutomationMoveSlEnabled && (ordersByInstrument.Count > 0))
							{
								foreach (var order in ordersByInstrument)
								{
									order.SL = order.OpenPrice;
									xtbApi.SetPositionSlAndPt(order);
								}
							}
						}
					}

					SlToBeAutomationOrders = xtbApi.GetMarketOrders(true);
				}

				//if (!SlToBeAutomationOrders.Any())
				//{
				//	DisableSlToBeAutomation();
				//}
			}
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

		private void trackBarPositionUsing_ValueChanged(object? sender, EventArgs? e)
		{
			labelPositionUsingPercent.Text = GetTrackBarPositionUsingPercent().ToString() + " %";
			//timerRefreshTexts.Enabled = true;
		}

		private void timerRefreshTexts_Tick(object sender, EventArgs e)
		{
			timerRefreshTexts.Enabled = false;
			RefreshTexts();
		}

		private void buttonBuy100_Click(object sender, EventArgs e)
		{
			Buy(1, 0, 0);
		}

		private void buttonBuy60_Click(object sender, EventArgs e)
		{
			Buy(0.6, 0, 0);
		}

		private void buttonBuy30_Click(object sender, EventArgs e)
		{
			Buy(0.3, 0, 0);
		}

		private void buttonBuy10_Click(object sender, EventArgs e)
		{
			Buy(0.1, 0, 0);
		}

		private void buttonSell100_Click(object sender, EventArgs e)
		{
			Sell(1, 0, 0);
		}

		private void buttonSell60_Click(object sender, EventArgs e)
		{
			Sell(0.6, 0, 0);
		}

		private void buttonSell30_Click(object sender, EventArgs e)
		{
			Sell(0.3, 0, 0);
		}

		private void buttonSell10_Click(object sender, EventArgs e)
		{
			Sell(0.1, 0, 0);
		}

		/// <summary>
		/// Je pozice buy nebo sell?
		/// </summary>
		private bool IsExistingPositionBuy(List<Order> orders)
		{
			return orders.Any() && orders[0].Units >= 0;
		}

		private double IdealMaximumSlPrice(List<Order> orders)
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

		private double IdealMaximumPrice(List<Order> orders)
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

		/// <summary>
		/// Pokud je nejaka limit order na nejakem miste, chceme prednostne, 
		/// aby nova cena se nastavila na jiz existujici cenu.Teprve potom
		/// chceme, aby se nastavila nejdale od ceny (IdealMaximumPrice).
		/// </summary>
		private double PriceAfterJoin(List<Order> orders)
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
		private double SlPriceAfterJoin(List<Order> orders)
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

		private bool JoinPrice(XtbApi xtbApi, List<Order> orders)
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
					xtbApi.ModifyPendingOrder(order);
				}
			}
			return orders.Any();
		}

		private bool JoinSl(XtbApi xtbApi, List<Order> orders, bool position)
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
						xtbApi.SetPositionSlAndPt(order);
					}
					else
					{
						xtbApi.ModifyPendingOrder(order);
					}
				}
			}
			return orders.Any();
		}

		private void JoinSl()
		{
			XtbApi xtbApi = new XtbApi(textBoxSymbol.Text, 0);
			if (checkBoxMovePendingOrder.Checked)
			{

				List<Order> orders = xtbApi.GetPendingOrders(false);
				JoinPrice(xtbApi, orders);
			}
			else
			{
				List<Order> orders = xtbApi.GetMarketOrders(false);
				if (!JoinSl(xtbApi, orders, true))
				{
					orders = xtbApi.GetPendingOrders(false);
					JoinSl(xtbApi, orders, false);
				}
			}
		}


		private void buttonJoinSl_Click(object sender, EventArgs e)
		{
			JoinSl();
		}

		private double GetTpDistanceByUnit(List<Order> orders, double unit)
		{
			// Aby nebyly vsechny TP ve stejne vzdalenosti, pocitam vzdalenost TP podle velikosti pozice.
			// Nejvetsi pozice ma nejblizsi TP.
			double maxUnit = orders.Max(x => Math.Abs(x.Units));
			return 0.7 + Math.Abs(maxUnit - Math.Abs(unit)) * 3;
		}

		private void buttonResetTp_Click(object sender, EventArgs e)
		{
			XtbApi xtbApi = new XtbApi(textBoxSymbol.Text, 0);
			List<Order> orders = xtbApi.GetMarketOrders(false);
			if (orders.Any())
			{
				foreach (var order in orders)
				{
					xtbApi.SetPositionSlAndPtPercent(order, 0, GetTpDistanceByUnit(orders, Math.Abs(order.Units)));
				}
			}
			else
			{
				orders = xtbApi.GetPendingOrders(false);
				foreach (var order in orders)
				{
					xtbApi.SetPendingOrderSlAndPtPercent(order, 0, GetTpDistanceByUnit(orders, Math.Abs(order.Units)));
				}
			}
		}

		private void SlUp(double movement)
		{
			XtbApi xtbApi = new XtbApi(textBoxSymbol.Text, 0);
			List<Order> orders;
			if (checkBoxMovePendingOrder.Checked)
			{
				orders = xtbApi.GetPendingOrders(false);
				double idealPrice = IdealMaximumPrice(orders);
				foreach (var order in orders)
				{
					order.OpenPrice = idealPrice + (idealPrice * movement);
					xtbApi.ModifyPendingOrder(order);
				}
			}
			else
			{
				orders = xtbApi.GetMarketOrders(false);
				double idealSl = IdealMaximumSlPrice(orders);
				foreach (var order in orders)
				{
					order.SL = idealSl + (idealSl * movement);
					xtbApi.SetPositionSlAndPt(order);
				}
				if (!orders.Any())
				{
					orders = xtbApi.GetPendingOrders(false);
					idealSl = IdealMaximumSlPrice(orders);
					foreach (var order in orders)
					{
						order.SL = idealSl + (idealSl * movement);
						xtbApi.ModifyPendingOrder(order);
					}
				}
			}
		}

		private void SlDown(double movement)
		{
			XtbApi xtbApi = new XtbApi(textBoxSymbol.Text, 0);
			List<Order> orders;
			if (checkBoxMovePendingOrder.Checked)
			{
				orders = xtbApi.GetPendingOrders(false);
				double idealPrice = IdealMaximumPrice(orders);
				foreach (var order in orders)
				{
					order.OpenPrice = idealPrice - (idealPrice * movement);
					xtbApi.ModifyPendingOrder(order);
				}
			}
			else
			{
				orders = xtbApi.GetMarketOrders(false);
				double idealSl = IdealMaximumSlPrice(orders);
				foreach (var order in orders)
				{
					order.SL = idealSl - (idealSl * movement);
					xtbApi.SetPositionSlAndPt(order);
				}
				if (!orders.Any())
				{
					orders = xtbApi.GetPendingOrders(false);
					idealSl = IdealMaximumSlPrice(orders);
					foreach (var order in orders)
					{
						order.SL = idealSl - (idealSl * movement);
						xtbApi.ModifyPendingOrder(order);
					}
				}
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

		private void buttonSlUpMin_Click(object sender, EventArgs e)
		{
			SlUp(0.00025);
		}

		private void buttonSlDownMin_Click(object sender, EventArgs e)
		{
			SlDown(0.00025);
		}

		private void buttonCloseAll_Click(object sender, EventArgs e)
		{
			DialogResult dialogResult = MessageBox.Show("Do you really close all orders?", "SvpTradePanel", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
			if (dialogResult == DialogResult.Yes)
			{
				XtbApi xtbApi = new XtbApi(textBoxSymbol.Text, 0);

				SlToBeAutomation = false;

				List<Order> orders = xtbApi.GetMarketOrders(false);
				foreach (var order in orders)
				{
					xtbApi.CloseMarketOrder(order);
				}
				orders = xtbApi.GetPendingOrders(false);
				foreach (var order in orders)
				{
					xtbApi.ClosePendingOrder(order);
				}
			}
		}

		private void buttonEquity_Click(object sender, EventArgs e)
		{
			FormEquity formEquity = new FormEquity();
			formEquity.Symbol = textBoxSymbol.Text;
			formEquity.TopMost = checkBoxAlwaysOnTop.Checked;
			formEquity.Text = this.Text;
			formEquity.ShowDialog();
		}

		private void checkBoxAlwaysOnTop_CheckedChanged(object sender, EventArgs e)
		{
			this.TopMost = checkBoxAlwaysOnTop.Checked;
		}
	}
}