namespace Xtb
{
	partial class FormEquity
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
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEquity));
			chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
			labelYear = new Label();
			textBoxYear = new TextBox();
			labelTaxForm = new Label();
			labelIncome = new Label();
			((System.ComponentModel.ISupportInitialize)chart1).BeginInit();
			SuspendLayout();
			// 
			// chart1
			// 
			chart1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			chartArea1.Name = "ChartArea1";
			chart1.ChartAreas.Add(chartArea1);
			legend1.Name = "Legend1";
			chart1.Legends.Add(legend1);
			chart1.Location = new Point(-1, 29);
			chart1.Margin = new Padding(2);
			chart1.Name = "chart1";
			series1.ChartArea = "ChartArea1";
			series1.Legend = "Legend1";
			series1.Name = "Series1";
			chart1.Series.Add(series1);
			chart1.Size = new Size(982, 452);
			chart1.TabIndex = 0;
			chart1.Text = "chart";
			// 
			// labelYear
			// 
			labelYear.AutoSize = true;
			labelYear.Location = new Point(7, 4);
			labelYear.Margin = new Padding(2, 0, 2, 0);
			labelYear.Name = "labelYear";
			labelYear.Size = new Size(29, 15);
			labelYear.TabIndex = 1;
			labelYear.Text = "Year";
			// 
			// textBoxYear
			// 
			textBoxYear.Location = new Point(47, 3);
			textBoxYear.Margin = new Padding(2);
			textBoxYear.Name = "textBoxYear";
			textBoxYear.Size = new Size(104, 23);
			textBoxYear.TabIndex = 2;
			textBoxYear.Leave += textBoxYear_Leave;
			// 
			// labelTaxForm
			// 
			labelTaxForm.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			labelTaxForm.AutoSize = true;
			labelTaxForm.Location = new Point(11, 492);
			labelTaxForm.Margin = new Padding(2, 0, 2, 0);
			labelTaxForm.Name = "labelTaxForm";
			labelTaxForm.Size = new Size(38, 15);
			labelTaxForm.TabIndex = 3;
			labelTaxForm.Text = "label1";
			// 
			// labelIncome
			// 
			labelIncome.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			labelIncome.AutoSize = true;
			labelIncome.Location = new Point(11, 516);
			labelIncome.Margin = new Padding(2, 0, 2, 0);
			labelIncome.Name = "labelIncome";
			labelIncome.Size = new Size(38, 15);
			labelIncome.TabIndex = 4;
			labelIncome.Text = "label1";
			// 
			// FormEquity
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(982, 540);
			Controls.Add(labelIncome);
			Controls.Add(labelTaxForm);
			Controls.Add(textBoxYear);
			Controls.Add(labelYear);
			Controls.Add(chart1);
			Icon = (Icon)resources.GetObject("$this.Icon");
			Margin = new Padding(2);
			Name = "FormEquity";
			Text = "Equity";
			Load += FormEquity_Load;
			((System.ComponentModel.ISupportInitialize)chart1).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
		private Label labelYear;
		private TextBox textBoxYear;
		private Label labelTaxForm;
		private Label labelIncome;
	}
}