using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
	public class SQLiteDBContext : DbContext 
	{
		public DbSet<Watchlist> Watchlists { get; set; }
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
			=> optionsBuilder.UseSqlite("Data Source=sqlitedemo.db");
	}
}
