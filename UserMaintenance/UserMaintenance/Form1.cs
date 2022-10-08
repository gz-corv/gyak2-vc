using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserMaintenance.Entities;
using System.IO;

namespace UserMaintenance
{
    public partial class Form1 : Form
    {

        BindingList<User> users = new BindingList<User>(); 
        public Form1()
        {
            InitializeComponent();

            label1.Text = AppResources.FullName;
            button1.Text = AppResources.Add;
            button2.Text = AppResources.Save;

            listBox1.DataSource = users;
            listBox1.ValueMember = "ID";
            listBox1.DisplayMember = "FullName";
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var user = new User()
            {
                FullName = textBox1.Text
            };

            users.Add(user);

            textBox1.Clear();
             
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string filter = "CSV file (*.csv)|*.csv| All Files (*.*)|*.*";
            saveFileDialog1.Filter = filter;
            const string header = "ID,FullName";
            StreamWriter writer = null;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filter = saveFileDialog1.FileName;
                
                try 
                {
                    writer = new StreamWriter(filter, false, Encoding.UTF8);
                    writer.WriteLine(header);
                    foreach (var user in users)
                    {

                        writer.WriteLine(user.ID.ToString() + "," + user.FullName);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show(AppResources.Error);
                }

                if (writer != null)
                    writer.Close();



            }
        }
    }
}
