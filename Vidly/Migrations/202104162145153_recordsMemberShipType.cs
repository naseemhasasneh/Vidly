namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class recordsMemberShipType : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MemberShipTypes Values(1,0,0,0)");
            Sql("INSERT INTO MemberShipTypes Values(2,30,1,10)");
            Sql("INSERT INTO MemberShipTypes Values(3,90,3,15)");
            Sql("INSERT INTO MemberShipTypes Values(4,300,12,20)");
        }
        
        public override void Down()
        {
        }
    }
}
