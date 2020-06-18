using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TEA
{
    public partial class Form1 : Form
    {
        private string ciphertext, plaintext;
        public Form1()
        {
            InitializeComponent();
            richTextBox1.Enabled = false;
            
        }
        
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.TextLength == 0) {
                richTextBox1.Text = richTextBox1.Text + "System:" + "Plaintext was null\n";
            } else if (textBox1.TextLength == 0)
            {
                richTextBox1.Text = richTextBox1.Text + "System:" + "Key was null\n";
            }else {
                TEA tea = new TEA();
                ciphertext = tea.Encrypt(textBox2.Text, textBox1.Text);
                textBox3.Text = ciphertext;
                richTextBox1.Text = richTextBox1.Text + "System:" + "Plaintext has been encrypted\n";
            };     
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox2.TextLength != 0)
            {
                textBox2.Text = "";
                richTextBox1.Text = richTextBox1.Text + "System:" + "Plaintext has been erased\n";
            }
                
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(textBox3.TextLength != 0)
            {
                textBox3.Text = "";
                richTextBox1.Text = richTextBox1.Text + "System:" + "Ciphertext has been erased\n";
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox3.TextLength == 0)
            {
                richTextBox1.Text = richTextBox1.Text + "System:" + "Ciphertext was null\n";
            }
            else if (textBox1.TextLength == 0)
            {
                richTextBox1.Text = richTextBox1.Text + "System:" + "Key was null\n";
            }else {
                TEA tea = new TEA();
                plaintext = tea.Decrypt(textBox3.Text, textBox1.Text);
                textBox2.Text = plaintext;
                richTextBox1.Text = richTextBox1.Text + "System:" + "Ciphertext has been decrypted\n";
            }; 
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1.TextLength != 0)
            {
                textBox1.Text = "";
                richTextBox1.Text = richTextBox1.Text + "System:" + "Key has been erased\n";
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox1.TextLength != 0 || textBox2.TextLength != 0|| textBox2.TextLength != 0)
            {
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                richTextBox1.Text = richTextBox1.Text + "System:" + "All has been erased\n";
            }
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0123456789ABCDEF";
            richTextBox1.Text = richTextBox1.Text + "System:" + "Key has been added\n";
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox2.Text = "I Love Cryptography!";
            richTextBox1.Text = richTextBox1.Text + "System:" + "Plaintext has been added\n";
            
        }
    }
}
