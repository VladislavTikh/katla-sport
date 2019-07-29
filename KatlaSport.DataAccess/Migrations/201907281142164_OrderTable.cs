namespace KatlaSport.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class OrderTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.order_details",
                c => new
                    {
                        order_detail_id = c.Int(nullable: false, identity: true),
                        order_detail_price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        order_detail_quantity = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        OrderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.order_detail_id)
                .ForeignKey("dbo.order_records", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.product_store_items", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.OrderId);

            CreateTable(
                "dbo.order_records",
                c => new
                    {
                        order_id = c.Int(nullable: false, identity: true),
                        created_utc = c.DateTime(nullable: false),
                        order_address = c.String(nullable: false, maxLength: 60),
                        required_utc = c.DateTime(nullable: false),
                        CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.order_id)
                .ForeignKey("dbo.customer_records", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
        }

        public override void Down()
        {
            DropForeignKey("dbo.order_details", "ProductId", "dbo.product_store_items");
            DropForeignKey("dbo.order_details", "OrderId", "dbo.order_records");
            DropForeignKey("dbo.order_records", "CustomerId", "dbo.customer_records");
            DropIndex("dbo.order_records", new[] { "CustomerId" });
            DropIndex("dbo.order_details", new[] { "OrderId" });
            DropIndex("dbo.order_details", new[] { "ProductId" });
            DropTable("dbo.order_records");
            DropTable("dbo.order_details");
        }
    }
}
