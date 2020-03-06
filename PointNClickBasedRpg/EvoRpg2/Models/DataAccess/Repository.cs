using EvoRpg2.Helpers.DataAccess;
using EvoRpg2.Models.Interfaces;
using System.Collections.Generic;

namespace EvoRpg2
{
    public class Repository<T> where T : IEntity
    {
        private List<T> _entities;
        private IContextHelper _contextHelper;

        private int NextFreeID { get; }

        public Repository(List<T> entities, IContextHelper contextHelper)
        {
            _entities = entities;
            _contextHelper = contextHelper;
        }

        //CREATE
        public void Add(T entity)
        {
            _entities.Add(entity);
        }

        public void AddList(List<T> entities)
        {
            _entities.AddRange(entities);
        }

        public T GetEntityById(int id)
        {
            return _entities[id];
        }

        //DELETE
        public void Delete(T entity)
        {
            _entities.Remove(entity);
        }

        public void DeleteList(List<T> entities)
        {
            _entities.RemoveAll(x => entities.Contains(x));
        }

        public void Save()
        {
            _contextHelper.SaveDataType(_entities);
        }
    }
}
