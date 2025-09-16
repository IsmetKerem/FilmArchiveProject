using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

namespace FilmArchiveProject
{
    public partial class Tamekran : Form
    {
        public Tamekran()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=localhost;Initial Catalog=FilmArchiveDb;Integrated Security=True");
        public string film;

        private void Tamekran_Load(object sender, EventArgs e)
        {
            this.Text = film.ToString();
            this.WindowState = FormWindowState.Maximized;
            webBrowser1.Navigate(this.Text);

        }
    }
}
