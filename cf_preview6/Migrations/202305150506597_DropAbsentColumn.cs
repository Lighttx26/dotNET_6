namespace cf_preview6.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropAbsentColumn : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.StudentCourses", "Absent");
        }
        
        public override void Down()
        {
            AddColumn("dbo.StudentCourses", "Absent", c => c.Double(nullable: false));
        }
    }
}
