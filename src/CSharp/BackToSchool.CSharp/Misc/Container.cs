using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackToSchool.CSharp.Misc
{
    public class Container : IContainer
    {
        private readonly List<int> _values = new List<int>();

        public Container()
        {
            // write your code here
        }

        public void Add(int value)
        {
            // write your code here
            _values.Add(value);
        }

        public bool Delete(int value)
        {
            // write your code here
            var indexOf = _values.IndexOf(value);
            if (indexOf > -1)
            {
                _values.RemoveAt(indexOf);
                return true;
            }

            return false;
        }

        public int GetMedian()
        {
            _values.Sort();
            
            // write your code here
            var valueCount = _values.Count;

            if (valueCount % 2 == 0)
            {
                var idx = (valueCount / 2) - 1;
                return _values[idx];
            }
            else
            {
                var idx = Math.Floor((decimal)valueCount / 2);
                return _values[int.Parse(idx.ToString())];
            }

            return 0;
        }
    }

    /// <summary>
    /// A container of integers that should support
    /// addition, removal, and search for the median integer
    /// </summary>
    public interface IContainer
    {
        /// <summary>
        /// Adds the specified value to the container
        /// </summary>
        /// <param name="value"></param>
        void Add(int value);

        /// <summary>
        /// Attempts to delete one item of the specified value from the container
        /// </summary>
        /// <param name="value"></param>
        /// <returns>
        /// true, if the value has been deleted,
        /// or false, otherwise
        /// </returns>
        bool Delete(int value);

        /// <summary>
        /// Finds the container's median integer value, which is
        /// the middle integer when the all integers are sorted in order.
        /// If the sorted array has an even length,
        /// the leftmost integer between the two middle
        /// integers should be considered as the median.
        /// </summary>
        /// <returns>the median if the array is not empty, or</returns>
        /// <throws>a runtime exception, otherwise.</throws>
        int GetMedian();
    }
}
