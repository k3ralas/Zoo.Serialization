namespace ZooRunner.GUI
{
    partial class AnimalsRepresentation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnimalsRepresentation));
            this._typeLabel = new System.Windows.Forms.Label();
            this._typeComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this._figureComboBox = new System.Windows.Forms.ComboBox();
            this._okButton = new System.Windows.Forms.Button();
            this._cancelButton = new System.Windows.Forms.Button();
            this._colorDialog = new System.Windows.Forms.ColorDialog();
            this._colorButton = new System.Windows.Forms.Button();
            this._modifyButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _typeLabel
            // 
            this._typeLabel.AutoSize = true;
            this._typeLabel.Location = new System.Drawing.Point(12, 70);
            this._typeLabel.Name = "_typeLabel";
            this._typeLabel.Size = new System.Drawing.Size(37, 13);
            this._typeLabel.TabIndex = 0;
            this._typeLabel.Text = "Type :";
            // 
            // _typeComboBox
            // 
            this._typeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._typeComboBox.FormattingEnabled = true;
            this._typeComboBox.Location = new System.Drawing.Point(55, 67);
            this._typeComboBox.Name = "_typeComboBox";
            this._typeComboBox.Size = new System.Drawing.Size(121, 21);
            this._typeComboBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(182, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Representation :";
            // 
            // _figureComboBox
            // 
            this._figureComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._figureComboBox.FormattingEnabled = true;
            this._figureComboBox.Location = new System.Drawing.Point(273, 67);
            this._figureComboBox.Name = "_figureComboBox";
            this._figureComboBox.Size = new System.Drawing.Size(121, 21);
            this._figureComboBox.TabIndex = 3;
            // 
            // _okButton
            // 
            this._okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._okButton.Location = new System.Drawing.Point(165, 119);
            this._okButton.Name = "_okButton";
            this._okButton.Size = new System.Drawing.Size(75, 23);
            this._okButton.TabIndex = 4;
            this._okButton.Text = "Ok";
            this._okButton.UseVisualStyleBackColor = true;
            // 
            // _cancelButton
            // 
            this._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._cancelButton.Location = new System.Drawing.Point(302, 119);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(75, 23);
            this._cancelButton.TabIndex = 5;
            this._cancelButton.Text = "Cancel";
            this._cancelButton.UseVisualStyleBackColor = true;
            // 
            // _colorButton
            // 
            this._colorButton.Location = new System.Drawing.Point(400, 65);
            this._colorButton.Name = "_colorButton";
            this._colorButton.Size = new System.Drawing.Size(75, 23);
            this._colorButton.TabIndex = 6;
            this._colorButton.Text = "Color";
            this._colorButton.UseVisualStyleBackColor = true;
            this._colorButton.Click += new System.EventHandler(this._colorButton_Click);
            // 
            // _modifyButton
            // 
            this._modifyButton.Location = new System.Drawing.Point(480, 65);
            this._modifyButton.Name = "_modifyButton";
            this._modifyButton.Size = new System.Drawing.Size(75, 23);
            this._modifyButton.TabIndex = 7;
            this._modifyButton.Text = "Modify";
            this._modifyButton.UseVisualStyleBackColor = true;
            this._modifyButton.Click += new System.EventHandler(this._modifyButton_Click);
            // 
            // AnimalsRepresentation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 154);
            this.Controls.Add(this._modifyButton);
            this.Controls.Add(this._colorButton);
            this.Controls.Add(this._cancelButton);
            this.Controls.Add(this._okButton);
            this.Controls.Add(this._figureComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._typeComboBox);
            this.Controls.Add(this._typeLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AnimalsRepresentation";
            this.Text = "Animals representation";
            this.Load += new System.EventHandler(this.AnimalsRepresentation_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _typeLabel;
        private System.Windows.Forms.ComboBox _typeComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox _figureComboBox;
        private System.Windows.Forms.Button _okButton;
        private System.Windows.Forms.Button _cancelButton;
        private System.Windows.Forms.ColorDialog _colorDialog;
        private System.Windows.Forms.Button _colorButton;
        private System.Windows.Forms.Button _modifyButton;
    }
}