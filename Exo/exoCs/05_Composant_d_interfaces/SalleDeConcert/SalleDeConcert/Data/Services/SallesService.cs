using Microsoft.Extensions.Options;
using MongoDB.Driver;
using SalleDeConcert.Data.Models;

namespace SalleDeConcert.Data.Services
{
    public class SallesService
    {
        private readonly IMongoCollection<Salle> _SallesCollection;

        public SallesService(
            IOptions<BatimentDatabaseSettings> SalleStoreDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                SalleStoreDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                SalleStoreDatabaseSettings.Value.DatabaseName);

            _SallesCollection = mongoDatabase.GetCollection<Salle>(
                SalleStoreDatabaseSettings.Value.SallesCollectionName);
        }

        public async Task<List<Salle>> GetAsync() =>
            await _SallesCollection.Find(_ => true).ToListAsync();

        public async Task<Salle?> GetAsync(string id) =>
            await _SallesCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Salle newSalle) =>
            await _SallesCollection.InsertOneAsync(newSalle);

        public async Task UpdateAsync(string id, Salle updatedSalle) =>
            await _SallesCollection.ReplaceOneAsync(x => x.Id == id, updatedSalle);

        public async Task RemoveAsync(string id) =>
            await _SallesCollection.DeleteOneAsync(x => x.Id == id);
    }
}
