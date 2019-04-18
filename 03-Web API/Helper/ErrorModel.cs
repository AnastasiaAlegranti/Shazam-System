using System.Collections.Generic;

namespace Anastasia
{
	public class ErrorModel
	{
		public List<string> errors { get; set; } = new List<string>();

		public void AddError(string error)
		{
			errors.Add(error);
		}
	}
}