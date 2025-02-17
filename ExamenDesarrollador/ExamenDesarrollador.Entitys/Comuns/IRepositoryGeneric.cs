using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenDesarrollador.Entitys.Comuns
{
    public interface IRepositoryGeneric<TEntity> where TEntity : class
    {
        Task<TEntity> GetById(int id);
        Task Insert(TEntity entity);
        Task Insert(List<TEntity>? entities);
        Task Update(TEntity entity, int Id);
        Task Delete(int id);
        Task Delete(TEntity entity);
        void SetStateChanged(TEntity entity);
    }
}
