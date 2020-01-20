using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using auctionfinal.DAL;

namespace auctionfinal.Iservice
{
    interface Iservice
    {
         Boolean save(player player);
         Boolean update(player player);
         Boolean delete(int a);
        player[] getall();
         player getbyid(int a);

    }
}
