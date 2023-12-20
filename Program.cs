using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChipSecuritySystem
{
    class Program
    {
        static void Main()
        {
            // Example usage
            List<ColorChip> chips = new List<ColorChip>
            {
                new ColorChip(Color.Blue, Color.Yellow),
                new ColorChip(Color.Yellow, Color.Red),
                new ColorChip(Color.Red, Color.Green),   
            };

            Color startColor = Color.Blue;
            Color endColor = Color.Green;

            bool isValidSequence = IsSequenceValid(chips, startColor, endColor);

            if (isValidSequence)
            {
                Console.WriteLine("Valid sequence found.");
            }
            else
            {
                Console.WriteLine("No valid sequence found.");
            }
        }
        static bool IsSequenceValid(List<ColorChip> chips, Color startColor, Color endColor)
        {
            Stack<Color> colorStack = new Stack<Color>();

            foreach (var chip in chips)
            {
                if (colorStack.Count == 0)
                {
                    colorStack.Push(chip.StartColor);
                    colorStack.Push(chip.EndColor);
                }
                else
                {
                    if (colorStack.Peek() == chip.StartColor)
                    {
                        colorStack.Push(chip.EndColor);
                    }
                    else if (colorStack.Peek() == chip.EndColor)
                    {
                        colorStack.Push(chip.StartColor);
                    }
                    else
                    {

                        return false;
                    }
                }
            }

            if(colorStack.Count > 0 && colorStack.Peek() == endColor)
            {
                return true;
            }
            
            return false;
           
        }
    }

}
