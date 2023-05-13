namespace Xtb
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
			((System.ComponentModel.ISupportInitialize)trackBarPositionUsing).BeginInit();
			SuspendLayout();
			// 
			// labelSymbol
			// 
			labelSymbol.AutoSize = true;
			labelSymbol.Location = new Point(12, 9);
			labelSymbol.Name = "labelSymbol";
			labelSymbol.Size = new Size(80, 30);
			labelSymbol.TabIndex = 0;
			labelSymbol.Text = "Symbol";
			// 
			// textBoxSymbol
			// 
			textBoxSymbol.Location = new Point(135, 6);
			textBoxSymbol.Name = "textBoxSymbol";
			textBoxSymbol.Size = new Size(175, 35);
			textBoxSymbol.TabIndex = 1;
			// 
			// labelSlDistance
			// 
			labelSlDistance.AutoSize = true;
			labelSlDistance.Location = new Point(12, 52);
			labelSlDistance.Name = "labelSlDistance";
			labelSlDistance.Size = new Size(117, 30);
			labelSlDistance.TabIndex = 2;
			labelSlDistance.Text = "SL distance";
			// 
			// textBoxSlDistance
			// 
			textBoxSlDistance.Location = new Point(135, 49);
			textBoxSlDistance.Name = "textBoxSlDistance";
			textBoxSlDistance.Size = new Size(175, 35);
			textBoxSlDistance.TabIndex = 3;
			// 
			// buttonBuy631
			// 
			buttonBuy631.Location = new Point(12, 232);
			buttonBuy631.Name = "buttonBuy631";
			buttonBuy631.Size = new Size(201, 72);
			buttonBuy631.TabIndex = 10;
			buttonBuy631.Text = "Buy 60% 30% 10%";
			buttonBuy631.UseVisualStyleBackColor = true;
			buttonBuy631.Click += buttonBuy631_Click;
			// 
			// buttonSell631
			// 
			buttonSell631.Location = new Point(245, 232);
			buttonSell631.Name = "buttonSell631";
			buttonSell631.Size = new Size(201, 72);
			buttonSell631.TabIndex = 11;
			buttonSell631.Text = "Sell 60% 30% 10%";
			buttonSell631.UseVisualStyleBackColor = true;
			buttonSell631.Click += buttonSell631_Click;
			// 
			// labelLimitPrice
			// 
			labelLimitPrice.AutoSize = true;
			labelLimitPrice.Location = new Point(12, 93);
			labelLimitPrice.Name = "labelLimitPrice";
			labelLimitPrice.Size = new Size(109, 30);
			labelLimitPrice.TabIndex = 4;
			labelLimitPrice.Text = "Limit price";
			// 
			// textBoxLimitPrice
			// 
			textBoxLimitPrice.Location = new Point(135, 93);
			textBoxLimitPrice.Name = "textBoxLimitPrice";
			textBoxLimitPrice.Size = new Size(175, 35);
			textBoxLimitPrice.TabIndex = 5;
			// 
			// buttonCalculate
			// 
			buttonCalculate.Location = new Point(635, 14);
			buttonCalculate.Name = "buttonCalculate";
			buttonCalculate.Size = new Size(201, 109);
			buttonCalculate.TabIndex = 21;
			buttonCalculate.Text = "Calculate";
			buttonCalculate.UseVisualStyleBackColor = true;
			buttonCalculate.Click += buttonCalculate_Click;
			// 
			// labelRRR
			// 
			labelRRR.AutoSize = true;
			labelRRR.Location = new Point(334, 11);
			labelRRR.Name = "labelRRR";
			labelRRR.Size = new Size(71, 30);
			labelRRR.TabIndex = 20;
			labelRRR.Text = "RRR: -";
			// 
			// buttonBuy541
			// 
			buttonBuy541.Location = new Point(12, 310);
			buttonBuy541.Name = "buttonBuy541";
			buttonBuy541.Size = new Size(201, 72);
			buttonBuy541.TabIndex = 12;
			buttonBuy541.Text = "Buy 50% 40% 10%";
			buttonBuy541.UseVisualStyleBackColor = true;
			buttonBuy541.Click += buttonBuy541_Click;
			// 
			// buttonSell541
			// 
			buttonSell541.Location = new Point(245, 310);
			buttonSell541.Name = "buttonSell541";
			buttonSell541.Size = new Size(201, 72);
			buttonSell541.TabIndex = 13;
			buttonSell541.Text = "Sell 50% 40% 10%";
			buttonSell541.UseVisualStyleBackColor = true;
			buttonSell541.Click += buttonSell541_Click;
			// 
			// buttonBuy64
			// 
			buttonBuy64.Location = new Point(12, 388);
			buttonBuy64.Name = "buttonBuy64";
			buttonBuy64.Size = new Size(201, 72);
			buttonBuy64.TabIndex = 14;
			buttonBuy64.Text = "Buy 60% 40%";
			buttonBuy64.UseVisualStyleBackColor = true;
			buttonBuy64.Click += buttonBuy64_Click;
			// 
			// buttonSell64
			// 
			buttonSell64.Location = new Point(245, 388);
			buttonSell64.Name = "buttonSell64";
			buttonSell64.Size = new Size(201, 72);
			buttonSell64.TabIndex = 15;
			buttonSell64.Text = "Sell 60% 40%";
			buttonSell64.UseVisualStyleBackColor = true;
			buttonSell64.Click += buttonSell64_Click;
			// 
			// buttonSlToBe
			// 
			buttonSlToBe.Location = new Point(505, 232);
			buttonSlToBe.Name = "buttonSlToBe";
			buttonSlToBe.Size = new Size(264, 84);
			buttonSlToBe.TabIndex = 30;
			buttonSlToBe.Text = "SL to BE automation after first PT";
			buttonSlToBe.UseVisualStyleBackColor = true;
			buttonSlToBe.Click += buttonSlToBe_Click;
			// 
			// buttonSlPtMonitoring
			// 
			buttonSlPtMonitoring.Location = new Point(505, 398);
			buttonSlPtMonitoring.Name = "buttonSlPtMonitoring";
			buttonSlPtMonitoring.Size = new Size(264, 84);
			buttonSlPtMonitoring.TabIndex = 32;
			buttonSlPtMonitoring.Text = "SL/PT monitoring";
			buttonSlPtMonitoring.UseVisualStyleBackColor = true;
			buttonSlPtMonitoring.Click += buttonSlPtMonitoring_Click;
			// 
			// progressBarSlToBe
			// 
			progressBarSlToBe.Location = new Point(505, 322);
			progressBarSlToBe.Name = "progressBarSlToBe";
			progressBarSlToBe.Size = new Size(264, 40);
			progressBarSlToBe.TabIndex = 33;
			// 
			// progressBarSlPtMonitoring
			// 
			progressBarSlPtMonitoring.Location = new Point(505, 488);
			progressBarSlPtMonitoring.Name = "progressBarSlPtMonitoring";
			progressBarSlPtMonitoring.Size = new Size(264, 40);
			progressBarSlPtMonitoring.TabIndex = 34;
			// 
			// timer
			// 
			timer.Enabled = true;
			timer.Tick += timer_Tick;
			// 
			// trackBarPositionUsing
			// 
			trackBarPositionUsing.LargeChange = 10;
			trackBarPositionUsing.Location = new Point(165, 146);
			trackBarPositionUsing.Maximum = 250;
			trackBarPositionUsing.Minimum = 1;
			trackBarPositionUsing.Name = "trackBarPositionUsing";
			trackBarPositionUsing.Size = new Size(671, 80);
			trackBarPositionUsing.SmallChange = 5;
			trackBarPositionUsing.TabIndex = 8;
			trackBarPositionUsing.Value = 50;
			trackBarPositionUsing.ValueChanged += trackBarPositionUsing_ValueChanged;
			// 
			// labelPositionUsing
			// 
			labelPositionUsing.AutoSize = true;
			labelPositionUsing.Location = new Point(12, 146);
			labelPositionUsing.Name = "labelPositionUsing";
			labelPositionUsing.Size = new Size(147, 30);
			labelPositionUsing.TabIndex = 35;
			labelPositionUsing.Text = "Pos. utilization";
			// 
			// labelPositionUsingPercent
			// 
			labelPositionUsingPercent.AutoSize = true;
			labelPositionUsingPercent.Location = new Point(12, 176);
			labelPositionUsingPercent.Name = "labelPositionUsingPercent";
			labelPositionUsingPercent.Size = new Size(52, 30);
			labelPositionUsingPercent.TabIndex = 36;
			labelPositionUsingPercent.Text = "50%";
			// 
			// timerRefreshTexts
			// 
			timerRefreshTexts.Interval = 2000;
			timerRefreshTexts.Tick += timerRefreshTexts_Tick;
			// 
			// buttonBuy100
			// 
			buttonBuy100.Location = new Point(12, 466);
			buttonBuy100.Name = "buttonBuy100";
			buttonBuy100.Size = new Size(201, 72);
			buttonBuy100.TabIndex = 37;
			buttonBuy100.Text = "Buy 100%";
			buttonBuy100.UseVisualStyleBackColor = true;
			buttonBuy100.Click += buttonBuy100_Click;
			// 
			// buttonBuy60
			// 
			buttonBuy60.Location = new Point(12, 544);
			buttonBuy60.Name = "buttonBuy60";
			buttonBuy60.Size = new Size(201, 72);
			buttonBuy60.TabIndex = 38;
			buttonBuy60.Text = "Buy 60%";
			buttonBuy60.UseVisualStyleBackColor = true;
			buttonBuy60.Click += buttonBuy60_Click;
			// 
			// buttonBuy30
			// 
			buttonBuy30.Location = new Point(12, 622);
			buttonBuy30.Name = "buttonBuy30";
			buttonBuy30.Size = new Size(201, 72);
			buttonBuy30.TabIndex = 39;
			buttonBuy30.Text = "Buy 30%";
			buttonBuy30.UseVisualStyleBackColor = true;
			buttonBuy30.Click += buttonBuy30_Click;
			// 
			// buttonBuy10
			// 
			buttonBuy10.Location = new Point(12, 700);
			buttonBuy10.Name = "buttonBuy10";
			buttonBuy10.Size = new Size(201, 72);
			buttonBuy10.TabIndex = 40;
			buttonBuy10.Text = "Buy 10%";
			buttonBuy10.UseVisualStyleBackColor = true;
			buttonBuy10.Click += buttonBuy10_Click;
			// 
			// buttonSell100
			// 
			buttonSell100.Location = new Point(245, 466);
			buttonSell100.Name = "buttonSell100";
			buttonSell100.Size = new Size(201, 72);
			buttonSell100.TabIndex = 41;
			buttonSell100.Text = "Sell 100%";
			buttonSell100.UseVisualStyleBackColor = true;
			buttonSell100.Click += buttonSell100_Click;
			// 
			// buttonSell60
			// 
			buttonSell60.Location = new Point(245, 544);
			buttonSell60.Name = "buttonSell60";
			buttonSell60.Size = new Size(201, 72);
			buttonSell60.TabIndex = 42;
			buttonSell60.Text = "Sell 60%";
			buttonSell60.UseVisualStyleBackColor = true;
			buttonSell60.Click += buttonSell60_Click;
			// 
			// buttonSell30
			// 
			buttonSell30.Location = new Point(245, 622);
			buttonSell30.Name = "buttonSell30";
			buttonSell30.Size = new Size(201, 72);
			buttonSell30.TabIndex = 43;
			buttonSell30.Text = "Sell 30%";
			buttonSell30.UseVisualStyleBackColor = true;
			buttonSell30.Click += buttonSell30_Click;
			// 
			// buttonSell10
			// 
			buttonSell10.Location = new Point(245, 700);
			buttonSell10.Name = "buttonSell10";
			buttonSell10.Size = new Size(201, 72);
			buttonSell10.TabIndex = 44;
			buttonSell10.Text = "Sell 10%";
			buttonSell10.UseVisualStyleBackColor = true;
			buttonSell10.Click += buttonSell10_Click;
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(12F, 30F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(852, 789);
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
	}
}