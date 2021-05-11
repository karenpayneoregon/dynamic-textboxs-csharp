using System;

namespace CreateDynamicTextBoxes.Classes
{
    public class IdentifierButtonEventArgs : EventArgs
    {
        public IdentifierButtonEventArgs(int id)
        {
            Identifier = id;
        }

        public int Identifier { get; set; }
    }
}
