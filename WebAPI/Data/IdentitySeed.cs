﻿using Microsoft.AspNetCore.Identity;
using DAL;

namespace WebAPI.Data
{
    public static class IdentitySeed
    {
        public static async Task CreateUserRoles(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<User>>();
            // Создание ролей администратора и пользователя
            if (await roleManager.FindByNameAsync("admin") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("admin"));
            }
            if (await roleManager.FindByNameAsync("doctor") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("doctor"));
            }
            if (await roleManager.FindByNameAsync("user") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("user"));
            }
            // Создание Администратора
            string adminEmail = "babajenov@mail.ru";
            string adminPassword = "Aa123456!";
            if (await userManager.FindByNameAsync(adminEmail) == null)
            {
                User admin = new User { Email = adminEmail, UserName = adminEmail, UserId = 1};
                IdentityResult result = await userManager.CreateAsync(admin, adminPassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "doctor");
                }
            }
            // Создание Пользователя
            string userEmail = "user@mail.com";
            string userPassword = "Aa123456!";
            if (await userManager.FindByNameAsync(userEmail) == null)
            {
                User user = new User { Email = userEmail, UserName = userEmail, UserId = 1 };
                IdentityResult result = await userManager.CreateAsync(user, userPassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "user");
                }
            }
        }
    }
}
