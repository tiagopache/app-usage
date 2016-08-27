namespace AppUsage.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitializeDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Devices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        MacAddress = c.String(),
                        IpAddress = c.String(),
                        PartnerId = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        UpdatedOn = c.DateTime(nullable: false),
                        DeletedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Partners", t => t.PartnerId, cascadeDelete: true)
                .Index(t => t.PartnerId);
            
            CreateTable(
                "dbo.Partners",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        UpdatedOn = c.DateTime(nullable: false),
                        DeletedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Programs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        AssemblyName = c.String(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        UpdatedOn = c.DateTime(nullable: false),
                        DeletedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProgramPartners",
                c => new
                    {
                        Program_Id = c.Int(nullable: false),
                        Partner_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Program_Id, t.Partner_Id })
                .ForeignKey("dbo.Programs", t => t.Program_Id, cascadeDelete: true)
                .ForeignKey("dbo.Partners", t => t.Partner_Id, cascadeDelete: true)
                .Index(t => t.Program_Id)
                .Index(t => t.Partner_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Devices", "PartnerId", "dbo.Partners");
            DropForeignKey("dbo.ProgramPartners", "Partner_Id", "dbo.Partners");
            DropForeignKey("dbo.ProgramPartners", "Program_Id", "dbo.Programs");
            DropIndex("dbo.ProgramPartners", new[] { "Partner_Id" });
            DropIndex("dbo.ProgramPartners", new[] { "Program_Id" });
            DropIndex("dbo.Devices", new[] { "PartnerId" });
            DropTable("dbo.ProgramPartners");
            DropTable("dbo.Programs");
            DropTable("dbo.Partners");
            DropTable("dbo.Devices");
        }
    }
}
