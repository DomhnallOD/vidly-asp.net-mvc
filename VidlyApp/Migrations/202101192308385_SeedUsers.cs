namespace VidlyApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO[dbo].[AspNetUsers]
        ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES(N'27687ee3-13ee-4eb2-a77a-07f47ae62e81', N'admin@vidly.com', 0, N'APKHasGGI47fy+eKORJRe+3FCG/5eb9il4Z+tj4pi90vJs9N6/V+ug2BKgue0ay/dw==', N'f58ede73-4c5f-4177-9395-b0e7ee6f0a6e', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')");
            Sql(@"INSERT INTO[dbo].[AspNetUsers]
        ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES(N'7d8c872f-e0a1-4f58-80af-7669e509286d', N'guest@vidly.com', 0, N'AP8m3AfHWyWEh/Ae2nfUaLGqIbQKO7jykxVOFE0mpbLFqUz5XtZIbopKZ9pwhp+mQw==', N'bb84db4f-0a8c-4acf-b065-4356737510d8', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')");
            Sql(@"INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'c13b165b-cc7a-49b2-9c58-425c93c45def', N'CanManageMovies')");
            Sql(@"INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'27687ee3-13ee-4eb2-a77a-07f47ae62e81', N'c13b165b-cc7a-49b2-9c58-425c93c45def')");
        }

    public override void Down()
        {
        }
    }
}
