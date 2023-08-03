namespace WebApiWithMongoDb.Services
{
    public class CreatePersonCommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
}
