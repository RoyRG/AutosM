using System;
using System.Collections.Generic;
using System.Text;

namespace API.Negocio.Interfaces
{
    public interface INegocioBase <T>
    {
        List<T> Get();
        void Post(T entidad);
        void Put(T entidad);
        void Delete(Guid Id);
    }
}
