using FluentMigrator;

namespace Paldi.Web.Migrations
{
    [Migration(2)]
    public class CatalogSections:Migration
    {
        public override void Up()
        {
            Create.Table("catalog_sections")
                .WithColumn("guid").AsString(36).PrimaryKey()
                .WithColumn("slug").AsString(32)
                .WithColumn("name").AsString(32)
            ;
        }

        public override void Down()
        {
            Delete.Table("catalog_sections");
        }
    }
}
