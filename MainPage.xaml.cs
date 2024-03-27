using System;
using System.Net.Http;
using Xamarin.Forms;
using Newtonsoft.Json.Linq;

namespace App1
{
    public partial class MainPage : ContentPage
    {
        const string API = "1e8d464af859af9ea25f5936ca243dc7";
        public MainPage()
        {
            InitializeComponent();
        }
        private void Image()
        {
            DateTime currentTime = DateTime.Now;
        }

        private async void WeatherGet_Clicked(object sender, EventArgs e)
        {
            string City = Input.Text.Trim();
            if (City.Length < 2)
            {
                await DisplayAlert("Ошибка","Укажите город верно","ОК");
                return;
            }
            HttpClient client = new HttpClient();
            string url = $"https://api.openweathermap.org/data/2.5/weather?q={City}&appid={API}";
            string response = await client.GetStringAsync(url);
            var json = JObject.Parse(response);
            string temp = json["main"]["temp"].ToString();
            
            ResultWeather.Text ="Погода сейчас: "+ temp +" F";


        }

    }
}
