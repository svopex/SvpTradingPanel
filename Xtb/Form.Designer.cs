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
			labelSymbol = new Label();
			textBoxSymbol = new TextBox();
			labelSlDistance = new Label();
			textBoxSlDistance = new TextBox();
			buttonBuy = new Button();
			buttonSell = new Button();
			labelLimitPrice = new Label();
			textBoxLimitPrice = new TextBox();
			buttonCalculate = new Button();
			labelRRR = new Label();
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
			// buttonBuy
			// 
			buttonBuy.Location = new Point(12, 171);
			buttonBuy.Name = "buttonBuy";
			buttonBuy.Size = new Size(201, 109);
			buttonBuy.TabIndex = 4;
			buttonBuy.Text = "Buy";
			buttonBuy.UseVisualStyleBackColor = true;
			buttonBuy.Click += buttonBuy_Click;
			// 
			// buttonSell
			// 
			buttonSell.Location = new Point(219, 171);
			buttonSell.Name = "buttonSell";
			buttonSell.Size = new Size(201, 109);
			buttonSell.TabIndex = 5;
			buttonSell.Text = "Sell";
			buttonSell.UseVisualStyleBackColor = true;
			buttonSell.Click += buttonSell_Click;
			// 
			// labelLimitPrice
			// 
			labelLimitPrice.AutoSize = true;
			labelLimitPrice.Location = new Point(12, 93);
			labelLimitPrice.Name = "labelLimitPrice";
			labelLimitPrice.Size = new Size(109, 30);
			labelLimitPrice.TabIndex = 6;
			labelLimitPrice.Text = "Limit price";
			// 
			// textBoxLimitPrice
			// 
			textBoxLimitPrice.Location = new Point(135, 93);
			textBoxLimitPrice.Name = "textBoxLimitPrice";
			textBoxLimitPrice.Size = new Size(175, 35);
			textBoxLimitPrice.TabIndex = 7;
			// 
			// buttonCalculate
			// 
			buttonCalculate.Location = new Point(624, 171);
			buttonCalculate.Name = "buttonCalculate";
			buttonCalculate.Size = new Size(201, 109);
			buttonCalculate.TabIndex = 8;
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
			labelRRR.TabIndex = 9;
			labelRRR.Text = "RRR: -";
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(12F, 30F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(837, 367);
			Controls.Add(labelRRR);
			Controls.Add(buttonCalculate);
			Controls.Add(textBoxLimitPrice);
			Controls.Add(labelLimitPrice);
			Controls.Add(buttonSell);
			Controls.Add(buttonBuy);
			Controls.Add(textBoxSlDistance);
			Controls.Add(labelSlDistance);
			Controls.Add(textBoxSymbol);
			Controls.Add(labelSymbol);
			Name = "Form1";
			Text = "XTB";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label labelSymbol;
		private TextBox textBoxSymbol;
		private Label labelSlDistance;
		private TextBox textBoxSlDistance;
		private Button buttonBuy;
		private Button buttonSell;
		private Label labelLimitPrice;
		private TextBox textBoxLimitPrice;
		private Button buttonCalculate;
		private Label labelRRR;
	}
}