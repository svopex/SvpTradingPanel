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
			buttonBuy631.Location = new Point(12, 171);
			buttonBuy631.Name = "buttonBuy631";
			buttonBuy631.Size = new Size(201, 72);
			buttonBuy631.TabIndex = 4;
			buttonBuy631.Text = "Buy 60% 30% 10%";
			buttonBuy631.UseVisualStyleBackColor = true;
			buttonBuy631.Click += buttonBuy631_Click;
			// 
			// buttonSell631
			// 
			buttonSell631.Location = new Point(245, 171);
			buttonSell631.Name = "buttonSell631";
			buttonSell631.Size = new Size(201, 72);
			buttonSell631.TabIndex = 5;
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
			// buttonBuy541
			// 
			buttonBuy541.Location = new Point(12, 261);
			buttonBuy541.Name = "buttonBuy541";
			buttonBuy541.Size = new Size(201, 72);
			buttonBuy541.TabIndex = 10;
			buttonBuy541.Text = "Buy 50% 40% 10%";
			buttonBuy541.UseVisualStyleBackColor = true;
			buttonBuy541.Click += buttonBuy541_Click;
			// 
			// buttonSell541
			// 
			buttonSell541.Location = new Point(245, 261);
			buttonSell541.Name = "buttonSell541";
			buttonSell541.Size = new Size(201, 72);
			buttonSell541.TabIndex = 11;
			buttonSell541.Text = "Sell 50% 40% 10%";
			buttonSell541.UseVisualStyleBackColor = true;
			buttonSell541.Click += buttonSell541_Click;
			// 
			// buttonBuy64
			// 
			buttonBuy64.Location = new Point(12, 349);
			buttonBuy64.Name = "buttonBuy64";
			buttonBuy64.Size = new Size(201, 72);
			buttonBuy64.TabIndex = 12;
			buttonBuy64.Text = "Buy 60% 40%";
			buttonBuy64.UseVisualStyleBackColor = true;
			buttonBuy64.Click += buttonBuy64_Click;
			// 
			// buttonSell64
			// 
			buttonSell64.Location = new Point(245, 349);
			buttonSell64.Name = "buttonSell64";
			buttonSell64.Size = new Size(201, 72);
			buttonSell64.TabIndex = 13;
			buttonSell64.Text = "Sell 60% 40%";
			buttonSell64.UseVisualStyleBackColor = true;
			buttonSell64.Click += buttonSell64_Click;
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(12F, 30F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(848, 439);
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
	}
}