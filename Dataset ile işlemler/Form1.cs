using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Dataset_ile_işlemler
{
    public partial class Form1 : Form
    {
        //sınıf oluşturarak değişkene atama işlemi
        DataSet1TableAdapters.tbl_datasetislemTableAdapter ds = new DataSet1TableAdapters.tbl_datasetislemTableAdapter();
        public Form1()
        {
            InitializeComponent();
        }

        //listeleme işlemi 
        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.data1();
        }

        //uygulamayı kapatma işlemi
        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //çift tıklıyarak verileri textboxlara taşıma işlemi
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int seçilen = dataGridView1.SelectedCells[0].RowIndex;
            txtad.Text = dataGridView1.Rows[seçilen].Cells[0].Value.ToString();
            txtsoyad.Text = dataGridView1.Rows[seçilen].Cells[1].Value.ToString();
            txtokulno.Text = dataGridView1.Rows[seçilen].Cells[2].Value.ToString();
            txttc.Text = dataGridView1.Rows[seçilen].Cells[3].Value.ToString();
        }

        //kayıt ekleme işlemi
        private void btnekle_Click(object sender, EventArgs e)
        {
            try
            {
                ds.dataekleme(txtad.Text,txtsoyad.Text,txtokulno.Text,txttc.Text);
                MessageBox.Show("kayıt Yapma İşlemi Başarılı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch 
            {
                MessageBox.Show("Değerleri Kontrol Ediniz");
            }
        }

        //silme işlemi
        private void btnsil_Click(object sender, EventArgs e)
        {
            try
            {
                ds.datasilme(txtad.Text);
                MessageBox.Show("kayıt silindi");
            }
            catch
            {
                MessageBox.Show("Değerleri Kontrol Ediniz");
            }
            
        }

        //güncelleme işlemi
        private void btngüncelle_Click(object sender, EventArgs e)
        {

            try
            {
                ds.datagüncelleme(txtad.Text, txtsoyad.Text, txtokulno.Text, txttc.Text);
                MessageBox.Show("Güncelleme işlemi başarılı");
            }
            catch
            {
                MessageBox.Show("Değerleri Kontrol Ediniz");
            }
            
        }

        //form açıldığında imlec ad dan başlasın
        private void Form1_Load(object sender, EventArgs e)
        {
            txtad.Focus();
        }
    }
}
