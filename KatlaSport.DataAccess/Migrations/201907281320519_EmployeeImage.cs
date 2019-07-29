namespace KatlaSport.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class EmployeeImage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.employee_records", "employee_image", c => c.String());
        }

        public override void Down()
        {
            DropColumn("dbo.employee_records", "employee_image");
        }
    }
}
