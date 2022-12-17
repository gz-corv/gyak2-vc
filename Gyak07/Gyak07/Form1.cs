using Gyak07.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        public Form1()
        {
            InitializeComponent();

            ticks = context.Tick.ToList();
            dataGridView1.DataSource = ticks;
            CreatePortfolio();
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
    }
}
