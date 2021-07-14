using System;
using System.Collections.Generic;
using System.Data.Entity;
using Three_Tier.Model;
using Three_Tier.ViewModel;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Three_Tier
{
    class SqlContext : DbContext
    {        
        //Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=M:\Project\Three-Tier\Database1.mdf;Integrated Security=True
        public SqlContext():base("name=Database1Entities")
        {
 
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<SqlContext>(null);
            modelBuilder.Conventions.Remove<System.Data.Entity.ModelConfiguration.Conventions.PluralizingTableNameConvention>();
        }

        public SqlConnection GetSqlConn()
        {
            string connstring = this.Database.Connection.ConnectionString;
            return new SqlConnection(connstring);
        }
        public DbSet<Member> Member { set;get;}
        public DbSet<MemberInfo> MemberInfo { set; get; }
        public DbSet<ViewMember> ViewMember { set; get; }
    }
}
