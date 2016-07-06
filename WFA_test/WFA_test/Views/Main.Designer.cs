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
            this.dgv_Table = new System.Windows.Forms.DataGridView();
            this.p_Table = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Table)).BeginInit();
            this.p_Table.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_Table
            // 
            this.dgv_Table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Table.Location = new System.Drawing.Point(3, 3);
            this.dgv_Table.Name = "dgv_Table";
            this.dgv_Table.Size = new System.Drawing.Size(380, 234);
            this.dgv_Table.TabIndex = 0;
            // 
            // p_Table
            // 
            this.p_Table.Controls.Add(this.dgv_Table);
            this.p_Table.Location = new System.Drawing.Point(12, 12);
            this.p_Table.Name = "p_Table";
            this.p_Table.Size = new System.Drawing.Size(437, 277);
            this.p_Table.TabIndex = 1;
            this.p_Table.Paint += new System.Windows.Forms.PaintEventHandler(this.p_Table_Paint);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 301);
            this.Controls.Add(this.p_Table);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Table)).EndInit();
            this.p_Table.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_Table;
        private System.Windows.Forms.Panel p_Table;
    }
}