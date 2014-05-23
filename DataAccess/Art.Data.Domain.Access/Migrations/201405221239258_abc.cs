namespace Art.Data.Domain.Access.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class abc : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ExceptionLog", "Test", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ExceptionLog", "Test");
        }
    }
}
