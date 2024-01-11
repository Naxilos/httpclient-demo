using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HttpClientDemo.API;

namespace HttpClientDemo;

public partial class MainPageViewModel : ObservableObject
{
	[ObservableProperty]
	ObservableCollection<Product> products = new ObservableCollection<Product>();

	private DummyClient _client;

	public MainPageViewModel(DummyClient client)
	{
		_client = client;
	}


	[RelayCommand]
	async Task LoadData()
	{
		var apiProducts = await _client.GetProducts();

		Products = new ObservableCollection<Product>(apiProducts);
	}
}

