using BusinessLogic;
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
            Scriptslsv.Items.Clear();
            string searchText = SearchTxt.Text;
            string author = AuthorTxt.Text;
            string repoLocation = RepoLocationTxt.Text;
            var validScripts = new SearchInitial(searchText, author, repoLocation).Run();
            var validScriptsCount = validScripts.Count;
            var scriptNames = validScripts.Keys;
            for (int i = 0; 
                i < validScriptsCount; i++)
            {
                var keyOfMaxValue = validScripts.Aggregate((x, y) => x.Value > y.Value ? x : y).Key;
                Scriptslsv.Items.Add(keyOfMaxValue);
                validScripts.Remove(keyOfMaxValue);
            }
        }
    }
}
