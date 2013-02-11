namespace UniApplikation
{
    partial class UniApplikation
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dateiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.speichernToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.öffnenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.schließenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bearbeitenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.excellistenLadenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.excellistenBearbeitenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sucheToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kurseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verwaltenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.einfügenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.berechnenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusExcellists = new System.Windows.Forms.ToolStripStatusLabel();
            this.contentPanelDefault = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dateiToolStripMenuItem,
            this.bearbeitenToolStripMenuItem,
            this.kurseToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(880, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dateiToolStripMenuItem
            // 
            this.dateiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.speichernToolStripMenuItem,
            this.öffnenToolStripMenuItem,
            this.schließenToolStripMenuItem});
            this.dateiToolStripMenuItem.Name = "dateiToolStripMenuItem";
            this.dateiToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.dateiToolStripMenuItem.Text = "Datei";
            // 
            // speichernToolStripMenuItem
            // 
            this.speichernToolStripMenuItem.Enabled = false;
            this.speichernToolStripMenuItem.Name = "speichernToolStripMenuItem";
            this.speichernToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.speichernToolStripMenuItem.Text = "Speichern";
            this.speichernToolStripMenuItem.Click += new System.EventHandler(this.speichernToolStripMenuItem_Click);
            // 
            // öffnenToolStripMenuItem
            // 
            this.öffnenToolStripMenuItem.Enabled = false;
            this.öffnenToolStripMenuItem.Name = "öffnenToolStripMenuItem";
            this.öffnenToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.öffnenToolStripMenuItem.Text = "Öffnen";
            // 
            // schließenToolStripMenuItem
            // 
            this.schließenToolStripMenuItem.Name = "schließenToolStripMenuItem";
            this.schließenToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.schließenToolStripMenuItem.Text = "Schließen";
            this.schließenToolStripMenuItem.Click += new System.EventHandler(this.schließenToolStripMenuItem_Click);
            // 
            // bearbeitenToolStripMenuItem
            // 
            this.bearbeitenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.excellistenLadenToolStripMenuItem,
            this.excellistenBearbeitenToolStripMenuItem,
            this.sucheToolStripMenuItem});
            this.bearbeitenToolStripMenuItem.Name = "bearbeitenToolStripMenuItem";
            this.bearbeitenToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.bearbeitenToolStripMenuItem.Text = "Bearbeiten";
            // 
            // excellistenLadenToolStripMenuItem
            // 
            this.excellistenLadenToolStripMenuItem.Name = "excellistenLadenToolStripMenuItem";
            this.excellistenLadenToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.excellistenLadenToolStripMenuItem.Text = "Excellisten laden";
            this.excellistenLadenToolStripMenuItem.Click += new System.EventHandler(this.excellistenLadenToolStripMenuItem_Click);
            // 
            // excellistenBearbeitenToolStripMenuItem
            // 
            this.excellistenBearbeitenToolStripMenuItem.Enabled = false;
            this.excellistenBearbeitenToolStripMenuItem.Name = "excellistenBearbeitenToolStripMenuItem";
            this.excellistenBearbeitenToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.excellistenBearbeitenToolStripMenuItem.Text = "Excellisten bearbeiten";
            // 
            // sucheToolStripMenuItem
            // 
            this.sucheToolStripMenuItem.Enabled = false;
            this.sucheToolStripMenuItem.Name = "sucheToolStripMenuItem";
            this.sucheToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.sucheToolStripMenuItem.Text = "Suche";
            // 
            // kurseToolStripMenuItem
            // 
            this.kurseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verwaltenToolStripMenuItem,
            this.einfügenToolStripMenuItem,
            this.berechnenToolStripMenuItem});
            this.kurseToolStripMenuItem.Name = "kurseToolStripMenuItem";
            this.kurseToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.kurseToolStripMenuItem.Text = "Kurse";
            // 
            // verwaltenToolStripMenuItem
            // 
            this.verwaltenToolStripMenuItem.Name = "verwaltenToolStripMenuItem";
            this.verwaltenToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.verwaltenToolStripMenuItem.Text = "Verwalten";
            this.verwaltenToolStripMenuItem.Click += new System.EventHandler(this.verwaltenToolStripMenuItem_Click);
            // 
            // einfügenToolStripMenuItem
            // 
            this.einfügenToolStripMenuItem.Name = "einfügenToolStripMenuItem";
            this.einfügenToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.einfügenToolStripMenuItem.Text = "Einfügen";
            // 
            // berechnenToolStripMenuItem
            // 
            this.berechnenToolStripMenuItem.Name = "berechnenToolStripMenuItem";
            this.berechnenToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.berechnenToolStripMenuItem.Text = "Berechnen";
            this.berechnenToolStripMenuItem.Click += new System.EventHandler(this.berechnenToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.statusExcellists});
            this.statusStrip1.Location = new System.Drawing.Point(0, 422);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(880, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(109, 17);
            this.toolStripStatusLabel1.Text = "Excellisten geladen:";
            // 
            // statusExcellists
            // 
            this.statusExcellists.Name = "statusExcellists";
            this.statusExcellists.Size = new System.Drawing.Size(32, 17);
            this.statusExcellists.Text = "Nein";
            // 
            // contentPanelDefault
            // 
            this.contentPanelDefault.Location = new System.Drawing.Point(12, 27);
            this.contentPanelDefault.Name = "contentPanelDefault";
            this.contentPanelDefault.Size = new System.Drawing.Size(856, 392);
            this.contentPanelDefault.TabIndex = 2;
            // 
            // UniApplikation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 444);
            this.Controls.Add(this.contentPanelDefault);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "UniApplikation";
            this.Text = "Universitäts Applikation";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dateiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem speichernToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem öffnenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem schließenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bearbeitenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem excellistenLadenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem excellistenBearbeitenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sucheToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel statusExcellists;
        private System.Windows.Forms.Panel contentPanelDefault;
        private System.Windows.Forms.ToolStripMenuItem kurseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verwaltenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem einfügenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem berechnenToolStripMenuItem;

    }
}

