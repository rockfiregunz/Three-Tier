using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Three_Tier.Model
{
    class Member
    {
        [Key]
        public int Id { set;get;}
        public string Name { set; get; }
        public char Del { set; get; }
    }
}
