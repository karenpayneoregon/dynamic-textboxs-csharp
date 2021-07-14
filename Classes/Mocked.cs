using System.Collections.Generic;

namespace CreateDynamicTextBoxes.Classes
{
    public class Mocked
    {
        public static List<SingleButtonItem> List => new List<SingleButtonItem>()
        {
            new SingleButtonItem() {Tag = 1, Text = "Mazda"},
            new SingleButtonItem() {Tag = 2, Text = "Ford"},
            new SingleButtonItem() {Tag = 3, Text = "BMW"},
            new SingleButtonItem() {Tag = 4, Text = "Tesla"},
            new SingleButtonItem() {Tag = 5, Text = "Chevy"},
            new SingleButtonItem() {Tag = 6, Text = "Honda"}
        };
    }
}