using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CreateDynamicTextBoxes.Classes;

namespace CreateDynamicTextBoxes
{
    public partial class SingleItemForm : Form
    {
        public SingleItemForm()
        {
            InitializeComponent();
            
            Shown += OnShown;
        }

        private void OnShown(object sender, EventArgs e)
        {

            var ops = new CreateSingleButtonItems
            {
                ParentControl = flowLayoutPanel1, 
                BaseAddition = 60, 
                ButtonBaseName = "btn", 
                ButtonSize = new Size(100, 50)
            };
            
            ops.Create(Mocked.List);
            ops.Buttons.ForEach(button => button.Click += ButtonOnClick );
        }

        private void ButtonOnClick(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (int.TryParse(button.Tag.ToString(), out var identifier))
            {
                MessageBox.Show($"{button.Text} - {identifier}");
            }
        }
    }
}
