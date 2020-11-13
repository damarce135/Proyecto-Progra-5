﻿using EP.DAL.EF;
using EP.DAL.Repository;
using EP.DO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using data = EP.DO.Objects;

namespace EP.DAL
{
    public class Universidad : ICRUD<data.Universidad>
    {
        private Repository<data.Universidad> _repository = null;
        public Universidad(SolutionDBContext solutionDBContext)
        {
            _repository = new Repository<data.Universidad>(solutionDBContext);
        }
        public void Delete(data.Universidad t)
        {
            _repository.Delete(t);
            _repository.Commit();
        }

        public IEnumerable<data.Universidad> GetAll()
        {
            return _repository.GetAll();
        }

        public data.Universidad GetOneById(int id)
        {
            return _repository.GetOneById(id);
        }

        public void Insert(data.Universidad t)
        {
            _repository.Insert(t);
            _repository.Commit();
        }

        public void Update(data.Universidad t)
        {
            _repository.Update(t);
            _repository.Commit();
        }
    }
}
