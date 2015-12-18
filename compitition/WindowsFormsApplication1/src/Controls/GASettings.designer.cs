namespace WindowsFormsApplication1.Controls
{
    partial class GASettings
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
            this.label1 = new System.Windows.Forms.Label();
            this.GACapital = new System.Windows.Forms.TextBox();
            this.GAEquityPerContract = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.GAFinancialUpdate = new System.Windows.Forms.Button();
            this.timeRange = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chromosomes";
            // 
            // GACapital
            // 
            this.GACapital.Location = new System.Drawing.Point(120, 10);
            this.GACapital.Name = "GACapital";
            this.GACapital.Size = new System.Drawing.Size(54, 20);
            this.GACapital.TabIndex = 1;
            this.GACapital.Text = "1000";
            this.GACapital.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // GAEquityPerContract
            // 
            this.GAEquityPerContract.Location = new System.Drawing.Point(120, 43);
            this.GAEquityPerContract.Name = "GAEquityPerContract";
            this.GAEquityPerContract.Size = new System.Drawing.Size(54, 20);
            this.GAEquityPerContract.TabIndex = 69;
            this.GAEquityPerContract.Text = "5";
            this.GAEquityPerContract.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.Location = new System.Drawing.Point(13, 43);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(54, 13);
            this.label18.TabIndex = 68;
            this.label18.Text = "Threshold";
            // 
            // GAFinancialUpdate
            // 
            this.GAFinancialUpdate.Location = new System.Drawing.Point(201, 186);
            this.GAFinancialUpdate.Name = "GAFinancialUpdate";
            this.GAFinancialUpdate.Size = new System.Drawing.Size(142, 23);
            this.GAFinancialUpdate.TabIndex = 79;
            this.GAFinancialUpdate.Text = "Update Financial Settings";
            this.GAFinancialUpdate.UseVisualStyleBackColor = true;
            this.GAFinancialUpdate.Click += new System.EventHandler(this.GAFinancialUpdate_Click);
            // 
            // timeRange
            // 
            this.timeRange.AllowDrop = true;
            this.timeRange.DisplayMember = "0";
            this.timeRange.FormattingEnabled = true;
            this.timeRange.Items.AddRange(new object[] {
            "Sec",
            "Min",
            "Hr"});
            this.timeRange.Location = new System.Drawing.Point(181, 41);
            this.timeRange.Name = "timeRange";
            this.timeRange.Size = new System.Drawing.Size(66, 21);
            this.timeRange.TabIndex = 0;
            this.timeRange.Text = "Sec";
            // 
            // GASettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 227);
            this.Controls.Add(this.timeRange);
            this.Controls.Add(this.GAFinancialUpdate);
            this.Controls.Add(this.GAEquityPerContract);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.GACapital);
            this.Controls.Add(this.label1);
            this.Name = "GASettings";
            this.Text = "GASettings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox GACapital;
        private System.Windows.Forms.TextBox GAEquityPerContract;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button GAFinancialUpdate;
        private System.Windows.Forms.ComboBox timeRange;
    }
}