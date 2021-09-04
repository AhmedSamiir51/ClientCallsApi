using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientCall.Service
{
    public interface IServiceCalls<tEntity>
    {
        List<tEntity> List();
        tEntity GetById(int id_call , int id_client);
        List<tEntity> GetAllCallsById(int id );
        tEntity Create(tEntity entity);
        tEntity Edit(int id_call, int id_client, tEntity entity);
        tEntity Delete(int id_call, int id_client);

    }
}
