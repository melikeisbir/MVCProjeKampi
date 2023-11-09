namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig3 : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Drafts");
        }
        
        public override void Down()
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
    }
}
