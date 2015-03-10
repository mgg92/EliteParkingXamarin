using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Json;

namespace EliteParkingXamarinDroid
{
	[Activity (Label = "EliteParkingXamarinDroid", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			EditText cedula = FindViewById<EditText> (Resource.Id.INcedula);
			EditText pass = FindViewById<EditText> (Resource.Id.INPass);
			Button iniciar = FindViewById<Button>(Resource.Id.inicio);

			iniciar.Click += async (sender, e) => {

				string url = "http://eliteparkingapp.com?cedula=" +
					cedula.Text +
					"?pass=" +
					pass.Text;

				System.Console.WriteLine(url); 
				//JsonValue json = await FetchWeatherAsync (url);
			};

			Button registrar = FindViewById<Button> (Resource.Id.registrar);
			
			registrar.Click += (sender, e) =>
			{
				var intent = new Intent(this, typeof(RegistroActivity));
				StartActivity(intent);
			};
		}
	}
}


