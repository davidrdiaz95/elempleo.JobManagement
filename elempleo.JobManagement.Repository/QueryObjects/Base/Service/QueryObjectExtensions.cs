using elempleo.JobManagement.Repository.QueryObjects.Base.Interface;

namespace elempleo.JobManagement.Repository.QueryObjects.Base.Service
{
	public static class QueryObjectExtensions
	{
		public static List<T> GetAll<T>(this IQueryObjectBase<T> query)
		{
			return query.Query().ToList();
		}

		public static T GetFirst<T>(this IQueryObjectBase<T> query)
		{
			return query.QueryFirst();
		}
	}
}
