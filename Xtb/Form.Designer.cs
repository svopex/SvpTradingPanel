﻿namespace Xtb
{
	partial class Form1
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			labelSymbol = new Label();
			textBoxSymbol = new TextBox();
			labelSlDistance = new Label();
			textBoxSlDistance = new TextBox();
			buttonBuy631 = new Button();
			buttonSell631 = new Button();
			labelLimitPrice = new Label();
			textBoxLimitPrice = new TextBox();
			buttonCalculate = new Button();
			labelRRR = new Label();
			buttonBuy541 = new Button();
			buttonSell541 = new Button();
			buttonBuy64 = new Button();
			buttonSell64 = new Button();
			buttonSlToBe = new Button();
			buttonSlPtMonitoring = new Button();
			progressBarSlToBe = new ProgressBar();
			progressBarSlPtMonitoring = new ProgressBar();
			timer = new System.Windows.Forms.Timer(components);
			trackBarPositionUsing = new TrackBar();
			labelPositionUsing = new Label();
			labelPositionUsingPercent = new Label();
			timerRefreshTexts = new System.Windows.Forms.Timer(components);
			buttonBuy100 = new Button();
			buttonBuy60 = new Button();
			buttonBuy30 = new Button();
			buttonBuy10 = new Button();
			buttonSell100 = new Button();
			buttonSell60 = new Button();
			buttonSell30 = new Button();
			buttonSell10 = new Button();
			buttonJoinSl = new Button();
			checkBoxMovePendingOrder = new CheckBox();
			buttonResetTp = new Button();
			buttonSlUpMax = new Button();
			buttonSlDownMax = new Button();
			buttonSlDown = new Button();
			buttonSlUp = new Button();
			buttonSlDownMin = new Button();
			buttonSlUpMin = new Button();
			buttonCloseAll = new Button();
			buttonEquity = new Button();
			checkBoxAlwaysOnTop = new CheckBox();
			((System.ComponentModel.ISupportInitialize)trackBarPositionUsing).BeginInit();
			SuspendLayout();
			// 
			// labelSymbol
			// 
			labelSymbol.AutoSize = true;
			labelSymbol.Location = new Point(7, 4);
			labelSymbol.Margin = new Padding(2, 0, 2, 0);
			labelSymbol.Name = "labelSymbol";
			labelSymbol.Size = new Size(47, 15);
			labelSymbol.TabIndex = 0;
			labelSymbol.Text = "Symbol";
			// 
			// textBoxSymbol
			// 
			textBoxSymbol.Location = new Point(79, 3);
			textBoxSymbol.Margin = new Padding(2, 2, 2, 2);
			textBoxSymbol.Name = "textBoxSymbol";
			textBoxSymbol.Size = new Size(104, 23);
			textBoxSymbol.TabIndex = 1;
			// 
			// labelSlDistance
			// 
			labelSlDistance.AutoSize = true;
			labelSlDistance.Location = new Point(7, 26);
			labelSlDistance.Margin = new Padding(2, 0, 2, 0);
			labelSlDistance.Name = "labelSlDistance";
			labelSlDistance.Size = new Size(66, 15);
			labelSlDistance.TabIndex = 2;
			labelSlDistance.Text = "SL distance";
			// 
			// textBoxSlDistance
			// 
			textBoxSlDistance.Location = new Point(79, 24);
			textBoxSlDistance.Margin = new Padding(2, 2, 2, 2);
			textBoxSlDistance.Name = "textBoxSlDistance";
			textBoxSlDistance.Size = new Size(104, 23);
			textBoxSlDistance.TabIndex = 3;
			// 
			// buttonBuy631
			// 
			buttonBuy631.Location = new Point(7, 139);
			buttonBuy631.Margin = new Padding(2, 2, 2, 2);
			buttonBuy631.Name = "buttonBuy631";
			buttonBuy631.Size = new Size(117, 36);
			buttonBuy631.TabIndex = 30;
			buttonBuy631.Text = "Buy 60% 30% 10%";
			buttonBuy631.UseVisualStyleBackColor = true;
			buttonBuy631.Click += buttonBuy631_Click;
			// 
			// buttonSell631
			// 
			buttonSell631.Location = new Point(143, 139);
			buttonSell631.Margin = new Padding(2, 2, 2, 2);
			buttonSell631.Name = "buttonSell631";
			buttonSell631.Size = new Size(117, 36);
			buttonSell631.TabIndex = 31;
			buttonSell631.Text = "Sell 60% 30% 10%";
			buttonSell631.UseVisualStyleBackColor = true;
			buttonSell631.Click += buttonSell631_Click;
			// 
			// labelLimitPrice
			// 
			labelLimitPrice.AutoSize = true;
			labelLimitPrice.Location = new Point(7, 46);
			labelLimitPrice.Margin = new Padding(2, 0, 2, 0);
			labelLimitPrice.Name = "labelLimitPrice";
			labelLimitPrice.Size = new Size(63, 15);
			labelLimitPrice.TabIndex = 4;
			labelLimitPrice.Text = "Limit price";
			// 
			// textBoxLimitPrice
			// 
			textBoxLimitPrice.Location = new Point(79, 46);
			textBoxLimitPrice.Margin = new Padding(2, 2, 2, 2);
			textBoxLimitPrice.Name = "textBoxLimitPrice";
			textBoxLimitPrice.Size = new Size(104, 23);
			textBoxLimitPrice.TabIndex = 5;
			// 
			// buttonCalculate
			// 
			buttonCalculate.Location = new Point(370, 7);
			buttonCalculate.Margin = new Padding(2, 2, 2, 2);
			buttonCalculate.Name = "buttonCalculate";
			buttonCalculate.Size = new Size(117, 54);
			buttonCalculate.TabIndex = 10;
			buttonCalculate.Text = "Calculate";
			buttonCalculate.UseVisualStyleBackColor = true;
			buttonCalculate.Click += buttonCalculate_Click;
			// 
			// labelRRR
			// 
			labelRRR.AutoSize = true;
			labelRRR.Location = new Point(195, 6);
			labelRRR.Margin = new Padding(2, 0, 2, 0);
			labelRRR.Name = "labelRRR";
			labelRRR.Size = new Size(39, 15);
			labelRRR.TabIndex = 9;
			labelRRR.Text = "RRR: -";
			// 
			// buttonBuy541
			// 
			buttonBuy541.Location = new Point(7, 179);
			buttonBuy541.Margin = new Padding(2, 2, 2, 2);
			buttonBuy541.Name = "buttonBuy541";
			buttonBuy541.Size = new Size(117, 36);
			buttonBuy541.TabIndex = 32;
			buttonBuy541.Text = "Buy 50% 40% 10%";
			buttonBuy541.UseVisualStyleBackColor = true;
			buttonBuy541.Click += buttonBuy541_Click;
			// 
			// buttonSell541
			// 
			buttonSell541.Location = new Point(143, 179);
			buttonSell541.Margin = new Padding(2, 2, 2, 2);
			buttonSell541.Name = "buttonSell541";
			buttonSell541.Size = new Size(117, 36);
			buttonSell541.TabIndex = 33;
			buttonSell541.Text = "Sell 50% 40% 10%";
			buttonSell541.UseVisualStyleBackColor = true;
			buttonSell541.Click += buttonSell541_Click;
			// 
			// buttonBuy64
			// 
			buttonBuy64.Location = new Point(7, 217);
			buttonBuy64.Margin = new Padding(2, 2, 2, 2);
			buttonBuy64.Name = "buttonBuy64";
			buttonBuy64.Size = new Size(117, 36);
			buttonBuy64.TabIndex = 34;
			buttonBuy64.Text = "Buy 60% 40%";
			buttonBuy64.UseVisualStyleBackColor = true;
			buttonBuy64.Click += buttonBuy64_Click;
			// 
			// buttonSell64
			// 
			buttonSell64.Location = new Point(143, 217);
			buttonSell64.Margin = new Padding(2, 2, 2, 2);
			buttonSell64.Name = "buttonSell64";
			buttonSell64.Size = new Size(117, 36);
			buttonSell64.TabIndex = 35;
			buttonSell64.Text = "Sell 60% 40%";
			buttonSell64.UseVisualStyleBackColor = true;
			buttonSell64.Click += buttonSell64_Click;
			// 
			// buttonSlToBe
			// 
			buttonSlToBe.Location = new Point(295, 139);
			buttonSlToBe.Margin = new Padding(2, 2, 2, 2);
			buttonSlToBe.Name = "buttonSlToBe";
			buttonSlToBe.Size = new Size(250, 42);
			buttonSlToBe.TabIndex = 80;
			buttonSlToBe.Text = "SL to BE automation after first PT";
			buttonSlToBe.UseVisualStyleBackColor = true;
			buttonSlToBe.Click += buttonSlToBe_Click;
			// 
			// buttonSlPtMonitoring
			// 
			buttonSlPtMonitoring.Location = new Point(295, 223);
			buttonSlPtMonitoring.Margin = new Padding(2, 2, 2, 2);
			buttonSlPtMonitoring.Name = "buttonSlPtMonitoring";
			buttonSlPtMonitoring.Size = new Size(250, 42);
			buttonSlPtMonitoring.TabIndex = 82;
			buttonSlPtMonitoring.Text = "SL/PT monitoring";
			buttonSlPtMonitoring.UseVisualStyleBackColor = true;
			buttonSlPtMonitoring.Click += buttonSlPtMonitoring_Click;
			// 
			// progressBarSlToBe
			// 
			progressBarSlToBe.Location = new Point(295, 185);
			progressBarSlToBe.Margin = new Padding(2, 2, 2, 2);
			progressBarSlToBe.Name = "progressBarSlToBe";
			progressBarSlToBe.Size = new Size(250, 20);
			progressBarSlToBe.TabIndex = 81;
			// 
			// progressBarSlPtMonitoring
			// 
			progressBarSlPtMonitoring.Location = new Point(295, 267);
			progressBarSlPtMonitoring.Margin = new Padding(2, 2, 2, 2);
			progressBarSlPtMonitoring.Name = "progressBarSlPtMonitoring";
			progressBarSlPtMonitoring.Size = new Size(250, 20);
			progressBarSlPtMonitoring.TabIndex = 83;
			// 
			// timer
			// 
			timer.Enabled = true;
			timer.Tick += timer_Tick;
			// 
			// trackBarPositionUsing
			// 
			trackBarPositionUsing.LargeChange = 10;
			trackBarPositionUsing.Location = new Point(96, 90);
			trackBarPositionUsing.Margin = new Padding(2, 2, 2, 2);
			trackBarPositionUsing.Maximum = 250;
			trackBarPositionUsing.Minimum = 1;
			trackBarPositionUsing.Name = "trackBarPositionUsing";
			trackBarPositionUsing.Size = new Size(391, 45);
			trackBarPositionUsing.SmallChange = 5;
			trackBarPositionUsing.TabIndex = 8;
			trackBarPositionUsing.Value = 50;
			trackBarPositionUsing.ValueChanged += trackBarPositionUsing_ValueChanged;
			// 
			// labelPositionUsing
			// 
			labelPositionUsing.AutoSize = true;
			labelPositionUsing.Location = new Point(7, 90);
			labelPositionUsing.Margin = new Padding(2, 0, 2, 0);
			labelPositionUsing.Name = "labelPositionUsing";
			labelPositionUsing.Size = new Size(84, 15);
			labelPositionUsing.TabIndex = 6;
			labelPositionUsing.Text = "Pos. utilization";
			// 
			// labelPositionUsingPercent
			// 
			labelPositionUsingPercent.AutoSize = true;
			labelPositionUsingPercent.Location = new Point(7, 104);
			labelPositionUsingPercent.Margin = new Padding(2, 0, 2, 0);
			labelPositionUsingPercent.Name = "labelPositionUsingPercent";
			labelPositionUsingPercent.Size = new Size(29, 15);
			labelPositionUsingPercent.TabIndex = 7;
			labelPositionUsingPercent.Text = "50%";
			// 
			// timerRefreshTexts
			// 
			timerRefreshTexts.Interval = 2000;
			timerRefreshTexts.Tick += timerRefreshTexts_Tick;
			// 
			// buttonBuy100
			// 
			buttonBuy100.Location = new Point(7, 257);
			buttonBuy100.Margin = new Padding(2, 2, 2, 2);
			buttonBuy100.Name = "buttonBuy100";
			buttonBuy100.Size = new Size(117, 36);
			buttonBuy100.TabIndex = 50;
			buttonBuy100.Text = "Buy 100%";
			buttonBuy100.UseVisualStyleBackColor = true;
			buttonBuy100.Click += buttonBuy100_Click;
			// 
			// buttonBuy60
			// 
			buttonBuy60.Location = new Point(7, 295);
			buttonBuy60.Margin = new Padding(2, 2, 2, 2);
			buttonBuy60.Name = "buttonBuy60";
			buttonBuy60.Size = new Size(117, 36);
			buttonBuy60.TabIndex = 52;
			buttonBuy60.Text = "Buy 60%";
			buttonBuy60.UseVisualStyleBackColor = true;
			buttonBuy60.Click += buttonBuy60_Click;
			// 
			// buttonBuy30
			// 
			buttonBuy30.Location = new Point(7, 335);
			buttonBuy30.Margin = new Padding(2, 2, 2, 2);
			buttonBuy30.Name = "buttonBuy30";
			buttonBuy30.Size = new Size(117, 36);
			buttonBuy30.TabIndex = 54;
			buttonBuy30.Text = "Buy 30%";
			buttonBuy30.UseVisualStyleBackColor = true;
			buttonBuy30.Click += buttonBuy30_Click;
			// 
			// buttonBuy10
			// 
			buttonBuy10.Location = new Point(7, 373);
			buttonBuy10.Margin = new Padding(2, 2, 2, 2);
			buttonBuy10.Name = "buttonBuy10";
			buttonBuy10.Size = new Size(117, 36);
			buttonBuy10.TabIndex = 56;
			buttonBuy10.Text = "Buy 10%";
			buttonBuy10.UseVisualStyleBackColor = true;
			buttonBuy10.Click += buttonBuy10_Click;
			// 
			// buttonSell100
			// 
			buttonSell100.Location = new Point(143, 257);
			buttonSell100.Margin = new Padding(2, 2, 2, 2);
			buttonSell100.Name = "buttonSell100";
			buttonSell100.Size = new Size(117, 36);
			buttonSell100.TabIndex = 51;
			buttonSell100.Text = "Sell 100%";
			buttonSell100.UseVisualStyleBackColor = true;
			buttonSell100.Click += buttonSell100_Click;
			// 
			// buttonSell60
			// 
			buttonSell60.Location = new Point(143, 295);
			buttonSell60.Margin = new Padding(2, 2, 2, 2);
			buttonSell60.Name = "buttonSell60";
			buttonSell60.Size = new Size(117, 36);
			buttonSell60.TabIndex = 53;
			buttonSell60.Text = "Sell 60%";
			buttonSell60.UseVisualStyleBackColor = true;
			buttonSell60.Click += buttonSell60_Click;
			// 
			// buttonSell30
			// 
			buttonSell30.Location = new Point(143, 335);
			buttonSell30.Margin = new Padding(2, 2, 2, 2);
			buttonSell30.Name = "buttonSell30";
			buttonSell30.Size = new Size(117, 36);
			buttonSell30.TabIndex = 55;
			buttonSell30.Text = "Sell 30%";
			buttonSell30.UseVisualStyleBackColor = true;
			buttonSell30.Click += buttonSell30_Click;
			// 
			// buttonSell10
			// 
			buttonSell10.Location = new Point(143, 373);
			buttonSell10.Margin = new Padding(2, 2, 2, 2);
			buttonSell10.Name = "buttonSell10";
			buttonSell10.Size = new Size(117, 36);
			buttonSell10.TabIndex = 57;
			buttonSell10.Text = "Sell 10%";
			buttonSell10.UseVisualStyleBackColor = true;
			buttonSell10.Click += buttonSell10_Click;
			// 
			// buttonJoinSl
			// 
			buttonJoinSl.Location = new Point(382, 413);
			buttonJoinSl.Margin = new Padding(2, 2, 2, 2);
			buttonJoinSl.Name = "buttonJoinSl";
			buttonJoinSl.Size = new Size(76, 38);
			buttonJoinSl.TabIndex = 108;
			buttonJoinSl.Text = "Join SL";
			buttonJoinSl.UseVisualStyleBackColor = true;
			buttonJoinSl.Click += buttonJoinSl_Click;
			// 
			// checkBoxMovePendingOrder
			// 
			checkBoxMovePendingOrder.AutoSize = true;
			checkBoxMovePendingOrder.Location = new Point(302, 301);
			checkBoxMovePendingOrder.Margin = new Padding(2, 2, 2, 2);
			checkBoxMovePendingOrder.Name = "checkBoxMovePendingOrder";
			checkBoxMovePendingOrder.Size = new Size(173, 19);
			checkBoxMovePendingOrder.TabIndex = 100;
			checkBoxMovePendingOrder.Text = "Move pending order, not SL";
			checkBoxMovePendingOrder.UseVisualStyleBackColor = true;
			// 
			// buttonResetTp
			// 
			buttonResetTp.Location = new Point(468, 413);
			buttonResetTp.Margin = new Padding(2, 2, 2, 2);
			buttonResetTp.Name = "buttonResetTp";
			buttonResetTp.Size = new Size(76, 38);
			buttonResetTp.TabIndex = 109;
			buttonResetTp.Text = "Reset TP";
			buttonResetTp.UseVisualStyleBackColor = true;
			buttonResetTp.Click += buttonResetTp_Click;
			// 
			// buttonSlUpMax
			// 
			buttonSlUpMax.Location = new Point(295, 326);
			buttonSlUpMax.Margin = new Padding(2, 2, 2, 2);
			buttonSlUpMax.Name = "buttonSlUpMax";
			buttonSlUpMax.Size = new Size(76, 38);
			buttonSlUpMax.TabIndex = 101;
			buttonSlUpMax.Text = "SL Up Max";
			buttonSlUpMax.UseVisualStyleBackColor = true;
			buttonSlUpMax.Click += buttonSlUpMax_Click;
			// 
			// buttonSlDownMax
			// 
			buttonSlDownMax.Location = new Point(295, 371);
			buttonSlDownMax.Margin = new Padding(2, 2, 2, 2);
			buttonSlDownMax.Name = "buttonSlDownMax";
			buttonSlDownMax.Size = new Size(76, 38);
			buttonSlDownMax.TabIndex = 102;
			buttonSlDownMax.Text = "SL Down Max";
			buttonSlDownMax.UseVisualStyleBackColor = true;
			buttonSlDownMax.Click += buttonSlDownMax_Click;
			// 
			// buttonSlDown
			// 
			buttonSlDown.Location = new Point(382, 371);
			buttonSlDown.Margin = new Padding(2, 2, 2, 2);
			buttonSlDown.Name = "buttonSlDown";
			buttonSlDown.Size = new Size(76, 38);
			buttonSlDown.TabIndex = 104;
			buttonSlDown.Text = "SL Down";
			buttonSlDown.UseVisualStyleBackColor = true;
			buttonSlDown.Click += buttonSlDown_Click;
			// 
			// buttonSlUp
			// 
			buttonSlUp.Location = new Point(382, 326);
			buttonSlUp.Margin = new Padding(2, 2, 2, 2);
			buttonSlUp.Name = "buttonSlUp";
			buttonSlUp.Size = new Size(76, 38);
			buttonSlUp.TabIndex = 103;
			buttonSlUp.Text = "SL Up";
			buttonSlUp.UseVisualStyleBackColor = true;
			buttonSlUp.Click += buttonSlUp_Click;
			// 
			// buttonSlDownMin
			// 
			buttonSlDownMin.Location = new Point(468, 371);
			buttonSlDownMin.Margin = new Padding(2, 2, 2, 2);
			buttonSlDownMin.Name = "buttonSlDownMin";
			buttonSlDownMin.Size = new Size(76, 38);
			buttonSlDownMin.TabIndex = 106;
			buttonSlDownMin.Text = "SL Down Min";
			buttonSlDownMin.UseVisualStyleBackColor = true;
			buttonSlDownMin.Click += buttonSlDownMin_Click;
			// 
			// buttonSlUpMin
			// 
			buttonSlUpMin.Location = new Point(468, 326);
			buttonSlUpMin.Margin = new Padding(2, 2, 2, 2);
			buttonSlUpMin.Name = "buttonSlUpMin";
			buttonSlUpMin.Size = new Size(76, 38);
			buttonSlUpMin.TabIndex = 105;
			buttonSlUpMin.Text = "SL Up Min";
			buttonSlUpMin.UseVisualStyleBackColor = true;
			buttonSlUpMin.Click += buttonSlUpMin_Click;
			// 
			// buttonCloseAll
			// 
			buttonCloseAll.Location = new Point(295, 413);
			buttonCloseAll.Margin = new Padding(2, 2, 2, 2);
			buttonCloseAll.Name = "buttonCloseAll";
			buttonCloseAll.Size = new Size(76, 38);
			buttonCloseAll.TabIndex = 107;
			buttonCloseAll.Text = "CloseAll";
			buttonCloseAll.UseVisualStyleBackColor = true;
			buttonCloseAll.Click += buttonCloseAll_Click;
			// 
			// buttonEquity
			// 
			buttonEquity.Location = new Point(7, 413);
			buttonEquity.Margin = new Padding(2, 2, 2, 2);
			buttonEquity.Name = "buttonEquity";
			buttonEquity.Size = new Size(253, 38);
			buttonEquity.TabIndex = 110;
			buttonEquity.Text = "Equity";
			buttonEquity.UseVisualStyleBackColor = true;
			buttonEquity.Click += buttonEquity_Click;
			// 
			// checkBoxAlwaysOnTop
			// 
			checkBoxAlwaysOnTop.AutoSize = true;
			checkBoxAlwaysOnTop.Location = new Point(370, 66);
			checkBoxAlwaysOnTop.Name = "checkBoxAlwaysOnTop";
			checkBoxAlwaysOnTop.Size = new Size(101, 19);
			checkBoxAlwaysOnTop.TabIndex = 111;
			checkBoxAlwaysOnTop.Text = "Always on top";
			checkBoxAlwaysOnTop.UseVisualStyleBackColor = true;
			checkBoxAlwaysOnTop.CheckedChanged += checkBoxAlwaysOnTop_CheckedChanged;
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(562, 466);
			Controls.Add(checkBoxAlwaysOnTop);
			Controls.Add(buttonEquity);
			Controls.Add(buttonCloseAll);
			Controls.Add(buttonSlDownMin);
			Controls.Add(buttonSlUpMin);
			Controls.Add(buttonSlDown);
			Controls.Add(buttonSlUp);
			Controls.Add(buttonSlDownMax);
			Controls.Add(buttonSlUpMax);
			Controls.Add(buttonResetTp);
			Controls.Add(checkBoxMovePendingOrder);
			Controls.Add(buttonJoinSl);
			Controls.Add(buttonSell10);
			Controls.Add(buttonSell30);
			Controls.Add(buttonSell60);
			Controls.Add(buttonSell100);
			Controls.Add(buttonBuy10);
			Controls.Add(buttonBuy30);
			Controls.Add(buttonBuy60);
			Controls.Add(buttonBuy100);
			Controls.Add(labelPositionUsingPercent);
			Controls.Add(labelPositionUsing);
			Controls.Add(trackBarPositionUsing);
			Controls.Add(progressBarSlPtMonitoring);
			Controls.Add(progressBarSlToBe);
			Controls.Add(buttonSlPtMonitoring);
			Controls.Add(buttonSlToBe);
			Controls.Add(buttonSell64);
			Controls.Add(buttonBuy64);
			Controls.Add(buttonSell541);
			Controls.Add(buttonBuy541);
			Controls.Add(labelRRR);
			Controls.Add(buttonCalculate);
			Controls.Add(textBoxLimitPrice);
			Controls.Add(labelLimitPrice);
			Controls.Add(buttonSell631);
			Controls.Add(buttonBuy631);
			Controls.Add(textBoxSlDistance);
			Controls.Add(labelSlDistance);
			Controls.Add(textBoxSymbol);
			Controls.Add(labelSymbol);
			Icon = (Icon)resources.GetObject("$this.Icon");
			Margin = new Padding(2, 2, 2, 2);
			Name = "Form1";
			Text = "XTB";
			Load += Form1_Load;
			((System.ComponentModel.ISupportInitialize)trackBarPositionUsing).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label labelSymbol;
		private TextBox textBoxSymbol;
		private Label labelSlDistance;
		private TextBox textBoxSlDistance;
		private Button buttonBuy631;
		private Button buttonSell631;
		private Label labelLimitPrice;
		private TextBox textBoxLimitPrice;
		private Button buttonCalculate;
		private Label labelRRR;
		private Button buttonBuy541;
		private Button buttonSell541;
		private Button buttonBuy64;
		private Button buttonSell64;
		private Button buttonSlToBe;
		private Button buttonSlPtMonitoring;
		private ProgressBar progressBarSlToBe;
		private ProgressBar progressBarSlPtMonitoring;
		private System.Windows.Forms.Timer timer;
		private TrackBar trackBarPositionUsing;
		private Label labelPositionUsing;
		private Label labelPositionUsingPercent;
		private System.Windows.Forms.Timer timerRefreshTexts;
		private Button buttonBuy100;
		private Button buttonBuy60;
		private Button buttonBuy30;
		private Button buttonBuy10;
		private Button buttonSell100;
		private Button buttonSell60;
		private Button buttonSell30;
		private Button buttonSell10;
		private Button buttonJoinSl;
		private CheckBox checkBoxMovePendingOrder;
		private Button buttonResetTp;
		private Button buttonSlUpMax;
		private Button buttonSlDownMax;
		private Button buttonSlDown;
		private Button buttonSlUp;
		private Button buttonSlDownMin;
		private Button buttonSlUpMin;
		private Button buttonCloseAll;
		private Button buttonEquity;
		private CheckBox checkBoxAlwaysOnTop;
	}
}