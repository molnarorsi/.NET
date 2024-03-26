using BlazorApp1.Api;
using BlazorApp1.Models;
using MovieBlazorAPI.Api;
using System.Text.Json;
using BlazorApp1.Extensions;

namespace MovieBlazorAPI
{
    public class ApiClient: ApiClientBase
    {
		// https://api.themoviedb.org/3/search/movie?query=Jack+Reacher&api_key=e6eb89fd137d697119f64a07d2f76449

		private static string ApiKey = "e6eb89fd137d697119f64a07d2f76449";
        private string BaseUrl = "https://api.themoviedb.org/3/";

        public List<Movie> Search(string searchTerm)
		{
			//string searchUrl = $"{BaseUrl}search/movie?query={searchTerm}&api_key={ApiKey}";
			string searchUrl = $"{BaseUrl}search/movie" +
							   $"?api_key={ApiKey}" +
							   "&language=en-US&page=1&include_adult=false" +
							   $"&query={searchTerm}";

			// Console.WriteLine(searchUrl);

			SearchResult searchResult = Get<SearchResult>(searchUrl);

			return searchResult.ToMovies();

		}

        public MovieDetailsResult GetMovieDetailsResult(int id)
        {
			// https://api.themoviedb.org/3/movie/343611?api_key=e6eb89fd137d697119f64a07d2f76449

			string detailUrl = $"{BaseUrl}/movie/{id}?api_key={ApiKey}";

            MovieDetailsResult movieDetailResult = Get<MovieDetailsResult>(detailUrl);

			return movieDetailResult;
		}

		public MovieTrailerResult GetMovieTrailerResult(int id)
		{
			// https://api.themoviedb.org/3/movie/343611?api_key=e6eb89fd137d697119f64a07d2f76449

			string videoUrl = $"{BaseUrl}/movie/{id}/videos?api_key={ApiKey}";

			MovieTrailerResult movieTrailerResult = Get<MovieTrailerResult>(videoUrl);

			return movieTrailerResult;
		}
	}
}
