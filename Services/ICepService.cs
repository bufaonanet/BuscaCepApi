namespace BuscaCepApi.Services;

public interface ICepService
{
    Task<string?> GetEnderecoAsync(string cep, CancellationToken cancellationToken);
}