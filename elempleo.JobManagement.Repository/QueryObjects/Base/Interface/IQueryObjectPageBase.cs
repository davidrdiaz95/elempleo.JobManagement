namespace elempleo.JobManagement.Repository.QueryObjects.Base.Interface
{
	public interface IQueryObjectPageBase<T>
	{
		IQueryObjectBase<T> SetPagination(int page, int size);
	}
}
