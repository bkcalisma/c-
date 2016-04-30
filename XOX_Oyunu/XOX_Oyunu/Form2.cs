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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            textBox1.Text = "XOX bütün yaştan insanların kendi aralarında oynadıkları iki kişi ile oynanan ve çoğu yerde ismi  Tic Tac Toe diye geçen üçleme oyunlarındandır. Farenizi kullanarak 6 dikdörtgenden oluşan bölgede tıklayarak oyunu oynayın :)";
            textBox1.Select(textBox1.TextLength, 1);
        }
    }
}
