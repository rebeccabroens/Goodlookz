﻿using ModernHttpClient;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Good_Lookz.View
{
    /// <summary>
    /// Values dat opgeslagen moet worden in een class.
    /// </summary>
    class wardrobeItems
    {
        private static bool _noItems = false;

        public static bool noItems
        {
            get { return _noItems; }
            set { _noItems = value; }
        }
    }

    /// <summary>
    /// Code behind voor deze page (backend)
    /// </summary>
    public partial class WardrobePage : ContentPage
    {
        private HttpClient _client = new HttpClient(new NativeMessageHandler());

        /// <summary>
        /// List maken voor de 4 type clothes en later pas invullen met data.
        /// Dit moet op deze manier zodat er dan de Clear functie uitgevoerd kan worden.
        /// </summary>
        List<Models.WardrobeHead> gets_Head = new List<Models.WardrobeHead>();
        List<Models.WardrobeTop> gets_Top = new List<Models.WardrobeTop>();
        List<Models.WardrobeBottom> gets_Bottom = new List<Models.WardrobeBottom>();
        List<Models.WardrobeFeet> gets_Feet = new List<Models.WardrobeFeet>();

        public WardrobePage()
        {
            InitializeComponent();

            btnAdd.HeightRequest = 20;
            btnAdd.MinimumHeightRequest = 20;
            btnSave.HeightRequest = 45.0;
            btnSets.HeightRequest = 45.0;

            btnAdd.BackgroundColor = Color.Transparent;
            btnSave.BackgroundColor = Color.Transparent;
            btnSets.BackgroundColor = Color.Transparent;
        }

        protected override async void OnAppearing()
        {
            loadingHead.IsRunning = true;
            loadingTop.IsRunning = true;
            loadingBottom.IsRunning = true;
            loadingFeet.IsRunning = true;

            string Url_Head = "http://good-lookz.com/API/wardrobe/head/headDownload.php?users_id={0}";

            string data_Head = Models.LoginCredentials.loginId;

            string urlFilled_Head = string.Format(Url_Head, data_Head);

            var content_Head = await _client.GetStringAsync(urlFilled_Head);
            gets_Head = JsonConvert.DeserializeObject<List<Models.WardrobeHead>>(content_Head);

            loadingHead.IsRunning = false;
            loadingHead.IsVisible = false;

            try
            {
                // List vullen met de opgehaalde data
                CarouselViewHead.ItemsSource = gets_Head;
            }
            catch
            {

            }

            // ---------------------------

            string Url_Top = "http://good-lookz.com/API/wardrobe/top/topDownload.php?users_id={0}&size={1}";

            string data_Top = Models.LoginCredentials.loginId;
            string size_Top = "";

            string urlFilled_Top = string.Format(Url_Top, data_Top, size_Top);

            var content_Top = await _client.GetStringAsync(urlFilled_Top);
            gets_Top = JsonConvert.DeserializeObject<List<Models.WardrobeTop>>(content_Top);

            loadingTop.IsRunning = false;
            loadingTop.IsVisible = false;

            try
            {
                // List vullen met de opgehaalde data
                CarouselViewTop.ItemsSource = gets_Top;
            }
            catch
            {

            }

            // ---------------------------

            string Url_Bottom = "http://good-lookz.com/API/wardrobe/bottom/bottomDownload.php?users_id={0}&size={1}";

            string data_Bottom = Models.LoginCredentials.loginId;
            string size_Bottom = "";

            string urlFilled_Bottom = string.Format(Url_Bottom, data_Bottom, size_Bottom);

            var content_Bottom = await _client.GetStringAsync(urlFilled_Bottom);
            gets_Bottom = JsonConvert.DeserializeObject<List<Models.WardrobeBottom>>(content_Bottom);

            loadingBottom.IsRunning = false;
            loadingBottom.IsVisible = false;

            try
            {
                // List vullen met de opgehaalde data
                CarouselViewBottom.ItemsSource = gets_Bottom;
            }
            catch
            {

            }
            
            // ---------------------------

            string Url_Feet = "http://good-lookz.com/API/wardrobe/feet/feetDownload.php?users_id={0}&size={1}";

            string data_Feet = Models.LoginCredentials.loginId;
            string size_Feet = "";

            string urlFilled_Feet = string.Format(Url_Feet, data_Feet, size_Feet);

            var content_Feet = await _client.GetStringAsync(urlFilled_Feet);
            gets_Feet = JsonConvert.DeserializeObject<List<Models.WardrobeFeet>>(content_Feet);

            loadingFeet.IsRunning = false;
            loadingFeet.IsVisible = false;

            try
            {
                // List vullen met de opgehaalde data
                CarouselViewFeet.ItemsSource = gets_Feet;
            }
            catch
            {
                
            }

            // ---------------------------

            base.OnAppearing();

            var hasHead = gets_Head.Count;
            var hasTop = gets_Top.Count;
            var hasBottom = gets_Bottom.Count;
            var hasFeet = gets_Feet.Count;

            if ((hasHead == 0) && (hasTop == 0) && (hasBottom == 0) && (hasFeet == 0))
            {
                var _noItems = true;
                wardrobeItems.noItems = _noItems;

				//await DisplayAlert("Hello!", "This is your first time opening wardrobe. \n\nStart by adding some clothes!\n('add' button will let you add clothed.)", "OK");
				await DisplayAlert("Hello!", "Looks like your wardrobe is empty.\n\nLet's start by adding some clothing. \n(the 'add' button will let you add clothes.)", "OK");
			}
        }

        void CarouselViewHead_Selected(object sender, SelectedItemChangedEventArgs e)
        {
            Models.WardrobeHead SelectedHead = (Models.WardrobeHead)e.SelectedItem;

            var _head_id = SelectedHead.head_id;
            var _users_id = SelectedHead.users_id;
            var _picture = SelectedHead.picture;
            var _color = SelectedHead.color;
            var _date = SelectedHead.date;

            Models.SelectedHead.head_id = _head_id;
            Models.SelectedHead.users_id = _users_id;
            Models.SelectedHead.picture = _picture;
            Models.SelectedHead.color = _color;
            Models.SelectedHead.date = _date;
        }
        void CarouselViewTop_Selected(object sender, SelectedItemChangedEventArgs e)
        {
            Models.WardrobeTop SelectedTop = (Models.WardrobeTop)e.SelectedItem;

            var _top_id = SelectedTop.top_id;
            var _users_id = SelectedTop.users_id;
            var _picture = SelectedTop.picture;
            var _color = SelectedTop.color;
            var _date = SelectedTop.date;
            var _size = SelectedTop.size;

            Models.SelectedTop.top_id = _top_id;
            Models.SelectedTop.users_id = _users_id;
            Models.SelectedTop.picture = _picture;
            Models.SelectedTop.color = _color;
            Models.SelectedTop.date = _date;
            Models.SelectedTop.size = _size;
        }
        void CarouselViewBottom_Selected(object sender, SelectedItemChangedEventArgs e)
        {
            Models.WardrobeBottom SelectedBottom = (Models.WardrobeBottom)e.SelectedItem;

            var _bottom_id = SelectedBottom.bottom_id;
            var _users_id = SelectedBottom.users_id;
            var _picture = SelectedBottom.picture;
            var _color = SelectedBottom.color;
            var _date = SelectedBottom.date;
            var _size = SelectedBottom.size;

            Models.SelectedBottom.bottom_id = _bottom_id;
            Models.SelectedBottom.users_id = _users_id;
            Models.SelectedBottom.picture = _picture;
            Models.SelectedBottom.color = _color;
            Models.SelectedBottom.date = _date;
            Models.SelectedBottom.size = _size;
        }
        void CarouselViewFeet_Selected(object sender, SelectedItemChangedEventArgs e)
        {
            Models.WardrobeFeet SelectedFeet = (Models.WardrobeFeet)e.SelectedItem;

            var _feet_id = SelectedFeet.feet_id;
            var _users_id = SelectedFeet.users_id;
            var _picture = SelectedFeet.picture;
            var _color = SelectedFeet.color;
            var _date = SelectedFeet.date;
            var _size = SelectedFeet.size;

            Models.SelectedFeet.feet_id = _feet_id;
            Models.SelectedFeet.users_id = _users_id;
            Models.SelectedFeet.picture = _picture;
            Models.SelectedFeet.color = _color;
            Models.SelectedFeet.date = _date;
            Models.SelectedFeet.size = _size;
        }

        async void Add_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new WardrobePages.WardrobeAdd(), true);
        }

        async void Sets_Clicked(object sender, EventArgs e)
        {
            if (wardrobeItems.noItems == true)
            {
                await DisplayAlert("Wait!", "Add atleast one clothing so you can continue.", "OK");
            }
            else
            {
                await Navigation.PushAsync(new WardrobePages.WardrobeSets(), true);

                //var head = Models.SelectedHead.head_id.ToString();
                //var top = Models.SelectedTop.top_id.ToString();
                //var bottom = Models.SelectedBottom.bottom_id.ToString();
                //var feet = Models.SelectedFeet.feet_id.ToString();
                //var users_id = Models.LoginCredentials.loginId;

                ////var headString = head.ToString();

                //var itemsid = "Would you like to save the clothes as a set? \nitems: {0} - {1} - {2} - {3}";
                //var fullString = string.Format(itemsid, head, top, bottom, feet);

                //var answer = await DisplayAlert("Save?", itemsid, "Yes", "No");

                //var values = new Dictionary<string, string>
                //    {
                //        { "users_id", users_id },
                //        { "name",  },
                //        { "head_id", head },
                //        { "top_id", top },
                //        { "bottom_id", bottom },
                //        { "feet_id", feet }
                //    };

                //if (answer)
                //{
                //    var content = new FormUrlEncodedContent(values);
                //    var response = await _client.PostAsync
                //}
            }
        }

        async void SetSave_Clicked(object sender, EventArgs e)
        {
            if (wardrobeItems.noItems == true)
            {
                await DisplayAlert("Wait!", "Add atleast one clothing so you can continue.", "OK");
            }
            else
            {
                await Navigation.PushAsync(new WardrobePages.WardrobeSaveSet(), true);
            }
        }

        async void Friends_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new WardrobePages.WardrobeChoose(), true);
        }

        async void headTapped(object sender, EventArgs e)
        {
            var _typeCloth = 1;
            WardrobePages.selectedType.typeCloth = _typeCloth;

            await Navigation.PushAsync(new WardrobePages.WardrobeSelectedItem(), true);
        }

        async void topTapped(object sender, EventArgs e)
        {
            var _typeCloth = 2;
            WardrobePages.selectedType.typeCloth = _typeCloth;

            await Navigation.PushAsync(new WardrobePages.WardrobeSelectedItem(), true);
        }

        async void bottomTapped(object sender, EventArgs e)
        {
            var _typeCloth = 3;
            WardrobePages.selectedType.typeCloth = _typeCloth;

            await Navigation.PushAsync(new WardrobePages.WardrobeSelectedItem(), true);
        }

        async void feetTapped(object sender, EventArgs e)
        {
            var _typeCloth = 4;
            WardrobePages.selectedType.typeCloth = _typeCloth;

            await Navigation.PushAsync(new WardrobePages.WardrobeSelectedItem(), true);
        }

        async void Selling_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new WardrobePages.WardrobeSelling(), true);
        }

        protected override void OnDisappearing()
        {
            /// Tijdens het afsluiten van de pagina wordt dit uitgevoerd. 
            /// Clear alle opgeslagen data in het List.
            /// Dit zorgt ervoor dat er geen java error tevoorschijn komt.
            base.OnDisappearing();
            gets_Head.Clear();
            gets_Top.Clear();
            gets_Bottom.Clear();
            gets_Feet.Clear();
            GC.Collect();
        }
    }
} 