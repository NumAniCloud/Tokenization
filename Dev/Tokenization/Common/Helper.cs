using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tokenization.Model.Common
{
    public static class Helper
    {
        public static T[] Wrap<T>(this T item)
        {
            return new T[] { item };
        }
    }
}
