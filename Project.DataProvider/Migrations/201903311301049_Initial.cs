using System.Data.Entity.Migrations;

namespace Project.DataProvider.Migrations
{
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        PhoneNumber = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        MyProperty = c.DateTime(nullable: false),
                        Employee_Id = c.Long(),
                        Services_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.Employee_Id)
                .ForeignKey("dbo.Servicies", t => t.Services_Id, cascadeDelete: true)
                .Index(t => t.Employee_Id)
                .Index(t => t.Services_Id);
            
            CreateTable(
                "dbo.Servicies",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Double(nullable: false),
                        Duration = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        RoleName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ServiceEmployees",
                c => new
                    {
                        Service_Id = c.Long(nullable: false),
                        Employee_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.Service_Id, t.Employee_Id })
                .ForeignKey("dbo.Servicies", t => t.Service_Id, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.Employee_Id, cascadeDelete: true)
                .Index(t => t.Service_Id)
                .Index(t => t.Employee_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "Services_Id", "dbo.Servicies");
            DropForeignKey("dbo.ServiceEmployees", "Employee_Id", "dbo.Employees");
            DropForeignKey("dbo.ServiceEmployees", "Service_Id", "dbo.Servicies");
            DropForeignKey("dbo.Orders", "Employee_Id", "dbo.Employees");
            DropIndex("dbo.ServiceEmployees", new[] { "Employee_Id" });
            DropIndex("dbo.ServiceEmployees", new[] { "Service_Id" });
            DropIndex("dbo.Orders", new[] { "Services_Id" });
            DropIndex("dbo.Orders", new[] { "Employee_Id" });
            DropTable("dbo.ServiceEmployees");
            DropTable("dbo.Roles");
            DropTable("dbo.Servicies");
            DropTable("dbo.Orders");
            DropTable("dbo.Employees");
        }
    }
}
