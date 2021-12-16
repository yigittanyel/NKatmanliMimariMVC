namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Contacts", "HeadingId", "dbo.Headings");
            DropForeignKey("dbo.Contents", "Heading_HeadingId", "dbo.Headings");
            DropIndex("dbo.Contents", new[] { "Heading_HeadingId" });
            DropIndex("dbo.Contacts", new[] { "HeadingId" });
            RenameColumn(table: "dbo.Contents", name: "Heading_HeadingId", newName: "HeadingId");
            AddColumn("dbo.Contents", "WriterId", c => c.Int());
            AlterColumn("dbo.Contents", "HeadingId", c => c.Int(nullable: false));
            CreateIndex("dbo.Contents", "HeadingId");
            CreateIndex("dbo.Contents", "WriterId");
            AddForeignKey("dbo.Contents", "WriterId", "dbo.Writers", "WriterId");
            AddForeignKey("dbo.Contents", "HeadingId", "dbo.Headings", "HeadingId", cascadeDelete: true);
            DropColumn("dbo.Contacts", "HeadingId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contacts", "HeadingId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Contents", "HeadingId", "dbo.Headings");
            DropForeignKey("dbo.Contents", "WriterId", "dbo.Writers");
            DropIndex("dbo.Contents", new[] { "WriterId" });
            DropIndex("dbo.Contents", new[] { "HeadingId" });
            AlterColumn("dbo.Contents", "HeadingId", c => c.Int());
            DropColumn("dbo.Contents", "WriterId");
            RenameColumn(table: "dbo.Contents", name: "HeadingId", newName: "Heading_HeadingId");
            CreateIndex("dbo.Contacts", "HeadingId");
            CreateIndex("dbo.Contents", "Heading_HeadingId");
            AddForeignKey("dbo.Contents", "Heading_HeadingId", "dbo.Headings", "HeadingId");
            AddForeignKey("dbo.Contacts", "HeadingId", "dbo.Headings", "HeadingId", cascadeDelete: true);
        }
    }
}
