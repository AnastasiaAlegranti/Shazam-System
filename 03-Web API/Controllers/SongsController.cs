using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Anastasia
{
	[EnableCors("*","*","*")]
	[RoutePrefix("api")]
    public class SongsController : ApiController
    {
		private SongsLogic logic = new SongsLogic();

		[HttpGet]
		[Route ("getAllFavorites")]
		public HttpResponseMessage GetAllFavorites()
		{
			try
			{
				List<SongModel> allFavorites= logic.GetAllFavoriteSongs();
				return Request.CreateResponse(HttpStatusCode.OK, allFavorites);
			}
			catch(Exception ex)
			{
				return Request.CreateResponse(HttpStatusCode.InternalServerError, ErrorsHelper.GetErrorModel(ex));
			}
		}

		[HttpPost]
		[Route ("addToFavorites")]
		public HttpResponseMessage AddSongToFavorites (SongModel songModel)
		{
			try
			{
				if (!ModelState.IsValid)
				{
					return Request.CreateResponse(HttpStatusCode.BadRequest, ErrorsHelper.GetErrorModel(ModelState));
				}
				SongModel addedSong = logic.AddSong(songModel);
				return Request.CreateResponse(HttpStatusCode.OK, addedSong);
			}
			catch (Exception ex)
			{
				return Request.CreateResponse(HttpStatusCode.InternalServerError, ErrorsHelper.GetErrorModel(ex));
			}
		}

		[HttpDelete]
		[Route("deleteFavorite/{id}")]
		public HttpResponseMessage RemoveSongFromFavorites(int id)
		{
			try
			{
				logic.DeleteSong(id);
				return Request.CreateResponse(HttpStatusCode.NoContent);
			}
			catch (Exception ex)
			{
				return Request.CreateResponse(HttpStatusCode.InternalServerError, ErrorsHelper.GetErrorModel(ex));
			}
		}
	}
}
