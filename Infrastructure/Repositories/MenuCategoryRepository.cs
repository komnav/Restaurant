﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class MenuCategoryRepository(ApplicationDbContext dbContext) : IMenuCategoryRepository
    {
        private readonly ApplicationDbContext _dbContext = dbContext;
        public async Task CreateAsync(MenuCategory menuCategory)
        {
            await _dbContext.MenuCategories.AddAsync(menuCategory);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await _dbContext.MenuCategories.Where(x => x.Id == id).ExecuteDeleteAsync();
            await _dbContext.SaveChangesAsync();
        }

        public async Task<MenuCategory> GetAsync(int id)
        {
            return await _dbContext.MenuCategories.SingleAsync(x => x.Id.Equals(id));

        }

        public async Task UpdateAsync(int id, MenuCategory menuCategory)
        {
            await _dbContext.MenuCategories
                .Where(x => x.Id == id)
                .ExecuteUpdateAsync(s => s
                .SetProperty(x => x.ParentId, menuCategory.ParentId)
                .SetProperty(x => x.Name, menuCategory.Name));
        }
    }
}
