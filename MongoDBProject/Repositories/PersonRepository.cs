using MongoDB.Bson;
using MongoDB.Driver;
using MongoDBProject.Repositories.Bsons;
using MongoDBProject.Repositories.Infrastructure;
using System.Collections.Generic;

namespace MongoDBProject.Repositories
{
    public class PersonRepository
    {
        private readonly IMongoCollection<PersonBson> PersonCollection;
        private readonly IMongoCollection<AddressBson> AddressCollection;

        public PersonRepository()
        {
            var mongoDBConfiguration = new MongoDBConfiguration();
            var mongoDatabase = mongoDBConfiguration.GetMongoDatabase();

            PersonCollection = mongoDatabase.GetCollection<PersonBson>("Person");
            AddressCollection = mongoDatabase.GetCollection<AddressBson>("Address");
        }

        public void DeleteAllPersonsAndAddress()
        {
            PersonCollection.DeleteMany(FilterDefinition<PersonBson>.Empty, null);
            AddressCollection.DeleteMany(FilterDefinition<AddressBson>.Empty, null);
        }

        public void InsertPersonsWithAddress()
        {
            InsertPerson1();
            InsertPerson2();
        }

        public void InsertPersons()
        {
            var listPerson = new List<PersonBson>();
            for (int i = 0; i < 10000; i++)
            {
                var purchase = new PersonBson
                {
                    Id = ObjectId.GenerateNewId(),
                    Name = $"Person {i + 1}",
                    YearsOld = i + 1
                };

                listPerson.Add(purchase);
            }

            PersonCollection.InsertMany(listPerson.ToArray());
        }

        public PersonBson[] FindPersons()
        {
            return PersonCollection.Find(FilterDefinition<PersonBson>.Empty, null).ToList().ToArray();
        }

        public PersonBson FindPersonsByKey(string personId)
        {
            return PersonCollection.Find(p => p.Id == ObjectId.Parse(personId)).SingleOrDefault();
        }

        public AddressBson[] FindAddressesByPerson(ObjectId personId)
        {
            return AddressCollection.Find(p => p.PersonId == personId).ToList().ToArray();
        }

        private void InsertPerson1()
        {
            // pessoa
            var personId = ObjectId.GenerateNewId();
            var person = new PersonBson
            {
                Id = personId,
                Name = $"Person 1",
                YearsOld = 12
            };

            // endereços
            var addresses = new List<AddressBson>();
            var enderecoPerson1 = new AddressBson
            {
                Id = ObjectId.GenerateNewId(),
                Street = "Aderbal rocha de fraga",
                Number = 15,
                PersonId = personId
            };

            var enderecoPerson2 = new AddressBson
            {
                Id = ObjectId.GenerateNewId(),
                Street = "Jose humberto bronca",
                Number = 6,
                PersonId = personId
            };
            addresses.Add(enderecoPerson1);
            addresses.Add(enderecoPerson2);

            // cada um em uma collection
            PersonCollection.InsertOne(person);
            AddressCollection.InsertMany(addresses);
        }

        private void InsertPerson2()
        {
            // pessoa
            var personId = ObjectId.GenerateNewId();
            var person = new PersonBson
            {
                Id = personId,
                Name = $"Person 2",
                YearsOld = 12
            };

            // endereços
            var addresses = new List<AddressBson>();
            var enderecoPerson1 = new AddressBson
            {
                Id = ObjectId.GenerateNewId(),
                Street = "Correa da silva",
                Number = 99,
                PersonId = personId
            };

            var enderecoPerson2 = new AddressBson
            {
                Id = ObjectId.GenerateNewId(),
                Street = "Tupac Amaru",
                Number = 1,
                PersonId = personId
            };

            var enderecoPerson3 = new AddressBson
            {
                Id = ObjectId.GenerateNewId(),
                Street = "Correa de melo",
                Number = 10,
                PersonId = personId
            };
            addresses.Add(enderecoPerson1);
            addresses.Add(enderecoPerson2);
            addresses.Add(enderecoPerson3);

            // cada um em uma collection
            PersonCollection.InsertOne(person);
            AddressCollection.InsertMany(addresses);
        }
    }
}
