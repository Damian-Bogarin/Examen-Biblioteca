using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibreryManagment.Models;
using LibreryManagment.Presenter;

namespace LibreryManagment
{
    public partial class Form1 : Form, IlibraryView
    {
        LibraryPresenter library;

        public Form1()
        {
            InitializeComponent();
            library = new LibraryPresenter(this);
        }

      
     
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //Metodos Book
        public string GetInputName()
        {
            return textBox1.Text;
        }

        public string GetInputAutor()
        {
            return textBox2.Text;
        }

        public string GetInputISBN()
        {
            return textBox3.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            library.CreateBook();
        }

        public string GetBookSelected()
        {
            return comboBox1.Text;
        }

        public string GetInputDate()
        {
            return textBox4.Text;
        }

        public string GetInputLocation()
        {
            return textBox5.Text;
        }

        public void ShowResult(string result)
        {
            label13.Visible = true;
            label13.Text = result;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        public void ShowBook(string autor, bool count)
        {
            
        }

        public void ShowCopyError(bool result)
        {
            label15.Visible = false;
            label14.Visible = true;
            label13.Visible = false;
            if (result)
            {
            
            label14.Text = "Los datos son invalidos";
            }
            else
            {
                label14.Text = "El ejemplar se añadio";
                comboBox1.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
            }
            
        }

        public void ShowBooks(string result)
        {
            comboBox1.Items.Add(result);
            comboBox3.Items.Add(result);
        }


        //Methods Partner
        public string GetName()
        {
            return textBox6.Text;
        }

        public string GetLastName()
        {
            return textBox7.Text;
        }

        public string GetDNI()
        {
            return textBox8.Text;
        }

        public bool GetVip()
        {
            return checkBox1.Checked;
        }

        public void ShowAddResult(string result)
        {
           label15.Visible = true;
            label13.Visible = false;
            label14.Visible = false;
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            checkBox1.Checked = false;
            label15.Text = result;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            library.AddCopy();
        }

   

   

        private void button3_Click(object sender, EventArgs e)
        {
            library.AddPartner();
        }

        public void ShowPartners(string result)
        {
            comboBox2.Items.Add(result);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            library.SearchPartner();
        }

        public string GetPartnerSelected()
        {
            return comboBox2.Text;
        }

        public string GetBookToGive()
        {
            return comboBox3.Text;
        }

        public void ShowPartnerAtribute(string nameComplete, string vip, string dni, string available)
        {
            label25.Text = nameComplete;
            label26.Text = dni;
            label27.Text = vip;
            label29.Text = available;
           
            
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            library.SearchBook();
        }

        public void ShowBookAtribute(string available)
        {
            label30.Text = available;
        }

        public void LoanError(string result)
        {
           label16.Text = result;
           label16.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            library.GenerateLoan();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            library.ReturnLoan();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            library.ShowLoan();
        }

      

        public void LoanCharge(string result)
        {
            richTextBox1.Text = result;
        }
    }
}
