using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Utility.Model.ApplicationClass
{
	public class LoginResponseAC
	{
		[JsonProperty("Id")]
		public string Id { get; set; }

		[JsonProperty("Role")]
		public string Role { get; set; }

		[JsonProperty("Status")]
		public int Status { get; set; }
		
		[JsonProperty("Message")]
		public string Message { get;set;}

		[JsonProperty("AccessToken")]
		public string AccessToken { get;set;}
	}
}
