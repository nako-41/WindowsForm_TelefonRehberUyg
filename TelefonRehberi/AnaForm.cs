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
    public partial class AnaForm : Form
    {
        public AnaForm()
        {
            InitializeComponent();
        }

        private void btn_yenikayit_Click(object sender, EventArgs e)
        {
            TelefonBLL bll = new TelefonBLL();
            int result = bll.Kaydet(new Rehber
            {
                Isim = txtyeniadi.Text,
                Soyisim = txtyenisoyisim.Text,
                TelefonNumarasi = txtyenitelefon.Text,
                Aciklama = txtyeniaciklama.Text,
                WebAdres = txtyeniweb.Text,
                EmailAdres = txtyenimail.Text,
                Adres = txtyeniadres.Text
            }
            );
            if (result > 0)
            {
                MessageBox.Show("yeni kayıt eklendi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void AnaForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'telefonRehberiDataSet1.Rehber' table. You can move, or remove it, as needed.
            this.rehberTableAdapter.Fill(this.telefonRehberiDataSet1.Rehber);
            // TODO: This line of code loads data into the 'telefonRehberiDataSet.Rehber' table. You can move, or remove it, as needed.

            ListeDoldur();
        }
        private void ListeDoldur()
        {
            TelefonBLL bll = new TelefonBLL();
            List<Rehber> rehbers = bll.KayitListe();
            if (rehbers != null && rehbers.Count > 0)
            {
                dataGridView1.DataSource = rehbers;
                dataGridView1.Columns[0].Visible = false;
            }
        }

        private void dataGridView1_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
          //  Id.Text= dataGridView1.CurrentRow.Cells[0].Value.ToString();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Id.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtisim.Text=dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtsoyisim.Text= dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtel.Text= dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtmail.Text= dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtweb.Text= dataGridView1.CurrentRow.Cells[5].Value.ToString();
            txtadres.Text= dataGridView1.CurrentRow.Cells[6].Value.ToString();
            txtaciklama.Text= dataGridView1.CurrentRow.Cells[7].Value.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            TelefonBLL bll = new TelefonBLL();
            int result = bll.KayitDuzenle(new Rehber
            {
                ID=int.Parse(Id.Text),
                Isim = txtisim.Text,
                Soyisim=txtsoyisim.Text,
                TelefonNumarasi=txtel.Text,
                EmailAdres=txtmail.Text,
                WebAdres=txtweb.Text,
                Adres=txtadres.Text,
                Aciklama=txtaciklama.Text

            }) ;
            if (result > 0)
            {
                MessageBox.Show("Kayıt guncellendi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }

}
