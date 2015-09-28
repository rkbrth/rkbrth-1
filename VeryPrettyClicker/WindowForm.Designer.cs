namespace VeryPrettyClicker
{
    partial class WindowForm
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
            this.panelExpand = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panelExpand
            // 
            this.panelExpand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panelExpand.BackgroundImage = global::VeryPrettyClicker.Properties.Resources.expand;
            this.panelExpand.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelExpand.Location = new System.Drawing.Point(4, 25);
            this.panelExpand.Name = "panelExpand";
            this.panelExpand.Size = new System.Drawing.Size(11, 12);
            this.panelExpand.TabIndex = 0;
            this.panelExpand.Click += new System.EventHandler(this.panelExpand_Click);
            // 
            // WindowForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::VeryPrettyClicker.Properties.Resources.row;
            this.ClientSize = new System.Drawing.Size(490, 46);
            this.ControlBox = false;
            this.Controls.Add(this.panelExpand);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "WindowForm";
            this.Text = "WindowForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WindowForm_FormClosing);
            this.Load += new System.EventHandler(this.WindowForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelExpand;
    }
}