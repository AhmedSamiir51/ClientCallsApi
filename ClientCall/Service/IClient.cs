using ClientCall.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientCall.Service
{
    public class IClient : IService<Client>
    {

        ClientDbContext db = new ClientDbContext();

        public Client Create(Client entity)
        {
            db.Clients.Add(entity);
            db.SaveChanges();
            return entity;
        }

        public Client Delete(int id)
        {
            var client = db.Clients.Find(id);

            db.Clients.Remove(client);
            db.SaveChanges();
            return client;

        }

        public Client Edit(int id, Client entity)
        {
            var client = GetById(id);
            client.Age = entity.Age;
            client.Name = entity.Name;
            client.Email = entity.Email;
            client.Phone = entity.Phone;
            db.SaveChanges();

            return client;
        }

        public List<Client> GetAllCallsById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Client> GetAllCallsById(int id, int client)
        {
            throw new NotImplementedException();
        }

        public Client GetById(int id)
        {
            var client =db.Clients.Find(id);

            return client;
        }

        public List<Client> List()
        {
            return db.Clients.ToList();
        }
    }
}
