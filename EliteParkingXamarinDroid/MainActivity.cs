using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Net;
using System.IO;
using System.Json;
using System.Threading.Tasks;

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

				string url = "http://eliteparkingapp.com/login.php?cedula=" +
					cedula.Text +
					"&contrasena=" +
					pass.Text;

				System.Console.WriteLine(url);
				JsonValue json = await FetchWeatherAsync (url);
				ParseAndDisplay (json);
			};

			Button registrar = FindViewById<Button> (Resource.Id.registrar);			
			registrar.Click += (sender, e) =>
			{
				var intent = new Intent(this, typeof(RegistroActivity));
				StartActivity(intent);
			};
		}

		private async Task<JsonValue> FetchWeatherAsync (string url)
		{
			// Create an HTTP web request using the URL:
			HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create (new Uri (url));
			request.ContentType = "application/json";
			request.Method = "GET";

			// Send the request to the server and wait for the response:
			using (WebResponse response = await request.GetResponseAsync ())
			{
				// Get a stream representation of the HTTP web response:
				using (Stream stream = response.GetResponseStream ())
				{
					// Use this stream to build a JSON document object:
					JsonValue jsonDoc = await Task.Run (() => JsonObject.Load (stream));
					Console.Out.WriteLine("Response: ", jsonDoc.ToString ());

					// Return the JSON document:
					return jsonDoc;
				}
			}
		}

		private void ParseAndDisplay (JsonValue json)
		{
			TextView estado = FindViewById<TextView>(Resource.Id.estado);

			estado.Text = "idUsuarioApp";
		}

	}
}


