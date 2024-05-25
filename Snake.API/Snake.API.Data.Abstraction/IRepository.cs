using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.API.Data.Abstraction
{
	public interface IRepository<T> where T : class
	{
		void Add(float points, CancellationToken cancellationToken);
		IList<T> GetAll(CancellationToken cancellationToken);
		bool Delete(int id, CancellationToken cancellationToken);
	}
}

