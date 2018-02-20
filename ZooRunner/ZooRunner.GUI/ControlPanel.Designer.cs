namespace ZooRunner.GUI
{
    partial class ControlPanel
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
            this.components = new System.ComponentModel.Container();
            this._panel = new System.Windows.Forms.Panel();
            this._backgroundSaveButton = new System.Windows.Forms.Button();
            this._engineTextBox = new System.Windows.Forms.TextBox();
            this._calculatorButton = new System.Windows.Forms.Button();
            this._representationButton = new System.Windows.Forms.Button();
            this._showGridLinesCheckBox = new System.Windows.Forms.CheckBox();
            this._boxCountLabel = new System.Windows.Forms.Label();
            this._boxCountNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this._fastLabel = new System.Windows.Forms.Label();
            this._slowLabel = new System.Windows.Forms.Label();
            this._timerTrackBar = new System.Windows.Forms.TrackBar();
            this._gameLoopBouton = new System.Windows.Forms.Button();
            this._createAnimalsBouton = new System.Windows.Forms.Button();
            this._dllBouton = new System.Windows.Forms.Button();
            this._dllOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this._gameLoopTimer = new System.Windows.Forms.Timer(this.components);
            this._backgroundSaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this._panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._boxCountNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._timerTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // _panel
            // 
            this._panel.Controls.Add(this._backgroundSaveButton);
            this._panel.Controls.Add(this._engineTextBox);
            this._panel.Controls.Add(this._calculatorButton);
            this._panel.Controls.Add(this._representationButton);
            this._panel.Controls.Add(this._showGridLinesCheckBox);
            this._panel.Controls.Add(this._boxCountLabel);
            this._panel.Controls.Add(this._boxCountNumericUpDown);
            this._panel.Controls.Add(this._fastLabel);
            this._panel.Controls.Add(this._slowLabel);
            this._panel.Controls.Add(this._timerTrackBar);
            this._panel.Controls.Add(this._gameLoopBouton);
            this._panel.Controls.Add(this._createAnimalsBouton);
            this._panel.Controls.Add(this._dllBouton);
            this._panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._panel.Location = new System.Drawing.Point(0, 0);
            this._panel.Margin = new System.Windows.Forms.Padding(2);
            this._panel.Name = "_panel";
            this._panel.Size = new System.Drawing.Size(620, 96);
            this._panel.TabIndex = 0;
            // 
            // _backgroundSaveButton
            // 
            this._backgroundSaveButton.Enabled = false;
            this._backgroundSaveButton.Location = new System.Drawing.Point(6, 39);
            this._backgroundSaveButton.Name = "_backgroundSaveButton";
            this._backgroundSaveButton.Size = new System.Drawing.Size(104, 23);
            this._backgroundSaveButton.TabIndex = 12;
            this._backgroundSaveButton.Text = "Save background";
            this._backgroundSaveButton.UseVisualStyleBackColor = true;
            this._backgroundSaveButton.Click += new System.EventHandler(this._backgroundSaveButton_Click);
            // 
            // _engineTextBox
            // 
            this._engineTextBox.Enabled = false;
            this._engineTextBox.Location = new System.Drawing.Point(344, 39);
            this._engineTextBox.Multiline = true;
            this._engineTextBox.Name = "_engineTextBox";
            this._engineTextBox.ReadOnly = true;
            this._engineTextBox.Size = new System.Drawing.Size(270, 49);
            this._engineTextBox.TabIndex = 11;
            // 
            // _calculatorButton
            // 
            this._calculatorButton.Enabled = false;
            this._calculatorButton.Location = new System.Drawing.Point(116, 39);
            this._calculatorButton.Name = "_calculatorButton";
            this._calculatorButton.Size = new System.Drawing.Size(75, 23);
            this._calculatorButton.TabIndex = 10;
            this._calculatorButton.Text = "Calculator";
            this._calculatorButton.UseVisualStyleBackColor = true;
            this._calculatorButton.Click += new System.EventHandler(this._calculatorButton_Click);
            // 
            // _representationButton
            // 
            this._representationButton.Enabled = false;
            this._representationButton.Location = new System.Drawing.Point(163, 2);
            this._representationButton.Name = "_representationButton";
            this._representationButton.Size = new System.Drawing.Size(98, 26);
            this._representationButton.TabIndex = 9;
            this._representationButton.Text = "Representation";
            this._representationButton.UseVisualStyleBackColor = true;
            this._representationButton.Click += new System.EventHandler(this._representationButton_Click);
            // 
            // _showGridLinesCheckBox
            // 
            this._showGridLinesCheckBox.AutoSize = true;
            this._showGridLinesCheckBox.Enabled = false;
            this._showGridLinesCheckBox.Location = new System.Drawing.Point(168, 74);
            this._showGridLinesCheckBox.Name = "_showGridLinesCheckBox";
            this._showGridLinesCheckBox.Size = new System.Drawing.Size(97, 17);
            this._showGridLinesCheckBox.TabIndex = 8;
            this._showGridLinesCheckBox.Text = "Show grid lines";
            this._showGridLinesCheckBox.UseVisualStyleBackColor = true;
            this._showGridLinesCheckBox.CheckedChanged += new System.EventHandler(this._showGridLinesCheckBox_CheckedChanged);
            // 
            // _boxCountLabel
            // 
            this._boxCountLabel.AutoSize = true;
            this._boxCountLabel.Enabled = false;
            this._boxCountLabel.Location = new System.Drawing.Point(3, 75);
            this._boxCountLabel.Name = "_boxCountLabel";
            this._boxCountLabel.Size = new System.Drawing.Size(61, 13);
            this._boxCountLabel.TabIndex = 7;
            this._boxCountLabel.Text = "Box count :";
            // 
            // _boxCountNumericUpDown
            // 
            this._boxCountNumericUpDown.Enabled = false;
            this._boxCountNumericUpDown.Location = new System.Drawing.Point(70, 73);
            this._boxCountNumericUpDown.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this._boxCountNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this._boxCountNumericUpDown.Name = "_boxCountNumericUpDown";
            this._boxCountNumericUpDown.Size = new System.Drawing.Size(92, 20);
            this._boxCountNumericUpDown.TabIndex = 6;
            this._boxCountNumericUpDown.Tag = "";
            this._boxCountNumericUpDown.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this._boxCountNumericUpDown.ValueChanged += new System.EventHandler(this._boxCountNumericUpDown_ValueChanged);
            // 
            // _fastLabel
            // 
            this._fastLabel.AutoSize = true;
            this._fastLabel.Enabled = false;
            this._fastLabel.Location = new System.Drawing.Point(587, 9);
            this._fastLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this._fastLabel.Name = "_fastLabel";
            this._fastLabel.Size = new System.Drawing.Size(27, 13);
            this._fastLabel.TabIndex = 5;
            this._fastLabel.Text = "Fast";
            // 
            // _slowLabel
            // 
            this._slowLabel.AutoSize = true;
            this._slowLabel.Enabled = false;
            this._slowLabel.Location = new System.Drawing.Point(341, 9);
            this._slowLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this._slowLabel.Name = "_slowLabel";
            this._slowLabel.Size = new System.Drawing.Size(30, 13);
            this._slowLabel.TabIndex = 4;
            this._slowLabel.Text = "Slow";
            // 
            // _timerTrackBar
            // 
            this._timerTrackBar.Enabled = false;
            this._timerTrackBar.LargeChange = 1;
            this._timerTrackBar.Location = new System.Drawing.Point(372, 3);
            this._timerTrackBar.Margin = new System.Windows.Forms.Padding(2);
            this._timerTrackBar.Maximum = 7;
            this._timerTrackBar.Minimum = 1;
            this._timerTrackBar.Name = "_timerTrackBar";
            this._timerTrackBar.Size = new System.Drawing.Size(215, 45);
            this._timerTrackBar.TabIndex = 2;
            this._timerTrackBar.Value = 1;
            this._timerTrackBar.ValueChanged += new System.EventHandler(this._timerTrackBar_ValueChanged);
            // 
            // _gameLoopBouton
            // 
            this._gameLoopBouton.Enabled = false;
            this._gameLoopBouton.Location = new System.Drawing.Point(266, 2);
            this._gameLoopBouton.Margin = new System.Windows.Forms.Padding(2);
            this._gameLoopBouton.Name = "_gameLoopBouton";
            this._gameLoopBouton.Size = new System.Drawing.Size(71, 26);
            this._gameLoopBouton.TabIndex = 2;
            this._gameLoopBouton.Text = "Game loop";
            this._gameLoopBouton.UseVisualStyleBackColor = true;
            this._gameLoopBouton.Click += new System.EventHandler(this._gameLoopBouton_Click);
            // 
            // _createAnimalsBouton
            // 
            this._createAnimalsBouton.Enabled = false;
            this._createAnimalsBouton.Location = new System.Drawing.Point(66, 2);
            this._createAnimalsBouton.Margin = new System.Windows.Forms.Padding(2);
            this._createAnimalsBouton.Name = "_createAnimalsBouton";
            this._createAnimalsBouton.Size = new System.Drawing.Size(92, 26);
            this._createAnimalsBouton.TabIndex = 1;
            this._createAnimalsBouton.Text = "Create animals";
            this._createAnimalsBouton.UseVisualStyleBackColor = true;
            this._createAnimalsBouton.Click += new System.EventHandler(this._createAnimalsBouton_Click);
            // 
            // _dllBouton
            // 
            this._dllBouton.Location = new System.Drawing.Point(6, 2);
            this._dllBouton.Margin = new System.Windows.Forms.Padding(2);
            this._dllBouton.Name = "_dllBouton";
            this._dllBouton.Size = new System.Drawing.Size(56, 26);
            this._dllBouton.TabIndex = 0;
            this._dllBouton.Text = "DLL";
            this._dllBouton.UseVisualStyleBackColor = true;
            this._dllBouton.Click += new System.EventHandler(this._dllBouton_Click);
            // 
            // _gameLoopTimer
            // 
            this._gameLoopTimer.Interval = 10000;
            this._gameLoopTimer.Tick += new System.EventHandler(this._gameLoopTimer_Tick);
            // 
            // _backgroundSaveFileDialog
            // 
            this._backgroundSaveFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this._backgoundsaveFileDialog_FileOk);
            // 
            // ControlPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._panel);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ControlPanel";
            this.Size = new System.Drawing.Size(620, 96);
            this.Load += new System.EventHandler(this.ControlPanel_Load);
            this._panel.ResumeLayout(false);
            this._panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._boxCountNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._timerTrackBar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel _panel;
        private System.Windows.Forms.Button _dllBouton;
        private System.Windows.Forms.Button _createAnimalsBouton;
        private System.Windows.Forms.Button _gameLoopBouton;
        private System.Windows.Forms.TrackBar _timerTrackBar;
        private System.Windows.Forms.Label _fastLabel;
        private System.Windows.Forms.Label _slowLabel;
        private System.Windows.Forms.OpenFileDialog _dllOpenFileDialog;
        private System.Windows.Forms.Timer _gameLoopTimer;
        private System.Windows.Forms.Label _boxCountLabel;
        private System.Windows.Forms.NumericUpDown _boxCountNumericUpDown;
        private System.Windows.Forms.CheckBox _showGridLinesCheckBox;
        private System.Windows.Forms.Button _representationButton;
        private System.Windows.Forms.Button _calculatorButton;
        private System.Windows.Forms.TextBox _engineTextBox;
        private System.Windows.Forms.Button _backgroundSaveButton;
        private System.Windows.Forms.SaveFileDialog _backgroundSaveFileDialog;
    }
}
