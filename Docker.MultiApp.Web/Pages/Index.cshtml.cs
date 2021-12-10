using Docker.MultiApp.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace Docker.MultiApp.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;       
        }

        public async Task OnGetAsync()
        {
            using (var client = new System.Net.Http.HttpClient())
            {

                var bookModel = new { Name = "", Author ="", Price = 0, Category="" };
               
                var request = new System.Net.Http.HttpRequestMessage();
                request.RequestUri = new Uri("http://docker.multiapp.api/api/Book");
                var response = await client.SendAsync(request);
                var bookList = await response.Content.ReadAsStringAsync();
                var details = JObject.Parse(bookList);
                ViewData["Book"] = details["name"] + ";;" + details["author"] + ";;" + details["price"]+ ";;" + details["category"];
               // ViewData["Books"] = books;// books[0]["name"] + ";;" + books[0]["text"] + ";;" + books[0]["category"];
            }
        }
    }
}
