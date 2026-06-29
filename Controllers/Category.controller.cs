using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/category")]
public class CategoryController : ControllerBase
{
    public readonly CategoryService _categoryService;
    public CategoryController(CategoryService categoryService)
    {
        _categoryService = categoryService;
    }
    private static List<Category> Categories = new List<Category>();

    // Get: api/category => Get all category
    [HttpGet]
    public IActionResult GetCategories(string query = "")
    {
        var categoryList = _categoryService.GetAllCategories();
        return Ok(categoryList);
    }

    // Post: api/category => Post a new category
    [HttpPost]
    public IActionResult CreateCategory(CreateCategoryDto CategoryData)
    {
        var newCategory = new Category
        {
            CategoryId = Guid.NewGuid(),
            Name = CategoryData.Name,
            Narration = CategoryData.Narration ?? "",
            CreatedAt = DateTime.UtcNow
        };
        Categories.Add(newCategory);

        return Created($"/api/category/{newCategory.CategoryId}", newCategory);
    }

    // Put: api/category => Post a new category
    [HttpPut("{categoryId:guid}")]
    public IActionResult UpdateCategory(Guid categoryId, Category CategoryData)
    {
        var OldCategory = Categories.FirstOrDefault(category => category.CategoryId == categoryId);
        if (OldCategory == null)
        {
            return NotFound("Category are not found");
        }
        OldCategory.Name = CategoryData.Name;
        OldCategory.Narration = CategoryData.Narration;
        OldCategory.CreatedAt = DateTime.UtcNow;

        return NoContent();
    }

    // Delete: api/category => Delete a new category
    [HttpDelete("{categoryId:guid}")]
    public IActionResult DeleteCategory(Guid categoryId)
    {
        var FoundCategory = Categories.FirstOrDefault(category => category.CategoryId == categoryId);
        if (FoundCategory == null)
        {
            return NotFound("Category are not found");
        }
        Categories.Remove(FoundCategory);
        return NoContent();
    }
}