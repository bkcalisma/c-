using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace XOX_Oyunu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        bool isaret = true;
        int tiklanmaSayisi = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (isaret == true)
            {
                btn.Text = "X";
                btn.BackColor = Color.Red;
            }
            else
            {
                btn.Text = "O";
                btn.BackColor = Color.Yellow;
            }

            btn.Enabled = false;
            isaret = !isaret;
            tiklanmaSayisi++;
            KazananKontrol();

        }

        void KazananKontrol()
        {
            bool kazananvarmi = false;
            //yatay kontrol
            if ((button1.Text == button2.Text) && (button2.Text == button3.Text) && (!button1.Enabled))
                kazananvarmi = true;
            if ((button4.Text == button5.Text) && (button5.Text == button6.Text) && (!button4.Enabled))
                kazananvarmi = true;
            if ((button7.Text == button8.Text) && (button8.Text == button9.Text) && (!button7.Enabled))
                kazananvarmi = true;
            //dikey kontrol
            else if ((button1.Text == button4.Text) && (button4.Text == button7.Text) && (!button1.Enabled))
                kazananvarmi = true;
            if ((button2.Text == button5.Text) && (button5.Text == button8.Text) && (!button2.Enabled))
                kazananvarmi = true;
            if ((button3.Text == button6.Text) && (button6.Text == button9.Text) && (!button3.Enabled))
                kazananvarmi = true;
            //çapraz kontrol 
            else if ((button1.Text == button5.Text) && (button5.Text == button9.Text) && (!button1.Enabled))
                kazananvarmi = true;
            if ((button3.Text == button5.Text) && (button5.Text == button7.Text) && (!button7.Enabled))
                kazananvarmi = true;
            if (kazananvarmi)
            {
                ButtonDeAktifEt();
                string kimkazandi = "";
                if (isaret)
                    kimkazandi = "O";
                else
                    kimkazandi = "X";
                DialogResult dr = MessageBox.Show(kimkazandi + " Kazandı!\nTekrardan oynamak istiyor musunuz?", "Oyun Bitti", MessageBoxButtons.YesNo);

                if (dr == DialogResult.Yes)
                {
                    OyunuTekrarBaslat();
                }
                else
                {
                    Application.Exit();
                }

            }
            else
            {
                if (tiklanmaSayisi == 9)
                {
                    DialogResult dr = MessageBox.Show("Berabere!\nTekrardan oynamak istiyor musunuz?", "Oyun Bitti", MessageBoxButtons.YesNo);

                    if (dr == DialogResult.Yes)
                    {
                        OyunuTekrarBaslat();
                    }
                    else
                    {
                        Application.Exit();
                    }
                }
            }
        }

        void ButtonDeAktifEt()
        {
            foreach (Control control in this.Controls)
            {
                if (control is Button)
                {
                    ((Button)control).Enabled = false;
                }
            }
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Sadece formu kapatır
            // this.Close();

            // Uygulamayı kapatır.
            Application.Exit();
        }

        private void yeniOyunToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OyunuTekrarBaslat();
        }

        void OyunuTekrarBaslat()
        {
            foreach (var item in this.Controls)
            {
                if (item is Button)
                {
                    Button btn = item as Button;
                    btn.Enabled = true;
                    btn.Text = "";
                    btn.BackColor = Color.Empty;
                }
            }

            isaret = true;
            tiklanmaSayisi = 0;

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.facebook.com/ege.universitesi.bilgisayar.kulubu/");
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://twitter.com/egebk");
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.egebk.org");
        }

        private void nasılOynanırToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }
    }
}
