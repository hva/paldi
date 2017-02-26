using FluentMigrator;

namespace Paldi.Web.Migrations
{
    [Migration(201702261458)]
    public class Users : Migration
    {
        public override void Up()
        {
            Create.Table("users")
                .WithColumn("guid").AsString(36)
                .WithColumn("login").AsString(32)
                .WithColumn("hash").AsString(64)
            ;
        }

        public override void Down()
        {
            Delete.Table("users");
        }
    }
}
