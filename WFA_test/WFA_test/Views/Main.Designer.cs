namespace WFA_test.Views
{
    partial class Main
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
            this.components = new System.ComponentModel.Container();
            this.lstView_Table = new System.Windows.Forms.ListView();
            this.imgList_Table = new System.Windows.Forms.ImageList(this.components);
            this.cMenuShip_Table = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsMenuItem_Open = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMenuItem_Cancel = new System.Windows.Forms.ToolStripMenuItem();
            this.cMenuShip_Table.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstView_Table
            // 
            this.lstView_Table.Location = new System.Drawing.Point(7, 26);
            this.lstView_Table.Name = "lstView_Table";
            this.lstView_Table.Size = new System.Drawing.Size(473, 292);
            this.lstView_Table.TabIndex = 0;
            this.lstView_Table.UseCompatibleStateImageBehavior = false;
            this.lstView_Table.View = System.Windows.Forms.View.Tile;
            this.lstView_Table.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lstView_Table_MouseClick);
            // 
            // imgList_Table
            // 
            this.imgList_Table.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imgList_Table.ImageSize = new System.Drawing.Size(16, 16);
            this.imgList_Table.TransparentColor = System.Drawing.Color.Maroon;
            // 
            // cMenuShip_Table
            // 
            this.cMenuShip_Table.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsMenuItem_Open,
            this.tsMenuItem_Cancel});
            this.cMenuShip_Table.Name = "contextMenuStrip1";
            this.cMenuShip_Table.Size = new System.Drawing.Size(153, 70);
            // 
            // tsMenuItem_Open
            // 
            this.tsMenuItem_Open.Name = "tsMenuItem_Open";
            this.tsMenuItem_Open.Size = new System.Drawing.Size(152, 22);
            this.tsMenuItem_Open.Text = "Open";
            this.tsMenuItem_Open.Click += new System.EventHandler(this.tsMenuItem_Open_Click);
            // 
            // tsMenuItem_Cancel
            // 
            this.tsMenuItem_Cancel.Name = "tsMenuItem_Cancel";
            this.tsMenuItem_Cancel.Size = new System.Drawing.Size(152, 22);
            this.tsMenuItem_Cancel.Text = "Cancel";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(970, 353);
            this.Controls.Add(this.lstView_Table);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Main_Load);
            this.cMenuShip_Table.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lstView_Table;
        private System.Windows.Forms.ImageList imgList_Table;
        private System.Windows.Forms.ContextMenuStrip cMenuShip_Table;
        private System.Windows.Forms.ToolStripMenuItem tsMenuItem_Open;
        private System.Windows.Forms.ToolStripMenuItem tsMenuItem_Cancel;




    }
}