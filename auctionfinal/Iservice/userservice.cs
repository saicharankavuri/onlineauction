using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using auctionfinal.DAL;

namespace auctionfinal.Iservice
{
    interface userservice
    {
        Boolean save(user user);
        Boolean check(int a);
    }
}
