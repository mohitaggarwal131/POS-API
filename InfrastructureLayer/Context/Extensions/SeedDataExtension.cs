using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using Utility.Enums;

namespace InfrastructureLayer.Context.Extensions
{
    public static class SeedDataExtension
    {
        public static ModelBuilder AddDataSeeding(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
            new Category()
            {
                Id = (int)CategoryEnum.Clothes,
                Guid = new Guid("6fc7825d-9965-47a5-b892-9ddae2929480"),
                Name = CategoryEnum.Clothes.ToString()
            },
            new Category()
            {
                Id = (int)CategoryEnum.Computers,
                Guid = new Guid("fb32f25d-26e7-4224-8879-9045a6b5230c"),
                Name = CategoryEnum.Computers.ToString()
            },
            new Category()
            {
                Id = (int)CategoryEnum.Fruits,
                Guid = new Guid("b77c2555-c196-42f2-8ce0-83fd53c82dd9"),
                Name = CategoryEnum.Fruits.ToString()
            },
            new Category()
            {
                Id = (int)CategoryEnum.Electronics,
                Guid = new Guid("d36d70e7-5591-4a6b-b27f-cf3dd85dc2c5"),
                Name = CategoryEnum.Electronics.ToString()
            },
            new Category()
            {
                Id = (int)CategoryEnum.Accessories,
                Guid = new Guid("a8a2146e-e3dc-40d3-ab58-2815205ba9c1"),
                Name = CategoryEnum.Accessories.ToString()
            });
            modelBuilder.Entity<Role>().HasData(
            new Role()
            {
                Id = (int)UserRoleEnum.Admin,
                GuId = new Guid("be3d9955-fe14-459e-b80a-d1626b9442cb"),
                Name = UserRoleEnum.Admin.ToString()
            },
            new Role()
            {
                Id = (int)UserRoleEnum.User,
                GuId = new Guid("437a0da2-6799-4f3c-8d87-a08738b7605b"),
                Name = UserRoleEnum.User.ToString()
            });
            modelBuilder.Entity<User>().HasData(
            new User()
            {
                Id = 1,
                GuId = new Guid("1b4eb4e3-56af-4e9d-8342-90dc98a146e9"),
                FirstName = "Mohit",
                LastName = "Aggarwal",
                UserName = "mohit-131",
                Password = "1234"
            },
            new User()
            {
                Id = 2,
                GuId = new Guid("37c5c837-7512-4e4f-a7b6-93db19e6158c"),
                FirstName = "Shweta",
                LastName = "Sharma",
                UserName = "shweta-123",
                Password = "4321"
            });
            modelBuilder.Entity<UserRole>().HasData(
            new UserRole()
            {
                UserId = 1,
                RoleId = 1
            },
            new UserRole()
            {
                UserId = 2,
                RoleId = 2
            });
            return modelBuilder;
        }
    }
}
