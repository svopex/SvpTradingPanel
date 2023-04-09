namespace Wtrs
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form));
			this.labelAtr = new System.Windows.Forms.Label();
			this.timer = new System.Windows.Forms.Timer(this.components);
			this.labelConnected = new System.Windows.Forms.Label();
			this.buttonBuy = new System.Windows.Forms.Button();
			this.buttonSell = new System.Windows.Forms.Button();
			this.buttonCloseAll = new System.Windows.Forms.Button();
			this.labelProfit = new System.Windows.Forms.Label();
			this.labelLoss = new System.Windows.Forms.Label();
			this.labelRrr = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// labelAtr
			// 
			this.labelAtr.AutoSize = true;
			this.labelAtr.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labelAtr.Location = new System.Drawing.Point(12, 54);
			this.labelAtr.Name = "labelAtr";
			this.labelAtr.Size = new System.Drawing.Size(81, 30);
			this.labelAtr.TabIndex = 0;
			this.labelAtr.Text = "label1";
			// 
			// timer
			// 
			this.timer.Enabled = true;
			this.timer.Interval = 1000;
			this.timer.Tick += new System.EventHandler(this.timer_Tick);
			// 
			// labelConnected
			// 
			this.labelConnected.AutoSize = true;
			this.labelConnected.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labelConnected.Location = new System.Drawing.Point(607, 9);
			this.labelConnected.Name = "labelConnected";
			this.labelConnected.Size = new System.Drawing.Size(204, 30);
			this.labelConnected.TabIndex = 1;
			this.labelConnected.Text = "labelConnected";
			// 
			// buttonBuy
			// 
			this.buttonBuy.Location = new System.Drawing.Point(50, 117);
			this.buttonBuy.Name = "buttonBuy";
			this.buttonBuy.Size = new System.Drawing.Size(312, 121);
			this.buttonBuy.TabIndex = 2;
			this.buttonBuy.Text = "Buy";
			this.buttonBuy.UseVisualStyleBackColor = true;
			this.buttonBuy.Click += new System.EventHandler(this.buttonBuy_Click);
			// 
			// buttonSell
			// 
			this.buttonSell.Location = new System.Drawing.Point(396, 117);
			this.buttonSell.Name = "buttonSell";
			this.buttonSell.Size = new System.Drawing.Size(312, 121);
			this.buttonSell.TabIndex = 3;
			this.buttonSell.Text = "Sell";
			this.buttonSell.UseVisualStyleBackColor = true;
			this.buttonSell.Click += new System.EventHandler(this.buttonSell_Click);
			// 
			// buttonCloseAll
			// 
			this.buttonCloseAll.Location = new System.Drawing.Point(50, 266);
			this.buttonCloseAll.Name = "buttonCloseAll";
			this.buttonCloseAll.Size = new System.Drawing.Size(658, 121);
			this.buttonCloseAll.TabIndex = 4;
			this.buttonCloseAll.Text = "Close all";
			this.buttonCloseAll.UseVisualStyleBackColor = true;
			this.buttonCloseAll.Click += new System.EventHandler(this.buttonCloseAll_Click);
			// 
			// labelProfit
			// 
			this.labelProfit.AutoSize = true;
			this.labelProfit.Location = new System.Drawing.Point(416, 9);
			this.labelProfit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelProfit.Name = "labelProfit";
			this.labelProfit.Size = new System.Drawing.Size(56, 25);
			this.labelProfit.TabIndex = 38;
			this.labelProfit.Text = "Profit";
			// 
			// labelLoss
			// 
			this.labelLoss.AutoSize = true;
			this.labelLoss.Location = new System.Drawing.Point(204, 9);
			this.labelLoss.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelLoss.Name = "labelLoss";
			this.labelLoss.Size = new System.Drawing.Size(54, 25);
			this.labelLoss.TabIndex = 37;
			this.labelLoss.Text = "Loss";
			// 
			// labelRrr
			// 
			this.labelRrr.AutoSize = true;
			this.labelRrr.Location = new System.Drawing.Point(12, 9);
			this.labelRrr.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelRrr.Name = "labelRrr";
			this.labelRrr.Size = new System.Drawing.Size(51, 25);
			this.labelRrr.TabIndex = 36;
			this.labelRrr.Text = "RRR";
			// 
			// Form
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(763, 416);
			this.Controls.Add(this.labelProfit);
			this.Controls.Add(this.labelLoss);
			this.Controls.Add(this.labelRrr);
			this.Controls.Add(this.buttonCloseAll);
			this.Controls.Add(this.buttonSell);
			this.Controls.Add(this.buttonBuy);
			this.Controls.Add(this.labelConnected);
			this.Controls.Add(this.labelAtr);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Form";
			this.Text = "WTRS";
			this.Load += new System.EventHandler(this.Form_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label labelAtr;
		private System.Windows.Forms.Timer timer;
		private System.Windows.Forms.Label labelConnected;
		private System.Windows.Forms.Button buttonBuy;
		private System.Windows.Forms.Button buttonSell;
		private System.Windows.Forms.Button buttonCloseAll;
		private System.Windows.Forms.Label labelProfit;
		private System.Windows.Forms.Label labelLoss;
		private System.Windows.Forms.Label labelRrr;
	}
}

