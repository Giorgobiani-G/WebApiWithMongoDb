using MongoDB.Driver;
using WebApiWithMongoDb.Services.Persons;

namespace WebApiWithMongoDb.Services
{
    public class PersonService : IPersonService
    {
        private readonly IMongoCollection<Person> _person;

        public PersonService(IPersonDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _person = database.GetCollection<Person>(settings.CollectionName);
        }

        public async Task<Person> Create(CreatePersonCommand student, CancellationToken cancellationToken)
        {
            var pers = new Person(student);

            await _person.InsertOneAsync(pers, cancellationToken);

            return pers;
        }

        public async Task<List<Person>> Get(CancellationToken cancellationToken)
        {
           var res = await _person.Find(x => true).ToListAsync(cancellationToken);
            return res;
        }

        public async Task<Person> GetOne(string id, CancellationToken cancellationToken)
        {
            return await _person.Find(x => x.Id == id).FirstOrDefaultAsync(cancellationToken);
        }
    }
}
