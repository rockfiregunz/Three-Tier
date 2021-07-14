using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Three_Tier.Model
{
    public class Member
    {
        [Key]
        public int Id { set;get;}
        public string Name { set; get; }
        public char Del { set; get; }
    }

    public class MemberInfo
    {
        [Key]
     //   [ForeignKey("Id")]
        public int MId { set; get; }
        public string Sex { set; get; }
        //    public Member Member { set;get;}

    }
}
