using elempleo.JobManagement.Repository.Context;
using elempleo.JobManagement.Repository.Entity;
using elempleo.JobManagement.Repository.QueryObjects;
using elempleo.JobManagement.Repository.QueryObjects.Base.Interface;
using elempleo.JobManagement.Repository.QueryObjects.Base.Service;

namespace elempleo.JobManagement.BusinessServices.QueryObjects
{
	public class JobOffertPageQueryObject : QueryObjectPageBase<JobOfferEntity>, IJobOffertPageQueryObject
	{
		private readonly ElEmpleoContext context;
		public string description;
		public string name;

		public JobOffertPageQueryObject(ElEmpleoContext contextDb)
		{
			this.context = contextDb;
		}

		protected override int Page { get; set; }
		protected override int Size { get; set; }
		protected override int Count { get; set; }


		public IJobOffertPageQueryObject ForDescription(string description)
		{
			this.description = description;
			return this;
		}

		public IJobOffertPageQueryObject ForName(string name)
		{
			this.name = name;
			return this;
		}

		public int GetCount()
		{
			return this.Count;
		}

		public IQueryObjectBase<JobOfferEntity> SetPagination(int page, int size)
		{
			this.Page = page;
			this.Size = size;
			return this;
		}

		protected override IQueryable<JobOfferEntity> AppliFylters(IQueryable<JobOfferEntity> query)
		{
			if (!string.IsNullOrEmpty(name))
				query = query.Where(x => x.Name.Contains(name));

			if (!string.IsNullOrEmpty(description))
				query = query.Where(x => x.Description.Contains(description));

			query = query.Where(x => x.IsActive);

			return query;
		}

		protected override IOrderedQueryable<JobOfferEntity> ApplySort(IQueryable<JobOfferEntity> query)
		{
			return query.OrderByDescending(x => x.DateCreate);
		}

		protected override IOrderedQueryable<JobOfferEntity> ApplyThenSort(IOrderedQueryable<JobOfferEntity> query)
		{
			return query.ThenByDescending(x => x.Name);
		}

		protected override void Clear()
		{
			this.name = string.Empty;
			this.description = string.Empty;
		}

		protected override IQueryable<JobOfferEntity> NewQueryInstance()
		{
			return this.context.JobOffer.AsQueryable();
		}
	}
}
