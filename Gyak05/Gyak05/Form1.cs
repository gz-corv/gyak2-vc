using Gyak05.Entities;
using Gyak05.MnbServiceReference;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml;

namespace Gyak05
{
    public partial class Form1 : Form
    {

        private BindingList<RateData> rates = new BindingList<RateData>();
       
        
        public Form1()
        {
            InitializeComponent();

            dataGridView1.DataSource = rates;

            DisplayData();
        }

        private string FetchExchangeResults()
        {
            var mnbService = new MNBArfolyamServiceSoapClient();
            var request = new GetExchangeRatesRequestBody()
            {
                currencyNames = "EUR",
                startDate = "2020-01-01",
                endDate = "2020-06-30"
            };

            var response = mnbService.GetExchangeRates(request);

            return response.GetExchangeRatesResult;
        }


        private void ReadXml() 
        {
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(FetchExchangeResults());
            foreach (XmlElement element in xml.DocumentElement)
            {
                RateData rateData = new RateData();
                rates.Add(rateData);
                rateData.Currency = element.ChildNodes[0].Attributes["curr"].Value;
                rateData.Date = Convert.ToDateTime(element.Attributes["date"].Value);
                decimal unit = Convert.ToDecimal(element.ChildNodes[0].Attributes["unit"].Value);
                decimal value = Convert.ToDecimal(element.ChildNodes[0].InnerText);
                if (unit != 0)
                {
                    rateData.Value = value / unit;
                }
                else
                {
                    rateData.Value = value;
                }
            }


        }


        private void DisplayData()
        {
            rates.Clear();

            ReadXml();

            chartRateData.DataSource = rates;
            chartRateData.Series[0].ChartType = SeriesChartType.Line;
            chartRateData.Series[0].XValueMember = "date";
            chartRateData.Series[0].YValueMembers = "value";
            chartRateData.Series[0].BorderWidth = 2;
            chartRateData.Legends[0].Enabled = false;

            chartRateData.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chartRateData.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            chartRateData.ChartAreas[0].AxisY.IsStartedFromZero = false;
        }
    }
}
