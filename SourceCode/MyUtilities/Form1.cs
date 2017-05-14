using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyUtilities
{
    public partial class MainForm : Form
    {
        int count = 0;
        Random rnd;
        char[] spec_chars = new char[] { '{', '}', '[' ,']','(',')', '/',};
     
        public MainForm()
        {
            InitializeComponent();
            rnd = new Random();
        }

        private void tsmiExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsmiAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The program MyUtilites contain a few small programs that can be useful in any case of life.\n Version 1.0.0\n Created by DeltaLabs Inc and Hovhannes Zohrabyan");
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            count++;
            lblCounter.Text = count.ToString();
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            count--;
            lblCounter.Text = count.ToString();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            count = 0;
            lblCounter.Text = count.ToString();
        }

        private void nudMax_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            int n;
            n = rnd.Next(Convert.ToInt32( nudMin.Value), Convert.ToInt32(nudMax.Value));
            lblNumber.Text = n.ToString();
        }

        private void enterDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbNotepad.AppendText(DateTime.Now.ToShortDateString() + "\n");
        }

        private void enterTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbNotepad.AppendText(DateTime.Now.ToShortTimeString() + "\n");
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                rtbNotepad.SaveFile("Notepad.rtf");
            }
            catch
            {
                MessageBox.Show("Error occured while saving file");
            }
        }

        void loadNotepad()
        {
            try
            {
                rtbNotepad.LoadFile("Notepad.rtf");
            }
            catch
            {
                MessageBox.Show("Error occured while loading file");
            }
        }
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadNotepad();
        }

        private void rtbNotepad_Enter(object sender, EventArgs e)
        {
          
        }

        private void rtbNotepad_MouseEnter(object sender, EventArgs e)
        {
         
        }

        private void Numbers_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (clbPassword.CheckedItems.Count == 0) return;
            string password = "";

            for (int i = 0; i < nudPasswordLenght.Value; i++)
            {
                int n = rnd.Next(0, clbPassword.CheckedItems.Count);
                
                string s = clbPassword.CheckedItems[n].ToString();
                
                switch (s)
                {
                    case "Numbers":
                        password += rnd.Next(10).ToString();
                        break;
                    case "Lowercase Characters":
                        password += Convert.ToChar(rnd.Next(65, 68));
                        break;
                    case "Upercase Characters":
                        password += Convert.ToChar(rnd.Next(97, 122));
                        break;
                    default:
                        password += spec_chars[rnd.Next(spec_chars.Length)];
                        break;
                 }

              
            }
            tbPassword.Text = password;
            Clipboard.SetText(password);
            string PasswordHistory = Clipboard.GetText();
            rtbPasswordHistory.AppendText(PasswordHistory+ "\n");
        }

        private void savePasswordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            { rtbPasswordHistory.SaveFile("PasswordHistory"); }
            catch
            {
                MessageBox.Show("An error occured while saving file");
            }
            
        }

        private void loadPasswordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbPasswordHistory.LoadFile("PasswordHistory");
        }
    }
}
