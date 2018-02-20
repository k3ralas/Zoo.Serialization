using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZooRunner.GUI
{
    public partial class AnimalsRepresentation : Form
    {
        ZooAdapter _zoo;
        AnimalsRedering _animalsRedering;

        public AnimalsRepresentation(ZooAdapter zoo, AnimalsRedering animalsRedering)
        {
            InitializeComponent();
            _zoo = zoo;
            _animalsRedering = animalsRedering;
        }

        private void AnimalsRepresentation_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < _zoo.AnimalTypes.Count; i++)
            {
                _typeComboBox.Items.Add(_zoo.AnimalTypes[i].Name);

            }
            _typeComboBox.SelectedIndex = 0;

            _figureComboBox.Items.Add(Shape.Rectangle);
            _figureComboBox.Items.Add(Shape.Ellipse);
            _figureComboBox.Items.Add(Shape.Triangle);
            _figureComboBox.Items.Add(Shape.Rhombus);
            _figureComboBox.Items.Add(Shape.Star);
            _figureComboBox.SelectedIndex = 0;
        }

        private void _colorButton_Click(object sender, EventArgs e)
        {
            if (_colorDialog.ShowDialog() == DialogResult.OK)
            {
                _colorButton.BackColor = _colorDialog.Color;
            }
        }

        private void _modifyButton_Click(object sender, EventArgs e)
        {
            _animalsRedering.Add
            (
                _typeComboBox.SelectedItem.ToString(),
                //_figureComboBox.SelectedItem.ToString(),
                (Shape)_figureComboBox.SelectedItem,
                _colorDialog.Color
            );       
        }
    }
}
