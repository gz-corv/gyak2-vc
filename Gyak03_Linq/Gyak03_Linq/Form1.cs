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

namespace Gyak03_Linq
{
    public partial class Form1 : Form
    {

        private List<Country> countries;
        public Form1()
        {
            InitializeComponent();

            LoadData("ramen.csv");
        }

        private void LoadData(String fileName) 
        {
            if (countries == null)
                countries = new List<Country>();
            countries.Clear();

            using (StreamReader sr = new StreamReader(fileName, Encoding.Default))
            {

                sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    string[] line = sr.ReadLine().Split(';');
                    Country item = new Country();

                    String currentName = line[2];
                    var currentCountry = (from c in countries
                                          where c.Name.Equals(currentName)
                                          select c).FirstOrDefault();

                    if (currentCountry == null)
                    {
                        currentCountry = new Country();
                        currentCountry.ID = countries.Count() + 1;
                        currentCountry.Name = currentName;
                        countries.Add(currentCountry);
                    }
                    
                    
                }

            }
        }

    }
}
