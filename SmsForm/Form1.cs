using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SmsForm.Midle;

namespace SmsForm
{
    public partial class SmsSender : Form
    {
        public SmsSender()
        {
            InitializeComponent();
        }

        private void SmsSender_Load(object sender, EventArgs e)
        {
            FindCarrier.load();

        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
          {
            string errorMsg;
            if(ValidateString(textBox1.Text, out errorMsg))
            {
                e.Cancel = true;                
                this.errorProvider1.SetError(textBox1, errorMsg);
            }
            

        }

        private void textBox1_Validated(object sender, EventArgs e)
        {
            this.errorProvider1.SetError(textBox1,"");
        }
        public bool ValidateString(string content, out string errorMsg)
        {
            bool isnum = false;
            string temp = "";
            if(string.IsNullOrEmpty(content))
            {
               
                temp = "Debe introducir Valores";
                isnum = true;
                
            }
            
            if (content != string.Empty)
            {
                foreach (char car in content.ToCharArray())
                {
                    if (char.IsNumber(car))
                    {
                        isnum = true;
                        temp = "No se Permiten Numeros.";
                        break;
                    }
                                       
                }                
                
            }
            errorMsg = temp;
            return isnum;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty && maskedTextBox1.Text != string.Empty && textBox3.Text != string.Empty)
            {
            

                if (FindCarrier.Validar(maskedTextBox1.Text.Substring(0,4)))
                {
                    Sms msg = new Sms(textBox1.Text, cleanMaskedTextBox(textBox2.Text, maskedTextBox1.Text), textBox3.Text);
                    MessageBox.Show(msg.send(msg));
                     clean();
                }
                else
                {
                    MessageBox.Show($"El numero dado no es valido o no puede ser validado  {maskedTextBox1.Text}","Adviso",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                    maskedTextBox1.Focus(); 
                }
            }
            else
            {
                MessageBox.Show("por favor revise los datos");
            }
        
           


        }

        private void clean()
        {
            //limpiar la interfaz de usuario
            foreach (Control c in this.Controls)
            {
                if( c is TextBox && c.Enabled ==true )
                {                                 
                   c.Text = "";
                }
                if( c is MaskedTextBox)
                {
                    
                    c.Text = "";
                }
            }
        }

        private string cleanMaskedTextBox(string  area,string data)
        {
            
            return string.Concat(area,data).Replace("(", "").Replace(")", "").Replace("-", "");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            clean();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
