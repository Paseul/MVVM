using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.Model
{
    public class DataRange
    {
        private int _range;
        public int Range
        {
            get { return _range; }
            set { _range = value; }
        }
    }
}
