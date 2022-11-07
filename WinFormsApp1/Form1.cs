namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public string BufferUserName { get; set; }
        public string BufferPassword { get; set; }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form2 novaForma = new Form2();
            this.Hide();
            novaForma.Show();

       }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            BufferUserName = textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            BufferPassword = textBox2.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormDB newDB = new FormDB();
            User loggedUser = newDB.FindUser(BufferUserName, BufferPassword);

            if (BufferUserName != "")
            {

                if (loggedUser != null)
                {
                    MessageBox.Show($"Welcome {loggedUser.Name} {loggedUser.Surname}", "Home Page", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                { 

                    MessageBox.Show("Account does not exist/Wrong informations","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("ne radi");
           




        }

        private void Form1_Load(object sender, EventArgs e)
        {
            errorProvider1.ContainerControl = this;
        } //@todo napraviti registraciju i popraviti errorProvider

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}