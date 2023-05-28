namespace Books_with_pictures
{
    partial class Form1
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
            this.loadPictureMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showOneMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.showAllMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.coverPictureBox = new System.Windows.Forms.PictureBox();
            this.booksDataGrid = new System.Windows.Forms.DataGridView();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.coverPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.booksDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadPictureMenuItem,
            this.showOneMenuItem,
            this.findTextBox,
            this.showAllMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 27);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // loadPictureMenuItem
            // 
            this.loadPictureMenuItem.Name = "loadPictureMenuItem";
            this.loadPictureMenuItem.Size = new System.Drawing.Size(85, 23);
            this.loadPictureMenuItem.Text = "Load Picture";
            this.loadPictureMenuItem.Click += new System.EventHandler(this.loadPictureMenuItem_Click);
            // 
            // showOneMenuItem
            // 
            this.showOneMenuItem.Name = "showOneMenuItem";
            this.showOneMenuItem.Size = new System.Drawing.Size(73, 23);
            this.showOneMenuItem.Text = "Show One";
            this.showOneMenuItem.Click += new System.EventHandler(this.showOneMenuItem_Click);
            // 
            // findTextBox
            // 
            this.findTextBox.Name = "findTextBox";
            this.findTextBox.Size = new System.Drawing.Size(100, 23);
            // 
            // showAllMenuItem
            // 
            this.showAllMenuItem.Name = "showAllMenuItem";
            this.showAllMenuItem.Size = new System.Drawing.Size(65, 23);
            this.showAllMenuItem.Text = "Show All";
            this.showAllMenuItem.Click += new System.EventHandler(this.showAllMenuItem_Click);
            // 
            // coverPictureBox
            // 
            this.coverPictureBox.Location = new System.Drawing.Point(465, 39);
            this.coverPictureBox.Name = "coverPictureBox";
            this.coverPictureBox.Size = new System.Drawing.Size(323, 399);
            this.coverPictureBox.TabIndex = 1;
            this.coverPictureBox.TabStop = false;
            // 
            // booksDataGrid
            // 
            this.booksDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.booksDataGrid.Location = new System.Drawing.Point(12, 39);
            this.booksDataGrid.Name = "booksDataGrid";
            this.booksDataGrid.RowTemplate.Height = 25;
            this.booksDataGrid.Size = new System.Drawing.Size(447, 399);
            this.booksDataGrid.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.booksDataGrid);
            this.Controls.Add(this.coverPictureBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.coverPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.booksDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem loadPictureMenuItem;
        private ToolStripMenuItem showOneMenuItem;
        private ToolStripTextBox findTextBox;
        private ToolStripMenuItem showAllMenuItem;
        private PictureBox coverPictureBox;
        private DataGridView booksDataGrid;
    }
}