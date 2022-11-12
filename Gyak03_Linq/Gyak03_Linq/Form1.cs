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
        private List<Ramen> ramens;
        public Form1()
        {
            InitializeComponent();

            LoadData("ramen.csv");
            Console.WriteLine("end of load");
        }

        private void LoadData(String fileName) 
        {
            if (countries == null)
                countries = new List<Country>();
            countries.Clear();

            if (ramens == null)
                ramens = new List<Ramen>();
            ramens.Clear();


            using (StreamReader sr = new StreamReader(fileName, Encoding.Default))
            {

                sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    string[] line = sr.ReadLine().Split(';');
                    

                    String currentName = line[2];

                    var country = AddCountry(currentName);

                    var ramen = new Ramen()
                    {
                        ID = ramens.Count + 1,
                        Brand = line[0],
                        Name = line[1],
                        CountryFK = country.ID,
                        Country = country,
                        Rating = Convert.ToDouble(line[3])
                    };
                    
                    ramens.Add(ramen);
                    
                }

            }
        }

        private Country AddCountry(String countryName)
        {
            var currentCountry = (from c in countries
                                  where c.Name.Equals(countryName)
                                  select c).FirstOrDefault();

            if (currentCountry == null)
            {
                currentCountry = new Country();
                currentCountry.ID = countries.Count() + 1;
                currentCountry.Name = countryName;
                countries.Add(currentCountry);
            }

            return currentCountry;

        }

    }
}
