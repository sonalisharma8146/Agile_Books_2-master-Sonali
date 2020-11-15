using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Agile_Books_2
{
    [Activity(Label = "Logged_in_Activity")]
    public class Logged_in_Activity : Activity
    {
        Button btnshowcategory;
        Button btnshowbooks;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Logged_in_Layout );
            btnshowcategory = FindViewById<Button>(Resource.Id.btn_show_book_category);
            btnshowbooks = FindViewById<Button>(Resource.Id.btn_show_books);


            btnshowcategory.Click += btnshowcategory_Click;
            btnshowbooks.Click += btnshowbooks_Click;

        }

        private void btnshowbooks_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(Create_Book_Activity));
        }

        private void btnshowcategory_Click(object sender, EventArgs e)
        {
            // StartActivity(typeof(Create_Sub_Master));
            StartActivity(typeof(Create_Category_Activity));
        }
    }
}