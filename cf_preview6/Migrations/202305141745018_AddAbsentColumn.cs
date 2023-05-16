namespace cf_preview6.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAbsentColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StudentCourses", "Absent", c => c.Double(nullable: true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.StudentCourses", "Absent");
        }
    }
}
