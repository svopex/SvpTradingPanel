using Mt5Api;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
			
			SvpMT5.Instance.Connect();

			textBoxPositionSize.Text = "0.5";
			checkBoxAlwaysOnTop.Checked = true;
			this.TopMost = true;
		}

		private void BuySell603010(bool buy)
		{
			if (Double.TryParse(textBoxPositionSize.Text, out double positionSize) && (positionSize * 0.1 > 0))
			{
				if (!buy)
				{
					positionSize = -positionSize;
				}
				SvpMT5.Instance.CreateMarketOrderSlPtPercent(positionSize * 0.6, 1, 1);
				SvpMT5.Instance.CreateMarketOrderSlPtPercent(positionSize * 0.3, 1, 1.2);
				SvpMT5.Instance.CreateMarketOrderSlPtPercent(positionSize * 0.1, 1, 1.4);
				JoinSl();
			}
		}

		private void BuySellPercent(bool buy, double percent)
		{
			if (Double.TryParse(textBoxPositionSize.Text, out double positionSize) && (positionSize * percent / 100 > 0))
			{
				if (!buy)
				{
					positionSize = -positionSize;
				}
				SvpMT5.Instance.CreateMarketOrderSlPtPercent(positionSize * percent / 100, 1, 1);
				JoinSl();
			}
		}

		private void buttonOrder1_Click(object sender, EventArgs e)
		{
			BuySell603010(true);
		}

		private bool Buy(Orders orders)
		{
			return orders.Any() && orders[0].SL < orders[0].Price;
		}

		private double IdealSlPrice(Orders orders)
		{
			if (Buy(orders))
			{
				return orders.Min(x => x.SL);
			}
			else
			{
				return orders.Max(x => x.SL);
			}
		}

		private void SlUp(double movement)
		{
			Orders orders = SvpMT5.Instance.GetMarketOrders();
			double idealSl = IdealSlPrice(orders);
			foreach (var order in orders)
			{
				order.SL = idealSl + (idealSl * movement);
				SvpMT5.Instance.SetPositionSlAndPt(order);
			}
		}

		private void SlDown(double movement)
		{
			Orders orders = SvpMT5.Instance.GetMarketOrders();
			double idealSl = IdealSlPrice(orders);
			foreach (var order in orders)
			{
				order.SL = idealSl - (idealSl * movement);
				SvpMT5.Instance.SetPositionSlAndPt(order);
			}
		}

		private void JoinSl()
		{
			Orders orders = SvpMT5.Instance.GetMarketOrders();
			double idealSl = IdealSlPrice(orders);
			foreach (var order in orders)
			{
				order.SL = idealSl;
				SvpMT5.Instance.SetPositionSlAndPt(order);
			}
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

		private void buttonOrder2_Click(object sender, EventArgs e)
		{
			BuySell603010(false);
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
	}
}
