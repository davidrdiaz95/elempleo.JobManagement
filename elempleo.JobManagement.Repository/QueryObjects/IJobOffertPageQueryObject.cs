using elempleo.JobManagement.Repository.Entity;
using elempleo.JobManagement.Repository.QueryObjects.Base.Interface;

namespace elempleo.JobManagement.Repository.QueryObjects
{
    public interface IJobOffertPageQueryObject : IQueryObjectBase<JobOfferEntity>, IQueryObjectPageBase<JobOfferEntity>
	{
		IJobOffertPageQueryObject ForName(string name);
		IJobOffertPageQueryObject ForDescription(string description);
		int GetCount();
	}
}
