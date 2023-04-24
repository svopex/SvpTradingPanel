using Mt5Api;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SvpTradingGraph
{
	public partial class Form : System.Windows.Forms.Form
	{
		public Form()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			bool connected = MetatraderInstance.Connect();

			while (!MetatraderInstance.IsConnectedConsole())
			{
				Task.Delay(100);
			}
			
			var result = MetatraderInstance.Instance.GetLatestProfitHistory(new DateTime(2023, 1, 1), DateTime.Now);

			if (result.Count() == 0)
			{
				return;
			}

			chart1.Series.Clear();
			var series1 = new System.Windows.Forms.DataVisualization.Charting.Series
			{
				Name = "Equity",
				Color = System.Drawing.Color.Green,
				IsVisibleInLegend = false,
				IsXValueIndexed = true,
				ChartType = SeriesChartType.Line,
				BorderWidth = 2
			};
			this.chart1.Series.Add(series1);

			var series2 = new System.Windows.Forms.DataVisualization.Charting.Series
			{
				Name = "Equity with commission and sap",
				Color = System.Drawing.Color.Red,
				IsVisibleInLegend = false,
				IsXValueIndexed = true,
				ChartType = SeriesChartType.Line,
				BorderWidth = 2
			};
			this.chart1.Series.Add(series2);

			series1.Points.AddXY(0, 0);
			series2.Points.AddXY(0, 0);

			double profit = 0;
			double income = 0;
			double spending = 0;
			double commission = 0;
			double swap = 0;
			for (int i = 0; i < result.Count(); i++)
			{
				if (result[i].profit >= 0)
				{
					income += result[i].profit;
					commission += result[i].commission;
					swap += result[i].swap;
				}
				else
				{
					spending += result[i].profit;
					commission += result[i].commission;
					swap += result[i].swap;					
				}
				profit += result[i].profit;

				series1.Points.AddXY(i + 1, profit);
				series2.Points.AddXY(i + 1, profit + commission + swap);
			}
			chart1.Invalidate();

			labelIncome.Text = $"Profit: {income + spending}, prijmy: {income}, vydaje: {spending}, commision = {commission}, swap = {swap}.";
			labelTaxForm.Text = $"Pro danove priznani, celkove prijmy: {income}, celkove vydaje (prijmy - commission - swap): {spending + commission + swap}.";

			this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
		}

		private void chart1_Click(object sender, EventArgs e)
		{

		}
	}
}
