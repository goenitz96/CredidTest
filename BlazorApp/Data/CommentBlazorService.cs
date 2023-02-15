using System.Globalization;
using Interfaces;
using Models;
using Newtonsoft.Json;

namespace BlazorApp.Data;

public class CommentBlazorService : ICommentService
{
    private readonly IConfiguration _configuration;
    private readonly HttpClient _httpClient;

    public CommentBlazorService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;
    }

    public async Task<IEnumerable<Comment>> getComments()
    {
       var url = _configuration["CommentsURI"];
       var response = await _httpClient.GetAsync(url);
       var content = await response.Content.ReadAsStringAsync();
       var result = JsonConvert.DeserializeObject<IEnumerable<Comment>>(content);
       var body = result.Select(x => new Comment()
       {
           name = x.name,
           email = x.email, 
           id = x.id, 
           postId = x.postId, 
           body = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(x.body)
         }).ToList();
       return body!;
    }

    public async Task<IEnumerable<Comment>> searchByNameOrBody(string name, string body)
    {
        throw new NotImplementedException();
    }
}