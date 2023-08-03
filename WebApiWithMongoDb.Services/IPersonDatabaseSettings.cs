﻿namespace WebApiWithMongoDb.Services
{
    public interface IPersonDatabaseSettings
    {
        string CollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
