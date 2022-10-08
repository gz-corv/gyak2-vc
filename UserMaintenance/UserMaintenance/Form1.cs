﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserMaintenance.Entities;

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
        }


    }
}
