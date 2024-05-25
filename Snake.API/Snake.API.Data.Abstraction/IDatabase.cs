using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.API.Data.Abstraction
{
    public interface IDatabase
    {
        public TCollection GetCollection<TCollection, TItem>(string name) where TCollection : class;
    }
}
