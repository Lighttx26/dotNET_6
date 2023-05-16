namespace cf_preview6.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseID = c.String(nullable: false, maxLength: 128),
                        CourseName = c.String(),
                    })
                .PrimaryKey(t => t.CourseID);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentID = c.String(nullable: false, maxLength: 128),
                        StudentName = c.String(),
                        ClassName = c.String(),
                        Gender = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.StudentID);
            
            CreateTable(
                "dbo.StudentCourses",
                c => new
                    {
                        StudentID = c.String(nullable: false, maxLength: 128),
                        CourseID = c.String(nullable: false, maxLength: 128),
                        Grade_ex = c.Double(nullable: true),
                        Grade_mid = c.Double(nullable: true),
                        Grade_final = c.Double(nullable: true),
                        ExaminationTime = c.DateTime(nullable: true),
                    })
                .PrimaryKey(t => new { t.StudentID, t.CourseID })
                .ForeignKey("dbo.Courses", t => t.CourseID, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentID, cascadeDelete: true)
                .Index(t => t.StudentID)
                .Index(t => t.CourseID);
            
            //CreateTable(
            //    "dbo.StudentCourse1",
            //    c => new
            //        {
            //            Student_StudentID = c.String(nullable: false, maxLength: 128),
            //            Course_CourseID = c.String(nullable: false, maxLength: 128),
            //        })
            //    .PrimaryKey(t => new { t.Student_StudentID, t.Course_CourseID })
            //    .ForeignKey("dbo.Students", t => t.Student_StudentID, cascadeDelete: true)
            //    .ForeignKey("dbo.Courses", t => t.Course_CourseID, cascadeDelete: true)
            //    .Index(t => t.Student_StudentID)
            //    .Index(t => t.Course_CourseID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentCourses", "StudentID", "dbo.Students");
            DropForeignKey("dbo.StudentCourses", "CourseID", "dbo.Courses");
            //DropForeignKey("dbo.StudentCourse1", "Course_CourseID", "dbo.Courses");
            //DropForeignKey("dbo.StudentCourse1", "Student_StudentID", "dbo.Students");
            //DropIndex("dbo.StudentCourse1", new[] { "Course_CourseID" });
            //DropIndex("dbo.StudentCourse1", new[] { "Student_StudentID" });
            DropIndex("dbo.StudentCourses", new[] { "CourseID" });
            DropIndex("dbo.StudentCourses", new[] { "StudentID" });
            //DropTable("dbo.StudentCourse1");
            DropTable("dbo.StudentCourses");
            DropTable("dbo.Students");
            DropTable("dbo.Courses");
        }
    }
}
