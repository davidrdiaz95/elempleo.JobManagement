using elempleo.JobManagement.Repository.QueryObjects.Base.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace elempleo.JobManagement.Repository.QueryObjects.Base.Service
{
	public abstract class QueryObjectPageBase<T> : IQueryObjectBase<T>
	{
		protected abstract int Page { get; set; }
		protected abstract int Size { get; set; }
		protected abstract int Count { get; set; }
		protected abstract IQueryable<T> AppliFylters(IQueryable<T> query);
		protected abstract IQueryable<T> NewQueryInstance();
		protected abstract IOrderedQueryable<T> ApplySort(IQueryable<T> query);
		protected abstract IOrderedQueryable<T> ApplyThenSort(IOrderedQueryable<T> query);
		protected abstract void Clear();

		private IQueryable<T> GenerateQueryExpression()
		{
			IQueryable<T> query = NewQueryInstance();
			query = AppliFylters(query);
			Count = query.Count();
			return ApplyPagination(ApplyThenSort(ApplySort(query)));
		}

		private IQueryable<T> ApplyPagination(IOrderedQueryable<T> queryOrder)
		{
			return queryOrder.Skip(Page * Size).Take(Size);
		}

		public IEnumerable<T> Query()
		{
			return GenerateQueryExpression().ToList();
		}

		public T QueryFirst()
		{
			return GenerateQueryExpression().FirstOrDefault();
		}
	}
}
