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
        public Form1()
        {
            InitializeComponent();

            ticks = context.Tick.ToList();
            dataGridView1.DataSource = ticks;
        }
    }
}
