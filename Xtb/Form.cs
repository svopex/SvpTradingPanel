using System.Runtime.Serialization;
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
					xtbApi.BuyLimit(limitPrice, p1, p2, p3);
				}
			}
			else
			{
				double slDistance;
				if (Double.TryParse(textBoxSlDistance.Text, out slDistance))
				{
					XtbApi xtbApi = new XtbApi(textBoxSymbol.Text, slDistance);
					xtbApi.Buy(p1, p2, p3);
				}
			}
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
					xtbApi.SellLimit(limitPrice, p1, p2, p3);
				}
			}
			else
			{
				double slDistance;
				if (Double.TryParse(textBoxSlDistance.Text, out slDistance))
				{
					XtbApi xtbApi = new XtbApi(textBoxSymbol.Text, slDistance);
					xtbApi.Sell(p1, p2, p3);
				}
			}
		}

		private void buttonCalculate_Click(object sender, EventArgs e)
		{
			DisableSlToBeAutomation();
			XtbApi xtbApi = new XtbApi(textBoxSymbol.Text, 0);
			(double, double) result = xtbApi.CalculateProfit();
			var accountCurrency = xtbApi.GetAccountCurrency();
			labelRRR.Text = $"RRR: {Math.Round(result.Item1 / result.Item2, 2)}\r\nProfit: {Math.Round(result.Item1, 2)} {accountCurrency}\r\nLoss: {Math.Round(result.Item2, 2)} {accountCurrency}";
		}

		private void buttonSlToBe_Click(object sender, EventArgs e)
		{
			SlToBeAutomation = !SlToBeAutomation;
			SlToBeAutomationMoveSlEnabled = true;
			XtbApi xtbApi = new XtbApi(textBoxSymbol.Text, 0);
			SlToBeAutomationOrders = xtbApi.GetMarketOrders();
		}

		private void buttonSlPtMonitoring_Click(object sender, EventArgs e)
		{
			SlToBeAutomation = !SlToBeAutomation;
			SlToBeAutomationMoveSlEnabled = false;
			XtbApi xtbApi = new XtbApi(textBoxSymbol.Text, 0);
			SlToBeAutomationOrders = xtbApi.GetMarketOrders();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			DisableSlToBeAutomation(); 
			timer.Interval = 1000;
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

				var orders = xtbApi.GetMarketOrders();

				if (SlToBeAutomationOrders!.Count != orders.Count)
				{
					Task.Delay(5000); // Cekani na pripadne uzavreni vsech pozic.

					foreach (var instrument in SlToBeAutomationOrders.Select(x => x.Instrument).Distinct())
					{
						var slToBeAutomationOrdersByInstrument = SlToBeAutomationOrders.Where(x => x.Instrument == instrument).ToList();
						var ordersByInstrument = xtbApi.GetMarketOrders().Where(x => x.Instrument == instrument).ToList();

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

					SlToBeAutomationOrders = xtbApi.GetMarketOrders();
				}

				//if (!SlToBeAutomationOrders.Any())
				//{
				//	DisableSlToBeAutomation();
				//}
			}
		}
	}
}