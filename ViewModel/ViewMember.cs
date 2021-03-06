using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Three_Tier.ViewModel
{

    public class ViewMember
    {
        [Key]
        public int Id { set; get; }
        public string Name { set; get; }
        public char Del { set; get; }
        public int FK_Id { set; get; }
        public char Sex { set; get; }
        public Byte Zip { set; get; }
        public string Addr { set; get; }
    }
}
