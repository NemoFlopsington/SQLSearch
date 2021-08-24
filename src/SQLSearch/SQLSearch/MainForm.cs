using BusinessLogic;
using BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLSearch
{
    public partial class MainForm : Form
    {
        List<ScriptInfo> validScripts;
        public MainForm()
        {
            InitializeComponent();
            //RepoLocationTxt.Text = @"C:\Users\Nehemiah\Documents\coding stuff\SQLSearch\SQLSearch\sqlRepo";
            RepoLocationTxt.Text = System.Configuration.ConfigurationManager.AppSettings["SqlRepo"];
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            Scriptslsv.Items.Clear();
            string searchText = SearchTxt.Text;
            string author = AuthorTxt.Text;
            string repoLocation = RepoLocationTxt.Text;
            validScripts = new SearchInitial(searchText, author, repoLocation).Run();
            stopWatch.Stop();
            foreach (ScriptInfo scriptInfo in validScripts)
                Scriptslsv.Items.Add(scriptInfo.fileName);
            LoadedTimerLbl.Visible = true;
            LoadedTimerLbl.Text = "Search completed in: " + stopWatch.ElapsedMilliseconds.ToString() + " milliseconds";
        }

        private void Scriptslsv_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Scriptslsv.SelectedItems.Count == 0)
                return;
            var selectedItemText = Scriptslsv.SelectedItems[0].Text;
            ScriptInfo selectedItem = new ScriptInfo();
            foreach(ScriptInfo script in validScripts)
            {
                if(selectedItemText == script.fileName)
                {
                    selectedItem = script;
                    break;
                }
            }
            string displayText = "Author: "+selectedItem.Author +"\nDescription: "+ selectedItem.description + "\nTags: "+ selectedItem.tags.ToString();
            ScriptInfoDisplayTxt.Lines = new string[] { "Author: " + selectedItem.Author, "Description: " + selectedItem.description, "Tags: " + tagsToString(selectedItem.tags) };
            //ScriptInfoDisplayTxt.Text = displayText;

        }

        private string tagsToString(List<string> tags)
        {
            string returnVal = "";
            var tagsArray = tags.ToArray();
                for (int i = 0; i < tags.Count - 1; i++)
                    returnVal += tagsArray[i] + ", ";
            returnVal += tagsArray[tags.Count - 1];
            return returnVal;
        }

        private void SearchTxt_Enter(object sender, KeyPressEventArgs e)
        {
            handleEnterKey(e);
        }

        private void AuthorTxt_keyPress(object sender, KeyPressEventArgs e)
        {
            handleEnterKey(e);
        }
        private void handleEnterKey(KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                SearchBtn.PerformClick();
            }
        }
    }
}
