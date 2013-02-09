namespace UniApplikation.Controls
{
    partial class CoursesCalculationControll
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
            this.startCalculation = new System.Windows.Forms.Button();
            this.excelExport = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // startCalculation
            // 
            this.startCalculation.Location = new System.Drawing.Point(4, 4);
            this.startCalculation.Name = "startCalculation";
            this.startCalculation.Size = new System.Drawing.Size(75, 23);
            this.startCalculation.TabIndex = 0;
            this.startCalculation.Text = "Start";
            this.startCalculation.UseVisualStyleBackColor = true;
            this.startCalculation.Click += new System.EventHandler(this.startCalculation_Click);
            // 
            // excelExport
            // 
            this.excelExport.Enabled = false;
            this.excelExport.Location = new System.Drawing.Point(4, 34);
            this.excelExport.Name = "excelExport";
            this.excelExport.Size = new System.Drawing.Size(157, 23);
            this.excelExport.TabIndex = 1;
            this.excelExport.Text = "Nach Excel exportieren";
            this.excelExport.UseVisualStyleBackColor = true;
            this.excelExport.Click += new System.EventHandler(this.excelExport_Click);
            // 
            // CoursesCalculationControll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.excelExport);
            this.Controls.Add(this.startCalculation);
            this.Name = "CoursesCalculationControll";
            this.Size = new System.Drawing.Size(434, 150);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button startCalculation;
        private System.Windows.Forms.Button excelExport;
    }
}
