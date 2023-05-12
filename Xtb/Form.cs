using System.Runtime.Serialization;

namespace Xtb
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void buttonBuy_Click(object sender, EventArgs e)
		{
			Buy(0.6, 0.3, 0.1);
		}


		private void Buy(double p1, double p2, double p3)
		{
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

		private void buttonSell_Click(object sender, EventArgs e)
		{
			Sell(0.6, 0.3, 0.1);
		}

		private void Sell(double p1, double p2, double p3)
		{
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
			XtbApi xtbApi = new XtbApi(textBoxSymbol.Text, 0);
			(double, double) result = xtbApi.CalculateProfit();
			var accountCurrency =  xtbApi.GetAccountCurrency();
			labelRRR.Text = $"RRR: {Math.Round(result.Item1 / result.Item2, 2)}\r\nProfit: {Math.Round(result.Item1, 2)} {accountCurrency}\r\nLoss: {Math.Round(result.Item2, 2)} {accountCurrency}";
		}
	}
}