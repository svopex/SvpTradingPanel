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
		}

		private void BuySell603010(bool buy)
		{
			if (Double.TryParse(textBoxPositionSize.Text, out double positionSize) // Je validni velikost pozice v textboxu?
				&& (positionSize * 0.1 > 0) // Je validni velikost pozice v textboxu?
				&& ((IsExistingPositionBuy() && buy) || (IsExistingPositionSell() && !buy)) // pokud je jiz otevrena pozice, nova pozice musi byt stejnejo typu (buy/sell).
				)
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

		private void BuySell6040(bool buy)
		{
			if (Double.TryParse(textBoxPositionSize.Text, out double positionSize) // Je validni velikost pozice v textboxu?
				&& (positionSize * 0.1 > 0) // Je validni velikost pozice v textboxu?
				&& ((IsExistingPositionBuy() && buy) || (IsExistingPositionSell() && !buy))) // pokud je jiz otevrena pozice, nova pozice musi byt stejnejo typu (buy/sell).
			{
				if (!buy)
				{
					positionSize = -positionSize;
				}
				SvpMT5.Instance.CreateMarketOrderSlPtPercent(positionSize * 0.6, 1, 1);
				SvpMT5.Instance.CreateMarketOrderSlPtPercent(positionSize * 0.4, 1, 1.2);
				JoinSl();
			}
		}

		private void BuySellPercent(bool buy, double percent)
		{
			if (Double.TryParse(textBoxPositionSize.Text, out double positionSize) // Je validni velikost pozice v textboxu?
				&& (positionSize * 0.1 > 0) // Je validni velikost pozice v textboxu?
				&& ((IsExistingPositionBuy() && buy) || (IsExistingPositionSell() && !buy))) // pokud je jiz otevrena pozice, nova pozice musi byt stejnejo typu (buy/sell).
			{
				if (!buy)
				{
					positionSize = -positionSize;
				}
				SvpMT5.Instance.CreateMarketOrderSlPtPercent(positionSize * percent / 100, 1, 1);
				JoinSl();
			}
		}

		private bool IsExistingPositionBuy()
		{
			Orders orders = SvpMT5.Instance.GetMarketOrders();
			return IsExistingPositionBuy(orders);
		}

		private bool IsExistingPositionSell()
		{
			Orders orders = SvpMT5.Instance.GetMarketOrders();
			return !orders.Any() || (orders.Any() && orders[0].Units <= 0);
		}

		private bool IsExistingPositionBuy(Orders orders)
		{
			return !orders.Any() || (orders.Any() && orders[0].Units >= 0);
		}

		private double IdealMaximumSlPrice(Orders orders)
		{
			if (orders.Any())
			{
				if (IsExistingPositionBuy(orders))
				{
					return orders.Min(x => x.SL);
				}
				else
				{
					return orders.Max(x => x.SL);
				}
			}
			return 0;
		}

		private void SlUp(double movement)
		{
			Orders orders = SvpMT5.Instance.GetMarketOrders();
			double idealSl = IdealMaximumSlPrice(orders);
			foreach (var order in orders)
			{
				order.SL = idealSl + (idealSl * movement);
				SvpMT5.Instance.SetPositionSlAndPt(order);
			}
		}

		private void SlDown(double movement)
		{
			Orders orders = SvpMT5.Instance.GetMarketOrders();
			double idealSl = IdealMaximumSlPrice(orders);
			foreach (var order in orders)
			{
				order.SL = idealSl - (idealSl * movement);
				SvpMT5.Instance.SetPositionSlAndPt(order);
			}
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

		private void JoinSl()
		{
			Orders orders = SvpMT5.Instance.GetMarketOrders();
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
				SvpMT5.Instance.SetPositionSlAndPt(order);
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

		private void FormTradingPanel_Load(object sender, EventArgs e)
		{
			if (SvpMT5.Instance.Connect())
			{
				labelConnected.Text = "Connected!";
				labelConnected.ForeColor = Color.Green;
			}
			else
			{
				labelConnected.Text = "Not connected!";
				labelConnected.ForeColor = Color.Red;
			}

			textBoxPositionSize.Text = "0.5";
			checkBoxAlwaysOnTop.Checked = true;
			this.TopMost = true;
		}

		private void buttonCloseAll_Click(object sender, EventArgs e)
		{
			Orders orders = SvpMT5.Instance.GetMarketOrders();			
			foreach (var order in orders)
			{
				SvpMT5.Instance.CloseOrder(order.Id);
			}
		}
	}
}
