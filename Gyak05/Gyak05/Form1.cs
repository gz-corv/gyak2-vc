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

namespace Gyak05
{
    public partial class Form1 : Form
    {

        private BindingList<RateData> rates = new BindingList<RateData>();
       
        
        public Form1()
        {
            InitializeComponent();

            dataGridView1.DataSource = rates;
        }

        private void FetchExchangeResults()
        {
            var mnbService = new MNBArfolyamServiceSoapClient();
            var request = new GetExchangeRatesRequestBody()
            {
                currencyNames = "EUR",
                startDate = "2020-01-01",
                endDate = "2020-06-30"
            };

            var response = mnbService.GetExchangeRates(request);

            var result = response.GetExchangeRatesResult;
        }

    }
}
