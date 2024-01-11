using System.Net.Http;

namespace HttpClientDemo;

public partial class MainPage : ContentPage
{

	public MainPage(MainPageViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}


}