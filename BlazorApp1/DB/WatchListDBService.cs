using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
	public class WatchListDBService
	{
		public bool InWatchlist(int movieId)
		{
			using (var db = new SQLiteDBContext()) { 
				return db.Watchlists.Any(X => X.MovieId == movieId);
			}
		}

		public bool TryAdd(Watchlist watchlist)
		{
			if(InWatchlist(watchlist.MovieId))
			{
				return false;
			}
			using (var db = new SQLiteDBContext())
			{
				db.Watchlists.Add(watchlist);
				db.SaveChanges();
				return true;
			}
		}

		public List<Watchlist> Get() {
			using (var db = new SQLiteDBContext())
			{
				return db.Watchlists.ToList();
			}
		}

		public bool Remove(int movieId)
		{
			using(var db = new SQLiteDBContext())
			{
				var item = db.Watchlists.FirstOrDefault(x => x.MovieId == movieId);
				if (item != null)
				{
					db.Watchlists.Remove(item);
					db.SaveChanges();
					return true;
				}
				return false;
			}
		}
	}
}
