﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace app.Context
{
    public class Repository<T>: IRepository<T>
        where T : class
    {
        #region Dependencies  

        private readonly EFDbContext _context;

        #endregion Dependencies  

        #region Fields

        private DbSet<T> entities;

        #endregion Fields

        #region Ctors

        public Repository(EFDbContext context)
        {
            _context = context;
        }

        #endregion Ctors

        #region Properties

        private DbSet<T> Entities
        {
            get
            {
                if (entities == null)
                {
                    entities = _context.Set<T>();
                }

                return entities;
            }
        }

        #endregion Properties

        #region IRepository

        public void Create(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            Entities.Add(entity);
            Save();
        }        

        public T GetItemById(int id)
        {
            return Entities.Find(id);
        }        

        public IEnumerable<T> GetItemList()
        {
            return Entities.AsEnumerable();
        }

        public void Save()
        {
            _context.SaveChanges();
        }        

        #endregion IRepository
    }
}
