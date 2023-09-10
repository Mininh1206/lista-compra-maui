using ListaCompraApp.Helpers;
using ListaCompraApp.Views;

namespace ListaCompraApp;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}
