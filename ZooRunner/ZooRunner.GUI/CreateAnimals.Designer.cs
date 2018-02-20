namespace ZooRunner.GUI
{
    partial class CreateAnimals
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateAnimals));
            this._okButton = new System.Windows.Forms.Button();
            this._cancelButton = new System.Windows.Forms.Button();
            this._addButton = new System.Windows.Forms.Button();
            this._animalsComboBox = new System.Windows.Forms.ComboBox();
            this._animalsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this._animalsLabel = new System.Windows.Forms.Label();
            this._numberLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this._animalsNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // _okButton
            // 
            this._okButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this._okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._okButton.Location = new System.Drawing.Point(107, 97);
            this._okButton.Margin = new System.Windows.Forms.Padding(2);
            this._okButton.Name = "_okButton";
            this._okButton.Size = new System.Drawing.Size(56, 26);
            this._okButton.TabIndex = 0;
            this._okButton.Text = "OK";
            this._okButton.UseVisualStyleBackColor = true;
            // 
            // _cancelButton
            // 
            this._cancelButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._cancelButton.Location = new System.Drawing.Point(201, 97);
            this._cancelButton.Margin = new System.Windows.Forms.Padding(2);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(56, 26);
            this._cancelButton.TabIndex = 1;
            this._cancelButton.Text = "Cancel";
            this._cancelButton.UseVisualStyleBackColor = true;
            // 
            // _addButton
            // 
            this._addButton.Location = new System.Drawing.Point(305, 51);
            this._addButton.Margin = new System.Windows.Forms.Padding(2);
            this._addButton.Name = "_addButton";
            this._addButton.Size = new System.Drawing.Size(56, 21);
            this._addButton.TabIndex = 6;
            this._addButton.Text = "Add";
            this._addButton.UseVisualStyleBackColor = true;
            this._addButton.Click += new System.EventHandler(this._addButton_Click);
            // 
            // _animalsComboBox
            // 
            this._animalsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._animalsComboBox.FormattingEnabled = true;
            this._animalsComboBox.Location = new System.Drawing.Point(61, 51);
            this._animalsComboBox.Margin = new System.Windows.Forms.Padding(2);
            this._animalsComboBox.Name = "_animalsComboBox";
            this._animalsComboBox.Size = new System.Drawing.Size(92, 21);
            this._animalsComboBox.TabIndex = 7;
            // 
            // _animalsNumericUpDown
            // 
            this._animalsNumericUpDown.Location = new System.Drawing.Point(211, 51);
            this._animalsNumericUpDown.Margin = new System.Windows.Forms.Padding(2);
            this._animalsNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this._animalsNumericUpDown.Name = "_animalsNumericUpDown";
            this._animalsNumericUpDown.Size = new System.Drawing.Size(90, 20);
            this._animalsNumericUpDown.TabIndex = 8;
            this._animalsNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // _animalsLabel
            // 
            this._animalsLabel.AutoSize = true;
            this._animalsLabel.Location = new System.Drawing.Point(11, 54);
            this._animalsLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this._animalsLabel.Name = "_animalsLabel";
            this._animalsLabel.Size = new System.Drawing.Size(49, 13);
            this._animalsLabel.TabIndex = 9;
            this._animalsLabel.Text = "Animals :";
            // 
            // _numberLabel
            // 
            this._numberLabel.AutoSize = true;
            this._numberLabel.Location = new System.Drawing.Point(157, 54);
            this._numberLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this._numberLabel.Name = "_numberLabel";
            this._numberLabel.Size = new System.Drawing.Size(50, 13);
            this._numberLabel.TabIndex = 10;
            this._numberLabel.Text = "Number :";
            // 
            // CreateAnimals
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 134);
            this.Controls.Add(this._animalsLabel);
            this.Controls.Add(this._addButton);
            this.Controls.Add(this._numberLabel);
            this.Controls.Add(this._animalsComboBox);
            this.Controls.Add(this._cancelButton);
            this.Controls.Add(this._okButton);
            this.Controls.Add(this._animalsNumericUpDown);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "CreateAnimals";
            this.Text = "Create Animals";
            this.Load += new System.EventHandler(this.CreateAnimals_Load);
            ((System.ComponentModel.ISupportInitialize)(this._animalsNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _okButton;
        private System.Windows.Forms.Button _cancelButton;
        private System.Windows.Forms.Button _addButton;
        private System.Windows.Forms.ComboBox _animalsComboBox;
        private System.Windows.Forms.NumericUpDown _animalsNumericUpDown;
        private System.Windows.Forms.Label _animalsLabel;
        private System.Windows.Forms.Label _numberLabel;
    }
}