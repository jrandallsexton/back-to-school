using System;
using System.Text;

namespace BackToSchool.CSharp.Misc
{
    /// <summary>
    /// We can render an ASCII art pyramid with N levels by printing N rows of asterisks, where the top row has a single asterisk in the center and each successive row has two additional asterisks on either side.
    /// </summary>
    public class AsciiArt
    {
        public string Draw(int nRows)
        {
            var sb = new StringBuilder();
            for (var i = 1; i <= nRows; i++)
            {
                sb.AppendLine(new string(' ', nRows - i) + new string('*', (i * 2) - 1));
            }
            Console.WriteLine(sb.ToString());
            return sb.ToString();
        }
    }
}
