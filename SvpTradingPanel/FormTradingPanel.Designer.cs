﻿namespace SvpTradingPanel
{
	partial class FormTradingPanel
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.buttonOrderBuy1 = new System.Windows.Forms.Button();
			this.textBoxPositionSize = new System.Windows.Forms.TextBox();
			this.LabelPositionSize = new System.Windows.Forms.Label();
			this.buttonSlUp = new System.Windows.Forms.Button();
			this.buttonSlDown = new System.Windows.Forms.Button();
			this.buttonJoinSl = new System.Windows.Forms.Button();
			this.buttonSlUpMini = new System.Windows.Forms.Button();
			this.buttonSlDownMini = new System.Windows.Forms.Button();
			this.checkBoxAlwaysOnTop = new System.Windows.Forms.CheckBox();
			this.buttonOrderSell1 = new System.Windows.Forms.Button();
			this.buttonBuy60 = new System.Windows.Forms.Button();
			this.buttonBuy30 = new System.Windows.Forms.Button();
			this.buttonBuy10 = new System.Windows.Forms.Button();
			this.buttonBuy100 = new System.Windows.Forms.Button();
			this.buttonSell100 = new System.Windows.Forms.Button();
			this.buttonSell60 = new System.Windows.Forms.Button();
			this.buttonSell30 = new System.Windows.Forms.Button();
			this.buttonSell10 = new System.Windows.Forms.Button();
			this.labelConnected = new System.Windows.Forms.Label();
			this.buttonOrderBuy2 = new System.Windows.Forms.Button();
			this.buttonOrderSell2 = new System.Windows.Forms.Button();
			this.buttonCloseAll = new System.Windows.Forms.Button();
			this.buttonSlDownMax = new System.Windows.Forms.Button();
			this.buttonSlUpMax = new System.Windows.Forms.Button();
			this.labelRrr = new System.Windows.Forms.Label();
			this.timerRefreshLabels = new System.Windows.Forms.Timer(this.components);
			this.labelLoss = new System.Windows.Forms.Label();
			this.labelProfit = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// buttonOrderBuy1
			// 
			this.buttonOrderBuy1.Location = new System.Drawing.Point(29, 484);
			this.buttonOrderBuy1.Margin = new System.Windows.Forms.Padding(4);
			this.buttonOrderBuy1.Name = "buttonOrderBuy1";
			this.buttonOrderBuy1.Size = new System.Drawing.Size(257, 76);
			this.buttonOrderBuy1.TabIndex = 11;
			this.buttonOrderBuy1.Text = "Buy 60% 30% 10%";
			this.buttonOrderBuy1.UseVisualStyleBackColor = true;
			this.buttonOrderBuy1.Click += new System.EventHandler(this.buttonOrderBuy1_Click);
			// 
			// textBoxPositionSize
			// 
			this.textBoxPositionSize.Location = new System.Drawing.Point(150, 78);
			this.textBoxPositionSize.Margin = new System.Windows.Forms.Padding(4);
			this.textBoxPositionSize.Name = "textBoxPositionSize";
			this.textBoxPositionSize.Size = new System.Drawing.Size(134, 29);
			this.textBoxPositionSize.TabIndex = 1;
			// 
			// LabelPositionSize
			// 
			this.LabelPositionSize.AutoSize = true;
			this.LabelPositionSize.Location = new System.Drawing.Point(24, 79);
			this.LabelPositionSize.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.LabelPositionSize.Name = "LabelPositionSize";
			this.LabelPositionSize.Size = new System.Drawing.Size(121, 25);
			this.LabelPositionSize.TabIndex = 0;
			this.LabelPositionSize.Text = "&Position size";
			// 
			// buttonSlUp
			// 
			this.buttonSlUp.Location = new System.Drawing.Point(240, 672);
			this.buttonSlUp.Margin = new System.Windows.Forms.Padding(4);
			this.buttonSlUp.Name = "buttonSlUp";
			this.buttonSlUp.Size = new System.Drawing.Size(205, 105);
			this.buttonSlUp.TabIndex = 20;
			this.buttonSlUp.Text = "SL up";
			this.buttonSlUp.UseVisualStyleBackColor = true;
			this.buttonSlUp.Click += new System.EventHandler(this.buttonSlUp_Click);
			// 
			// buttonSlDown
			// 
			this.buttonSlDown.Location = new System.Drawing.Point(240, 783);
			this.buttonSlDown.Margin = new System.Windows.Forms.Padding(4);
			this.buttonSlDown.Name = "buttonSlDown";
			this.buttonSlDown.Size = new System.Drawing.Size(205, 105);
			this.buttonSlDown.TabIndex = 21;
			this.buttonSlDown.Text = "SL down";
			this.buttonSlDown.UseVisualStyleBackColor = true;
			this.buttonSlDown.Click += new System.EventHandler(this.buttonSlDown_Click);
			// 
			// buttonJoinSl
			// 
			this.buttonJoinSl.Location = new System.Drawing.Point(400, 923);
			this.buttonJoinSl.Margin = new System.Windows.Forms.Padding(4);
			this.buttonJoinSl.Name = "buttonJoinSl";
			this.buttonJoinSl.Size = new System.Drawing.Size(257, 76);
			this.buttonJoinSl.TabIndex = 24;
			this.buttonJoinSl.Text = "Join SL";
			this.buttonJoinSl.UseVisualStyleBackColor = true;
			this.buttonJoinSl.Click += new System.EventHandler(this.buttonJoinSl_Click);
			// 
			// buttonSlUpMini
			// 
			this.buttonSlUpMini.Location = new System.Drawing.Point(451, 672);
			this.buttonSlUpMini.Margin = new System.Windows.Forms.Padding(4);
			this.buttonSlUpMini.Name = "buttonSlUpMini";
			this.buttonSlUpMini.Size = new System.Drawing.Size(205, 105);
			this.buttonSlUpMini.TabIndex = 22;
			this.buttonSlUpMini.Text = "SL up mini";
			this.buttonSlUpMini.UseVisualStyleBackColor = true;
			this.buttonSlUpMini.Click += new System.EventHandler(this.buttonSlUpMini_Click);
			// 
			// buttonSlDownMini
			// 
			this.buttonSlDownMini.Location = new System.Drawing.Point(451, 783);
			this.buttonSlDownMini.Margin = new System.Windows.Forms.Padding(4);
			this.buttonSlDownMini.Name = "buttonSlDownMini";
			this.buttonSlDownMini.Size = new System.Drawing.Size(205, 105);
			this.buttonSlDownMini.TabIndex = 23;
			this.buttonSlDownMini.Text = "SL down mini";
			this.buttonSlDownMini.UseVisualStyleBackColor = true;
			this.buttonSlDownMini.Click += new System.EventHandler(this.buttonSlDownMini_Click);
			// 
			// checkBoxAlwaysOnTop
			// 
			this.checkBoxAlwaysOnTop.AutoSize = true;
			this.checkBoxAlwaysOnTop.Location = new System.Drawing.Point(451, 78);
			this.checkBoxAlwaysOnTop.Margin = new System.Windows.Forms.Padding(4);
			this.checkBoxAlwaysOnTop.Name = "checkBoxAlwaysOnTop";
			this.checkBoxAlwaysOnTop.Size = new System.Drawing.Size(160, 29);
			this.checkBoxAlwaysOnTop.TabIndex = 2;
			this.checkBoxAlwaysOnTop.Text = "Always on top";
			this.checkBoxAlwaysOnTop.UseVisualStyleBackColor = true;
			this.checkBoxAlwaysOnTop.CheckedChanged += new System.EventHandler(this.checkBoxAlwaysOnTop_CheckedChanged);
			// 
			// buttonOrderSell1
			// 
			this.buttonOrderSell1.Location = new System.Drawing.Point(290, 484);
			this.buttonOrderSell1.Margin = new System.Windows.Forms.Padding(4);
			this.buttonOrderSell1.Name = "buttonOrderSell1";
			this.buttonOrderSell1.Size = new System.Drawing.Size(257, 76);
			this.buttonOrderSell1.TabIndex = 12;
			this.buttonOrderSell1.Text = "Sell 60% 30% 10%";
			this.buttonOrderSell1.UseVisualStyleBackColor = true;
			this.buttonOrderSell1.Click += new System.EventHandler(this.buttonOrderSell1_Click);
			// 
			// buttonBuy60
			// 
			this.buttonBuy60.Location = new System.Drawing.Point(29, 216);
			this.buttonBuy60.Margin = new System.Windows.Forms.Padding(4);
			this.buttonBuy60.Name = "buttonBuy60";
			this.buttonBuy60.Size = new System.Drawing.Size(257, 76);
			this.buttonBuy60.TabIndex = 4;
			this.buttonBuy60.Text = "Buy 60%";
			this.buttonBuy60.UseVisualStyleBackColor = true;
			this.buttonBuy60.Click += new System.EventHandler(this.buttonBuy60_Click);
			// 
			// buttonBuy30
			// 
			this.buttonBuy30.Location = new System.Drawing.Point(29, 297);
			this.buttonBuy30.Margin = new System.Windows.Forms.Padding(4);
			this.buttonBuy30.Name = "buttonBuy30";
			this.buttonBuy30.Size = new System.Drawing.Size(257, 76);
			this.buttonBuy30.TabIndex = 5;
			this.buttonBuy30.Text = "Buy 30%";
			this.buttonBuy30.UseVisualStyleBackColor = true;
			this.buttonBuy30.Click += new System.EventHandler(this.buttonBuy30_Click);
			// 
			// buttonBuy10
			// 
			this.buttonBuy10.Location = new System.Drawing.Point(29, 378);
			this.buttonBuy10.Margin = new System.Windows.Forms.Padding(4);
			this.buttonBuy10.Name = "buttonBuy10";
			this.buttonBuy10.Size = new System.Drawing.Size(257, 76);
			this.buttonBuy10.TabIndex = 6;
			this.buttonBuy10.Text = "Buy 10%";
			this.buttonBuy10.UseVisualStyleBackColor = true;
			this.buttonBuy10.Click += new System.EventHandler(this.buttonBuy10_Click);
			// 
			// buttonBuy100
			// 
			this.buttonBuy100.Location = new System.Drawing.Point(29, 135);
			this.buttonBuy100.Margin = new System.Windows.Forms.Padding(4);
			this.buttonBuy100.Name = "buttonBuy100";
			this.buttonBuy100.Size = new System.Drawing.Size(257, 76);
			this.buttonBuy100.TabIndex = 3;
			this.buttonBuy100.Text = "Buy 100%";
			this.buttonBuy100.UseVisualStyleBackColor = true;
			this.buttonBuy100.Click += new System.EventHandler(this.buttonBuy100_Click);
			// 
			// buttonSell100
			// 
			this.buttonSell100.Location = new System.Drawing.Point(290, 135);
			this.buttonSell100.Margin = new System.Windows.Forms.Padding(4);
			this.buttonSell100.Name = "buttonSell100";
			this.buttonSell100.Size = new System.Drawing.Size(257, 76);
			this.buttonSell100.TabIndex = 7;
			this.buttonSell100.Text = "Sell 100%";
			this.buttonSell100.UseVisualStyleBackColor = true;
			this.buttonSell100.Click += new System.EventHandler(this.buttonSell100_Click);
			// 
			// buttonSell60
			// 
			this.buttonSell60.Location = new System.Drawing.Point(290, 216);
			this.buttonSell60.Margin = new System.Windows.Forms.Padding(4);
			this.buttonSell60.Name = "buttonSell60";
			this.buttonSell60.Size = new System.Drawing.Size(257, 76);
			this.buttonSell60.TabIndex = 8;
			this.buttonSell60.Text = "Sell 60%";
			this.buttonSell60.UseVisualStyleBackColor = true;
			this.buttonSell60.Click += new System.EventHandler(this.buttonSell60_Click);
			// 
			// buttonSell30
			// 
			this.buttonSell30.Location = new System.Drawing.Point(290, 297);
			this.buttonSell30.Margin = new System.Windows.Forms.Padding(4);
			this.buttonSell30.Name = "buttonSell30";
			this.buttonSell30.Size = new System.Drawing.Size(257, 76);
			this.buttonSell30.TabIndex = 9;
			this.buttonSell30.Text = "Sell 30%";
			this.buttonSell30.UseVisualStyleBackColor = true;
			this.buttonSell30.Click += new System.EventHandler(this.buttonSell30_Click);
			// 
			// buttonSell10
			// 
			this.buttonSell10.Location = new System.Drawing.Point(290, 378);
			this.buttonSell10.Margin = new System.Windows.Forms.Padding(4);
			this.buttonSell10.Name = "buttonSell10";
			this.buttonSell10.Size = new System.Drawing.Size(257, 76);
			this.buttonSell10.TabIndex = 10;
			this.buttonSell10.Text = "Sell 10%";
			this.buttonSell10.UseVisualStyleBackColor = true;
			this.buttonSell10.Click += new System.EventHandler(this.buttonSell10_Click);
			// 
			// labelConnected
			// 
			this.labelConnected.AutoSize = true;
			this.labelConnected.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labelConnected.Location = new System.Drawing.Point(446, 15);
			this.labelConnected.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelConnected.Name = "labelConnected";
			this.labelConnected.Size = new System.Drawing.Size(145, 30);
			this.labelConnected.TabIndex = 25;
			this.labelConnected.Text = "Connected";
			this.labelConnected.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// buttonOrderBuy2
			// 
			this.buttonOrderBuy2.Location = new System.Drawing.Point(29, 565);
			this.buttonOrderBuy2.Margin = new System.Windows.Forms.Padding(4);
			this.buttonOrderBuy2.Name = "buttonOrderBuy2";
			this.buttonOrderBuy2.Size = new System.Drawing.Size(257, 76);
			this.buttonOrderBuy2.TabIndex = 13;
			this.buttonOrderBuy2.Text = "Buy 60% 40%";
			this.buttonOrderBuy2.UseVisualStyleBackColor = true;
			this.buttonOrderBuy2.Click += new System.EventHandler(this.buttonOrderBuy2_Click);
			// 
			// buttonOrderSell2
			// 
			this.buttonOrderSell2.Location = new System.Drawing.Point(290, 565);
			this.buttonOrderSell2.Margin = new System.Windows.Forms.Padding(4);
			this.buttonOrderSell2.Name = "buttonOrderSell2";
			this.buttonOrderSell2.Size = new System.Drawing.Size(257, 76);
			this.buttonOrderSell2.TabIndex = 14;
			this.buttonOrderSell2.Text = "Sell 60% 40%";
			this.buttonOrderSell2.UseVisualStyleBackColor = true;
			this.buttonOrderSell2.Click += new System.EventHandler(this.buttonOrderSell2_Click);
			// 
			// buttonCloseAll
			// 
			this.buttonCloseAll.Location = new System.Drawing.Point(29, 923);
			this.buttonCloseAll.Margin = new System.Windows.Forms.Padding(4);
			this.buttonCloseAll.Name = "buttonCloseAll";
			this.buttonCloseAll.Size = new System.Drawing.Size(257, 76);
			this.buttonCloseAll.TabIndex = 30;
			this.buttonCloseAll.Text = "Close All";
			this.buttonCloseAll.UseVisualStyleBackColor = true;
			this.buttonCloseAll.Click += new System.EventHandler(this.buttonCloseAll_Click);
			// 
			// buttonSlDownMax
			// 
			this.buttonSlDownMax.Location = new System.Drawing.Point(29, 783);
			this.buttonSlDownMax.Margin = new System.Windows.Forms.Padding(4);
			this.buttonSlDownMax.Name = "buttonSlDownMax";
			this.buttonSlDownMax.Size = new System.Drawing.Size(205, 105);
			this.buttonSlDownMax.TabIndex = 32;
			this.buttonSlDownMax.Text = "SL down max";
			this.buttonSlDownMax.UseVisualStyleBackColor = true;
			this.buttonSlDownMax.Click += new System.EventHandler(this.buttonSlDownMax_Click);
			// 
			// buttonSlUpMax
			// 
			this.buttonSlUpMax.Location = new System.Drawing.Point(29, 672);
			this.buttonSlUpMax.Margin = new System.Windows.Forms.Padding(4);
			this.buttonSlUpMax.Name = "buttonSlUpMax";
			this.buttonSlUpMax.Size = new System.Drawing.Size(205, 105);
			this.buttonSlUpMax.TabIndex = 31;
			this.buttonSlUpMax.Text = "SL up max";
			this.buttonSlUpMax.UseVisualStyleBackColor = true;
			this.buttonSlUpMax.Click += new System.EventHandler(this.buttonSlUpMax_Click);
			// 
			// labelRrr
			// 
			this.labelRrr.AutoSize = true;
			this.labelRrr.Location = new System.Drawing.Point(24, 20);
			this.labelRrr.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelRrr.Name = "labelRrr";
			this.labelRrr.Size = new System.Drawing.Size(51, 25);
			this.labelRrr.TabIndex = 33;
			this.labelRrr.Text = "RRR";
			// 
			// timerRefreshLabels
			// 
			this.timerRefreshLabels.Enabled = true;
			this.timerRefreshLabels.Interval = 5000;
			this.timerRefreshLabels.Tick += new System.EventHandler(this.timerRefreshLabels_Tick);
			// 
			// labelLoss
			// 
			this.labelLoss.AutoSize = true;
			this.labelLoss.Location = new System.Drawing.Point(156, 20);
			this.labelLoss.Name = "labelLoss";
			this.labelLoss.Size = new System.Drawing.Size(54, 25);
			this.labelLoss.TabIndex = 34;
			this.labelLoss.Text = "Loss";
			// 
			// labelProfit
			// 
			this.labelProfit.AutoSize = true;
			this.labelProfit.Location = new System.Drawing.Point(285, 21);
			this.labelProfit.Name = "labelProfit";
			this.labelProfit.Size = new System.Drawing.Size(56, 25);
			this.labelProfit.TabIndex = 35;
			this.labelProfit.Text = "Profit";
			// 
			// FormTradingPanel
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(684, 1014);
			this.Controls.Add(this.labelProfit);
			this.Controls.Add(this.labelLoss);
			this.Controls.Add(this.labelRrr);
			this.Controls.Add(this.buttonSlDownMax);
			this.Controls.Add(this.buttonSlUpMax);
			this.Controls.Add(this.buttonCloseAll);
			this.Controls.Add(this.buttonOrderSell2);
			this.Controls.Add(this.buttonOrderBuy2);
			this.Controls.Add(this.labelConnected);
			this.Controls.Add(this.buttonSell10);
			this.Controls.Add(this.buttonSell30);
			this.Controls.Add(this.buttonSell60);
			this.Controls.Add(this.buttonSell100);
			this.Controls.Add(this.buttonBuy100);
			this.Controls.Add(this.buttonBuy10);
			this.Controls.Add(this.buttonBuy30);
			this.Controls.Add(this.buttonBuy60);
			this.Controls.Add(this.buttonOrderSell1);
			this.Controls.Add(this.checkBoxAlwaysOnTop);
			this.Controls.Add(this.buttonSlDownMini);
			this.Controls.Add(this.buttonSlUpMini);
			this.Controls.Add(this.buttonJoinSl);
			this.Controls.Add(this.buttonSlDown);
			this.Controls.Add(this.buttonSlUp);
			this.Controls.Add(this.LabelPositionSize);
			this.Controls.Add(this.textBoxPositionSize);
			this.Controls.Add(this.buttonOrderBuy1);
			this.Cursor = System.Windows.Forms.Cursors.Default;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.MaximizeBox = false;
			this.Name = "FormTradingPanel";
			this.Text = "SvpTradePanel";
			this.Load += new System.EventHandler(this.FormTradingPanel_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button buttonOrderBuy1;
		private System.Windows.Forms.TextBox textBoxPositionSize;
		private System.Windows.Forms.Label LabelPositionSize;
		private System.Windows.Forms.Button buttonSlUp;
		private System.Windows.Forms.Button buttonSlDown;
		private System.Windows.Forms.Button buttonJoinSl;
		private System.Windows.Forms.Button buttonSlUpMini;
		private System.Windows.Forms.Button buttonSlDownMini;
		private System.Windows.Forms.CheckBox checkBoxAlwaysOnTop;
		private System.Windows.Forms.Button buttonOrderSell1;
		private System.Windows.Forms.Button buttonBuy60;
		private System.Windows.Forms.Button buttonBuy30;
		private System.Windows.Forms.Button buttonBuy10;
		private System.Windows.Forms.Button buttonBuy100;
		private System.Windows.Forms.Button buttonSell100;
		private System.Windows.Forms.Button buttonSell60;
		private System.Windows.Forms.Button buttonSell30;
		private System.Windows.Forms.Button buttonSell10;
		private System.Windows.Forms.Label labelConnected;
		private System.Windows.Forms.Button buttonOrderBuy2;
		private System.Windows.Forms.Button buttonOrderSell2;
		private System.Windows.Forms.Button buttonCloseAll;
		private System.Windows.Forms.Button buttonSlDownMax;
		private System.Windows.Forms.Button buttonSlUpMax;
		private System.Windows.Forms.Label labelRrr;
		private System.Windows.Forms.Timer timerRefreshLabels;
		private System.Windows.Forms.Label labelLoss;
		private System.Windows.Forms.Label labelProfit;
	}
}

