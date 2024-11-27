using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Activity_lab
{
    internal class Validation
    {
        public void chkName(string n)
        {
            if (n.Length > 15)
            {
                throw new Exception("Name must be less than 15 characters");

            }
            else if (n.Length == 0)
            {
                throw new Exception("Name is required");
            }
        }
    }
}
