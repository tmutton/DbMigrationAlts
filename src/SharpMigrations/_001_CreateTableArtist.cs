namespace SharpMigrations
{
    using Sharp.Migrations;

    public class _001_CreateTableArtist : SchemaMigration
    {

        public override void Up()
        {
            Add.Table("Artist")
               .WithColumns(
                   Column.AutoIncrement("ArtistId").AsPrimaryKey(),
                   Column.String("Name", 120).NotNull());
        }

        public override void Down()
        {
            Remove.Table("Artist");
        }
    }
}
