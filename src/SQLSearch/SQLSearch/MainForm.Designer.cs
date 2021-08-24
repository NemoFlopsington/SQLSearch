namespace SQLSearch
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.RepoLocationTxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.AuthorTxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SearchTxt = new System.Windows.Forms.TextBox();
            this.SearchBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.Scriptslsv = new System.Windows.Forms.ListView();
            this.ScriptInfoDisplayTxt = new System.Windows.Forms.TextBox();
            this.LoadedTimerLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // RepoLocationTxt
            // 
            this.RepoLocationTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RepoLocationTxt.Location = new System.Drawing.Point(12, 29);
            this.RepoLocationTxt.Name = "RepoLocationTxt";
            this.RepoLocationTxt.Size = new System.Drawing.Size(252, 26);
            this.RepoLocationTxt.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(56, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "RepoLocation";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 184);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Author";
            // 
            // AuthorTxt
            // 
            this.AuthorTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AuthorTxt.Location = new System.Drawing.Point(80, 184);
            this.AuthorTxt.Name = "AuthorTxt";
            this.AuthorTxt.Size = new System.Drawing.Size(189, 26);
            this.AuthorTxt.TabIndex = 2;
            this.AuthorTxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AuthorTxt_keyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(115, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(221, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "What are you wanting to do?";
            // 
            // SearchTxt
            // 
            this.SearchTxt.AcceptsReturn = true;
            this.SearchTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchTxt.Location = new System.Drawing.Point(80, 107);
            this.SearchTxt.MinimumSize = new System.Drawing.Size(100, 100);
            this.SearchTxt.Name = "SearchTxt";
            this.SearchTxt.Size = new System.Drawing.Size(317, 26);
            this.SearchTxt.TabIndex = 4;
            this.SearchTxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SearchTxt_Enter);
            // 
            // SearchBtn
            // 
            this.SearchBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchBtn.Location = new System.Drawing.Point(296, 229);
            this.SearchBtn.Name = "SearchBtn";
            this.SearchBtn.Size = new System.Drawing.Size(101, 35);
            this.SearchBtn.TabIndex = 6;
            this.SearchBtn.Text = "Search";
            this.SearchBtn.UseVisualStyleBackColor = true;
            this.SearchBtn.Click += new System.EventHandler(this.SearchBtn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(525, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Scripts";
            // 
            // Scriptslsv
            // 
            this.Scriptslsv.HideSelection = false;
            this.Scriptslsv.Location = new System.Drawing.Point(421, 55);
            this.Scriptslsv.MultiSelect = false;
            this.Scriptslsv.Name = "Scriptslsv";
            this.Scriptslsv.Size = new System.Drawing.Size(336, 244);
            this.Scriptslsv.TabIndex = 9;
            this.Scriptslsv.UseCompatibleStateImageBehavior = false;
            this.Scriptslsv.View = System.Windows.Forms.View.List;
            this.Scriptslsv.SelectedIndexChanged += new System.EventHandler(this.Scriptslsv_SelectedIndexChanged);
            // 
            // ScriptInfoDisplayTxt
            // 
            this.ScriptInfoDisplayTxt.AcceptsReturn = true;
            this.ScriptInfoDisplayTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ScriptInfoDisplayTxt.Location = new System.Drawing.Point(296, 305);
            this.ScriptInfoDisplayTxt.Multiline = true;
            this.ScriptInfoDisplayTxt.Name = "ScriptInfoDisplayTxt";
            this.ScriptInfoDisplayTxt.ReadOnly = true;
            this.ScriptInfoDisplayTxt.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ScriptInfoDisplayTxt.Size = new System.Drawing.Size(461, 167);
            this.ScriptInfoDisplayTxt.TabIndex = 10;
            // 
            // LoadedTimerLbl
            // 
            this.LoadedTimerLbl.AutoSize = true;
            this.LoadedTimerLbl.Location = new System.Drawing.Point(526, 29);
            this.LoadedTimerLbl.Name = "LoadedTimerLbl";
            this.LoadedTimerLbl.Size = new System.Drawing.Size(98, 17);
            this.LoadedTimerLbl.TabIndex = 11;
            this.LoadedTimerLbl.Text = "Completed in: ";
            this.LoadedTimerLbl.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 509);
            this.Controls.Add(this.LoadedTimerLbl);
            this.Controls.Add(this.ScriptInfoDisplayTxt);
            this.Controls.Add(this.Scriptslsv);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.SearchBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.SearchTxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.AuthorTxt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RepoLocationTxt);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox RepoLocationTxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox AuthorTxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox SearchTxt;
        private System.Windows.Forms.Button SearchBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListView Scriptslsv;
        private System.Windows.Forms.TextBox ScriptInfoDisplayTxt;
        private System.Windows.Forms.Label LoadedTimerLbl;
    }
}

