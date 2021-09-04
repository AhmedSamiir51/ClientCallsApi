using ClientCall.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientCall.Service
{
    public class ICalls : IServiceCalls<Calls>
    {
        ClientDbContext db = new ClientDbContext();
        public Calls Create(Calls entity)
        {
            db.Calls.Add(entity);
            db.SaveChanges();
            return entity;
        }

        public Calls Delete(int id_call, int id_client)
        {
            var client = GetById(id_call, id_client);

            db.Calls.Remove(client);
            db.SaveChanges();
            return client;

        }

        public Calls Edit(int id_call, int id_client, Calls entity)
        {
            var calls = GetById(id_call, id_client);

            calls.Call_To = entity.Call_To;
            calls.Date_Call = entity.Date_Call;
            calls.PhoneNumber = entity.PhoneNumber;
            db.SaveChanges();
            return entity;

        }

        public Calls GetById(int id_call, int id_client)
        {
            var calls = db.Calls.Where(e=>e.Client_Id== id_client && e.Call_Id==id_call).FirstOrDefault();

            return calls;
        }

        public List<Calls> List()
        {
            return db.Calls.ToList();
        }
        public List<Calls> GetAllCallsById(int id)
        {

            var calls = db.Calls.Where(e => e.Client_Id == id).ToList();
            return calls;
        }

    }
}
