namespace VeryPrettyClicker
{
    partial class IntervalPicker
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
            this.buttonAccept = new System.Windows.Forms.Button();
            this.numericUpDown = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonAccept
            // 
            this.buttonAccept.BackColor = System.Drawing.Color.Transparent;
            this.buttonAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonAccept.FlatAppearance.BorderSize = 0;
            this.buttonAccept.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonAccept.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAccept.Font = new System.Drawing.Font("Open Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAccept.Image = global::VeryPrettyClicker.Properties.Resources.button_ok;
            this.buttonAccept.Location = new System.Drawing.Point(110, 9);
            this.buttonAccept.Name = "buttonAccept";
            this.buttonAccept.Size = new System.Drawing.Size(79, 23);
            this.buttonAccept.TabIndex = 0;
            this.buttonAccept.UseVisualStyleBackColor = false;
            this.buttonAccept.Click += new System.EventHandler(this.buttonAccept_Click);
            // 
            // numericUpDown
            // 
            this.numericUpDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.numericUpDown.Cursor = System.Windows.Forms.Cursors.Default;
            this.numericUpDown.DecimalPlaces = 2;
            this.numericUpDown.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericUpDown.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.numericUpDown.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numericUpDown.Location = new System.Drawing.Point(12, 6);
            this.numericUpDown.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numericUpDown.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.numericUpDown.Name = "numericUpDown";
            this.numericUpDown.Size = new System.Drawing.Size(92, 29);
            this.numericUpDown.TabIndex = 1;
            this.numericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown.ValueChanged += new System.EventHandler(this.numericUpDown_ValueChanged);
            // 
            // IntervalPicker
            // 
            this.AcceptButton = this.buttonAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(200, 42);
            this.ControlBox = false;
            this.Controls.Add(this.numericUpDown);
            this.Controls.Add(this.buttonAccept);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "IntervalPicker";
            this.ShowInTaskbar = false;
            this.Text = "IntervalPicker";
            this.Load += new System.EventHandler(this.IntervalPicker_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonAccept;
        private System.Windows.Forms.NumericUpDown numericUpDown;
    }
}