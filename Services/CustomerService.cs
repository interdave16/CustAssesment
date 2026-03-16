using CustAssesment.Interfaces;
using Shared.Models;

namespace CustAssesment.Services;
public class CustomerService : ICustomerService
{
    private readonly HttpClient _http;

    public CustomerService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<Customer>> GetCustomersAsync()
    {
        return await _http.GetFromJsonAsync<List<Customer>>("api/customers") ?? new();
    }

    public async Task<Customer?> CreateCustomerAsync(Customer customer)
    {
        var response = await _http.PostAsJsonAsync("api/customers", customer);

        if (!response.IsSuccessStatusCode)
            return null;

        return await response.Content.ReadFromJsonAsync<Customer>();
    }

    public async Task<bool> UpdateCustomerAsync(Customer customer)
    {
        var response = await _http.PutAsJsonAsync($"api/customers/{customer.Id}", customer);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteCustomerAsync(int id)
    {
        var response = await _http.DeleteAsync($"api/customers/{id}");
        return response.IsSuccessStatusCode;
    }

    public async Task<Customer?> GetCustomerByIdAsync(int id)
    {
        return await _http.GetFromJsonAsync<Customer>($"api/customers/{id}");
    }
}