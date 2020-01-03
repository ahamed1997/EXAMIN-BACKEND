namespace ExamenProjectAngular.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedDefaultColumnNames : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "Name", c => c.String());
            AddColumn("dbo.User", "Phone", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "Phone");
            DropColumn("dbo.User", "Name");
        }
    }
}
