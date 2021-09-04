using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientCall.Service
{
    public interface IService<tEntity>
    {
        List<tEntity> List();
        tEntity GetById(int id );
        List<tEntity> GetAllCallsById(int id );
        tEntity Create(tEntity entity);
        tEntity Edit(int id, tEntity entity);
        tEntity Delete(int id);

    }
}
