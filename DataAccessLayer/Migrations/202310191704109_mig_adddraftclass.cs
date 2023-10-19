namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_adddraftclass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Drafts",
                c => new
                    {
                        IDDraft = c.Int(nullable: false, identity: true),
                        DraftSenderMail = c.String(maxLength: 50),
                        DraftReceiverMail = c.String(maxLength: 50),
                        DraftSubject = c.String(maxLength: 100),
                        DraftMessageContent = c.String(),
                        DraftMessageDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IDDraft);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Drafts");
        }
    }
}
