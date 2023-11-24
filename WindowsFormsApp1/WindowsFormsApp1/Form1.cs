using LiveCharts.Wpf;
using LiveCharts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cartesianChart1.Series = new LiveCharts.SeriesCollection()
            {
                new LineSeries
                {
                    Title = "Series 1",
                    Values = new ChartValues<double> { 4, 6, 5, 2 ,4 }
                }
            };
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cartesianChart1.Series = new LiveCharts.SeriesCollection()
            {
                new LineSeries
                {
                    Title = "Series 1",
                    Values = new ChartValues<double> { 15,70,23,5,-2 }
                }
            };
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cartesianChart1.Series = new LiveCharts.SeriesCollection()
            {
                new LineSeries
                {
                    Title = "Series 1",
                    Values = new ChartValues<double> {2,3,4,5,6,7 }
                }
            };
        }

        private void cartesianChart1_DataClick(object sender, ChartPoint chartPoint)
        {
            label1.Text = "X: " + chartPoint.X.ToString() + " Y:" + chartPoint.Y.ToString();
        }
    }
}
