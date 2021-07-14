using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CreateDynamicTextBoxes.Classes
{
    public class CreateSingleButtonItems
    {
        /// <summary>
        /// Size to create each button
        /// </summary>
        /// <returns></returns>
        public  Size ButtonSize { get; set; }
        /// <summary>
        /// Provides a reference to your buttons
        /// </summary>
        /// <returns></returns>
        public  List<Button> Buttons { get; set; }
        /// <summary>
        /// base name of button e.g. btn, cmd etc.
        /// </summary>
        /// <returns></returns>
        public string ButtonBaseName { get; set; }

        /// <summary>
        /// Used to spread out buttons
        /// </summary>
        /// <returns></returns>
        public int Base { get; set; } = 10;
        public int BaseAddition { get; set; }
        /// <summary>
        /// Count of buttons
        /// </summary>
        /// <returns></returns>
        public int ButtonCount { get; set; }
        /// <summary>
        /// control to place buttons onto
        /// </summary>
        /// <returns></returns>
        public Control ParentControl { get; set; }
        public EventHandler<IdentifierButtonEventArgs> ClickedHandler;

        public void Create(List<SingleButtonItem> sender)
        {
            Buttons = new List<Button>();
            ButtonCount = sender.Count - 1;

            foreach (var item in sender)
            {
                Button button = new Button
                {
                    Name = string.Concat(ButtonBaseName, item.Text),
                    Text = item.Text,
                    Tag = item.Tag,
                    Size = ButtonSize,
                    Location = new Point(25, 10),
                    Parent = ParentControl,
                    Visible = true
                };

                ParentControl.Controls.Add(button);
                Buttons.Add(button);
                Base += BaseAddition;

            }
        }
    }
}
