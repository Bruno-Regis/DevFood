using DevFood.Api.Core.Entities;
using DevFood.Api.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace DevFood.Api.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoriesController : ControllerBase
    {
        private readonly DeliveryDbContext _dbContext;
        public CategoriesController(DeliveryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public IActionResult CreateCategory(CreateCategoryCommand command)
        {
            var category = new Category(command.Title, command.Description);
            _dbContext.Categories.Add(category);
            return Ok(category.Id);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var categories = _dbContext
                .Categories
                .Select(c => CategoryModel.FromEntity(c))
                .ToList();

            return Ok(categories);
        }


    public class CreateCategoryCommand
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; }
    }

    public class CategoryModel
    {
        public CategoryModel(Guid id, string title, string description)
        {
            Id = id;
            Title = title;
            Description = description;
        }

        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public static CategoryModel FromEntity(Category category)
            => new CategoryModel(category.Id, category.Title, category.Description);

    }
    }


}
