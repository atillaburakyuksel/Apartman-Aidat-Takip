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
    public partial class Form2 : Form
    {
        apartmanTakibiEntities db = new apartmanTakibiEntities();
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.KisiListesis.ToList();

        }
        void yenile()
        {
            dataGridView1.DataSource = db.KisiListesis.ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var ekle = new KisiListesi()
            {
                AdSoyad = yeniAdSoyad.Text,
                TelefonNo = yeniTelefon.Text,
                DaireNo = Convert.ToInt32(yeniDaire.Text),

            };
            db.KisiListesis.Add(ekle);
            db.SaveChanges();
            yenile();
        }
    }
}
