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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        apartmanTakibiEntities db = new apartmanTakibiEntities();
        private void Form4_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.OdemeKisiListesis.ToList();
        }

        private void txtAra_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource=db.OdemeKisiListesis.Where(x=>x.AdSoyad.Contains(txtAra.Text)).ToList();
        }
    }
}
