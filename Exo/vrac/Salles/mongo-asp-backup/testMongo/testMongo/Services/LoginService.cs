 using Microsoft.Extensions.Options;
using MongoDB.Driver;
using testMongo.Models;

namespace testMongo.Services
{
    public class LoginService
    {
        private readonly IMongoCollection<Login> _LoginCollection;

        public LoginService(
            IOptions<SallesDatabaseLoginSettings> SalleStoreDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                SalleStoreDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                SalleStoreDatabaseSettings.Value.DatabaseName);

            _LoginCollection = mongoDatabase.GetCollection<Login>(
                SalleStoreDatabaseSettings.Value.CollectionName);
        }

        public async Task<List<Login>> GetAsync() =>
            await _LoginCollection.Find(_ => true).ToListAsync();

        public async Task<Login?> GetAsync(int id) =>
            await _LoginCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Login newSalle) =>
            await _LoginCollection.InsertOneAsync(newSalle);

        public async Task UpdateAsync(int id, Login updatedSalle) =>
            await _LoginCollection.ReplaceOneAsync(x => x.Id == id, updatedSalle);

        public async Task RemoveAsync(int id) =>
            await _LoginCollection.DeleteOneAsync(x => x.Id == id);
    }
}
