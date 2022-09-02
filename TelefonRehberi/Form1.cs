using BusinessLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TelefonRehberi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TelefonBLL telefon = new TelefonBLL();
            int result = telefon.SistemKontol(new Kullanici { KullaniciAdi = textBox1.Text, Sifre = textBox2.Text });
            if (result > 0)
            {
                AnaForm anaform = new AnaForm();
                this.Hide();
                anaform.Show();
            }
            else
            {
                MessageBox.Show("Hatalı Kullanıcı girişi,lütfen tekrar deneyiniz","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }
    }
}
