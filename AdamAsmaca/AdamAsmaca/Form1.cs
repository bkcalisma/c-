using System;
using System.Windows.Forms;
using System.Drawing;

namespace AdamAsmaca
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string[] kelimeler;
        string[] ipuclari;
        private void Form1_Load(object sender, EventArgs e)
        {
            kelimeler = new string[] { "BİLGİSAYAR", "BUZDOLABI", "MASA", "TEBEŞİR", "SANDALYE", "KÖFTE", "ŞEKERPARE", "MARMARA", "GİTAR", "PAPAĞAN", "İZMİR", "EGE ÜNİVERSİTESİ", "VİŞNE ÇÜRÜĞÜ", "PAPATYA", "RUSYA FEDERASYONU", "BADMİNTON", "TERS YÜZ", "MOODLE", "BUGS BUNNY", "ADAM ASMACA", "LİNKEDİN", "KARA LAHANA", "FONDÖTEN", "İNCE BAĞIRSAK", "BANLİYÖ", "KAYINBİRADER", "BLAZER CEKET" };
            ipuclari = new string[] { "Bilişim", "Ev eşyası", "Eşya", "Mataryel", "Eşya", "Yemek", "Tatlı", "Bölge", "Çalgı", "Hayvan", "Şehir", "Üniversite", "Renk", "Çiçek", "Ülke", "Spor", "Film", "İnternet", "Çizgi Film", "Oyun", "Sosyal Medya", "Bitki", "Makyaj", "Organ", "Ulaşım", "Aile", "Kıyafet" };

            OyunuBaslat();
        }

        const int HAK_SAYISI = 6;
        string kelime;
        int yanlisSayisi = 0;
        int hak = HAK_SAYISI;
        private void button1_Click(object sender, EventArgs e)
        {
            bool varMi = false;
            Button btn = (Button)sender;
            btn.Enabled = false;
            btn.BackColor = Color.PapayaWhip;
            char harf = Convert.ToChar(btn.Text);
            char[] harfler = lblKelime.Text.ToCharArray();

            for (int i = 0; i < kelime.Length; i++)
            {
                char gelenHarf = kelime[i];

                if (harf == gelenHarf)
                {
                    harfler[i] = harf;
                    varMi = true;
                }
            }

            lblKelime.Text = "";
            for (int i = 0; i < harfler.Length; i++)
            {
                lblKelime.Text += harfler[i];
            }

            if (varMi == false)
            {
                btn.ForeColor = Color.PaleVioletRed;
                yanlisSayisi++;
                hak--;
                lblKalanHak.Text = "Kalan hak = " + hak;
                switch (yanlisSayisi)
                {
                    case 1: pictureBox1.Image = AdamAsmaca.Properties.Resources.resim_1;
                        break;
                    case 2: pictureBox1.Image = AdamAsmaca.Properties.Resources.resim_2;
                        break;
                    case 3: pictureBox1.Image = AdamAsmaca.Properties.Resources.resim_3;
                        break;
                    case 4: pictureBox1.Image = AdamAsmaca.Properties.Resources.resim_4;
                        break;
                    case 5: pictureBox1.Image = AdamAsmaca.Properties.Resources.resim_5;
                        break;
                    case 6: pictureBox1.Image = AdamAsmaca.Properties.Resources.resim_6;
                        TekrarSoru("Öldün! Kelime: " + kelime);

                        break;
                }
            }
            else
            {
                btn.ForeColor = Color.LightGreen;
                if (lblKelime.Text.Contains("-") == false)
                {
                    TekrarSoru("Kazandın!");
                }
            }
        }

        void TekrarSoru(string mesaj)
        {
            DialogResult dr = MessageBox.Show(mesaj + "\nTekrar oynamak istiyor musun?", "Adam Asmaca", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                OyunuBaslat();
            }
            else
            {
                Application.Exit();
            }
        }


        void OyunuBaslat()
        {
            yanlisSayisi = 0;
            lblKelime.Text = "";
            hak = HAK_SAYISI;
            lblKalanHak.Text = "";
            //  lblKalanHak.Text = "Kalan Hak = " + kalanHak;

            pictureBox1.Image = AdamAsmaca.Properties.Resources.resim_0;

            foreach (Control control in panel1.Controls)
            {
                if (control is Button)
                {
                    Button btn = (Button)control;
                    btn.Enabled = true;
                    btn.BackColor = Color.Empty;
                    btn.ForeColor = Color.Empty;
                }
            }

            Random rnd = new Random();
            int index = rnd.Next(0, kelimeler.Length);
            kelime = kelimeler[index];
            string ipucu = ipuclari[index];

            for (int i = 0; i < kelime.Length; i++)
            {
                if (kelime[i] == ' ')
                {
                    lblKelime.Text += " ";
                }
                else
                {
                    lblKelime.Text += "-";
                    lblKelime.Tag += kelime[i].ToString();
                }
            }

            lblIpucu.Text = string.Format("{0} harfli kelime. İpucu: {1}", kelime.Replace(" ", "").Length, ipucu);
        }


        private void yeniOyunToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OyunuBaslat();
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void nasılOynanırToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Verilen ipucuna göre gizli kelimeleri, ekrandaki harfleri kullanarak bulmaya çalışın. Maksimum yanlış tahmin sayınız 6'dır.", "Nasıl Oynanır?");
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.egebk.org");
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://twitter.com/egebk");
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.facebook.com/ege.universitesi.bilgisayar.kulubu/");
        }

    }
}
