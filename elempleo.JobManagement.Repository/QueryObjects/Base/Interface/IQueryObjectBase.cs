namespace elempleo.JobManagement.Repository.QueryObjects.Base.Interface
{
	public interface IQueryObjectBase<T>
	{
		IEnumerable<T> Query();
		T QueryFirst();
	}
}
