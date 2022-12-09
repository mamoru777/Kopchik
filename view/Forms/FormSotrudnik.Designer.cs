
namespace view.Forms
{
    partial class FormSotrudnik
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
            this.textBoxFio = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxAuto = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.controlSelectedComboBoxList1 = new ControlsLibraryNet50.Selected.ControlSelectedComboBoxList();
            this.label4 = new System.Windows.Forms.Label();
            this.SaveButton = new System.Windows.Forms.Button();
            this.controlInputNullableDate1 = new ControlsLibraryNet50.Input.ControlInputNullableDate();
            this.SuspendLayout();
            // 
            // textBoxFio
            // 
            this.textBoxFio.Location = new System.Drawing.Point(116, 34);
            this.textBoxFio.Name = "textBoxFio";
            this.textBoxFio.Size = new System.Drawing.Size(178, 23);
            this.textBoxFio.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "ФИО";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Автобиография";
            // 
            // textBoxAuto
            // 
            this.textBoxAuto.Location = new System.Drawing.Point(116, 101);
            this.textBoxAuto.Name = "textBoxAuto";
            this.textBoxAuto.Size = new System.Drawing.Size(178, 23);
            this.textBoxAuto.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 169);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Должность";
            // 
            // controlSelectedComboBoxList1
            // 
            this.controlSelectedComboBoxList1.Location = new System.Drawing.Point(116, 169);
            this.controlSelectedComboBoxList1.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.controlSelectedComboBoxList1.Name = "controlSelectedComboBoxList1";
            this.controlSelectedComboBoxList1.SelectedElement = "";
            this.controlSelectedComboBoxList1.Size = new System.Drawing.Size(178, 24);
            this.controlSelectedComboBoxList1.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(12, 229);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 51);
            this.label4.TabIndex = 6;
            this.label4.Text = "Дата повышения квалификации";
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(140, 315);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 8;
            this.SaveButton.Text = "Сохранить";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // controlInputNullableDate1
            // 
            this.controlInputNullableDate1.Location = new System.Drawing.Point(107, 242);
            this.controlInputNullableDate1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.controlInputNullableDate1.Name = "controlInputNullableDate1";
            this.controlInputNullableDate1.Size = new System.Drawing.Size(187, 23);
            this.controlInputNullableDate1.TabIndex = 9;
            this.controlInputNullableDate1.Value = null;
            // 
            // FormSotrudnik
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 363);
            this.Controls.Add(this.controlInputNullableDate1);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.controlSelectedComboBoxList1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxAuto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxFio);
            this.Name = "FormSotrudnik";
            this.Text = "FormSotrudnik";
            this.Load += new System.EventHandler(this.FormSotrudnik_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxFio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxAuto;
        private System.Windows.Forms.Label label3;
        private ControlsLibraryNet50.Selected.ControlSelectedComboBoxList controlSelectedComboBoxList1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button SaveButton;
        private ControlsLibraryNet50.Input.ControlInputNullableDate controlInputNullableDate1;
    }
}