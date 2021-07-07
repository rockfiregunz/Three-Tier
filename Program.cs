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
            try
            {
                var _repo = new MemberRepo();
                var data    =   _repo.FindAll(x=>x.Id>0);
                Console.WriteLine("A");
                Console.WriteLine(data.Count());
                Console.WriteLine("B");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            

        }
    }
}
