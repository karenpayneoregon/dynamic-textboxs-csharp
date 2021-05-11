using System;
using System.Drawing;
using System.Windows.Forms;
using CreateDynamicTextBoxes.Classes;
using CreateDynamicTextBoxes_CS;

namespace CreateDynamicTextBoxes
{
    public partial class Form1 : Form
    {
        DataOperations dataOperations = new DataOperations(".\\SQLEXPRESS");
        public Form1()
        {
            InitializeComponent();
        }

        void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            
            /*
             * Configure/set properties to properly
             * place buttons into a container, in this case a Panel
             * along with setting the button size and vertical spacing
             */
            CreateButtons MakeButtons = new CreateButtons()
            {
                ParentControl = panel2,
                Base = 10,
                ButtonBaseName = "btn",
                BaseAddition = 60,
                ButtonSize = new Size(100, 50)
            };

            /*
             * Setup a delegate so that when a button is clicked we
             * can use the tag property which in this case has the primary key
             * back to the record for the current customer in the database table.
             */
            MakeButtons.ClickedHandler += button_Clicker;
            
            /*
             * Generate buttons, CustomerIdentifier will be assigned to the button tag property
             * while CompanyName field is assigned to the Text property of the button.
             */
            MakeButtons.CreateButtonsFromTable(dataOperations.PopulateInitial(), "CustomerIdentifier", "CompanyName");
            
        }
        /// <summary>
        /// For simplicity show all fields brought back in our select statement using
        /// an overload of ToString.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void button_Clicker(object sender, IdentifierButtonEventArgs e)
        {
            dataGridView1.Visible = false;
            dataGridView1.DataSource = null;

            var Customer = dataOperations.GetCustomer(e.Identifier);

            if (checkBox1.Checked)
            {
                customerEditor f = new customerEditor(Customer);

                try
                {
                    if (f.ShowDialog() == DialogResult.OK)
                    {
                        MessageBox.Show(f.Customer.ToString());
                    }
                }
                finally
                {
                    f.Dispose();
                }
            }
            else
            {
                dataGridView1.DataSource = dataOperations.GetOrders(e.Identifier);
                dataGridView1.Visible = true;
            }
        }
    }
}