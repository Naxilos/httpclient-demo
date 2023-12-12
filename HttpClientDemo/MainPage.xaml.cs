using System.Net.Http;

namespace HttpClientDemo;

public partial class MainPage : ContentPage
{
	HttpClient client = new HttpClient();

	public MainPage()
	{
		InitializeComponent();
	}

	private async void OnCounterClicked(object sender, EventArgs e)
	{
		try
		{
			using HttpResponseMessage response = await client.GetAsync("https://dummyjson.com/products?limit=20");

			string responseBody = await response.Content.ReadAsStringAsync();

			GetProductsResponse obj = Newtonsoft.Json.JsonConvert.DeserializeObject< GetProductsResponse>(responseBody);

			ProductsCollection.ItemsSource = obj.Products;

		}
		catch(HttpRequestException ex)
		{
            await Shell.Current.DisplayAlert($"Error {(int)(ex.StatusCode ?? System.Net.HttpStatusCode.OK)}", ex.Message, "Oh snap!");
		}
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert($"Unknown Error", ex.Message, "Oh snap!");
        }
    }
}