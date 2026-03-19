using Grade.Common.Models;


namespace Grade.Web.Services;

public class GradeApiService
{
    private readonly IHttpClientFactory _httpClientFactory;
    
    public GradeApiService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    
    public async Task<GradeResponse?> GetGradeAsync(int percentage, CancellationToken ct = default)
    {
        if (percentage < 0 || percentage > 100)
            return null;
        
        var client = _httpClientFactory.CreateClient("GradeApi");
        
        var request = new GradeRequest() { Percentage = percentage };
        
        
        var response = await client.PostAsJsonAsync("api/grades/calculate", request, ct);
        
        if (!response.IsSuccessStatusCode) 
            return null;
        
        return await response.Content.ReadFromJsonAsync<GradeResponse>(cancellationToken: ct);
        
    }
}