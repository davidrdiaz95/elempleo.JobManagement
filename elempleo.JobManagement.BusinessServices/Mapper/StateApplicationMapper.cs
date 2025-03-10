using elempleo.JobManagement.Model.Dto;
using elempleo.JobManagement.Repository.Entity;

namespace elempleo.JobManagement.BusinessServices.Mapper
{
    public static class StateApplicationMapper
    {
		public static StateApplicationDto MapFrom(this StateApplicationEntity model)
		{
			var state = new StateApplicationDto
			{
				Name = model.Name,
				Id = model.Id

			};
			return state;
		}

		public static StateApplicationEntity MapTo(this StateApplicationDto model)
		{
			var state = new StateApplicationEntity
			{
				Name = model.Name
			};
			return state;
		}
	}
}
