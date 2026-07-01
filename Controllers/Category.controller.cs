using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/v1/category")]
public class CategoryController : ControllerBase
{
    public readonly ICategoryService _categoryService;
    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    // Get: api/category => Read all category
    [HttpGet]
    public async Task<IActionResult> LoadCategories(string query = "")
    {
        List<ResCategoryDto> response = await _categoryService.GetAllCategories();
        return Ok(response);
    }

    // Get: api/category/{categoryId} => Read a category
    [HttpGet("{categoryId:guid}")]
    public async Task<IActionResult> GetCategory(Guid categoryId)
    {
        ResCategoryDto? response = await _categoryService.GetCategoryById(categoryId);
        return response == null ? Ok(response) : NotFound("Category not found!");
    }

    // Post: api/category => Create a new category
    [HttpPost]
    public async Task<IActionResult> CreateCategory(CreateCategoryDto categoryData)
    {
        ResCategoryDto newCategory = await _categoryService.CreateCategory(categoryData);
        return Created($"/api/v1/category/{newCategory.CategoryId}", newCategory);
    }

    // Put: api/category/{categoryId} => Update a category
    [HttpPut("{categoryId:guid}")]
    public async Task<IActionResult> UpdateCategory(Guid categoryId, UpdateCategoryDto updateData)
    {
        bool response = await _categoryService.UpdateCategory(categoryId, updateData);
        return response ? NoContent() : NotFound("Category not found!");
    }

    // Delete: api/category/{categoryId} => Delete a category
    [HttpDelete("{categoryId:guid}")]
    public async Task<IActionResult> DeleteCategory(Guid categoryId)
    {
        bool response = await _categoryService.DeleteCategory(categoryId);
        return response ? NoContent() : NotFound("Category not found!");
    }
}