namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'18e30773-db77-4da7-89a6-c83346c2e2cd', N'admin1@val.com', 0, N'ALvIW8mY2QbTOykyI8ckkHr4J9w3jTadHCVcl4slld+EkavGXDJ18EkuadFQ44FTLw==', N'17a88f86-658e-4401-b050-71b842e173b4', NULL, 0, 0, NULL, 1, 0, N'admin1@val.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'59065d32-14f6-469b-a63a-f095f897d876', N'guest@valery.com', 0, N'APznXX5X2cYs/lnIfbQp2tTTkMKazw3JfZvlMjRsJ24J4JMWsFDVt2lrC+z0MmR3Cw==', N'6ada2a26-62a0-4bb7-8c18-1d5ca25c43a8', NULL, 0, 0, NULL, 1, 0, N'guest@valery.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'e7b73554-d9e2-414e-9fee-811354754aa2', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'18e30773-db77-4da7-89a6-c83346c2e2cd', N'e7b73554-d9e2-414e-9fee-811354754aa2')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'59065d32-14f6-469b-a63a-f095f897d876', N'e7b73554-d9e2-414e-9fee-811354754aa2')

");
        }
        
        public override void Down()
        {
        }
    }
}
