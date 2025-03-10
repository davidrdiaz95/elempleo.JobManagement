using elempleo.JobManagement.Repository.Context;
using elempleo.JobManagement.Repository.Repositoty.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Linq.Expressions;

namespace elempleo.JobManagement.Repository.Repositoty.Service
{
	public class Repository<T> : IRepository<T> where T : Entity.Base.Entity
	{
		private readonly ElEmpleoContext contextDataBase;
		private readonly DbSet<T> entity;

		public Repository(ElEmpleoContext contextDataBase)
		{
			this.contextDataBase = contextDataBase;
			this.entity = this.contextDataBase.Set<T>();
		}

		public IEnumerable<T> All()
		{
			IQueryable<T> query = this.entity
				.AsNoTracking();

			return query.ToList();
		}

		public IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate)
		{
			IQueryable<T> query = this.entity
				.AsNoTracking()
				.Where(predicate);

			return query.ToList();
		}

		public IEnumerable<T> FindByInclude(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
		{
			IQueryable<T> query = this.entity
				.AsNoTracking()
				.Where(predicate);

			foreach (var include in includes)
			{
				query = query.Include(include);
			}

			return query.ToList();
		}

		public T? SingleFindBy(Expression<Func<T, bool>> predicate)
		{
			return this.entity
				.SingleOrDefault(predicate);
		}

		public T? SingleFindByInclude(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
		{
			IQueryable<T> query = this.entity
				.AsNoTracking()
				.Where(predicate);

			foreach (var include in includes)
			{
				query = query.Include(include);
			}

			return query.SingleOrDefault();
		}


		public int Insert(T entity)
		{
			if (entity == null) throw new ArgumentNullException("entity");
			int record = 0;
			using (IDbContextTransaction transaction = this.contextDataBase.Database.BeginTransaction())
			{
				this.entity.Add(entity);
				record = this.contextDataBase.SaveChanges();
				if (record > 0)
					transaction.Commit();
				else
					transaction.Rollback();
			}
			return record;
		}

		public int Update(T entity)
		{
			if (entity == null) throw new ArgumentNullException("entity");
			var record = this.contextDataBase.SaveChanges();
			return record;
		}

	}
}
