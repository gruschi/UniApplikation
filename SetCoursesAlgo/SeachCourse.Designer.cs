namespace SetCoursesAlgo
{
    partial class SeachCourse
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtCourseName = new System.Windows.Forms.Label();
            this.cBSelectCourse = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Search Course: ";
            // 
            // txtCourseName
            // 
            this.txtCourseName.AutoSize = true;
            this.txtCourseName.Location = new System.Drawing.Point(125, 9);
            this.txtCourseName.Name = "txtCourseName";
            this.txtCourseName.Size = new System.Drawing.Size(35, 13);
            this.txtCourseName.TabIndex = 1;
            this.txtCourseName.Text = "label2";
            // 
            // cBSelectCourse
            // 
            this.cBSelectCourse.FormattingEnabled = true;
            this.cBSelectCourse.Location = new System.Drawing.Point(14, 81);
            this.cBSelectCourse.Name = "cBSelectCourse";
            this.cBSelectCourse.Size = new System.Drawing.Size(341, 21);
            this.cBSelectCourse.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(60, 135);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Select Course:";
            // 
            // SeachCourse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 205);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cBSelectCourse);
            this.Controls.Add(this.txtCourseName);
            this.Controls.Add(this.label1);
            this.Name = "SeachCourse";
            this.Text = "SeachCourse";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label txtCourseName;
        private System.Windows.Forms.ComboBox cBSelectCourse;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
    }
}