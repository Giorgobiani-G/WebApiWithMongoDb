namespace WebApiWithMongoDb.Services.Persons
{
    public interface IPersonService
    {
        Task<List<Person>> Get(CancellationToken cancellationToken);
        Task<Person> GetOne(string id, CancellationToken cancellationToken);
        Task<Person> Create(CreatePersonCommand student, CancellationToken cancellationToken);
        //void Update(string id, Person student, CancellationToken cancellationToken);
        //void Remove(string id, CancellationToken cancellationToken);
    }
}
