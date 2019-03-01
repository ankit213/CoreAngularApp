using System;
using System.Threading.Tasks;

namespace CoreAngularApp.Seed
{
	public interface IEnsureSeedData
	{
		/// <summary>
		/// This method used for seed (insert admin record). -An
		/// </summary>
		/// <param name="serviceProvider"></param>
		 Task Seed(IServiceProvider serviceProvider);

	}
}
