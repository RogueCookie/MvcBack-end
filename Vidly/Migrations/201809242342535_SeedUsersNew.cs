namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsersNew : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'4d07a544-3258-4fda-8af9-df89d1d4bd28', N'guest@valery.com', 0, N'AAVfXYGEVN0iAXt4nvmezDfMMsEPAkKHkoUWBbe72QfVylPYqKj85o2Se5N2x8HwKA==', N'41ea0f09-b0a4-4667-b85c-049341c8289d', NULL, 0, 0, NULL, 1, 0, N'guest@valery.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'd09976a0-9cb3-4c34-934a-fb588586ae75', N'admin1@val.com', 0, N'AJQnN9M72dg8WgrQu7YcN43La4tYpYe4DLWV04ADt/6coxbICyZm1jK6lrkRXBMvfw==', N'3ee40cf7-c860-43de-9e0c-e9766dd44d04', NULL, 0, 0, NULL, 1, 0, N'admin1@val.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'e7b73554-d9e2-414e-9fee-811354754aa2', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'd09976a0-9cb3-4c34-934a-fb588586ae75', N'e7b73554-d9e2-414e-9fee-811354754aa2')

");
        }
        
        public override void Down()
        {
        }
    }
}
