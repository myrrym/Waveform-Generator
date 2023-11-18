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

namespace Waveform_Generator
{
    public partial class WaveformGeneratorForm : Form
    {
        Graphics graphic;
        Bitmap bitmap;
        int Width = 1500;
        int Height = 650;
        bool Sampling_F = false;
        bool IsSineWave = true; // Flag to indicate the current wave type

        float freq = 5;
        float amplitude = 250;
        float Time = 0;
        float NoOfCycles = 0;
        float NoOfPoints = 0;
        double Angle_Step = 0;

        int Count = 0;

        List<PointF> CurrentPointList = new List<PointF>();
        List<PointF> CurrentSamplingList = new List<PointF>();

        List<PointF> LastPointList = new List<PointF>();
        List<PointF> LastSamplingList = new List<PointF>();

        private List<PointF> recordedData = new List<PointF>();

        private List<PointF> importedData;

        bool Screen_Full = false;

        private string importedFilePath;

        public WaveformGeneratorForm()
        {
            InitializeComponent();

            bitmap = new Bitmap(Width, Height);
            graphic = Graphics.FromImage(bitmap);

            // define time
            Time = 1000 * (1 / freq);

            // number of total cycles >>> picture box
            NoOfCycles = Width / Time;

            // set number of points per one cycle
            NoOfPoints = 360 / 6;// 4;

            // define angle step
            Angle_Step = 360 / NoOfPoints;

            timer1.Enabled = false;

            int interval = (int)(Time / NoOfPoints);
            if (interval == 0) timer1.Interval = 1;
            else timer1.Interval = interval;

            Count = 0;

            timer1.Enabled = true;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            graphic.Clear(Color.White);

            // draw lines 
            for (int i = 0; i < Height / 50; i++)
            {
                PointF A = new PointF(0, i * 50);
                PointF B = new PointF(Width, i * 50);

                Pen pen = new Pen(Color.Black, 1);

                if (i == 6) pen.Width = 3;

                graphic.DrawLine(pen, A, B);
            }

            // calc T_Points
            int TotalPoints = (int)(NoOfPoints * NoOfCycles);

            // cal X_Step
            float X_Step = Time / NoOfPoints;

            // define angle
            double Angle = 0;

            int shift = 2;

            CurrentPointList.Clear();
            CurrentSamplingList.Clear();

            for (int i = 0; i < Count + shift; i++)
            {
                float Y = 0;

                if (IsSineWave)
                {
                    Y = (float)(amplitude * Math.Sin(Math.PI * Angle / 180));
                }
                else
                {
                    Y = (Angle % 360 < 180) ? amplitude : -amplitude;
                }

                PointF Pi = new PointF(0 + X_Step * i, 300 + (-1 * Y));
                PointF PA = new PointF(0 + X_Step * i, 300);

                recordedData.Add(new PointF(Count * X_Step, Y));

                if (Sampling_F)
                {
                    graphic.DrawLine(new Pen(Color.Blue, 1), PA, Pi);
                }

                Angle += Angle_Step;

                CurrentPointList.Add(Pi);
                CurrentSamplingList.Add(PA);
            }

            if (!Sampling_F)
            {
                if (Screen_Full)
                {
                    PointF[] LArray = LastPointList.ToArray();

                    if ((LArray.Length - (Count + shift)) > 2)
                    {
                        PointF[] NArray = new PointF[LArray.Length - (Count + shift)];
                        Array.Copy(LArray, (Count + shift), NArray, 0, LArray.Length - (Count + shift));
                        graphic.DrawCurve(new Pen(Color.Red, 1), NArray);
                    }
                }

                graphic.DrawCurve(new Pen(Color.Red, 1), CurrentPointList.ToArray());
            }

            Count++;

            if (Count == TotalPoints)
            {
                Count = 0;

                LastPointList.Clear();
                LastSamplingList.Clear();

                LastPointList.AddRange(CurrentPointList);
                LastSamplingList.AddRange(CurrentSamplingList);

                Screen_Full = true;
            }

            pictureBox1.Image = bitmap;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked) Sampling_F = true;
            else Sampling_F = false;
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (Txt1.Text == "") return;
            if (Txt2.Text == "") return;

            freq = Convert.ToInt16(Txt1.Text);
            if (float.TryParse(Txt2.Text, out float newAmplitude))
            {
                amplitude = newAmplitude;
                Txt2.Text = amplitude.ToString();
            }
            else
            {
                MessageBox.Show("Invalid amplitude value.");
                return;
            }

            if (freq == 0) return;
            if (amplitude == 0) return;


            // define time
            Time = 1000 * (1 / freq);

            // number of total cycles >>> picture box
            NoOfCycles = Width / Time;

            // set number of points per one cycle
            NoOfPoints = 360 / 6;// 4;

            // define angle step
            Angle_Step = 360 / NoOfPoints;

            timer1.Enabled = false;

            int interval = (int)(Time / NoOfPoints);
            if (interval == 0) timer1.Interval = 1;
            else timer1.Interval = interval;

            Count = 0;
            Screen_Full = false;

            timer1.Enabled = true;
        }

        private void buttonLoadCSV_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                importedFilePath = openFileDialog.FileName;

                try
                {
                    // Read data from the file
                    string[] lines = File.ReadAllLines(importedFilePath);

                    // Process the data as needed
                    importedData = new List<PointF>();

                    foreach (string line in lines.Skip(1)) // Skip the header
                    {
                        string[] parts = line.Split(',');

                        if (parts.Length == 2 && float.TryParse(parts[0], out float time) && float.TryParse(parts[1], out float amplitude))
                        {
                            importedData.Add(new PointF(time, amplitude));
                        }
                        else
                        {
                            MessageBox.Show($"Invalid data format in the file. Check line: {line}");
                            return;
                        }
                    }

                    if (importedData.Count > 1)
                    {
                        // Display the loaded data
                        DisplayData(importedData);

                        MessageBox.Show("Data loaded and displayed successfully!");
                    }
                    else
                    {
                        MessageBox.Show("Not enough data points in the file.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error reading the file: {ex.Message}");
                }
                finally
                {
                    timer1.Enabled = true;
                }
            }
        }

        private void DisplayData(List<PointF> data)
        {
            // Clear existing data
            recordedData.Clear();

            // Copy the loaded data to recordedData
            recordedData.AddRange(data);

            // Clear the display
            graphic.Clear(Color.White);

            // Calculate the offset to center the waveform vertically
            float yOffset = Height / 2f;

            // Find the maximum amplitude in the loaded data
            float maxAmplitude = Math.Max(Math.Abs(data.Max(p => p.Y)), Math.Abs(data.Min(p => p.Y)));

            // Scale factor to normalize the amplitude of loaded data with the black lines
            float scaleFactor = amplitude / maxAmplitude;

            // Draw the grid lines
            for (int i = 0; i < Height / 50; i++)
            {
                float gridY = yOffset + (i - Height / 100) * 50; // Adjust the calculation here

                PointF A = new PointF(0, gridY);
                PointF B = new PointF(Width, gridY);

                Pen pen = new Pen(Color.Black, 1);

                if (i == 6) pen.Width = 3;

                // Ensure the line stays within the PictureBox bounds
                if (B.Y > Height)
                {
                    B.Y = Height;
                }

                graphic.DrawLine(pen, A, B);
            }

            // Draw the loaded data
            for (int i = 0; i < recordedData.Count - 1; i++)
            {
                PointF currentPoint = recordedData[i];
                PointF nextPoint = recordedData[i + 1];

                // Offset the y-coordinate to center the waveform vertically
                currentPoint.Y = yOffset - currentPoint.Y * scaleFactor;
                nextPoint.Y = yOffset - nextPoint.Y * scaleFactor;

                // Draw the blue waveform
                graphic.DrawLine(new Pen(Color.Blue, 1), currentPoint, nextPoint);
            }

            // Update the display
            pictureBox1.Image = bitmap;
        }



        private void buttonToggleWave_Click(object sender, EventArgs e)
        {
            IsSineWave = !IsSineWave;
        }

        private void buttonExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
            saveFileDialog.FileName = "ExportedWaveData.csv";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                    {
                        // Write header
                        writer.WriteLine("Time,Amplitude");

                        // Calculate time and amplitude for each point based on the current settings
                        for (int i = 0; i < recordedData.Count; i++)
                        {
                            float time = i * (Time / (NoOfPoints * NoOfCycles));
                            float y = IsSineWave
                                ? (float)(amplitude * Math.Sin(Math.PI * (i * Angle_Step) / 180))
                                : (i * Angle_Step % 360 < 180) ? amplitude : -amplitude;

                            writer.WriteLine($"{time},{y}");
                        }

                        MessageBox.Show("Data exported to CSV successfully!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error exporting data to CSV: {ex.Message}");
                }
            }
        }
    }
}
