using System;
using System.Collections.Generic;
using System.Linq;
using Three_Tier.Model;
using Three_Tier.Repository;

namespace Three_Tier
{
    class Program
    {
        static void Main(string[] args)
        {
            var c = new SqlContext();
            var r = new Random().Next(0, 999);
            var data = new MemberInfo();
            data.Id = 1;

            c.Set<MemberInfo>().Add(data);
            c.SaveChanges();
        }
    }
}
