
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.справочникToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.должностиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.действияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьCtrlAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.изменитьCtrlUToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьCtrlDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.документыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.простойДокументCtrlSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.документСТаблицейCtrlTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.диаграммаCtrlCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.controlDataTreeTable1 = new ControlsLibraryNet50.Data.ControlDataTreeTable();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.справочникToolStripMenuItem,
            this.действияToolStripMenuItem,
            this.документыToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(591, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // справочникToolStripMenuItem
            // 
            this.справочникToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.должностиToolStripMenuItem});
            this.справочникToolStripMenuItem.Name = "справочникToolStripMenuItem";
            this.справочникToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
            this.справочникToolStripMenuItem.Text = "Справочник";
            // 
            // должностиToolStripMenuItem
            // 
            this.должностиToolStripMenuItem.Name = "должностиToolStripMenuItem";
            this.должностиToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.должностиToolStripMenuItem.Text = "Должности";
            this.должностиToolStripMenuItem.Click += new System.EventHandler(this.продуктыToolStripMenuItem_Click);
            // 
            // действияToolStripMenuItem
            // 
            this.действияToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьCtrlAToolStripMenuItem,
            this.изменитьCtrlUToolStripMenuItem,
            this.удалитьCtrlDToolStripMenuItem});
            this.действияToolStripMenuItem.Name = "действияToolStripMenuItem";
            this.действияToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.действияToolStripMenuItem.Text = "Действия";
            // 
            // добавитьCtrlAToolStripMenuItem
            // 
            this.добавитьCtrlAToolStripMenuItem.Name = "добавитьCtrlAToolStripMenuItem";
            this.добавитьCtrlAToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.добавитьCtrlAToolStripMenuItem.Text = "Добавить    Ctrl + A";
            this.добавитьCtrlAToolStripMenuItem.Click += new System.EventHandler(this.добавитьCtrlAToolStripMenuItem_Click);
            // 
            // изменитьCtrlUToolStripMenuItem
            // 
            this.изменитьCtrlUToolStripMenuItem.Name = "изменитьCtrlUToolStripMenuItem";
            this.изменитьCtrlUToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.изменитьCtrlUToolStripMenuItem.Text = "Изменить   Ctrl + U";
            this.изменитьCtrlUToolStripMenuItem.Click += new System.EventHandler(this.изменитьCtrlUToolStripMenuItem_Click);
            // 
            // удалитьCtrlDToolStripMenuItem
            // 
            this.удалитьCtrlDToolStripMenuItem.Name = "удалитьCtrlDToolStripMenuItem";
            this.удалитьCtrlDToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.удалитьCtrlDToolStripMenuItem.Text = "Удалить       Ctrl + D";
            this.удалитьCtrlDToolStripMenuItem.Click += new System.EventHandler(this.удалитьCtrlDToolStripMenuItem_Click);
            // 
            // документыToolStripMenuItem
            // 
            this.документыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.простойДокументCtrlSToolStripMenuItem,
            this.документСТаблицейCtrlTToolStripMenuItem,
            this.диаграммаCtrlCToolStripMenuItem});
            this.документыToolStripMenuItem.Name = "документыToolStripMenuItem";
            this.документыToolStripMenuItem.Size = new System.Drawing.Size(82, 20);
            this.документыToolStripMenuItem.Text = "Документы";
            // 
            // простойДокументCtrlSToolStripMenuItem
            // 
            this.простойДокументCtrlSToolStripMenuItem.Name = "простойДокументCtrlSToolStripMenuItem";
            this.простойДокументCtrlSToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.простойДокументCtrlSToolStripMenuItem.Text = "Простой документ          Ctrl + S";
            this.простойДокументCtrlSToolStripMenuItem.Click += new System.EventHandler(this.простойДокументCtrlSToolStripMenuItem_Click);
            // 
            // документСТаблицейCtrlTToolStripMenuItem
            // 
            this.документСТаблицейCtrlTToolStripMenuItem.Name = "документСТаблицейCtrlTToolStripMenuItem";
            this.документСТаблицейCtrlTToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.документСТаблицейCtrlTToolStripMenuItem.Text = "Документ с таблицей     Ctrl + T";
            this.документСТаблицейCtrlTToolStripMenuItem.Click += new System.EventHandler(this.документСТаблицейCtrlTToolStripMenuItem_Click);
            // 
            // диаграммаCtrlCToolStripMenuItem
            // 
            this.диаграммаCtrlCToolStripMenuItem.Name = "диаграммаCtrlCToolStripMenuItem";
            this.диаграммаCtrlCToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.диаграммаCtrlCToolStripMenuItem.Text = "Диаграмма                       Ctrl + C";
            this.диаграммаCtrlCToolStripMenuItem.Click += new System.EventHandler(this.диаграммаCtrlCToolStripMenuItem_Click);
            // 
            // controlDataTreeTable1
            // 
            this.controlDataTreeTable1.Location = new System.Drawing.Point(13, 27);
            this.controlDataTreeTable1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.controlDataTreeTable1.Name = "controlDataTreeTable1";
            this.controlDataTreeTable1.Size = new System.Drawing.Size(564, 360);
            this.controlDataTreeTable1.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 403);
            this.Controls.Add(this.controlDataTreeTable1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Сотрудники";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormMain_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem справочникToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem должностиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem действияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem добавитьCtrlAToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem изменитьCtrlUToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьCtrlDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem документыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem простойДокументCtrlSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem документСТаблицейCtrlTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem диаграммаCtrlCToolStripMenuItem;
        private ControlsLibraryNet50.Data.ControlDataTreeTable controlDataTreeTable1;
    }
}

