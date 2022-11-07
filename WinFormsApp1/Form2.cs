using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public static User newUser = new User();

        public string BufferName { get; set; }
        public string BufferSurname { get; set; }

        public string BufferUsername { get; set; }
        public string BufferPassword { get; set; }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            BufferName = textBox4.Text;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            BufferSurname = textBox3.Text;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

          //  textBox1.Text += $"{textBox4.Text}" + "." + $"{textBox3.Text}";
            BufferUsername = textBox1.Text;


        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            BufferPassword = textBox2.Text;

        }

        public bool ValidateName()
        {
            if (textBox4.Text.Length < 4)
            {
                errorProvider6.SetError(textBox4, "Name too short!");

                return false;
            }
            errorProvider6.Clear();
            
            return true;
        }
        public bool ValidateSurname()
        {
            if (textBox3.Text.Length < 4)
            {
                errorProvider7.SetError(textBox3, "Surname too short!");
                return false;
            }
            errorProvider7.Clear();

            return true;
        }

        public bool ValidateUsername()
        {
            if (textBox1.Text.Length < 4)
            {
                errorProvider8.SetError(textBox1, "Username too short!");

                return false;
            }
         foreach (var user in FormDB.users)
            {
                if (BufferUsername == user.UserName)
                {
                    errorProvider8.SetError(textBox1, "Username already exists!");

                    return false;
                }

               // return true;
            }
            errorProvider8.Clear();
            return true;
        }

        public bool ValidatePassword()
        {
            if (textBox2.Text != textBox5.Text)
            {
                errorProvider10.SetError(textBox5, "Passwords are not same!");
                return false;
            }
            else if(textBox2.Text.Length < 8){
                errorProvider9.SetError(textBox2, "Passwords too weak!");

                return false;
            }
            errorProvider10.Clear();
            errorProvider9.Clear();  
            return true;
        }

        public void ValidateForm()
        {
           // if (!ValidateName())
            // if (!ValidateSurname())
            //    errorProvider2.SetError(textBox3, "Surname too short!");
            //else if (!ValidateUsername())
            //    errorProvider3.SetError(textBox1, "Already exist!");
            //else if (!ValidatePassword())
            //    errorProvider4.SetError(textBox2, "Weak password!");
        
                FormDB.AddUser(BufferName, BufferSurname, BufferUsername, BufferPassword);
        }

        private void textBox4_Validated(object sender, EventArgs e)
        {
            ValidateName();

        }

        private void textBox3_Validated(object sender, EventArgs e)
        {
            ValidateSurname();
        }

        private void textBox1_Validated(object sender, EventArgs e)
        {
            ValidateUsername();

        }

        private void textBox2_Validated(object sender, EventArgs e)
        {
            ValidatePassword();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ValidatePassword() && ValidateUsername() && ValidateName() && ValidateSurname())
            {
                FormDB.AddUser(BufferName, BufferSurname, BufferUsername, BufferPassword);
                DialogResult dr = MessageBox.Show($"You did it!\n You made a new account \n Account stats: \n Name: {BufferName} \n Surname: {BufferSurname} \n UserName: {BufferUsername} \n Password: {BufferPassword} \n  Do you want to go to login form?", "Registration", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);


                switch (dr)
                {
          
                    case DialogResult.Yes:
                        Form1 backLink = new Form1();
                        this.Hide();
                        backLink.Show();
                        break;
                    case DialogResult.No:
                        break;
      
                    default:
                        break;
                }


            }

            else
            {
                MessageBox.Show("Something went wrong...\n Try again","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}