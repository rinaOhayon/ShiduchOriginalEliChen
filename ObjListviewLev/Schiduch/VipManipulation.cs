using System;
using System.Collections.Generic;
using System.Text;

namespace Schiduch
{
    class VipManipulation
    {
        public static bool ChadchanOnTheList(string query)
        {
            if (query.Contains("{" + GLOBALVARS.MyUser.ID.ToString() + "}"))
                return true;
            return false;
        }
        
    }
}
