namespace WindowsFormsApplication1
{
    partial class Form1
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.errorDataDone = new System.Windows.Forms.TextBox();
            this.testDataDone = new System.Windows.Forms.TextBox();
            this.TestDataButton = new System.Windows.Forms.Button();
            this.ErrorReportButton = new System.Windows.Forms.Button();
            this.TestDataBox = new System.Windows.Forms.TextBox();
            this.ErrorReportBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.Trades = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.GeneticAlgorithmOptions = new System.Windows.Forms.Button();
            this.RunGAButton = new System.Windows.Forms.Button();
            this.GeneticAlgorithm = new System.Windows.Forms.Button();
            this.StopGA = new System.Windows.Forms.Button();
            this.timeRange = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.MutationRate = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.ChromosomeSize = new System.Windows.Forms.NumericUpDown();
            this.Chromosomes = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.NoGenerations = new System.Windows.Forms.NumericUpDown();
            this.NoIterations = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.backgroundWorkerRunGA = new System.ComponentModel.BackgroundWorker();
            this.ThreadCheck = new System.Windows.Forms.Timer(this.components);
            this.ShowTrades = new System.Windows.Forms.Button();
            this.ShowGenerations = new System.Windows.Forms.CheckBox();
            this.SaveModel = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.FlightBox = new System.Windows.Forms.TextBox();
            this.LoadBox = new System.Windows.Forms.TextBox();
            this.LoadModel = new System.Windows.Forms.Button();
            this.FlightData = new System.Windows.Forms.Button();
            this.ResultsBox = new System.Windows.Forms.TextBox();
            this.Analyze = new System.Windows.Forms.Button();
            this.ThresholdValue = new System.Windows.Forms.NumericUpDown();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MutationRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChromosomeSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Chromosomes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NoGenerations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NoIterations)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ThresholdValue)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(935, 444);
            this.tabControl1.TabIndex = 11;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Transparent;
            this.tabPage1.Controls.Add(this.errorDataDone);
            this.tabPage1.Controls.Add(this.testDataDone);
            this.tabPage1.Controls.Add(this.TestDataButton);
            this.tabPage1.Controls.Add(this.ErrorReportButton);
            this.tabPage1.Controls.Add(this.TestDataBox);
            this.tabPage1.Controls.Add(this.ErrorReportBox);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(927, 418);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "File Upload";
            // 
            // errorDataDone
            // 
            this.errorDataDone.Location = new System.Drawing.Point(369, 157);
            this.errorDataDone.Name = "errorDataDone";
            this.errorDataDone.ReadOnly = true;
            this.errorDataDone.Size = new System.Drawing.Size(135, 20);
            this.errorDataDone.TabIndex = 13;
            this.errorDataDone.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // testDataDone
            // 
            this.testDataDone.Location = new System.Drawing.Point(369, 43);
            this.testDataDone.Name = "testDataDone";
            this.testDataDone.ReadOnly = true;
            this.testDataDone.Size = new System.Drawing.Size(135, 20);
            this.testDataDone.TabIndex = 12;
            this.testDataDone.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TestDataButton
            // 
            this.TestDataButton.Location = new System.Drawing.Point(6, 40);
            this.TestDataButton.Name = "TestDataButton";
            this.TestDataButton.Size = new System.Drawing.Size(75, 23);
            this.TestDataButton.TabIndex = 6;
            this.TestDataButton.Text = "Test Data";
            this.TestDataButton.UseVisualStyleBackColor = true;
            this.TestDataButton.Click += new System.EventHandler(this.TestDataButton_Click);
            // 
            // ErrorReportButton
            // 
            this.ErrorReportButton.Location = new System.Drawing.Point(11, 155);
            this.ErrorReportButton.Name = "ErrorReportButton";
            this.ErrorReportButton.Size = new System.Drawing.Size(75, 23);
            this.ErrorReportButton.TabIndex = 7;
            this.ErrorReportButton.Text = "Error Report";
            this.ErrorReportButton.UseVisualStyleBackColor = true;
            this.ErrorReportButton.Click += new System.EventHandler(this.ErrorReportButton_Click);
            // 
            // TestDataBox
            // 
            this.TestDataBox.Location = new System.Drawing.Point(114, 43);
            this.TestDataBox.Name = "TestDataBox";
            this.TestDataBox.ReadOnly = true;
            this.TestDataBox.Size = new System.Drawing.Size(190, 20);
            this.TestDataBox.TabIndex = 8;
            // 
            // ErrorReportBox
            // 
            this.ErrorReportBox.Location = new System.Drawing.Point(119, 157);
            this.ErrorReportBox.Name = "ErrorReportBox";
            this.ErrorReportBox.ReadOnly = true;
            this.ErrorReportBox.Size = new System.Drawing.Size(190, 20);
            this.ErrorReportBox.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Select Flight Data";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Select Error Report";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.ThresholdValue);
            this.tabPage2.Controls.Add(this.SaveModel);
            this.tabPage2.Controls.Add(this.ShowGenerations);
            this.tabPage2.Controls.Add(this.ShowTrades);
            this.tabPage2.Controls.Add(this.NoIterations);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.NoGenerations);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.Chromosomes);
            this.tabPage2.Controls.Add(this.ChromosomeSize);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.MutationRate);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.timeRange);
            this.tabPage2.Controls.Add(this.label18);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.StopGA);
            this.tabPage2.Controls.Add(this.Trades);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.progressBar2);
            this.tabPage2.Controls.Add(this.GeneticAlgorithmOptions);
            this.tabPage2.Controls.Add(this.RunGAButton);
            this.tabPage2.Controls.Add(this.GeneticAlgorithm);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(927, 418);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Genetic Algorithm";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // Trades
            // 
            this.Trades.Location = new System.Drawing.Point(8, 143);
            this.Trades.Name = "Trades";
            this.Trades.Size = new System.Drawing.Size(912, 269);
            this.Trades.TabIndex = 16;
            this.Trades.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(795, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Progress Bar";
            // 
            // progressBar2
            // 
            this.progressBar2.Location = new System.Drawing.Point(752, 49);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(154, 23);
            this.progressBar2.TabIndex = 14;
            // 
            // GeneticAlgorithmOptions
            // 
            this.GeneticAlgorithmOptions.Location = new System.Drawing.Point(584, -34);
            this.GeneticAlgorithmOptions.Name = "GeneticAlgorithmOptions";
            this.GeneticAlgorithmOptions.Size = new System.Drawing.Size(154, 23);
            this.GeneticAlgorithmOptions.TabIndex = 12;
            this.GeneticAlgorithmOptions.Text = "Genetic Algorithm Options";
            this.GeneticAlgorithmOptions.UseVisualStyleBackColor = true;
            // 
            // RunGAButton
            // 
            this.RunGAButton.Location = new System.Drawing.Point(752, 20);
            this.RunGAButton.Name = "RunGAButton";
            this.RunGAButton.Size = new System.Drawing.Size(154, 23);
            this.RunGAButton.TabIndex = 12;
            this.RunGAButton.Text = "Run Genetic Algorithm";
            this.RunGAButton.UseVisualStyleBackColor = true;
            this.RunGAButton.Click += new System.EventHandler(this.RunGAButton_Click);
            // 
            // GeneticAlgorithm
            // 
            this.GeneticAlgorithm.Enabled = false;
            this.GeneticAlgorithm.Location = new System.Drawing.Point(584, -63);
            this.GeneticAlgorithm.Name = "GeneticAlgorithm";
            this.GeneticAlgorithm.Size = new System.Drawing.Size(154, 23);
            this.GeneticAlgorithm.TabIndex = 11;
            this.GeneticAlgorithm.Text = "Run Genetic Algorithm";
            this.GeneticAlgorithm.UseVisualStyleBackColor = true;
            // 
            // StopGA
            // 
            this.StopGA.Enabled = false;
            this.StopGA.Location = new System.Drawing.Point(580, 20);
            this.StopGA.Name = "StopGA";
            this.StopGA.Size = new System.Drawing.Size(154, 23);
            this.StopGA.TabIndex = 17;
            this.StopGA.Text = "Stop GA";
            this.StopGA.UseVisualStyleBackColor = true;
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
            this.timeRange.Location = new System.Drawing.Point(136, 56);
            this.timeRange.Name = "timeRange";
            this.timeRange.Size = new System.Drawing.Size(46, 21);
            this.timeRange.TabIndex = 70;
            this.timeRange.Text = "Sec";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.Location = new System.Drawing.Point(21, 60);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(54, 13);
            this.label18.TabIndex = 73;
            this.label18.Text = "Threshold";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 71;
            this.label3.Text = "Chromosomes";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(21, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 13);
            this.label5.TabIndex = 75;
            this.label5.Text = "Mutation Rate";
            // 
            // MutationRate
            // 
            this.MutationRate.DecimalPlaces = 2;
            this.MutationRate.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.MutationRate.Location = new System.Drawing.Point(100, 94);
            this.MutationRate.Name = "MutationRate";
            this.MutationRate.Size = new System.Drawing.Size(67, 20);
            this.MutationRate.TabIndex = 76;
            this.MutationRate.Value = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(213, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 13);
            this.label6.TabIndex = 77;
            this.label6.Text = "Chromosome size";
            // 
            // ChromosomeSize
            // 
            this.ChromosomeSize.Location = new System.Drawing.Point(309, 19);
            this.ChromosomeSize.Name = "ChromosomeSize";
            this.ChromosomeSize.Size = new System.Drawing.Size(53, 20);
            this.ChromosomeSize.TabIndex = 78;
            this.ChromosomeSize.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // Chromosomes
            // 
            this.Chromosomes.Location = new System.Drawing.Point(100, 18);
            this.Chromosomes.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.Chromosomes.Name = "Chromosomes";
            this.Chromosomes.Size = new System.Drawing.Size(53, 20);
            this.Chromosomes.TabIndex = 79;
            this.Chromosomes.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(213, 60);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 13);
            this.label7.TabIndex = 80;
            this.label7.Text = "# Generations";
            // 
            // NoGenerations
            // 
            this.NoGenerations.Location = new System.Drawing.Point(309, 57);
            this.NoGenerations.Name = "NoGenerations";
            this.NoGenerations.Size = new System.Drawing.Size(53, 20);
            this.NoGenerations.TabIndex = 81;
            this.NoGenerations.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // NoIterations
            // 
            this.NoIterations.Location = new System.Drawing.Point(309, 93);
            this.NoIterations.Name = "NoIterations";
            this.NoIterations.Size = new System.Drawing.Size(53, 20);
            this.NoIterations.TabIndex = 83;
            this.NoIterations.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(213, 96);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 13);
            this.label8.TabIndex = 82;
            this.label8.Text = "# Iterations";
            // 
            // backgroundWorkerRunGA
            // 
            this.backgroundWorkerRunGA.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerRunGA_DoWork);
            this.backgroundWorkerRunGA.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerRunGA_ProgressChanged);
            this.backgroundWorkerRunGA.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerRunGA_RunWorkerCompleted);
            // 
            // ShowTrades
            // 
            this.ShowTrades.Location = new System.Drawing.Point(384, 19);
            this.ShowTrades.Name = "ShowTrades";
            this.ShowTrades.Size = new System.Drawing.Size(113, 23);
            this.ShowTrades.TabIndex = 84;
            this.ShowTrades.Text = "Show Results";
            this.ShowTrades.UseVisualStyleBackColor = true;
            // 
            // ShowGenerations
            // 
            this.ShowGenerations.AutoSize = true;
            this.ShowGenerations.Location = new System.Drawing.Point(384, 60);
            this.ShowGenerations.Name = "ShowGenerations";
            this.ShowGenerations.Size = new System.Drawing.Size(113, 17);
            this.ShowGenerations.TabIndex = 85;
            this.ShowGenerations.Text = "Show Generations";
            this.ShowGenerations.UseVisualStyleBackColor = true;
            // 
            // SaveModel
            // 
            this.SaveModel.Location = new System.Drawing.Point(772, 114);
            this.SaveModel.Name = "SaveModel";
            this.SaveModel.Size = new System.Drawing.Size(113, 23);
            this.SaveModel.TabIndex = 86;
            this.SaveModel.Text = "Save Results";
            this.SaveModel.UseVisualStyleBackColor = true;
            this.SaveModel.Click += new System.EventHandler(this.SaveModels_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.Analyze);
            this.tabPage3.Controls.Add(this.ResultsBox);
            this.tabPage3.Controls.Add(this.FlightBox);
            this.tabPage3.Controls.Add(this.LoadBox);
            this.tabPage3.Controls.Add(this.LoadModel);
            this.tabPage3.Controls.Add(this.FlightData);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(927, 418);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Analysis";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // FlightBox
            // 
            this.FlightBox.Location = new System.Drawing.Point(117, 67);
            this.FlightBox.Name = "FlightBox";
            this.FlightBox.ReadOnly = true;
            this.FlightBox.Size = new System.Drawing.Size(135, 20);
            this.FlightBox.TabIndex = 20;
            this.FlightBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // LoadBox
            // 
            this.LoadBox.Location = new System.Drawing.Point(117, 18);
            this.LoadBox.Name = "LoadBox";
            this.LoadBox.ReadOnly = true;
            this.LoadBox.Size = new System.Drawing.Size(135, 20);
            this.LoadBox.TabIndex = 19;
            this.LoadBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // LoadModel
            // 
            this.LoadModel.Location = new System.Drawing.Point(17, 15);
            this.LoadModel.Name = "LoadModel";
            this.LoadModel.Size = new System.Drawing.Size(75, 23);
            this.LoadModel.TabIndex = 14;
            this.LoadModel.Text = "Load Model";
            this.LoadModel.UseVisualStyleBackColor = true;
            this.LoadModel.Click += new System.EventHandler(this.LoadModel_Click);
            // 
            // FlightData
            // 
            this.FlightData.Location = new System.Drawing.Point(17, 64);
            this.FlightData.Name = "FlightData";
            this.FlightData.Size = new System.Drawing.Size(75, 23);
            this.FlightData.TabIndex = 15;
            this.FlightData.Text = "Flight Data";
            this.FlightData.UseVisualStyleBackColor = true;
            this.FlightData.Click += new System.EventHandler(this.FlightData_Click);
            // 
            // ResultsBox
            // 
            this.ResultsBox.Location = new System.Drawing.Point(356, 37);
            this.ResultsBox.Multiline = true;
            this.ResultsBox.Name = "ResultsBox";
            this.ResultsBox.ReadOnly = true;
            this.ResultsBox.Size = new System.Drawing.Size(527, 371);
            this.ResultsBox.TabIndex = 21;
            // 
            // Analyze
            // 
            this.Analyze.Location = new System.Drawing.Point(17, 138);
            this.Analyze.Name = "Analyze";
            this.Analyze.Size = new System.Drawing.Size(75, 23);
            this.Analyze.TabIndex = 22;
            this.Analyze.Text = "Analyze";
            this.Analyze.UseVisualStyleBackColor = true;
            this.Analyze.Click += new System.EventHandler(this.Analyze_Click);
            // 
            // ThresholdValue
            // 
            this.ThresholdValue.Location = new System.Drawing.Point(81, 56);
            this.ThresholdValue.Name = "ThresholdValue";
            this.ThresholdValue.Size = new System.Drawing.Size(49, 20);
            this.ThresholdValue.TabIndex = 87;
            this.ThresholdValue.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(936, 442);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Trend Finder 2015";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MutationRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChromosomeSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Chromosomes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NoGenerations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NoIterations)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ThresholdValue)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button TestDataButton;
        private System.Windows.Forms.Button ErrorReportButton;
        private System.Windows.Forms.TextBox TestDataBox;
        private System.Windows.Forms.TextBox ErrorReportBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.RichTextBox Trades;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ProgressBar progressBar2;
        private System.Windows.Forms.Button GeneticAlgorithmOptions;
        private System.Windows.Forms.Button RunGAButton;
        private System.Windows.Forms.Button GeneticAlgorithm;
        private System.Windows.Forms.TextBox testDataDone;
        private System.Windows.Forms.TextBox errorDataDone;
        private System.Windows.Forms.Button StopGA;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox timeRange;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown MutationRate;
        private System.Windows.Forms.NumericUpDown ChromosomeSize;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown Chromosomes;
        private System.Windows.Forms.NumericUpDown NoIterations;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown NoGenerations;
        private System.Windows.Forms.Label label7;
        private System.ComponentModel.BackgroundWorker backgroundWorkerRunGA;
        private System.Windows.Forms.Timer ThreadCheck;
        private System.Windows.Forms.Button ShowTrades;
        private System.Windows.Forms.CheckBox ShowGenerations;
        private System.Windows.Forms.Button SaveModel;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox FlightBox;
        private System.Windows.Forms.TextBox LoadBox;
        private System.Windows.Forms.Button LoadModel;
        private System.Windows.Forms.Button FlightData;
        private System.Windows.Forms.TextBox ResultsBox;
        private System.Windows.Forms.Button Analyze;
        private System.Windows.Forms.NumericUpDown ThresholdValue;

    }
}

