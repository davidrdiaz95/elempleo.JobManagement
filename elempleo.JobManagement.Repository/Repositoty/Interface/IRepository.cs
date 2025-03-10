using Microsoft.Data.SqlClient;
using System.Linq.Expressions;

namespace elempleo.JobManagement.Repository.Repositoty.Interface
{
	public interface IRepository<T>
	{
		T? SingleFindBy(Expression<Func<T, bool>> predicate);
		T? SingleFindByInclude(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);
		IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);
		IEnumerable<T> All();
		IEnumerable<T> FindByInclude(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);
		int Insert(T entity);
		int Update(T entity);
	}
}
