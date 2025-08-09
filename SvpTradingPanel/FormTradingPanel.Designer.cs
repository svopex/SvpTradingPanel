namespace SvpTradingPanel
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTradingPanel));
			this.buttonOrderBuy1 = new System.Windows.Forms.Button();
			this.textBoxSlDistance = new System.Windows.Forms.TextBox();
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
			this.buttonOrderSell3 = new System.Windows.Forms.Button();
			this.buttonOrderBuy3 = new System.Windows.Forms.Button();
			this.labelPrice = new System.Windows.Forms.Label();
			this.textBoxPrice = new System.Windows.Forms.TextBox();
			this.checkBoxPendingOrder = new System.Windows.Forms.CheckBox();
			this.checkBoxMovePendingOrder = new System.Windows.Forms.CheckBox();
			this.buttonSetTp = new System.Windows.Forms.Button();
			this.trackBarPositionUsing = new System.Windows.Forms.TrackBar();
			this.labelPositionUsing = new System.Windows.Forms.Label();
			this.labelPositionUsingPercent = new System.Windows.Forms.Label();
			this.labelSlLoss = new System.Windows.Forms.Label();
			this.buttonSlToBeAutomation = new System.Windows.Forms.Button();
			this.progressBarSlToBeAutomation = new System.Windows.Forms.ProgressBar();
			this.buttonSlPtMonitoring = new System.Windows.Forms.Button();
			this.progressBarSlPtMonitoring = new System.Windows.Forms.ProgressBar();
			this.buttonEquity = new System.Windows.Forms.Button();
			this.labelSymbol = new System.Windows.Forms.Label();
			this.checkBoxBlink = new System.Windows.Forms.CheckBox();
			this.progressBarSlToHalfAutomation = new System.Windows.Forms.ProgressBar();
			this.buttonSlToHalfAutomation = new System.Windows.Forms.Button();
			this.buttonCallHueTest = new System.Windows.Forms.Button();
			this.labelPs = new System.Windows.Forms.Label();
			this.labelTickValue = new System.Windows.Forms.Label();
			this.labelUsdCzk = new System.Windows.Forms.Label();
			this.labelContractSize = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.trackBarPositionUsing)).BeginInit();
			this.SuspendLayout();
			// 
			// buttonOrderBuy1
			// 
			this.buttonOrderBuy1.Location = new System.Drawing.Point(24, 522);
			this.buttonOrderBuy1.Name = "buttonOrderBuy1";
			this.buttonOrderBuy1.Size = new System.Drawing.Size(210, 63);
			this.buttonOrderBuy1.TabIndex = 50;
			this.buttonOrderBuy1.Text = "Buy 40% 35% 25%";
			this.buttonOrderBuy1.UseVisualStyleBackColor = true;
			this.buttonOrderBuy1.Click += new System.EventHandler(this.buttonOrderBuy1_Click);
			// 
			// textBoxSlDistance
			// 
			this.textBoxSlDistance.Location = new System.Drawing.Point(135, 102);
			this.textBoxSlDistance.Name = "textBoxSlDistance";
			this.textBoxSlDistance.Size = new System.Drawing.Size(110, 26);
			this.textBoxSlDistance.TabIndex = 1;
			// 
			// LabelPositionSize
			// 
			this.LabelPositionSize.AutoSize = true;
			this.LabelPositionSize.Location = new System.Drawing.Point(20, 103);
			this.LabelPositionSize.Name = "LabelPositionSize";
			this.LabelPositionSize.Size = new System.Drawing.Size(93, 20);
			this.LabelPositionSize.TabIndex = 0;
			this.LabelPositionSize.Text = "&SL distance";
			// 
			// buttonSlUp
			// 
			this.buttonSlUp.Location = new System.Drawing.Point(606, 275);
			this.buttonSlUp.Name = "buttonSlUp";
			this.buttonSlUp.Size = new System.Drawing.Size(146, 63);
			this.buttonSlUp.TabIndex = 73;
			this.buttonSlUp.Text = "SL up";
			this.buttonSlUp.UseVisualStyleBackColor = true;
			this.buttonSlUp.Click += new System.EventHandler(this.buttonSlUp_Click);
			// 
			// buttonSlDown
			// 
			this.buttonSlDown.Location = new System.Drawing.Point(609, 343);
			this.buttonSlDown.Name = "buttonSlDown";
			this.buttonSlDown.Size = new System.Drawing.Size(146, 62);
			this.buttonSlDown.TabIndex = 74;
			this.buttonSlDown.Text = "SL down";
			this.buttonSlDown.UseVisualStyleBackColor = true;
			this.buttonSlDown.Click += new System.EventHandler(this.buttonSlDown_Click);
			// 
			// buttonJoinSl
			// 
			this.buttonJoinSl.Location = new System.Drawing.Point(759, 412);
			this.buttonJoinSl.Name = "buttonJoinSl";
			this.buttonJoinSl.Size = new System.Drawing.Size(144, 63);
			this.buttonJoinSl.TabIndex = 82;
			this.buttonJoinSl.Text = "Join SL";
			this.buttonJoinSl.UseVisualStyleBackColor = true;
			this.buttonJoinSl.Click += new System.EventHandler(this.buttonJoinSl_Click);
			// 
			// buttonSlUpMini
			// 
			this.buttonSlUpMini.Location = new System.Drawing.Point(759, 275);
			this.buttonSlUpMini.Name = "buttonSlUpMini";
			this.buttonSlUpMini.Size = new System.Drawing.Size(144, 63);
			this.buttonSlUpMini.TabIndex = 75;
			this.buttonSlUpMini.Text = "SL up mini";
			this.buttonSlUpMini.UseVisualStyleBackColor = true;
			this.buttonSlUpMini.Click += new System.EventHandler(this.buttonSlUpMini_Click);
			// 
			// buttonSlDownMini
			// 
			this.buttonSlDownMini.Location = new System.Drawing.Point(759, 343);
			this.buttonSlDownMini.Name = "buttonSlDownMini";
			this.buttonSlDownMini.Size = new System.Drawing.Size(144, 63);
			this.buttonSlDownMini.TabIndex = 76;
			this.buttonSlDownMini.Text = "SL down mini";
			this.buttonSlDownMini.UseVisualStyleBackColor = true;
			this.buttonSlDownMini.Click += new System.EventHandler(this.buttonSlDownMini_Click);
			// 
			// checkBoxAlwaysOnTop
			// 
			this.checkBoxAlwaysOnTop.AutoSize = true;
			this.checkBoxAlwaysOnTop.Location = new System.Drawing.Point(777, 102);
			this.checkBoxAlwaysOnTop.Name = "checkBoxAlwaysOnTop";
			this.checkBoxAlwaysOnTop.Size = new System.Drawing.Size(139, 27);
			this.checkBoxAlwaysOnTop.TabIndex = 13;
			this.checkBoxAlwaysOnTop.Text = "Always on top";
			this.checkBoxAlwaysOnTop.UseVisualStyleBackColor = true;
			this.checkBoxAlwaysOnTop.CheckedChanged += new System.EventHandler(this.checkBoxAlwaysOnTop_CheckedChanged);
			// 
			// buttonOrderSell1
			// 
			this.buttonOrderSell1.Location = new System.Drawing.Point(237, 522);
			this.buttonOrderSell1.Name = "buttonOrderSell1";
			this.buttonOrderSell1.Size = new System.Drawing.Size(210, 63);
			this.buttonOrderSell1.TabIndex = 53;
			this.buttonOrderSell1.Text = "Sell 40% 35% 25%";
			this.buttonOrderSell1.UseVisualStyleBackColor = true;
			this.buttonOrderSell1.Click += new System.EventHandler(this.buttonOrderSell1_Click);
			// 
			// buttonBuy60
			// 
			this.buttonBuy60.Location = new System.Drawing.Point(24, 317);
			this.buttonBuy60.Name = "buttonBuy60";
			this.buttonBuy60.Size = new System.Drawing.Size(210, 63);
			this.buttonBuy60.TabIndex = 21;
			this.buttonBuy60.Text = "Buy 60%";
			this.buttonBuy60.UseVisualStyleBackColor = true;
			this.buttonBuy60.Click += new System.EventHandler(this.buttonBuy60_Click);
			// 
			// buttonBuy30
			// 
			this.buttonBuy30.Location = new System.Drawing.Point(24, 383);
			this.buttonBuy30.Name = "buttonBuy30";
			this.buttonBuy30.Size = new System.Drawing.Size(210, 63);
			this.buttonBuy30.TabIndex = 22;
			this.buttonBuy30.Text = "Buy 30%";
			this.buttonBuy30.UseVisualStyleBackColor = true;
			this.buttonBuy30.Click += new System.EventHandler(this.buttonBuy30_Click);
			// 
			// buttonBuy10
			// 
			this.buttonBuy10.Location = new System.Drawing.Point(24, 452);
			this.buttonBuy10.Name = "buttonBuy10";
			this.buttonBuy10.Size = new System.Drawing.Size(210, 63);
			this.buttonBuy10.TabIndex = 23;
			this.buttonBuy10.Text = "Buy 10%";
			this.buttonBuy10.UseVisualStyleBackColor = true;
			this.buttonBuy10.Click += new System.EventHandler(this.buttonBuy10_Click);
			// 
			// buttonBuy100
			// 
			this.buttonBuy100.Location = new System.Drawing.Point(24, 249);
			this.buttonBuy100.Name = "buttonBuy100";
			this.buttonBuy100.Size = new System.Drawing.Size(210, 63);
			this.buttonBuy100.TabIndex = 20;
			this.buttonBuy100.Text = "Buy 100%";
			this.buttonBuy100.UseVisualStyleBackColor = true;
			this.buttonBuy100.Click += new System.EventHandler(this.buttonBuy100_Click);
			// 
			// buttonSell100
			// 
			this.buttonSell100.Location = new System.Drawing.Point(237, 249);
			this.buttonSell100.Name = "buttonSell100";
			this.buttonSell100.Size = new System.Drawing.Size(210, 63);
			this.buttonSell100.TabIndex = 24;
			this.buttonSell100.Text = "Sell 100%";
			this.buttonSell100.UseVisualStyleBackColor = true;
			this.buttonSell100.Click += new System.EventHandler(this.buttonSell100_Click);
			// 
			// buttonSell60
			// 
			this.buttonSell60.Location = new System.Drawing.Point(237, 317);
			this.buttonSell60.Name = "buttonSell60";
			this.buttonSell60.Size = new System.Drawing.Size(210, 63);
			this.buttonSell60.TabIndex = 25;
			this.buttonSell60.Text = "Sell 60%";
			this.buttonSell60.UseVisualStyleBackColor = true;
			this.buttonSell60.Click += new System.EventHandler(this.buttonSell60_Click);
			// 
			// buttonSell30
			// 
			this.buttonSell30.Location = new System.Drawing.Point(237, 383);
			this.buttonSell30.Name = "buttonSell30";
			this.buttonSell30.Size = new System.Drawing.Size(210, 63);
			this.buttonSell30.TabIndex = 26;
			this.buttonSell30.Text = "Sell 30%";
			this.buttonSell30.UseVisualStyleBackColor = true;
			this.buttonSell30.Click += new System.EventHandler(this.buttonSell30_Click);
			// 
			// buttonSell10
			// 
			this.buttonSell10.Location = new System.Drawing.Point(237, 452);
			this.buttonSell10.Name = "buttonSell10";
			this.buttonSell10.Size = new System.Drawing.Size(210, 63);
			this.buttonSell10.TabIndex = 27;
			this.buttonSell10.Text = "Sell 10%";
			this.buttonSell10.UseVisualStyleBackColor = true;
			this.buttonSell10.Click += new System.EventHandler(this.buttonSell10_Click);
			// 
			// labelConnected
			// 
			this.labelConnected.AutoSize = true;
			this.labelConnected.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labelConnected.Location = new System.Drawing.Point(786, 8);
			this.labelConnected.Name = "labelConnected";
			this.labelConnected.Size = new System.Drawing.Size(145, 36);
			this.labelConnected.TabIndex = 11;
			this.labelConnected.Text = "**********";
			this.labelConnected.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// buttonOrderBuy2
			// 
			this.buttonOrderBuy2.Location = new System.Drawing.Point(24, 662);
			this.buttonOrderBuy2.Name = "buttonOrderBuy2";
			this.buttonOrderBuy2.Size = new System.Drawing.Size(210, 63);
			this.buttonOrderBuy2.TabIndex = 52;
			this.buttonOrderBuy2.Text = "Buy 60% 40%";
			this.buttonOrderBuy2.UseVisualStyleBackColor = true;
			this.buttonOrderBuy2.Click += new System.EventHandler(this.buttonOrderBuy2_Click);
			// 
			// buttonOrderSell2
			// 
			this.buttonOrderSell2.Location = new System.Drawing.Point(237, 662);
			this.buttonOrderSell2.Name = "buttonOrderSell2";
			this.buttonOrderSell2.Size = new System.Drawing.Size(213, 63);
			this.buttonOrderSell2.TabIndex = 55;
			this.buttonOrderSell2.Text = "Sell 60% 40%";
			this.buttonOrderSell2.UseVisualStyleBackColor = true;
			this.buttonOrderSell2.Click += new System.EventHandler(this.buttonOrderSell2_Click);
			// 
			// buttonCloseAll
			// 
			this.buttonCloseAll.Location = new System.Drawing.Point(456, 412);
			this.buttonCloseAll.Name = "buttonCloseAll";
			this.buttonCloseAll.Size = new System.Drawing.Size(147, 63);
			this.buttonCloseAll.TabIndex = 80;
			this.buttonCloseAll.Text = "Close All";
			this.buttonCloseAll.UseVisualStyleBackColor = true;
			this.buttonCloseAll.Click += new System.EventHandler(this.buttonCloseAll_Click);
			// 
			// buttonSlDownMax
			// 
			this.buttonSlDownMax.Location = new System.Drawing.Point(456, 343);
			this.buttonSlDownMax.Name = "buttonSlDownMax";
			this.buttonSlDownMax.Size = new System.Drawing.Size(147, 63);
			this.buttonSlDownMax.TabIndex = 72;
			this.buttonSlDownMax.Text = "SL down max";
			this.buttonSlDownMax.UseVisualStyleBackColor = true;
			this.buttonSlDownMax.Click += new System.EventHandler(this.buttonSlDownMax_Click);
			// 
			// buttonSlUpMax
			// 
			this.buttonSlUpMax.Location = new System.Drawing.Point(456, 275);
			this.buttonSlUpMax.Name = "buttonSlUpMax";
			this.buttonSlUpMax.Size = new System.Drawing.Size(147, 63);
			this.buttonSlUpMax.TabIndex = 71;
			this.buttonSlUpMax.Text = "SL up max";
			this.buttonSlUpMax.UseVisualStyleBackColor = true;
			this.buttonSlUpMax.Click += new System.EventHandler(this.buttonSlUpMax_Click);
			// 
			// labelRrr
			// 
			this.labelRrr.AutoSize = true;
			this.labelRrr.Location = new System.Drawing.Point(20, 8);
			this.labelRrr.Name = "labelRrr";
			this.labelRrr.Size = new System.Drawing.Size(45, 20);
			this.labelRrr.TabIndex = 7;
			this.labelRrr.Text = "RRR";
			// 
			// timerRefreshLabels
			// 
			this.timerRefreshLabels.Enabled = true;
			this.timerRefreshLabels.Interval = 1000;
			this.timerRefreshLabels.Tick += new System.EventHandler(this.timerRefreshLabels_Tick);
			// 
			// labelLoss
			// 
			this.labelLoss.AutoSize = true;
			this.labelLoss.Location = new System.Drawing.Point(276, 8);
			this.labelLoss.Name = "labelLoss";
			this.labelLoss.Size = new System.Drawing.Size(43, 20);
			this.labelLoss.TabIndex = 8;
			this.labelLoss.Text = "Loss";
			// 
			// labelProfit
			// 
			this.labelProfit.AutoSize = true;
			this.labelProfit.Location = new System.Drawing.Point(530, 8);
			this.labelProfit.Name = "labelProfit";
			this.labelProfit.Size = new System.Drawing.Size(46, 20);
			this.labelProfit.TabIndex = 9;
			this.labelProfit.Text = "Profit";
			// 
			// buttonOrderSell3
			// 
			this.buttonOrderSell3.Location = new System.Drawing.Point(237, 592);
			this.buttonOrderSell3.Name = "buttonOrderSell3";
			this.buttonOrderSell3.Size = new System.Drawing.Size(210, 63);
			this.buttonOrderSell3.TabIndex = 54;
			this.buttonOrderSell3.Text = "Sell 50% 40% 10%";
			this.buttonOrderSell3.UseVisualStyleBackColor = true;
			this.buttonOrderSell3.Click += new System.EventHandler(this.buttonOrderSell3_Click);
			// 
			// buttonOrderBuy3
			// 
			this.buttonOrderBuy3.Location = new System.Drawing.Point(24, 592);
			this.buttonOrderBuy3.Name = "buttonOrderBuy3";
			this.buttonOrderBuy3.Size = new System.Drawing.Size(210, 63);
			this.buttonOrderBuy3.TabIndex = 51;
			this.buttonOrderBuy3.Text = "Buy 50% 40% 10%";
			this.buttonOrderBuy3.UseVisualStyleBackColor = true;
			this.buttonOrderBuy3.Click += new System.EventHandler(this.buttonOrderBuy3_Click);
			// 
			// labelPrice
			// 
			this.labelPrice.AutoSize = true;
			this.labelPrice.Location = new System.Drawing.Point(20, 135);
			this.labelPrice.Name = "labelPrice";
			this.labelPrice.Size = new System.Drawing.Size(44, 20);
			this.labelPrice.TabIndex = 2;
			this.labelPrice.Text = "&Price";
			// 
			// textBoxPrice
			// 
			this.textBoxPrice.Location = new System.Drawing.Point(135, 132);
			this.textBoxPrice.Name = "textBoxPrice";
			this.textBoxPrice.Size = new System.Drawing.Size(110, 26);
			this.textBoxPrice.TabIndex = 3;
			// 
			// checkBoxPendingOrder
			// 
			this.checkBoxPendingOrder.AutoSize = true;
			this.checkBoxPendingOrder.Location = new System.Drawing.Point(777, 132);
			this.checkBoxPendingOrder.Name = "checkBoxPendingOrder";
			this.checkBoxPendingOrder.Size = new System.Drawing.Size(140, 27);
			this.checkBoxPendingOrder.TabIndex = 14;
			this.checkBoxPendingOrder.Text = "Pending order";
			this.checkBoxPendingOrder.UseVisualStyleBackColor = true;
			this.checkBoxPendingOrder.CheckedChanged += new System.EventHandler(this.checkBoxPendingOrder_CheckedChanged);
			// 
			// checkBoxMovePendingOrder
			// 
			this.checkBoxMovePendingOrder.AutoSize = true;
			this.checkBoxMovePendingOrder.Location = new System.Drawing.Point(675, 245);
			this.checkBoxMovePendingOrder.Name = "checkBoxMovePendingOrder";
			this.checkBoxMovePendingOrder.Size = new System.Drawing.Size(236, 27);
			this.checkBoxMovePendingOrder.TabIndex = 70;
			this.checkBoxMovePendingOrder.Text = "Move pending order, not SL";
			this.checkBoxMovePendingOrder.UseVisualStyleBackColor = true;
			// 
			// buttonSetTp
			// 
			this.buttonSetTp.Location = new System.Drawing.Point(606, 412);
			this.buttonSetTp.Name = "buttonSetTp";
			this.buttonSetTp.Size = new System.Drawing.Size(147, 63);
			this.buttonSetTp.TabIndex = 81;
			this.buttonSetTp.Text = "Re-set TP";
			this.buttonSetTp.UseVisualStyleBackColor = true;
			this.buttonSetTp.Click += new System.EventHandler(this.buttonSetTp_Click);
			// 
			// trackBarPositionUsing
			// 
			this.trackBarPositionUsing.LargeChange = 50;
			this.trackBarPositionUsing.Location = new System.Drawing.Point(135, 172);
			this.trackBarPositionUsing.Maximum = 300;
			this.trackBarPositionUsing.Minimum = 10;
			this.trackBarPositionUsing.Name = "trackBarPositionUsing";
			this.trackBarPositionUsing.Size = new System.Drawing.Size(768, 90);
			this.trackBarPositionUsing.SmallChange = 10;
			this.trackBarPositionUsing.TabIndex = 6;
			this.trackBarPositionUsing.Value = 100;
			this.trackBarPositionUsing.ValueChanged += new System.EventHandler(this.trackBarPositionUsing_ValueChanged);
			// 
			// labelPositionUsing
			// 
			this.labelPositionUsing.AutoSize = true;
			this.labelPositionUsing.Location = new System.Drawing.Point(21, 172);
			this.labelPositionUsing.Name = "labelPositionUsing";
			this.labelPositionUsing.Size = new System.Drawing.Size(110, 20);
			this.labelPositionUsing.TabIndex = 4;
			this.labelPositionUsing.Text = "&Pos. utilization";
			// 
			// labelPositionUsingPercent
			// 
			this.labelPositionUsingPercent.AutoSize = true;
			this.labelPositionUsingPercent.Location = new System.Drawing.Point(46, 200);
			this.labelPositionUsingPercent.Name = "labelPositionUsingPercent";
			this.labelPositionUsingPercent.Size = new System.Drawing.Size(50, 20);
			this.labelPositionUsingPercent.TabIndex = 5;
			this.labelPositionUsingPercent.Text = "100%";
			// 
			// labelSlLoss
			// 
			this.labelSlLoss.AutoSize = true;
			this.labelSlLoss.Location = new System.Drawing.Point(20, 38);
			this.labelSlLoss.Name = "labelSlLoss";
			this.labelSlLoss.Size = new System.Drawing.Size(46, 20);
			this.labelSlLoss.TabIndex = 10;
			this.labelSlLoss.Text = "Profit";
			// 
			// buttonSlToBeAutomation
			// 
			this.buttonSlToBeAutomation.Location = new System.Drawing.Point(456, 522);
			this.buttonSlToBeAutomation.Name = "buttonSlToBeAutomation";
			this.buttonSlToBeAutomation.Size = new System.Drawing.Size(444, 46);
			this.buttonSlToBeAutomation.TabIndex = 86;
			this.buttonSlToBeAutomation.Text = "SL to BE automation after PT";
			this.buttonSlToBeAutomation.UseVisualStyleBackColor = true;
			this.buttonSlToBeAutomation.Click += new System.EventHandler(this.buttonSlToBeAutomation_Click);
			// 
			// progressBarSlToBeAutomation
			// 
			this.progressBarSlToBeAutomation.Location = new System.Drawing.Point(460, 575);
			this.progressBarSlToBeAutomation.Name = "progressBarSlToBeAutomation";
			this.progressBarSlToBeAutomation.Size = new System.Drawing.Size(440, 38);
			this.progressBarSlToBeAutomation.TabIndex = 87;
			// 
			// buttonSlPtMonitoring
			// 
			this.buttonSlPtMonitoring.Location = new System.Drawing.Point(456, 717);
			this.buttonSlPtMonitoring.Name = "buttonSlPtMonitoring";
			this.buttonSlPtMonitoring.Size = new System.Drawing.Size(447, 46);
			this.buttonSlPtMonitoring.TabIndex = 88;
			this.buttonSlPtMonitoring.Text = "SL/PT monitoring";
			this.buttonSlPtMonitoring.UseVisualStyleBackColor = true;
			this.buttonSlPtMonitoring.Click += new System.EventHandler(this.buttonSlPtMonitoring_Click);
			// 
			// progressBarSlPtMonitoring
			// 
			this.progressBarSlPtMonitoring.Location = new System.Drawing.Point(460, 769);
			this.progressBarSlPtMonitoring.Name = "progressBarSlPtMonitoring";
			this.progressBarSlPtMonitoring.Size = new System.Drawing.Size(440, 38);
			this.progressBarSlPtMonitoring.TabIndex = 89;
			// 
			// buttonEquity
			// 
			this.buttonEquity.Location = new System.Drawing.Point(609, 102);
			this.buttonEquity.Name = "buttonEquity";
			this.buttonEquity.Size = new System.Drawing.Size(144, 55);
			this.buttonEquity.TabIndex = 12;
			this.buttonEquity.Text = "Equity";
			this.buttonEquity.UseVisualStyleBackColor = true;
			this.buttonEquity.Click += new System.EventHandler(this.buttonEquity_Click);
			// 
			// labelSymbol
			// 
			this.labelSymbol.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labelSymbol.ForeColor = System.Drawing.Color.Blue;
			this.labelSymbol.Location = new System.Drawing.Point(270, 102);
			this.labelSymbol.Name = "labelSymbol";
			this.labelSymbol.Size = new System.Drawing.Size(322, 68);
			this.labelSymbol.TabIndex = 90;
			this.labelSymbol.Text = "? Symbol ?";
			// 
			// checkBoxBlink
			// 
			this.checkBoxBlink.AutoSize = true;
			this.checkBoxBlink.Location = new System.Drawing.Point(460, 489);
			this.checkBoxBlink.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.checkBoxBlink.Name = "checkBoxBlink";
			this.checkBoxBlink.Size = new System.Drawing.Size(163, 27);
			this.checkBoxBlink.TabIndex = 91;
			this.checkBoxBlink.Text = "Blink by Hue bulb";
			this.checkBoxBlink.UseVisualStyleBackColor = true;
			// 
			// progressBarSlToHalfAutomation
			// 
			this.progressBarSlToHalfAutomation.Location = new System.Drawing.Point(460, 672);
			this.progressBarSlToHalfAutomation.Name = "progressBarSlToHalfAutomation";
			this.progressBarSlToHalfAutomation.Size = new System.Drawing.Size(440, 38);
			this.progressBarSlToHalfAutomation.TabIndex = 93;
			// 
			// buttonSlToHalfAutomation
			// 
			this.buttonSlToHalfAutomation.Location = new System.Drawing.Point(456, 618);
			this.buttonSlToHalfAutomation.Name = "buttonSlToHalfAutomation";
			this.buttonSlToHalfAutomation.Size = new System.Drawing.Size(444, 46);
			this.buttonSlToHalfAutomation.TabIndex = 92;
			this.buttonSlToHalfAutomation.Text = "SL to half automation after PT";
			this.buttonSlToHalfAutomation.UseVisualStyleBackColor = true;
			this.buttonSlToHalfAutomation.Click += new System.EventHandler(this.buttonSlToHalfAutomation_Click);
			// 
			// buttonCallHueTest
			// 
			this.buttonCallHueTest.Location = new System.Drawing.Point(26, 749);
			this.buttonCallHueTest.Margin = new System.Windows.Forms.Padding(2);
			this.buttonCallHueTest.Name = "buttonCallHueTest";
			this.buttonCallHueTest.Size = new System.Drawing.Size(208, 58);
			this.buttonCallHueTest.TabIndex = 94;
			this.buttonCallHueTest.Text = "Call Hue Test";
			this.buttonCallHueTest.UseVisualStyleBackColor = true;
			this.buttonCallHueTest.Click += new System.EventHandler(this.buttonCallHueTest_Click);
			// 
			// labelPs
			// 
			this.labelPs.AutoSize = true;
			this.labelPs.Location = new System.Drawing.Point(21, 69);
			this.labelPs.Name = "labelPs";
			this.labelPs.Size = new System.Drawing.Size(97, 20);
			this.labelPs.TabIndex = 95;
			this.labelPs.Text = "Position size";
			// 
			// labelTickValue
			// 
			this.labelTickValue.AutoSize = true;
			this.labelTickValue.Location = new System.Drawing.Point(276, 69);
			this.labelTickValue.Name = "labelTickValue";
			this.labelTickValue.Size = new System.Drawing.Size(78, 20);
			this.labelTickValue.TabIndex = 96;
			this.labelTickValue.Text = "Tick value";
			// 
			// labelUsdCzk
			// 
			this.labelUsdCzk.AutoSize = true;
			this.labelUsdCzk.Location = new System.Drawing.Point(530, 69);
			this.labelUsdCzk.Name = "labelUsdCzk";
			this.labelUsdCzk.Size = new System.Drawing.Size(75, 20);
			this.labelUsdCzk.TabIndex = 97;
			this.labelUsdCzk.Text = "USDCZK";
			// 
			// labelContractSize
			// 
			this.labelContractSize.AutoSize = true;
			this.labelContractSize.Location = new System.Drawing.Point(754, 69);
			this.labelContractSize.Name = "labelContractSize";
			this.labelContractSize.Size = new System.Drawing.Size(105, 20);
			this.labelContractSize.TabIndex = 98;
			this.labelContractSize.Text = "Contract Size";
			// 
			// FormTradingPanel
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(932, 828);
			this.Controls.Add(this.labelContractSize);
			this.Controls.Add(this.labelUsdCzk);
			this.Controls.Add(this.labelTickValue);
			this.Controls.Add(this.labelPs);
			this.Controls.Add(this.buttonCallHueTest);
			this.Controls.Add(this.progressBarSlToHalfAutomation);
			this.Controls.Add(this.buttonSlToHalfAutomation);
			this.Controls.Add(this.checkBoxBlink);
			this.Controls.Add(this.labelSymbol);
			this.Controls.Add(this.buttonEquity);
			this.Controls.Add(this.progressBarSlPtMonitoring);
			this.Controls.Add(this.buttonSlPtMonitoring);
			this.Controls.Add(this.progressBarSlToBeAutomation);
			this.Controls.Add(this.buttonSlToBeAutomation);
			this.Controls.Add(this.labelSlLoss);
			this.Controls.Add(this.labelPositionUsingPercent);
			this.Controls.Add(this.labelPositionUsing);
			this.Controls.Add(this.trackBarPositionUsing);
			this.Controls.Add(this.buttonSetTp);
			this.Controls.Add(this.checkBoxMovePendingOrder);
			this.Controls.Add(this.checkBoxPendingOrder);
			this.Controls.Add(this.textBoxPrice);
			this.Controls.Add(this.labelPrice);
			this.Controls.Add(this.buttonOrderSell3);
			this.Controls.Add(this.buttonOrderBuy3);
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
			this.Controls.Add(this.textBoxSlDistance);
			this.Controls.Add(this.buttonOrderBuy1);
			this.Cursor = System.Windows.Forms.Cursors.Default;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "FormTradingPanel";
			this.Text = "SvpTradePanel";
			this.Load += new System.EventHandler(this.FormTradingPanel_Load);
			((System.ComponentModel.ISupportInitialize)(this.trackBarPositionUsing)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button buttonOrderBuy1;
		private System.Windows.Forms.TextBox textBoxSlDistance;
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
		private System.Windows.Forms.Button buttonOrderSell3;
		private System.Windows.Forms.Button buttonOrderBuy3;
		private System.Windows.Forms.Label labelPrice;
		private System.Windows.Forms.TextBox textBoxPrice;
		private System.Windows.Forms.CheckBox checkBoxPendingOrder;
		private System.Windows.Forms.CheckBox checkBoxMovePendingOrder;
		private System.Windows.Forms.Button buttonSetTp;
		private System.Windows.Forms.TrackBar trackBarPositionUsing;
		private System.Windows.Forms.Label labelPositionUsing;
		private System.Windows.Forms.Label labelPositionUsingPercent;
		private System.Windows.Forms.Label labelSlLoss;
		private System.Windows.Forms.Button buttonSlToBeAutomation;
		private System.Windows.Forms.ProgressBar progressBarSlToBeAutomation;
		private System.Windows.Forms.Button buttonSlPtMonitoring;
		private System.Windows.Forms.ProgressBar progressBarSlPtMonitoring;
		private System.Windows.Forms.Button buttonEquity;
		private System.Windows.Forms.Label labelSymbol;
		private System.Windows.Forms.CheckBox checkBoxBlink;
		private System.Windows.Forms.ProgressBar progressBarSlToHalfAutomation;
		private System.Windows.Forms.Button buttonSlToHalfAutomation;
		private System.Windows.Forms.Button buttonCallHueTest;
		private System.Windows.Forms.Label labelPs;
		private System.Windows.Forms.Label labelTickValue;
		private System.Windows.Forms.Label labelUsdCzk;
		private System.Windows.Forms.Label labelContractSize;
	}
}

