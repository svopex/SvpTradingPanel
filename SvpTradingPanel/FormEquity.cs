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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Utils;

namespace SvpTradingPanel
{
	public partial class FormEquity : System.Windows.Forms.Form
	{
		public bool MainWindowTopMost { get; set; }

		public FormEquity()
		{
			InitializeComponent();
		}

		public int GetYear()
		{
			if (int.TryParse(textBoxYear.Text, out int result))
			{
				return result;
			}
			else
			{
				return DateTime.Now.Year;
			}
		}

		private void RefreshData()
		{
			List<History> results = MetatraderInstance.Instance.GetLatestProfitHistory(new DateTime(GetYear(), 1, 1, 0, 0, 0), new DateTime(GetYear(), 12, 31, 23, 59, 59));

			results = results.Where(x => !String.IsNullOrWhiteSpace(x.comment) && (x.comment.StartsWith(Utilities.StrategyName) || Utilities.StrategyName.ToLower() == "none")).ToList();

			chart1.Series.Clear();
			labelIncome.Text = String.Empty;
			labelTaxForm.Text = String.Empty;

			if (results.Count() == 0)
			{
				return;
			}

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
				Name = "Equity with commission and swap",
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
			for (int i = 0; i < results.Count(); i++)
			{
				if (results[i].profit >= 0)
				{
					income += results[i].profit;
					commission += results[i].commission;
					swap += results[i].swap;
				}
				else
				{
					spending += results[i].profit;
					commission += results[i].commission;
					swap += results[i].swap;
				}
				profit += results[i].profit;

				series1.Points.AddXY(i + 1, profit);
				series2.Points.AddXY(i + 1, profit + commission + swap);
			}
			chart1.Invalidate();

			labelIncome.Text = $"Profit: {income + spending + commission + swap}, prijmy: {income}, vydaje: {spending}, commision = {commission}, swap = {swap}.";
			labelTaxForm.Text = $"Pro danove priznani, celkove prijmy: {income}, celkove vydaje (prijmy - commission - swap): {spending + commission + swap}.";
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;

			bool connected = MetatraderInstance.Connect();

			int counter = 0;
			while (!MetatraderInstance.IsConnectedConsole())
			{
				Thread.Sleep(100);
				if (counter++ == 10)
				{
					System.Environment.Exit(0);
				}
			}

			this.TopMost = MainWindowTopMost;

			this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);

			textBoxYear.Text = DateTime.Now.Year.ToString();

			RefreshData();

			this.Text = "SvpTradingPanel - " + Utilities.StrategyName;
		}

		private void textBoxYear_Leave(object sender, EventArgs e)
		{
			RefreshData();
		}
	}
}
