using System.ComponentModel.DataAnnotations;

namespace Anastasia
{
	public class SongModel
	{
		public int id { get; set; }

		[Required(ErrorMessage = "Must enter song index ")]
		public int indexInClientArray { get; set; }

		[Required(ErrorMessage = "Must enter song title ")]
		[StringLength(50, ErrorMessage = "Song title can not be more than 50 chars")]
		public string title { get; set; }

		[Required(ErrorMessage = "Must enter song subtitle ")]
		[StringLength(50, ErrorMessage = "Song subtitle can not be more than 50 chars")]
		public string subTitle { get; set; }

		[Required(ErrorMessage = "Must enter  image link ")]
		[StringLength(100, ErrorMessage = "Song image link can not be more than 100 chars")]
		public string image { get; set; }

		[Required(ErrorMessage = "Must enter link ")]
		[StringLength(100, ErrorMessage = "Song link can not be more than 100 chars")]
		public string link { get; set; }
	}
}
