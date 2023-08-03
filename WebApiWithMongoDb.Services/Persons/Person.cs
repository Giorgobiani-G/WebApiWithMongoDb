using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using WebApiWithMongoDb.Services;

namespace WebApiWithMongoDb.Services.Persons
{
    public class Person
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("firstname")]
        public string FirstName { get; set; }

        [BsonElement("lastname")]
        public string LastName { get; set; }

        [BsonElement("age")]
        public int Age { get; set; }

        public Person(CreatePersonCommand command)
        {
            FirstName = command.FirstName;
            LastName = command.LastName;
            Age = command.Age;
        }
    }
}
