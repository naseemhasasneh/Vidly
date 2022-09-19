namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedusers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'006024db-6c88-4cc5-a807-3b1258329365', N'admain@hotmail.com', 0, N'AH1Yj0gQ7L2EKPlolq9G6xeJtM2k1ZY2LAvuuW4tf6hTMN60W0g7EhQ7DrsI8ihOHg==', N'2e6a4bc7-f15a-43bc-876f-603fa0a74d6e', NULL, 0, 0, NULL, 1, 0, N'admain@hotmail.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'e753c3e8-989b-4e82-8f8b-a271a9afa81c', N'guest@hotmail.com', 0, N'AOxxMPNajQjQL1w3aOwTn4UtkZmWmwpgbgCzAUVEU5jQIDAOw7eYaOnJurnE14deNw==', N'573d97b0-08df-46b3-8359-ffa534d03597', NULL, 0, 0, NULL, 1, 0, N'guest@hotmail.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'87b7d122-16fa-42b9-b534-2a74aee6de38', N'CanMangeMovies')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'006024db-6c88-4cc5-a807-3b1258329365', N'87b7d122-16fa-42b9-b534-2a74aee6de38')


");
        }
        
        public override void Down()
        {
        }
    }
}
