using System.Collections.Generic;
using System.Linq;

namespace Anastasia
{
	public class SongsLogic:BaseLogic
	{
		public List<SongModel> GetAllFavoriteSongs()
		{
			return DB.Songs.Select(s => new SongModel
			{
				id = s.SongId,
				indexInClientArray = s.SongListNumber,
				title = s.SongTitle,
				subTitle = s.SongSubtitle,
				image = s.SongImage,
				link = s.SongLink
			}).ToList();
		}

		public  SongModel GetOneSong(int id)
		{
			return DB.Songs
				.Where(s => s.SongId == id)
				.Select(s => new SongModel
				{
					id = s.SongId,
					indexInClientArray = s.SongListNumber,
					title = s.SongTitle,
					subTitle = s.SongSubtitle,
					image = s.SongImage,
					link = s.SongLink
				}).SingleOrDefault();
		}

		public SongModel AddSong(SongModel songModel)
		{
			Song song = new Song
			{
				SongListNumber = songModel.indexInClientArray,
				SongTitle = songModel.title,
				SongSubtitle = songModel.subTitle,
				SongImage = songModel.image,
				SongLink = songModel.link
			};
			DB.Songs.Add(song);
			DB.SaveChanges();
			return GetOneSong(song.SongId);
		}

		public void DeleteSong(int id)
		{
			Song song = DB.Songs.Where(s => s.SongListNumber == id).FirstOrDefault();
			if (song == null)
				return;

			DB.Songs.Remove(song);
			DB.SaveChanges();
		}
	}
}
