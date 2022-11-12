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
        private List<Brand> brands;
        public Form1()
        {
            InitializeComponent();

            LoadData("ramen.csv");
            Console.WriteLine("end of load");

            countryList.DisplayMember = "Name";
        }

        private void LoadData(String fileName) 
        {
            if (countries == null)
                countries = new List<Country>();
            countries.Clear();

            if (ramens == null)
                ramens = new List<Ramen>();
            ramens.Clear();

            if (brands == null)
                brands = new List<Brand>();
            brands.Clear();


            using (StreamReader sr = new StreamReader(fileName, Encoding.Default))
            {

                sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    string[] line = sr.ReadLine().Split(';');
                    

                    String countryName = line[2];
                    String brandName = line[0];

                    var country = AddCountry(countryName);
                    var brand = AddBrand(brandName);

                    var ramen = new Ramen()
                    {
                        ID = ramens.Count + 1,
                        Name = line[1],
                        BrandFk = brand.ID,
                        Brand = brand,
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
                currentCountry.ID = countries.Count + 1;
                currentCountry.Name = countryName;
                countries.Add(currentCountry);
            }

            return currentCountry;

        }


        private Brand AddBrand(String brandName)
        {
            var currentBrand = (from b in brands
                                where b.Name.Equals(brandName)
                                select b).FirstOrDefault();

            if (currentBrand == null)
            {
                currentBrand = new Brand();
                currentBrand.ID = brands.Count + 1;
                currentBrand.Name = brandName;
                brands.Add(currentBrand);
            }

            return currentBrand;
                
                 
         }

        private void countryFilter_TextChanged(object sender, EventArgs e)
        {
            GetCountries();
        }

        private void GetCountries()
        {

            var countriesList = (from c in countries
                               where c.Name.ToLower().Contains(countryFilter.Text.ToString().ToLower())
                               orderby c.Name
                               select c
                             );
            countryList.DataSource = countriesList.ToList();
        }
    }
}
