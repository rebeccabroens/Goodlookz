﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Good_Lookz.View.SignPages
{
	public partial class ForgotPassword : ContentPage
	{
		public ForgotPassword()
		{
			InitializeComponent();
		}



		private void btnClicked(object sender, EventArgs e)
		{
			if(enMail.TextColor == Color.Red)
			{
				DisplayAlert("Warning", "Invalid e-mail address.", "Ok");
			}
			else if (string.IsNullOrEmpty(enMail.Text))
			{
				DisplayAlert("Warning", "Please provide your e-mail before proceeding.", "Ok");
			}
			else
			{
				//Sla email op in static class voor het volgende form
				Models.Settings.ResetPWD.mail = enMail.Text;

				//Verstuur de mail
				sendMail();

			}
		}

		private async void CodeClicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new View.SignPages.ResetCode(), true);
		}

		private async void sendMail()
		{
			try
			{
				string users_id = Models.LoginCredentials.loginId;
				string url = "http://www.good-lookz.com/API/email/emailForgotPWD.php?email=" + enMail.Text;

				HttpClient insert = new HttpClient();
				HttpResponseMessage response = await insert.GetAsync(url);
				response.EnsureSuccessStatusCode();
				string result = await response.Content.ReadAsStringAsync();

				if (result == "Success ")
				{
					await DisplayAlert("Message", "Mail has been sent, make sure to check your inbox.", "Ok");
					await Navigation.PushAsync(new View.SignPages.ResetCode(), true);
				}
				else if (result == "Failed ")
				{
					await DisplayAlert("Error", "Something went wrong, please check your internet connection and try again.", "OK");
				}

			}
			catch (Exception)
			{
				await DisplayAlert("Error", "Something went wrong, please check your internet connection and try again.", "OK");
				throw;
			}
		}
	}
}