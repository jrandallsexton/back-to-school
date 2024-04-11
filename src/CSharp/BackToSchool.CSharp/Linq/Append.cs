using System;
using System.Collections.Generic;
using System.Linq;

namespace BackToSchool.CSharp.Linq
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.append?view=net-8.0
    /// </summary>
    public class Append
    {
        public void AppendNumbers()
        {
            // Creating a list of numbers
            List<int> numbers = new List<int> { 1, 2, 3, 4 };

            // Trying to append any value of the same type
            numbers.Append(5);

            // It doesn't work because the original list has not been changed
            Console.WriteLine(string.Join(", ", numbers));

            // It works now because we are using a changed copy of the original list
            Console.WriteLine(string.Join(", ", numbers.Append(5)));

            // If you prefer, you can create a new list explicitly
            List<int> newNumbers = numbers.Append(5).ToList();

            // And then write to the console output
            Console.WriteLine(string.Join(", ", newNumbers));

            // This code produces the following output:
            //
            // 1, 2, 3, 4
            // 1, 2, 3, 4, 5
            // 1, 2, 3, 4, 5
        }
    }
}
