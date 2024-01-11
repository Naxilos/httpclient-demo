using System;
using System.Diagnostics;

namespace HttpClientDemo.API;

public class DummyClient
{
    HttpClient client = new HttpClient();


    public DummyClient()
	{
        client.BaseAddress = new Uri("https://dummyjson.com/");
	}

    public async Task<List<Product>> GetProducts(int limit = 10)
    {
        List<Product> result = new List<Product>();

        try
        {

            using HttpResponseMessage response =
                await client.GetAsync($"products?limit={limit}");

            string responseBody = await response.Content.ReadAsStringAsync();

            GetProductsResponse obj = Newtonsoft.Json.JsonConvert.DeserializeObject<GetProductsResponse>(responseBody);

            result = obj.Products;

        }
        catch (HttpRequestException ex)
        {
            await Shell.Current.DisplayAlert($"Error {(int)(ex.StatusCode ?? System.Net.HttpStatusCode.OK)}", ex.Message, "Oh snap!");
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert($"Unknown Error", ex.Message, "Oh snap!");
        }
       

        return result;
    }
}

