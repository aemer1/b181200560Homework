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
   
    public partial class Form2 : Form
    {
        
        int x;
        
        List<Customer> CustomerInfo ;
        List<string> CustomerInfoSort = new List<string>();
        int i = 4;
        public Form2()
        {
          
            InitializeComponent();
            
             CustomerInfo = new List<Customer>();
            CustomerInfo.Add(new Customer(600, "Sami", "Guzeltepe",54432456432));//this and the three below it would be for the first 4 customers only to begain with
            CustomerInfo.Add(new Customer(100, "Ahmet", "Mert", 23456732457));
            CustomerInfo.Add(new Customer(345, "Gizem", "Murat",76432234565));
            CustomerInfo.Add(new Customer(950, "Amir", "Owda",12345234135));
            CustomerInfoSort.Add(CustomerInfo[0].list());//this and the three below it are used to help sort the list by name using the radioButton2 
            CustomerInfoSort.Add(CustomerInfo[1].list());
            CustomerInfoSort.Add(CustomerInfo[2].list());
            CustomerInfoSort.Add(CustomerInfo[3].list());
            listBox1.Items.Add(CustomerInfo[0].list());
            listBox1.Items.Add(CustomerInfo[1].list());
            listBox1.Items.Add(CustomerInfo[2].list());
            listBox1.Items.Add(CustomerInfo[3].list());
           

        }
        public List<Customer> GetCustomers() { return CustomerInfo; }//this is used to work as a bridge bewtween form 2 and form one and transfer data to it

        public void SetCustomerInfo(List<Customer> CustomerInfo) { }//this is used to work as a bridge bewtween form 2 and form one and transfer data back from it

        public void Refresh()
        {
            if (radioButton2.Checked)
            {
                listBox1.Items.Clear();
                CustomerInfoSort.RemoveRange(0, CustomerInfo.Count);
                for (int i=0; i<CustomerInfo.Count; i++)
                {
                    CustomerInfoSort.Add(CustomerInfo[i].list());
                }
                    CustomerInfoSort.Sort();
                for (int i = 0; i < CustomerInfoSort.Count; i++)
                {
                    listBox1.Items.Add(CustomerInfoSort[i]);
                }
            }
            else 
            {
                
                CustomerInfoSort.RemoveRange(0, CustomerInfo.Count);
                for (int i = 0; i < CustomerInfo.Count; i++)
                {
                    CustomerInfoSort.Add(CustomerInfo[i].list());
                }
                listBox1.Items.Clear();
            for (int i = 0; i < CustomerInfo.Count; i++)
            {
                listBox1.Items.Add(CustomerInfo[i].list());
            }
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                
                int Debt = Convert.ToInt32(textBox4.Text);// this is used to determine if the debt is only written in numbers 
                long PersonalID = Convert.ToInt64(textBox5.Text);
                int counter = 0;// this counter is usedd to determine if the first name and surname are only alphabets or not and the id is vaild
                if(Debt <0)
                { counter++; }
                if ((PersonalID >= 10000000000) && (PersonalID < 100000000000))
                {  }
                else
                {
                    counter++;
                    
                }
                
              
                char[] firstName = textBox2.Text.ToCharArray();
                char[] surName = textBox1.Text.ToCharArray();
                for (int i = 0; i < firstName.Length; i++)//this for is used to allow only alphabets in the first name textbox
                {
                    x = Convert.ToInt32(firstName[i]);

                    if (((x >= 65) && (x <= 90)) || ((x >= 97) && (x <= 122)))
                    { }
                    else
                    {
                        counter++;
                    }

                }
                for (int i = 0; i < surName.Length; i++)//this for is used to allow only alphabets in the surname name textbox
                {
                    x = Convert.ToInt32(surName[i]);

                    if (((x >= 65) && (x <= 90)) || ((x >= 97) && (x <= 122)))
                    { }
                    else
                    {
                        counter++;
                    }
                }
                string strfirstName = new string(firstName);
                string strsurName = new string(surName);
                strfirstName = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(strfirstName.ToLower());//this command and the one below it are used to change a string from any form to a form in which the first letter is big and the rest are small eg:if i write "AMeER" it'll change to "Ameer"
                strsurName = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(strsurName.ToLower());
                CustomerInfo.Add(new Customer(Debt, strfirstName, strsurName, PersonalID));
                CustomerInfoSort.Add(CustomerInfo[i].list());




                if (counter == 0)
                    listBox1.Items.Add(CustomerInfo[this.i].list());
                else
                    MessageBox.Show("please write vaild id,firstname or surname");
                this.i++;
                
            }
            catch
            {
                MessageBox.Show("please write vaild debt");
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

            listBox1.Items.Clear();
            CustomerInfoSort.Sort();
            for (int i = 0; i < CustomerInfoSort.Count; i++)
            {
                listBox1.Items.Add(CustomerInfoSort[i]);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            
            listBox1.Items.Clear();
            for (int i = 0; i < CustomerInfo.Count; i++)
            {
                listBox1.Items.Add(CustomerInfo[i].list());
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This program is used to count the amount of money that a customer needs to pay for an apartmant/dorm ");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string change;
                int m = Convert.ToInt32(textBox3.Text);
                listBox1.Items.RemoveAt(m - 1);
                if (radioButton1.Checked)
                {
                    change = CustomerInfo[m - 1].list();
                    CustomerInfo.RemoveAt(m - 1);
                    for (int i = 0; i < CustomerInfoSort.Count; i++)
                    {
                        if (CustomerInfoSort[i] == change)
                        {
                            CustomerInfoSort.RemoveAt(i);
                            break;

                        }
                    }
                }
                else if (radioButton2.Checked)
                {
                    change = CustomerInfoSort[m - 1];
                    CustomerInfoSort.RemoveAt(m - 1);
                    for (int i = 0; i < CustomerInfo.Count; i++)
                    {
                        if (CustomerInfo[i].list() == change)
                        {
                            CustomerInfo.RemoveAt(i);
                            break;

                        }
                    }
                }
                else
                {
                    CustomerInfoSort.RemoveAt(m - 1);
                    CustomerInfo.RemoveAt(m - 1);

                }

                }

            catch
            {
                MessageBox.Show("please write a vaild number");
            }
        }

       
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ') e.Handled = true;//this is used to pevent using space in textBox2
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ') e.Handled = true;//this is used to pevent using space in textBox1
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ') e.Handled = true;//this is used to pevent using space in textBox4
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ') e.Handled = true;//this is used to pevent using space in textBox3
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ') e.Handled = true;//this is used to pevent using space in textBox5
        }

 


        private void button4_Click(object sender, EventArgs e)
        {
            
            this.Hide();

           
            
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
           
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        public void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
