﻿using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using ResraurantLayer.Services;
using RestaurantLayer.Dtos;
using RestaurantLayer.Dtos.MenuCategory.Requests;
using RestaurantLayer.Dtos.MenuCategory.Responses;

namespace Restaurant.WebApi.Controllers
{
    [ApiController]
    [Route("MenuCategory")]
    public class MenuCategoryController(IMenuCategoryService menuCategoryService) : ControllerBase
    {
        private readonly IMenuCategoryService _menuCategoryService = menuCategoryService;

        [HttpPost]
        public async Task<CreateMenuCategoryResponseModel> Create([FromBody] CreateMenuCategoryRequestModel request)
        {
            var createdCategory = await _menuCategoryService.CreateAsync(request.Name);
            return createdCategory;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _menuCategoryService.DeleteAsync(id);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<UpdateResponseModel> Update( int id, [FromBody] UpdateMenuCategoryRequestModel request)
        {
            var updateCategory = await _menuCategoryService.UpdateAsync(id, request);
            return updateCategory;
        }

        [HttpGet("{id}")]
        public async Task<GetMenuCategoryResponseModel?> Get([FromRoute] int id)
        {
            return await _menuCategoryService.GetAsync(id);
        }

        [HttpGet]
        public async Task<List<GetMenuCategoryResponseModel>> GetAll()
        {
            return await _menuCategoryService.GetAllAsync();
        }
    }
}
