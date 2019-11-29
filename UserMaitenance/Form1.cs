﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserMaitenance.Entities;

namespace UserMaitenance
{
    public partial class Form1 : Form
    {
        BindingList<User> users = new BindingList<User>();
        public Form1()
        {
            InitializeComponent();
            
            textBox1.Text = Resource1.FullName; // label1
            button2.Text = Resource1.Write;
            button1.Text = Resource1.Add; // button1

            listBox1.DataSource = users;
            listBox1.ValueMember = "ID";
            listBox1.DisplayMember = "FullName";
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var u = new User()
            {
                FullName = textBox1.Text + textBox2.Text,
                
            };
            users.Add(u);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() != DialogResult.OK) return;
            using (StreamWriter sw = new StreamWriter(sfd.FileName, false, Encoding.UTF8))
            {
               
                foreach (var s in users)
                {
                   
                    sw.Write(s.ID);
                    sw.Write(";");
                    sw.Write(s.FullName);
                    sw.Write(";");
                    
                }
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {

            listBox1.DataSource = users;

            users = new BindingList<User>(users);
            users.Remove((User)listBox1.SelectedItem);

            listBox1.DataSource = users;

        }
    }
}
