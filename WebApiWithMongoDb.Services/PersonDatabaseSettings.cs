namespace WebApiWithMongoDb.Services
{
    public class PersonDatabaseSettings : IPersonDatabaseSettings
    {
        public string CollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
