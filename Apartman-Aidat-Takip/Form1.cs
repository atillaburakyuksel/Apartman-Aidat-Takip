using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Apartman_Aidat_Takip
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }
        apartmanTakibiEntities db = new apartmanTakibiEntities();
        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource=db.OdemeKisiListesis.ToList();
        }
        
        void yenile()
        {
            dataGridView1.DataSource = db.OdemeKisiListesis.ToList();
        }
        void sil()
        {
            int id = int.Parse(dataGridView1.CurrentRow.Cells["ID"].Value.ToString());
            var model = db.OdemeKisiListesis.FirstOrDefault(x => x.ID == id);
            db.OdemeKisiListesis.Remove(model);
            db.SaveChanges();
            
        }
        void temizle()
        {
            txtID.Text = "";
            txtAdSoyad.Text = "";
            txtDaire.Text = "";
            txtOdenen.Text = "";
            cmbTarih.Text = "";
            txtTelNo.Text = "";
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    var entity = new OdemeKisiListesi
        //    {
        //        AdSoyad = txtAdSoyad.Text,
        //        TelefonNo = Convert.ToInt32(txtTelNo.Text),
        //        DaireNo=Convert.ToInt32(txtDaire.Text),
        //        OdemeTutarı=Convert.ToInt32(txtOdenen.Text),
        //        OdemeTarihi=Convert.ToDateTime(cmbTarih.Text),
                
        //    };
        //    db.OdemeKisiListesis.Add(entity);
        //    db.SaveChanges();
        //    yenile();
        //}

        private void button2_Click(object sender, EventArgs e)
        {
            sil();
            yenile();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
            txtAdSoyad.Text = dataGridView1.CurrentRow.Cells["AdSoyad"].Value.ToString();
            txtTelNo.Text = dataGridView1.CurrentRow.Cells["TelefonNo"].Value.ToString();
            txtDaire.Text = dataGridView1.CurrentRow.Cells["DaireNo"].Value.ToString();
            txtOdenen.Text = dataGridView1.CurrentRow.Cells["OdemeTutarı"].Value.ToString();
            cmbTarih.Text = dataGridView1.CurrentRow.Cells["OdemeTarihi"].Value.ToString();

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            temizle();
        }

       

        //private void button2_Click_1(object sender, EventArgs e)
        //{
        //    var ekle = new KisiListesi()
        //    {
        //        AdSoyad = yeniAdSoyad.Text,
        //        TelefonNo = yeniTelefon.Text,
        //        DaireNo = Convert.ToInt32(yeniDaire.Text),

        //    };
        //    db.KisiListesis.Add(ekle);
        //    db.SaveChanges();
        //    yenile();
        //}

        private void button3_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(txtID.Text);
            var model = db.KisiListesis.FirstOrDefault(x => x.ID == ID);
            model.AdSoyad = txtAdSoyad.Text;
            model.TelefonNo =txtTelNo.Text;
            model.DaireNo = Convert.ToInt32(txtDaire.Text);
            
            yenile();

        }

        private void txtAra_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.KisiListesis.Where(x => x.AdSoyad.Contains(txtAra.Text)).ToList();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
           
            form2.Show();
            this.Hide();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            var ekle = new OdemeKisiListesi()
            {
                AdSoyad = txtAdSoyad.Text,
                TelefonNo = Convert.ToInt32(txtTelNo.Text),
                DaireNo = Convert.ToInt32(txtDaire.Text),
               
                OdemeTutarı = Convert.ToInt32(txtOdenen.Text),
                OdemeTarihi = cmbTarih.Text,


            };
            db.OdemeKisiListesis.Add(ekle);
            db.SaveChanges();
            yenile();
        }
    }
}
    