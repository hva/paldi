using FluentMigrator;

namespace Paldi.Web.Migrations
{
    [Migration(1)]
    public class Users : Migration
    {
        public override void Up()
        {
            Create.Table("users")
                .WithColumn("guid").AsString(36).PrimaryKey()
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
