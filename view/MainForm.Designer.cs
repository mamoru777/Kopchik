
namespace view
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.myComboBox1 = new Kop_bibl.MyComboBox();
            this.shablonTextBox1 = new Kop_bibl.ShablonTextBox();
            this.SuspendLayout();
            // 
            // myComboBox1
            // 
            this.myComboBox1.Location = new System.Drawing.Point(56, 36);
            this.myComboBox1.Name = "myComboBox1";
            this.myComboBox1.SelectedElement = "";
            this.myComboBox1.Size = new System.Drawing.Size(164, 163);
            this.myComboBox1.TabIndex = 0;
            // 
            // shablonTextBox1
            // 
            this.shablonTextBox1.Location = new System.Drawing.Point(294, 36);
            this.shablonTextBox1.Name = "shablonTextBox1";
            this.shablonTextBox1.Pattern = "^\\+*\\d{1,11}(-\\d{3}-\\d{3}-\\d{2,4}(-\\d{2})*)*$";
            this.shablonTextBox1.Size = new System.Drawing.Size(150, 150);
            this.shablonTextBox1.TabIndex = 1;
            this.shablonTextBox1.Value = "";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.shablonTextBox1);
            this.Controls.Add(this.myComboBox1);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private Kop_bibl.MyComboBox myComboBox1;
        private Kop_bibl.ShablonTextBox shablonTextBox1;
    }
}

