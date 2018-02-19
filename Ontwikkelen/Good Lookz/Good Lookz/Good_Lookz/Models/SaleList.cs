﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Good_Lookz.Models
{
    /// <summary>
    /// JSON response word opgevangen en in een list met variables gestopt.
    /// </summary>
    class SaleList
    {
        public string sale_id { get; set; }
        public string users_id { get; set; }
        public string head_id { get; set; }
        public string top_id { get; set; }
        public string bottom_id { get; set; }
        public string feet_id { get; set; }
        public string size { get; set; }
        public string username { get; set; }
        public string picture { get; set; }
        public string price { get; set; }
        public string desc { get; set; }
        public string fullPrice { get { return price + "€"; } }
    }

    class SaleRequests
    {
        public string requests_id { get; set; }
        public string sale_id { get; set; }
        public string users_id1 { get; set; }
        public string users_id2 { get; set; }
        public string username { get; set; }
        public string bidding { get; set; }
        public string picture { get; set; }
        public string price { get; set; }
        public string desc { get; set; }
        public string fullPrice { get { return price + "€"; } }
    }

    /// <summary>
    /// Values dat opgeslagen moet worden in een class.
    /// </summary>
    class SelectedSaleList
    {
        private static string _sale_id;
        private static string _users_id;
        private static string _head_id;
        private static string _top_id;
        private static string _bottom_id;
        private static string _feet_id;
        private static string _size;
        private static string _username;
        private static string _picture;
        private static string _price;
        private static string _desc;
        private static string _fullPrice;
        private static string _clothID;

        public static string sale_id
        {
            get { return _sale_id; }
            set { _sale_id = value; }
        }

        public static string users_id
        {
            get { return _users_id; }
            set { _users_id = value; }
        }

        public static string head_id
        {
            get { return _head_id; }
            set { _head_id = value; }
        }

        public static string top_id
        {
            get { return _top_id; }
            set { _top_id = value; }
        }

        public static string bottom_id
        {
            get { return _bottom_id; }
            set { _bottom_id = value; }
        }

        public static string feet_id
        {
            get { return _feet_id; }
            set { _feet_id = value; }
        }

        public static string size
        {
            get { return _size; }
            set { _size = value; }
        }

        public static string username
        {
            get { return _username; }
            set { _username = value; }
        }

        public static string picture
        {
            get { return _picture; }
            set { _picture = value; }
        }

        public static string price
        {
            get { return _price; }
            set { _price = value; }
        }

        public static string desc
        {
            get { return _desc; }
            set { _desc = value; }
        }

        public static string fullPrice
        {
            get { return _fullPrice; }
            set { _fullPrice = value; }
        }

        public static string clothID
        {
            get { return _clothID; }
            set { _clothID = value; }
        }
    }

    class SelectedSaleRequests
    {
        private static string _requests_id;
        private static string _sale_id;
        private static string _users_id1;
        private static string _users_id2;
        private static string _username;
        private static string _bidding;
        private static string _picture;
        private static string _price;
        private static string _desc;
        private static string _fullPrice;

        public static string requests_id
        {
            get { return _requests_id; }
            set { _requests_id = value; }
        }

        public static string sale_id
        {
            get { return _sale_id; }
            set { _sale_id = value; }
        }

        public static string users_id1
        {
            get { return _users_id1; }
            set { _users_id1 = value; }
        }

        public static string users_id2
        {
            get { return _users_id2; }
            set { _users_id2 = value; }
        }

        public static string username
        {
            get { return _username; }
            set { _username = value; }
        }

        public static string bidding
        {
            get { return _bidding; }
            set { _bidding = value; }
        }

        public static string picture
        {
            get { return _picture; }
            set { _picture = value; }
        }

        public static string price
        {
            get { return _price; }
            set { _price = value; }
        }

        public static string desc
        {
            get { return _desc; }
            set { _desc = value; }
        }

        public static string fullPrice
        {
            get { return _fullPrice; }
            set { _fullPrice = value; }
        }
    }
}