using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateDynamicTextBoxes.Classes
{
    public class SingleButtonItem
    {
        public int Tag { get; set; }
        public string Text { get; set; }

        public override string ToString() => $"{Text}, {Tag}";

    }
}
