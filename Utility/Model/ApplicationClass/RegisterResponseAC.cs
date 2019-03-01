using Newtonsoft.Json;

namespace Utility.Model.ApplicationClass
{
	public class RegisterResponseAC
	{
		[JsonProperty("IsSuccess")]
		public bool IsSuccess { get; set; }

		[JsonProperty("Message")]
		public string Message { get; set; }
	}
}
