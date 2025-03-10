using elempleo.JobManagement.Repository.QueryObjects.Base.Interface;

namespace elempleo.JobManagement.Repository.QueryObjects.Base.Service
{
	public abstract class QueryObjectBase<T> : IQueryObjectBase<T>
	{
		protected abstract IQueryable<T> AppliFylters(IQueryable<T> query);

		protected abstract void Clear();

		protected abstract IQueryable<T> NewQueryInstance();

		private IQueryable<T> GenerateQueryExpression()
		{
			IQueryable<T> query = NewQueryInstance();
			return AppliFylters(query);
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
