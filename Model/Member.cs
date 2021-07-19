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
        public string Del { set; get; }
        public virtual MemberInfo info { set;get;}
    }

    public class MemberInfo
    {
        [Key]
        [ForeignKey("Member")]
        public int Id { set; get; }
        public string Sex { set; get; }
        public int? Zip { set; get; }
        public string County { set; get; }
        public string Area { set; get; }
        public string Addr { set; get; }

        public virtual Member Member { set;get;}

    }
}
