using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZooRunner.GUI
{
    public partial class ControlPanel : UserControl
    {
        ZooAdapter _zoo;
        List<AnimalAdapter> _animals;
        bool _timer;
        AnimalsRedering _animalsRedering;
        ToolTip _animalsCountToolTip;

        public ControlPanel()
        {
            InitializeComponent();
            _animals = new List<AnimalAdapter>();
            _timer = false;
            _animalsRedering = new AnimalsRedering();
            _animalsCountToolTip = new ToolTip();
        }

        public event EventHandler<ZooAdapter> UserGivesDll;
        public event EventHandler<List<AnimalAdapter>> TimerTick;
        public event EventHandler<int> BoxCountChange;
        public event EventHandler<bool> ShowGridLines;
        public event EventHandler<AnimalsRedering> AnimalsRederingChange;
        public event EventHandler<string> Backgroundsaved;

        private void _dllBouton_Click( object sender, EventArgs e )
        {
            if( _dllOpenFileDialog.ShowDialog() == DialogResult.OK )
            {
                _zoo = ZooAdapter.Load( _dllOpenFileDialog.FileName );
                UserGivesDll?.Invoke( this, _zoo );
                this.Text = _dllOpenFileDialog.FileName;
                _animals.Clear();
                _createAnimalsBouton.Enabled = true;
                _gameLoopBouton.Enabled = true;
                _boxCountLabel.Enabled = true;
                _boxCountNumericUpDown.Enabled = true;
                _showGridLinesCheckBox.Enabled = true;
                _representationButton.Enabled = true;
                _calculatorButton.Enabled = true;
                _engineTextBox.Enabled = true;
                if( _zoo.CollectColorAtMethod ) _backgroundSaveButton.Enabled = true;
            }
        }

        private void _createAnimalsBouton_Click( object sender, EventArgs e )
        {
            CreateAnimals createAnimals = new CreateAnimals( _zoo );
            if( createAnimals.ShowDialog() == DialogResult.OK )
            {
                _animals.AddRange( createAnimals.Animals );
                _animalsCountToolTip.SetToolTip( _createAnimalsBouton, "Animals count : " + _animals.Count.ToString() );
            }
            createAnimals.Dispose();
        }

        private void _gameLoopBouton_Click( object sender, EventArgs e )
        {
            if( _timer == false )
            {
                _gameLoopTimer.Start();
                _timer = true;
                _timerTrackBar.Enabled = true;
                _slowLabel.Enabled = true;
                _fastLabel.Enabled = true;
                _dllBouton.Enabled = false;
            }
            else
            {
                _timer = false;
                _gameLoopTimer.Stop();
                _timerTrackBar.Value = 1;
                _timerTrackBar.Enabled = false;
                _slowLabel.Enabled = false;
                _fastLabel.Enabled = false;
                _dllBouton.Enabled = true;
            }
        }

        private void _timerTrackBar_ValueChanged( object sender, EventArgs e )
        {
            _gameLoopTimer.Interval = 1000 / _timerTrackBar.Value;
        }

        private void _gameLoopTimer_Tick( object sender, EventArgs e )
        {
            _zoo.Update();
            for( int i = _animals.Count - 1; i >= 0; i-- )
            {
                if( !_animals[ i ].IsAlive ) _animals.RemoveAt( i );
            }
            _animalsCountToolTip.SetToolTip( _createAnimalsBouton, "Animals count : " + _animals.Count.ToString() );
            TimerTick?.Invoke( this, _animals );
        }

        private void _boxCountNumericUpDown_ValueChanged( object sender, EventArgs e )
        {
            BoxCountChange?.Invoke( this, ( int )_boxCountNumericUpDown.Value );
        }

        private void _showGridLinesCheckBox_CheckedChanged( object sender, EventArgs e )
        {
            ShowGridLines?.Invoke( sender, _showGridLinesCheckBox.Checked );
        }

        private void _representationButton_Click( object sender, EventArgs e )
        {
            AnimalsRepresentation representation = new AnimalsRepresentation( _zoo, _animalsRedering );
            if( representation.ShowDialog() == DialogResult.OK )
            {
                AnimalsRederingChange?.Invoke( this, _animalsRedering ); // (même adresse mémoire), créer une liste intermediaire
            }
            representation.Dispose();
        }

        private void _calculatorButton_Click( object sender, EventArgs e )
        {
            System.Diagnostics.Process.Start( "calc" );
        }

        public void DisplayEngineInformations( string infos )
        {
            _engineTextBox.Text = infos;
        }

        private void _backgroundSaveButton_Click( object sender, EventArgs e )
        {
            _backgroundSaveFileDialog.Filter = "jpg file (*.jpg)|*.jpg";
            _backgroundSaveFileDialog.ShowDialog();
        }

        private void _backgoundsaveFileDialog_FileOk( object sender, CancelEventArgs e )
        {
            Backgroundsaved?.Invoke( this, _backgroundSaveFileDialog.FileName );
        }

        private void ControlPanel_Load( object sender, EventArgs e )
        {
            _animalsCountToolTip.SetToolTip( _createAnimalsBouton, "Animals count : " + _animals.Count.ToString() );
        }
    }
}
