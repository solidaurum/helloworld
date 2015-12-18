///
///Copyright 2015 by Ammon Pickett
///Licensed under the MIT License
///


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1.src;
using WindowsFormsApplication1.src.MachineLearner;
using WindowsFormsApplication1.src.Interfaces;
using WindowsFormsApplication1.src.Entities;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        //variables
        private string testDataFilename = null;
        private List<DateTime> errorData = new List<DateTime>();
        private TestData testData;
        private Dictionary<DateTime, Dictionary<string, double>> TDD;
        private TradeCondition condition;
        BackgroundWorker backgroundWorker;
        /// <summary>
        /// The instance for the genetic algorithm.
        /// </summary>
        private GeneticAlgorithm geneticAlgorithm;

        /// <summary>
        /// The best results from each iteration of the genetic algorithm.
        /// </summary>
        private List<TradeSystemChromosome> bestResults = new List<TradeSystemChromosome>();

        /// <summary>
        /// The seed value for the genetic algorithm.
        /// </summary>
        private TradeSystem geneticAlgorithmSeed;

        /// <summary>
        /// The best from each generation in the latest iteration of the genetic algorithm.
        /// </summary>
        private List<TradeSystemChromosome> generationalBest = new List<TradeSystemChromosome>();
        public Form1()
        {
            InitializeComponent();
        }

        private void TestDataButton_Click(object sender, EventArgs e)
        {
            this.OpenTestData();
            this.testDataDone.Text = "Data Upload Complete";
            this.testDataDone.BackColor = Color.Blue;
        }

        private void ErrorReportButton_Click(object sender, EventArgs e)
        {
            this.openErrorData();
        }

        private void OpenTestData()
        {
            // Clear the DataGrid and Error Console before loading any new CSV file
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = ".";
                openFileDialog.Filter = "CSV Files|*.csv";
                openFileDialog.RestoreDirectory = true;
                //testData = new Dictionary<DateTime, Dictionary<string, double>>();
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    this.testDataFilename = openFileDialog.FileName;
                    if (this.testData != null)
                    {
                        this.testData.CloseFile();
                    }
                    this.testData = new TestData(this.testDataFilename);
                    TDD = testData.getDictionary();

                }
            }
        }

        private void openErrorData()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                Stream myStream = null;
                StreamReader dataWhole;

                String breakup = null;
                openFileDialog.InitialDirectory = ".";
                openFileDialog.Filter = "CSV Files|*.csv";
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if ((myStream = openFileDialog.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            dataWhole = new StreamReader(myStream, System.Text.Encoding.ASCII);
                            dataWhole.ReadLine();
                            while (!dataWhole.EndOfStream)
                            {

                                breakup = dataWhole.ReadLine();
                                if (!breakup.Split(',')[3].StartsWith("R"))
                                {
                                    errorData.Add(ParseDateTime(breakup.Split(',')[1]));
                                }
                            }
                            myStream.Close();
                        }
                    }
                }
                this.errorDataDone.Text = "Data Upload Complete";
                this.errorDataDone.BackColor = Color.Blue;
            }
        }
        public DateTime ParseDateTime(string date)
        {
            String justDate;
            String justTime;
            justDate = date.Split(' ')[0];
            justTime = date.Split(' ')[1];
            int dPointYear;
            int dPointMonth;
            int dPointDay;
            int dPointHour;
            int dPointMinute;
            int dPointSecond;
            if (date.Length != null)
            {
                dPointYear = Int32.Parse(justDate.Split('-')[0]);
                dPointMonth = Int32.Parse(justDate.Split('-')[1]);
                dPointDay = Int32.Parse(justDate.Split('-')[2]);
                dPointHour = Int32.Parse(justTime.Split(':')[0]);
                dPointMinute = Int32.Parse(justTime.Split(':')[1]);
                dPointSecond = Int32.Parse(justTime.Split(':')[2]);


            }
            else
            {
                dPointMonth = 0;
                dPointDay = 0;
                dPointYear = 0;
                dPointHour = 0;
                dPointMinute = 0;
                dPointSecond = 0;

            }



            if (dPointYear != 0)
            {
                return new DateTime(dPointYear, dPointMonth, dPointDay, dPointHour,
                    dPointMinute, dPointSecond);
            }
            return DateTime.MinValue;
        }
        Controls.GASettings GAFinancial = new Controls.GASettings();
        private void GAOptions_MouseClick(object sender, MouseEventArgs e)
        {
            GAFinancial.ShowDialog();
        }

        private void RunGAButton_Click(object sender, EventArgs e)
        {
            this.progressBar2.Value = 0;
            this.bestResults.Clear();
            this.generationalBest.Clear();
            if (TDD != null)
            {
                this.Cursor = Cursors.WaitCursor;
                this.StopGA.Enabled = true;
                //BackgroundWorker BGWkr = new BackgroundWorker();
                //DoWorkEventArgs eve = new DoWorkEventArgs(sender);
                //this.testData.Restart();
                TradeCondition newBCond = new TradeCondition();
                IndicatorHelper list = new IndicatorHelper(this.testData.IndicatorLocations.Keys.ToArray<string>());
                IGeneticMutating mutant = new TradeConditionMutation((double)this.MutationRate.Value, list);
                TradeSystem newSys = new TradeSystem(newBCond);
                TradeSystemChromosome newchromosome = new TradeSystemChromosome(newSys, list, (int)this.ChromosomeSize.Value);
                IGeneticBreeding newBreed = new RandomMultipleSplitBreeding();
                FitnessTest fitTest = new FitnessTest((int)ThresholdValue.Value, (string)timeRange.SelectedValue);
                IGeneticFitness newFitness = new BacktestFitness(this.testData, TDD, errorData, fitTest);
                this.geneticAlgorithm = new GeneticAlgorithm((int)this.Chromosomes.Value, (int)this.NoGenerations.Value, (int)this.ChromosomeSize.Value, newSys, list, newBreed, mutant, newFitness);
                this.backgroundWorkerRunGA.RunWorkerAsync(this.geneticAlgorithm);
                
            }
        }

        /// <summary>
        /// Event handler for the genetic algorithm's thread's progress changed event. 
        /// Updates the progress bar, adds generational best and shows results.
        /// </summary>
        /// <param name="sender">Genetic algortighm's progress changed event.</param>
        /// <param name="e">The best chromosome from the last iteration.</param>
        private void backgroundWorkerRunGA_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.progressBar2.Value = e.ProgressPercentage;
            this.progressBar2.Update();
            this.ShowResults();
        }

        /// <summary>
        /// The starting point for the genetic algorithm's background worker.
        /// </summary>
        /// <param name="sender">BackgroundWorker do work event.</param>
        /// <param name="e">Genetic algorithm to run.</param>
        private void backgroundWorkerRunGA_DoWork(object sender, DoWorkEventArgs e)
        {

            GeneticAlgorithm geneticAlgorithm = (GeneticAlgorithm)e.Argument;
            BackgroundWorker worker = sender as BackgroundWorker;
            int incrementsize = (int)100 / ((int)this.NoGenerations.Value * (int)this.NoIterations.Value);
            int progressbar = 0;
            for (int i = 0; i < this.NoIterations.Value; i++)
            {
                this.generationalBest.Clear();

                for (int j = 0; j < (int)this.NoGenerations.Value; j++)
                {
                    if (worker.CancellationPending)
                    {
                        e.Cancel = true;
                        break;
                    }
                    geneticAlgorithm.Run(worker, e);
                    this.generationalBest.Add(geneticAlgorithm.BestChromosome.Clone());
                    progressbar += incrementsize;
                    //this.backgroundWorkerRunGA.ReportProgress(progressbar);
                }
                TradeSystemChromosome bestChromosome;
                bestChromosome = DeepCopy.getDeepCopy(geneticAlgorithm.BestChromosome);
                this.bestResults.Add(DeepCopy.getDeepCopy(bestChromosome));
                TradeSystemChromosome chromosome;
                chromosome = this.bestResults.OrderByDescending(x => x.Fitness).First();
                TradeSystem bestTradeSystem = chromosome.ChromosomeValue;
                string tempPath = System.IO.Path.GetTempPath();
                tempPath += "tempTradeSystem.xml";
                StreamWriter sw = new StreamWriter(new FileStream(tempPath, FileMode.Create));
                sw.Write(SerializeHelper.SerializeObject(bestTradeSystem, bestTradeSystem.GetType()));
                sw.Close();
            }
        }

        /// <summary>
        /// Work completed event for the genetic algorithm's thread.
        /// </summary>
        /// <param name="sender">The genetic algorithm's work completed event.</param>
        /// <param name="e">Event arguments.</param>
        private void backgroundWorkerRunGA_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.RunGAButton.Enabled = true;
            this.StopGA.Enabled = false;
            this.ThreadCheck.Enabled = false;
            this.ShowTrades.Enabled = true;
            this.ShowResults();
            this.Cursor = Cursors.Default;
            if (!e.Cancelled)
            {
                if (e.Error != null)
                {
                    MessageBox.Show(e.Error.Message);
                }
                else
                {
                    this.progressBar2.Value = 100;
                    MessageBox.Show("All iterations complete.");
                }
            }
        }
        private void ShowResults()
        {
            this.Trades.Text = string.Empty;

            if (this.ShowGenerations.Checked)
            {
                for (int i = 0; i < this.generationalBest.Count; i++)
                {
                    this.Trades.Text += "Generation " + (i + 1).ToString() + " best: " + this.generationalBest[i].FitnessStats + "\n";
                }
            }
            else if (this.generationalBest.Count > 0)
            {
                this.Trades.Text += "Current best generation: " + this.geneticAlgorithm.BestChromosome.FitnessStats;
            }

            for (int i = 0; i < this.bestResults.Count; i++)
            {
                this.Trades.Text += "\nIteration: " + (i + 1).ToString() + "\n" + this.bestResults[i].FitnessStats;
            }
        }

        private void SaveModels_Click(object sender, EventArgs e)
        {
            if (this.bestResults.Count == 0)
            {
                MessageBox.Show("No model to save");
                return;
            }
            using (SaveFileDialog saveFileDialog1 = new SaveFileDialog())
            {
                saveFileDialog1.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
                saveFileDialog1.FilterIndex = 1;
                saveFileDialog1.RestoreDirectory = true;
                saveFileDialog1.Title = "Save Buy Conditions";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {

                    System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(TradeCondition));
                    System.IO.StreamWriter fs = new System.IO.StreamWriter(@saveFileDialog1.FileName);
                    writer.Serialize(fs, bestResults[0].ChromosomeValue.BuyCondition); //this.bestResults.OrderByDescending(x => x.Fitness).First().ChromosomeValue.BuyCondition);
                    //fs.Write(fs);
                    fs.Close();
                }
            }

        }

        private void FlightData_Click(object sender, EventArgs e)
        {
            this.OpenTestData();
            this.FlightBox.Text = "Data Upload Complete";
            this.FlightBox.BackColor = Color.Blue;
        }

        private void LoadModel_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.InitialDirectory = ".";
                    openFileDialog.Filter = "XML Files|*.xml";
                    openFileDialog.RestoreDirectory = true;
                    openFileDialog.Title = "Load Buy Conditions";
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        Stream newStream;

                        if ((newStream = openFileDialog.OpenFile()) != null)
                        {
                            System.Xml.Serialization.XmlSerializer reader = new System.Xml.Serialization.XmlSerializer(typeof(TradeCondition));
                            System.IO.StreamReader file = new System.IO.StreamReader(@openFileDialog.FileName);
                            condition = new TradeCondition();
                            condition = (TradeCondition)reader.Deserialize(file);
                            //BuyConditionControl.SetControlsToCondition(condition);
                        }
                        newStream.Close();
                    }
                }
            }


            catch
            {
                MessageBox.Show("Trade Conditions have not been saved yet");
            }

            this.LoadBox.Text = "Data Upload Complete";
            this.LoadBox.BackColor = Color.Blue;
        }

        private void Analyze_Click(object sender, EventArgs e)
        {
            TradeSystem analyze = new TradeSystem(condition);
            TradeHelper newAnalysis = new TradeHelper(analyze);
            newAnalysis.RunBacktest(testData, TDD);
            List<DateTime> results = newAnalysis.occuranceCount;
            for (int i = 0; i < results.Count; i++)
            {
                this.ResultsBox.AppendText(results[i].ToString()+"\n");
            }
        }
    }
}
