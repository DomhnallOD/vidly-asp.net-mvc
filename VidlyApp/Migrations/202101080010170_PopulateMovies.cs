namespace VidlyApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class PopulateMovies : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Movies (Name, ReleaseDate, DateAdded, GenreId, NumberInStock) VALUES ('Bás Beatha', 01/08/2021, 01/08/2021, 3, 10)");
            Sql("INSERT INTO Movies (Name, ReleaseDate, DateAdded, GenreId, NumberInStock) VALUES ('The Shining', 01/08/2021, 01/08/1978, 2, 5)");
            Sql("INSERT INTO Movies (Name, ReleaseDate, DateAdded, GenreId, NumberInStock) VALUES ('Lord of the Rings: The Fellowship of the Ring', 01/08/2021, 01/08/2001, 2, 8)");
            Sql("INSERT INTO Movies (Name, ReleaseDate, DateAdded, GenreId, NumberInStock) VALUES ('The Matrix', 01/08/2021, 01/08/1999, 2, 6)");
            Sql("INSERT INTO Movies (Name, ReleaseDate, DateAdded, GenreId, NumberInStock) VALUES ('Christmas with the Kramps', 01/08/2020, 01/08/2006, 1, 4)");
        }
        public override void Down()
        {
        }
    }
}


