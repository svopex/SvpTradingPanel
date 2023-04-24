namespace SvpTradingGraph
{
	partial class Form
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form));
			this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.labelIncome = new System.Windows.Forms.Label();
			this.labelTaxForm = new System.Windows.Forms.Label();
			this.labelYear = new System.Windows.Forms.Label();
			this.textBoxYear = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
			this.SuspendLayout();
			// 
			// chart1
			// 
			this.chart1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			chartArea1.Name = "ChartArea1";
			this.chart1.ChartAreas.Add(chartArea1);
			legend1.Name = "Legend1";
			this.chart1.Legends.Add(legend1);
			this.chart1.Location = new System.Drawing.Point(0, 38);
			this.chart1.Margin = new System.Windows.Forms.Padding(6);
			this.chart1.Name = "chart1";
			series1.ChartArea = "ChartArea1";
			series1.Legend = "Legend1";
			series1.Name = "Series1";
			this.chart1.Series.Add(series1);
			this.chart1.Size = new System.Drawing.Size(1639, 916);
			this.chart1.TabIndex = 0;
			this.chart1.Text = "chart1";
			// 
			// labelIncome
			// 
			this.labelIncome.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.labelIncome.AutoSize = true;
			this.labelIncome.Location = new System.Drawing.Point(22, 974);
			this.labelIncome.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
			this.labelIncome.Name = "labelIncome";
			this.labelIncome.Size = new System.Drawing.Size(60, 24);
			this.labelIncome.TabIndex = 1;
			this.labelIncome.Text = "label1";
			// 
			// labelTaxForm
			// 
			this.labelTaxForm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.labelTaxForm.AutoSize = true;
			this.labelTaxForm.Location = new System.Drawing.Point(22, 1020);
			this.labelTaxForm.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
			this.labelTaxForm.Name = "labelTaxForm";
			this.labelTaxForm.Size = new System.Drawing.Size(60, 24);
			this.labelTaxForm.TabIndex = 2;
			this.labelTaxForm.Text = "label1";
			// 
			// labelYear
			// 
			this.labelYear.AutoSize = true;
			this.labelYear.Location = new System.Drawing.Point(-4, 0);
			this.labelYear.Name = "labelYear";
			this.labelYear.Size = new System.Drawing.Size(49, 24);
			this.labelYear.TabIndex = 3;
			this.labelYear.Text = "Year";
			// 
			// textBoxYear
			// 
			this.textBoxYear.Location = new System.Drawing.Point(51, 0);
			this.textBoxYear.Name = "textBoxYear";
			this.textBoxYear.Size = new System.Drawing.Size(100, 29);
			this.textBoxYear.TabIndex = 4;
			this.textBoxYear.Leave += new System.EventHandler(this.textBoxYear_Leave);
			// 
			// Form
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1644, 1061);
			this.Controls.Add(this.textBoxYear);
			this.Controls.Add(this.labelYear);
			this.Controls.Add(this.labelTaxForm);
			this.Controls.Add(this.labelIncome);
			this.Controls.Add(this.chart1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(6);
			this.Name = "Form";
			this.Text = "Equity";
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
		private System.Windows.Forms.Label labelIncome;
		private System.Windows.Forms.Label labelTaxForm;
		private System.Windows.Forms.Label labelYear;
		private System.Windows.Forms.TextBox textBoxYear;
	}
}

