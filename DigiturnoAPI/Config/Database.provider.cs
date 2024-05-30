using DigiturnoAPI;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

public class DatabaseProvider {

    private readonly IMongoDatabase _mongoDatabase;

     public DatabaseProvider(IOptions<DBSettings> databaseSettings)
    {
        var mongoClient = new MongoClient(databaseSettings.Value.ConnectionString);
        _mongoDatabase = mongoClient.GetDatabase(databaseSettings.Value.DatabaseName);
    }

    public IMongoDatabase GetAccess() => _mongoDatabase;
}