namespace SocialMedia.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1st : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Post", "Author_Name", "dbo.User");
            DropIndex("dbo.Post", new[] { "Author_Name" });
            RenameColumn(table: "dbo.Post", name: "Author_Name", newName: "Author_UserID");
            DropPrimaryKey("dbo.User");
            AlterColumn("dbo.Post", "Author_UserID", c => c.Guid(nullable: false));
            AlterColumn("dbo.User", "Name", c => c.String(nullable: false));
            AddPrimaryKey("dbo.User", "UserID");
            CreateIndex("dbo.Post", "Author_UserID");
            AddForeignKey("dbo.Post", "Author_UserID", "dbo.User", "UserID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Post", "Author_UserID", "dbo.User");
            DropIndex("dbo.Post", new[] { "Author_UserID" });
            DropPrimaryKey("dbo.User");
            AlterColumn("dbo.User", "Name", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Post", "Author_UserID", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.User", "Name");
            RenameColumn(table: "dbo.Post", name: "Author_UserID", newName: "Author_Name");
            CreateIndex("dbo.Post", "Author_Name");
            AddForeignKey("dbo.Post", "Author_Name", "dbo.User", "Name", cascadeDelete: true);
        }
    }
}
