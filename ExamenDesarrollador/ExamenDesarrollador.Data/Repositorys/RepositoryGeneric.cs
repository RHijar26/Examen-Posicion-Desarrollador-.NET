using ExamenDesarrollador.Data.Context;
using ExamenDesarrollador.Entitys.Comuns;
using ExamenDesarrollador.Entitys.SeedWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenDesarrollador.Data.Repositorys
{
    public class RepositoryGeneric<TEntity> : IRepositoryGeneric<TEntity> where TEntity : class
    {
        public ContextDBO _context;

        public RepositoryGeneric(ContextDBO context)
        {
            _context = context;
        }

        public async Task Delete(int id)
        {
            var aux = await GetById(id);
            await Delete(aux);
        }

        public Task Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);            

            return Task.CompletedTask;  
        }

        public async Task<TEntity> GetById(int id)
        {
            var entity = await _context.Set<TEntity>().FindAsync(id);
            return entity;
        }

        public async Task Insert(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);            
        }

        public async Task Insert(List<TEntity>? entities)
        {
            await _context.Set<TEntity>().AddRangeAsync(entities);
        }

        public void SetStateChanged(TEntity entity)
        {
            _context.Entry<TEntity>(entity).State = EntityState.Modified;
        }

        public async Task Update(TEntity entity, int Id)
        {
            var entityDB = await _context.Set<TEntity>().FindAsync(Id);

            _context.Entry<TEntity>(entityDB).State = EntityState.Modified;

            if (entityDB == null)
            {
                throw new Exception("No existe la entidad");
            }

            _context.Entry(entityDB).CurrentValues.SetValues(entity);
        }
    }
}
