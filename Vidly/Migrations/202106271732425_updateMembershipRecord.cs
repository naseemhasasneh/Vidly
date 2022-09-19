namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateMembershipRecord : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MEMBERSHIPTYPES SET NAME='payAsYouGo' where ID=1");
            Sql("UPDATE MEMBERSHIPTYPES SET NAME='monthly' where ID=2");
            Sql("UPDATE MEMBERSHIPTYPES SET NAME='quarterly' where ID=3");
            Sql("UPDATE MEMBERSHIPTYPES SET NAME='annual'  where ID=4");
        }
    
    
    public override void Down()
        {
        }
    }
}
