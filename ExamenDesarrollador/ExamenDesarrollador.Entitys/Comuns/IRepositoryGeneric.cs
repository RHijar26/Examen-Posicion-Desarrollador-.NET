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
        Task<object> Insert(TEntity entity);
        Task<object> Insert(List<TEntity>? entities);
        Task<object> Update(TEntity entity, int Id);
        Task<object> Delete(int id);
        Task<object> Delete(TEntity entity);
        void SetStateChanged(TEntity entity);
    }
}
