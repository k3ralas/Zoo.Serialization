namespace ZooRunner.GUI
{
    partial class Informations
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
            this._zoomTextBox = new System.Windows.Forms.TextBox();
            this._watchsTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // _zoomTextBox
            // 
            this._zoomTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this._zoomTextBox.Location = new System.Drawing.Point(0, 0);
            this._zoomTextBox.Multiline = true;
            this._zoomTextBox.Name = "_zoomTextBox";
            this._zoomTextBox.ReadOnly = true;
            this._zoomTextBox.Size = new System.Drawing.Size(150, 32);
            this._zoomTextBox.TabIndex = 0;
            // 
            // _watchsTextBox
            // 
            this._watchsTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._watchsTextBox.Location = new System.Drawing.Point(0, 32);
            this._watchsTextBox.Multiline = true;
            this._watchsTextBox.Name = "_watchsTextBox";
            this._watchsTextBox.ReadOnly = true;
            this._watchsTextBox.Size = new System.Drawing.Size(150, 118);
            this._watchsTextBox.TabIndex = 1;
            // 
            // Informations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._watchsTextBox);
            this.Controls.Add(this._zoomTextBox);
            this.Enabled = false;
            this.Name = "Informations";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox _zoomTextBox;
        private System.Windows.Forms.TextBox _watchsTextBox;
    }
}
