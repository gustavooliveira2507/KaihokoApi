
using KaihokoApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace KaihokoApi.Services;

public class CategoryDataService
{
     private readonly IMongoCollection<Category> _categoryCollection;
    const string _categoryCollectionName = "category";

     public CategoryDataService(
        IOptions<MongDbDataBaseSettings> DatabaseSettings)
    {
        var mongoClient = new MongoClient(
            DatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            DatabaseSettings.Value.DatabaseName);

        _categoryCollection = mongoDatabase.GetCollection<Category>(
            _categoryCollectionName);
    }

    public async Task<List<Category>> GetAsync() =>
        await _categoryCollection.Find(_ => true).ToListAsync();

    public async Task<Category?> GetAsync(string name) =>
        await _categoryCollection.Find(x => x.Name == name).FirstOrDefaultAsync();

    public async Task CreateAsync(Category newCategory) =>
        await _categoryCollection.InsertOneAsync(newCategory);

    public async Task UpdateAsync(string name, Category updatedCategory) =>
        await _categoryCollection.ReplaceOneAsync(x => x.Name == name, updatedCategory);

    public async Task RemoveAsync(string name) =>
        await _categoryCollection.DeleteOneAsync(x => x.Name == name);
}