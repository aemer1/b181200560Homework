using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace homework
{
    public partial class Form1 : Form
    {

        
        List<Customer>  CustomerInfo ;
        Form2 frm2 = new Form2();
        public Form1()
        {
           
            InitializeComponent();
           




        }

        private void button1_Click(object sender, EventArgs e)
        {

            if(textBox5.Text=="password")
            { 
            frm2.SetCustomerInfo(CustomerInfo);
              
                frm2.Show();
            
            frm2.Refresh();// this is used toressort the data on the list box
            }
            else
            {
             MessageBox.Show("You entered the wrong password");
            }



        }

        private void button3_Click(object sender, EventArgs e)
        {
            CustomerInfo = frm2.GetCustomers();
            try
            {
                string CreditCard = Convert.ToString(textBox2.Text);
                string CVV = Convert.ToString(textBox3.Text);
                int Paying = Convert.ToInt32(textBox4.Text);
                long PersonalID = Convert.ToInt64(textBox1.Text);

                
                if (CreditCard.Length == 16 && (CVV.Length == 3 || CVV.Length == 4) && Paying>=  0 &&((PersonalID >= 10000000000) && (PersonalID < 100000000000)) )
                {
                    for (int i = 0; i < CustomerInfo.Count; i++)
                    {
                        if (PersonalID == CustomerInfo[i].getPersonalID())
                        {
                            if((CustomerInfo[i].getDebt() - Paying) >=0 )
                            { 
                            CustomerInfo[i].setDebt(CustomerInfo[i].getDebt() - Paying);                   
                            label6.Text = ("Remaining Debt = " + (CustomerInfo[i].getDebt()));
                                frm2.Refresh();
                                break;
                            }
                            else
                            {
                                MessageBox.Show("you can't pay more than you owe");
                                break;
                            }
                        }
                        else if (i == CustomerInfo.Count - 1)
                        {
                            MessageBox.Show("the ID you are looking for doesn't exist");
                        }
                    }
                    long CreditTest = Convert.ToInt64(CreditCard);
                int CVVTest = Convert.ToInt32(CVV);
                }
                else
                {
                    MessageBox.Show("Please enter vaild informations(credit card must be 16 digit,cvv must be 3 or 4,paying must be a positive number,personal id must be 11 digits and must not start with 0");
                }
            }
            catch
            {
                MessageBox.Show("Please enter vaild informations(credit card must be 16 digit,cvv must be 3 or 4,paying must be a positive number,personal id must be 11 digits and must not start with 0");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            { 
            long PersonalID = Convert.ToInt64(textBox1.Text);
            CustomerInfo = frm2.GetCustomers();
            for (int i = 0; i < CustomerInfo.Count; i++)
            {
                if (PersonalID == CustomerInfo[i].getPersonalID())
                {
                    label4.Text = ("Debt = "+ CustomerInfo[i].getDebt() );
                    break;
                }
                else if (i== CustomerInfo.Count-1)
                {
                    MessageBox.Show("the ID you are looking for doesn't exist");
                }
            }
            }
            catch
            {
                MessageBox.Show("Please enter a baild ID");
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ') e.Handled = true;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ') e.Handled = true;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ') e.Handled = true;
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ') e.Handled = true;
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ') e.Handled = true;
        }
    }
}
