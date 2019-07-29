namespace KatlaSport.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class Employee_Table_Added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.employee_records",
                c => new
                    {
                        employee_id = c.Int(nullable: false, identity: true),
                        employee_name = c.String(nullable: false, maxLength: 60),
                        employee_role = c.String(nullable: false, maxLength: 30),
                        StoreHiveId = c.Int(nullable: false),
                        BossId = c.Int(),
                    })
                .PrimaryKey(t => t.employee_id)
                .ForeignKey("dbo.employee_records", t => t.BossId)
                .ForeignKey("dbo.product_hives", t => t.StoreHiveId, cascadeDelete: true)
                .Index(t => t.StoreHiveId)
                .Index(t => t.BossId);

            AlterColumn("dbo.customer_records", "customer_name", c => c.String(nullable: false, maxLength: 60));
            AlterColumn("dbo.customer_records", "customer_address", c => c.String(nullable: false, maxLength: 60));
            AlterColumn("dbo.customer_records", "customer_phone", c => c.String(maxLength: 30));
        }

        public override void Down()
        {
            DropForeignKey("dbo.employee_records", "StoreHiveId", "dbo.product_hives");
            DropForeignKey("dbo.employee_records", "BossId", "dbo.employee_records");
            DropIndex("dbo.employee_records", new[] { "BossId" });
            DropIndex("dbo.employee_records", new[] { "StoreHiveId" });
            AlterColumn("dbo.customer_records", "customer_phone", c => c.String());
            AlterColumn("dbo.customer_records", "customer_address", c => c.String());
            AlterColumn("dbo.customer_records", "customer_name", c => c.String());
            DropTable("dbo.employee_records");
        }
    }
}
