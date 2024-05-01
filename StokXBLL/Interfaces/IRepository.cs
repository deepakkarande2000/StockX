using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Model;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokXBLL
{
    public interface IRepository<T,U> where T : class
    {
        Task<List<T>> AddData(U entity);

        Task<List<T>>Update(U entity);

        Task<List<U>> Delete(U entity);
    }
}
