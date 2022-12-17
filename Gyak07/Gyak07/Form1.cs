using Gyak07.Entities;
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

namespace Gyak07
{
    public partial class Form1 : Form
    {

        private PortfolioEntities context = new PortfolioEntities();
        private List<Tick> ticks;
        private List<PortfolioItem> portfolioItems;

        private List<decimal> orderedProfits;

        public Form1()
        {
            InitializeComponent();
            if (orderedProfits == null) saveBtn.Enabled = false;
            ticks = context.Tick.ToList();
            dataGridView1.DataSource = ticks;
            CreatePortfolio();
            GetProfit();
        }

        private void CreatePortfolio()
        {
            if (portfolioItems == null)
                portfolioItems = new List<PortfolioItem>();

            portfolioItems.Add(new PortfolioItem() { Index = "OTP", Volume = 10 });
            portfolioItems.Add(new PortfolioItem() { Index = "ZWACK", Volume = 10 });
            portfolioItems.Add(new PortfolioItem() { Index = "ELMU", Volume = 10 });

            dataGridView2.DataSource = portfolioItems;

        }

        private void GetProfit()
        {
            List<decimal> profits = new List<decimal>();
            int intervalum = 30;
            DateTime startDate = (from x in ticks select x.TradingDay).Min();
            DateTime endDate = new DateTime(2016, 12, 30);
            TimeSpan z = endDate - startDate;
            for (int i = 0; i < z.Days - intervalum; i++)
            {
                decimal ny = GetPortfolioValue(startDate.AddDays(i + intervalum))
                           - GetPortfolioValue(startDate.AddDays(i));
                profits.Add(ny);
                Console.WriteLine(i + " " + ny);
            }

            orderedProfits = (from x in profits
                                      orderby x
                                      select x)
                                        .ToList();
            
            saveBtn.Enabled = orderedProfits != null && orderedProfits.Count > 0;
            //MessageBox.Show(orderedProfits[orderedProfits.Count() / 5].ToString());
        }

        private decimal GetPortfolioValue(DateTime date)
        {
            decimal value = 0;

            foreach (var item in portfolioItems)
            {
                var last = (from x in ticks
                            where item.Index == x.Index.Trim()
                               && date <= x.TradingDay
                            select x)
                    .First();
                value += (decimal)last.Price * item.Volume;
            }
            return value;
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.InitialDirectory = Application.StartupPath;
            sfd.Filter = "Comma Seperated Values (*.csv)|*.csv";
            sfd.DefaultExt = "csv";
            sfd.AddExtension = true;
            if (sfd.ShowDialog() != DialogResult.OK) return;

            using (StreamWriter sw = new StreamWriter(sfd.FileName, false, Encoding.UTF8))
            {

                sw.WriteLine("Időszak;Nyereség");
                int row = 1;
                foreach (var item in orderedProfits)
                {
                    sw.WriteLine(String.Format("{0};{1}", row, item));
                    row++;
                   
                }
            }
        }
    }
}
