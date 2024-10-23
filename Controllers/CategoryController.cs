using Microsoft.AspNetCore.Mvc;
using KaihokoApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using KaihokoApi.Services;
namespace KaihokoApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoryController : ControllerBase
{
    private readonly ILogger<CategoryController> _logger;
    private readonly CategoryDataService _service;
    public CategoryController(CategoryDataService categoryDataService,ILogger<CategoryController> logger)
    {
        _logger = logger;
        _service = categoryDataService;
        
    }

    [HttpGet(Name = "GetCategory")]
    public async Task<IEnumerable<Category>> Get()
    {
        _logger.LogInformation("Getting all categories");
       return await _service.GetAsync();
    }

    [HttpPost(Name = "CreateCategory")]
    public async Task Create([FromBody]Category categoryData)
    {
        _logger.LogInformation("Create a new category");
        await _service.CreateAsync(categoryData);
    }
}
