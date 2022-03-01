using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TJAS_ENCRYPTION.Models;

namespace TJAS_ENCRYPTION
{
    public partial class Form1 : Form
    {
        List<UserModel> users = new List<UserModel>();

        public Form1()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

     
        private void button2_Click(object sender, EventArgs e)
        {
            UserModel user = new UserModel();

            if (textBox1.Text == textBox3.Text)
            {
                user.array3D = Encrypter.Encrypt(textBox1.Text, user);

            }
            else
            {
                MessageBox.Show("Your passwords do not match");
            }
            user.username = textBox2.Text;

            users.Add(user);

            MessageBox.Show("username: " + user.username + " Password" + user.password);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach(var user in users)
            {
                if (textBox5.Text == user.username)
                {
                    if (Encrypter.ValidatePass(user, textBox4.Text) == true)
                    {
                        MessageBox.Show("you gained access");
                    }
                    else
                    {
                        MessageBox.Show("That was inccorrect, Please try again");
                    }
                   
                }

            }
           
        }
    }
}
