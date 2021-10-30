using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using SwapiUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace SwapiUI.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IHttpClientFactory _httpClientFactory;

        public IndexModel(ILogger<IndexModel> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }

        public async Task OnGet()
        {
            await GetPeople();
        }

        private async Task GetPeople()
        {
            var _client = _httpClientFactory.CreateClient();
            var response = await _client.GetAsync("https://swapi.dev/api/people/1/");

            PeopleModel people;

            if (response.IsSuccessStatusCode)
            {
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                string responseText = await response.Content.ReadAsStringAsync();
                people = JsonSerializer.Deserialize<PeopleModel>(responseText);

                await GetFilm(people);
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }

        }

        private async Task GetFilm(PeopleModel people)
        {
            var _client = _httpClientFactory.CreateClient();
            var response = await _client.GetAsync(people.films[0]);

            FilmModel film;

            if (response.IsSuccessStatusCode)
            {
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                string responseText = await response.Content.ReadAsStringAsync();
                film = JsonSerializer.Deserialize<FilmModel>(responseText);
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }

        }
    }
}
