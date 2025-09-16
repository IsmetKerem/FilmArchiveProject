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

namespace FilmArchiveProject
{
    public partial class FilmPaneli : Form
    {
        public FilmPaneli()
        {
            InitializeComponent();
        }
        // Data Source=localhost;Initial Catalog=FilmArchiveDb;Integrated Security=True;Trust Server Certificate=True
        SqlConnection baglanti = new SqlConnection(@"Data Source=localhost;Initial Catalog=FilmArchiveDb;Integrated Security=True");

        void RastgeleRenk()
        {
            Random rnd = new Random();
            this.BackColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
        }
        void filmler ()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * from TBLFILMLER",baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            filmler();

        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into TBLFILMLER (AD,KATEGORI,LINK) values (@p1,@p2,@p3)",baglanti);
            komut.Parameters.AddWithValue("@p1",txtfilmad.Text);
            komut.Parameters.AddWithValue("@p2",txtkategori.Text);  
            komut.Parameters.AddWithValue("@p3",txtlink.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Film Listenize Başarıyla Eklendi !","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            string link = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            webBrowser1.Navigate(link);
        }

        private void btnhakkimizda_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bu Proje İsmet Kerem Eren tarafından 16 Eylül 2025'de Kodlandı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
           
        }

        private void btncikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnrenkdegistir_Click(object sender, EventArgs e)
        {
            RastgeleRenk();
        }

        private void btntamekran_Click(object sender, EventArgs e)
        {
            Tamekran frm = new Tamekran();
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            frm.film = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            frm.Show();
        }
    }
}
