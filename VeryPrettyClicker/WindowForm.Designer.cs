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
            this.components = new System.ComponentModel.Container();
            this.panelExpand = new System.Windows.Forms.Panel();
            this.stopBlockPanel = new System.Windows.Forms.Panel();
            this.blockPanel = new System.Windows.Forms.Panel();
            this.labelHotkey = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.blockPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelExpand
            // 
            this.panelExpand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panelExpand.BackgroundImage = global::VeryPrettyClicker.Properties.Resources.expand;
            this.panelExpand.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelExpand.Location = new System.Drawing.Point(4, 6);
            this.panelExpand.Name = "panelExpand";
            this.panelExpand.Size = new System.Drawing.Size(11, 12);
            this.panelExpand.TabIndex = 0;
            this.panelExpand.Click += new System.EventHandler(this.panelExpand_Click);
            // 
            // stopBlockPanel
            // 
            this.stopBlockPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.stopBlockPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.stopBlockPanel.BackgroundImage = global::VeryPrettyClicker.Properties.Resources.icon_locked;
            this.stopBlockPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.stopBlockPanel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.stopBlockPanel.Location = new System.Drawing.Point(474, 30);
            this.stopBlockPanel.Name = "stopBlockPanel";
            this.stopBlockPanel.Size = new System.Drawing.Size(16, 16);
            this.stopBlockPanel.TabIndex = 0;
            this.stopBlockPanel.Click += new System.EventHandler(this.stopBlockPanel_Click);
            // 
            // blockPanel
            // 
            this.blockPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.blockPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.blockPanel.BackgroundImage = global::VeryPrettyClicker.Properties.Resources.lock_outline;
            this.blockPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.blockPanel.Controls.Add(this.labelHotkey);
            this.blockPanel.Location = new System.Drawing.Point(4, 0);
            this.blockPanel.Name = "blockPanel";
            this.blockPanel.Size = new System.Drawing.Size(485, 46);
            this.blockPanel.TabIndex = 1;
            // 
            // labelHotkey
            // 
            this.labelHotkey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.labelHotkey.BackColor = System.Drawing.Color.Transparent;
            this.labelHotkey.Font = new System.Drawing.Font("Open Sans", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelHotkey.ForeColor = System.Drawing.Color.White;
            this.labelHotkey.Location = new System.Drawing.Point(270, 0);
            this.labelHotkey.Name = "labelHotkey";
            this.labelHotkey.Size = new System.Drawing.Size(102, 46);
            this.labelHotkey.TabIndex = 0;
            this.labelHotkey.Text = "label1";
            this.labelHotkey.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // WindowForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::VeryPrettyClicker.Properties.Resources.row;
            this.ClientSize = new System.Drawing.Size(490, 46);
            this.ControlBox = false;
            this.Controls.Add(this.stopBlockPanel);
            this.Controls.Add(this.panelExpand);
            this.Controls.Add(this.blockPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "WindowForm";
            this.Text = "WindowForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WindowForm_FormClosing);
            this.Load += new System.EventHandler(this.WindowForm_Load);
            this.blockPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelExpand;
        private System.Windows.Forms.Panel stopBlockPanel;
        private System.Windows.Forms.Panel blockPanel;
        private System.Windows.Forms.Label labelHotkey;
        private System.Windows.Forms.ToolTip toolTip;
    }
}