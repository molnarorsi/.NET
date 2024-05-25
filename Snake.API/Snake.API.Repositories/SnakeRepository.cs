using MongoDB.Driver;
using Snake.API.Data.Abstraction;
using Snake.API.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.API.Repositories
{
	public class SnakeRepository : ISnakeRepository
	{
		private readonly IMongoCollection<Domain.Snake> snakes;
		public SnakeRepository(IDatabase database) {
			this.snakes = database.GetCollection<IMongoCollection<Domain.Snake>, Domain.Snake>("Snakes");
		}
		public void Add(float points, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}

		public bool Delete(int id, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}

		public IList<Domain.Snake> GetAll(CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
	}
}
