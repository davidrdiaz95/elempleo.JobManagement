using elempleo.JobManagement.Model.Dto;
using elempleo.JobManagement.Services.Command;

namespace elempleo.JobManagement.BusinessServices.Command
{
	public class CreateApplicateForEmailCommand : ICreateApplicateForEmailCommand
	{
		public async Task<bool> Execute(ApplicateJobDto applicateJob)
		{
			var trimmedEmail = applicateJob.Email.Trim();

			if (string.IsNullOrEmpty(applicateJob.Email) || string.IsNullOrEmpty(applicateJob.Name))
				return false;

			if (trimmedEmail.EndsWith("."))
				return false;
			try
			{
				var addr = new System.Net.Mail.MailAddress(applicateJob.Email);
				return addr.Address == trimmedEmail;
			}
			catch
			{
				return false;
			}
		}
	}
}
