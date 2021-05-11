using System.Collections.Generic;
using System.Windows.Forms;

namespace CreateDynamicTextBoxes
{
    public static class LanguageExtensions
    {
        public static List<TextBox> TextBoxList(this Control sender)
        {
            List<TextBox> tbList = new List<TextBox>();

            Control ctrl = sender.GetNextControl(sender, true);

            while (ctrl != null)
            {
                if (ctrl is TextBox box)
                {
                    box.Text = "Hello";
                    tbList.Add(box);
                }
                ctrl = sender.GetNextControl(ctrl, true);
            }

            return tbList;
        }
    }
}