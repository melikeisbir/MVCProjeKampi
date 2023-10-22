namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_messagereaden : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "MessageIsReaden", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "MessageIsReaden");
        }
    }
}
