using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickANumber.Data.Model
{
    public class Child
    {
        public int ChildId { get; set; }

        public string Name
        {
            get
            {
                return string.Format("Child {0}", ChildId);
            }
        }
    }
}
