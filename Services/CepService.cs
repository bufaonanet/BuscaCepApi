namespace BuscaCepApi.Services;

public class CepService : ICepService
{
    private readonly HttpClient _client;

    public CepService(HttpClient client)
    {
        _client = client;
    }

    public async Task<string?> GetEnderecoAsync(string cep, CancellationToken cancellationToken)
    {
        try
        {
            Console.WriteLine("\nAguardando 4 segundos");
            await Task.Delay(4000);
            Console.WriteLine("\nBuscando CEP");

            HttpResponseMessage response = await _client.GetAsync($"https://viacep.com.br/ws/{cep}/json/", cancellationToken);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine("\nHttpRequestException Caught");
            Console.WriteLine("Message {0}", e.Message);           
        }
        catch (TaskCanceledException e)
        {
            Console.WriteLine("\nTaskCanceledException Caught");
            Console.WriteLine("Task Canceled {0}", e.Message);
        }

        return null;
    }
}
