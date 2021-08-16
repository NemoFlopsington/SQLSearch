using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLSearch
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            RepoLocationTxt.Text = @"C:\Users\Nehemiah\Documents\coding stuff\SQLSearch\SQLSearch\sqlRepo";
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            string searchText = SearchTxt.Text;
            string author = AuthorTxt.Text;
            string repoLocation = RepoLocationTxt.Text;

        }
    }
}
