namespace UniApplikation
{
    partial class ManageCourses
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.DgVCourses = new System.Windows.Forms.DataGridView();
            this.saveCourseList = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DgVCourses)).BeginInit();
            this.SuspendLayout();
            // 
            // DgVCourses
            // 
            this.DgVCourses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgVCourses.Location = new System.Drawing.Point(0, 0);
            this.DgVCourses.Name = "DgVCourses";
            this.DgVCourses.Size = new System.Drawing.Size(314, 182);
            this.DgVCourses.TabIndex = 0;
            //this.DgVCourses.DataSource = new App.Classes.CoursesList().getDataTable();
            this.DgVCourses.DataSource = new App.Classes.CoursesList().getDataTable();
            // 
            // saveCourseList
            // 
            this.saveCourseList.Location = new System.Drawing.Point(3, 188);
            this.saveCourseList.Name = "saveCourseList";
            this.saveCourseList.Size = new System.Drawing.Size(75, 23);
            this.saveCourseList.TabIndex = 1;
            this.saveCourseList.Text = "Speichern";
            this.saveCourseList.UseVisualStyleBackColor = true;
            this.saveCourseList.Click += new System.EventHandler(this.saveCourseList_Click);
            // 
            // ManageCourses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.saveCourseList);
            this.Controls.Add(this.DgVCourses);
            this.Name = "ManageCourses";
            this.Size = new System.Drawing.Size(466, 243);
            ((System.ComponentModel.ISupportInitialize)(this.DgVCourses)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DgVCourses;
        private System.Windows.Forms.Button saveCourseList;



    }
}
