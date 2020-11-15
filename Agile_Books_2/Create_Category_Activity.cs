using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;

namespace Agile_Books_2
{
    [Activity(Label = "Create_Category_Activity")]
    public class Create_Category_Activity : Activity
    {
        List<Tbl_Books_Category> List_Category;
        EditText txt_category;
        Button btn_save_category;
        Button btn_delete_category;
        Button btn_update_category;
        Button btn_new_category;


        Spinner spinner;
        TextView txtviewid;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Create_Category_Layout );
            // Create your application here


            btn_save_category = FindViewById<Button>(Resource.Id.btn_save_category);
            btn_delete_category = FindViewById<Button>(Resource.Id.btn_delete_category);

            btn_new_category = FindViewById<Button>(Resource.Id.btn_new_category);
            btn_update_category = FindViewById<Button>(Resource.Id.btn_update_category);
            txt_category = FindViewById<EditText>(Resource.Id.txt_category);
            spinner = FindViewById<Spinner>(Resource.Id.spinner_show);
            txtviewid = FindViewById<TextView>(Resource.Id.txt_v_category_id);


            string dpPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "books.sqlite");
            var db = new SQLiteConnection(dpPath);

            db.CreateTable<Tbl_Books_Category>();






            load_spiner_category();

            spinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_show_ItemSelected);


            btn_save_category.Click += btn_save_category_Click; ;
            btn_new_category.Click += btn_new_category_Click;
            btn_delete_category.Click += btn_delete_category_Click;
            btn_update_category.Click += btn_update_category_Click;

        }

        private void btn_update_category_Click(object sender, EventArgs e)
        {

            string dpPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "books.sqlite");
            var db = new SQLiteConnection(dpPath);





            var item = new Tbl_Books_Category();

            item.Id = Convert.ToInt32(txtviewid.Text);




            item.BooksCategory = txt_category.Text;


            db.Update(item);

            Toast.MakeText(this, "Record Updated Successfully...,", ToastLength.Short).Show();

            load_spiner_category();
        }

        private void btn_new_category_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(Create_Book_Activity));

        }

        private void btn_delete_category_Click(object sender, EventArgs e)
        {




            string dpPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "books.sqlite");
            var db = new SQLiteConnection(dpPath);


            var subitem = new Tbl_Books();
            subitem.Cid = Convert.ToInt32(txtviewid.Text);

            var data_s = db.Query<Tbl_Books>("select *  from Tbl_Books where Cid=" + Convert.ToInt32(txtviewid.Text));
            if (data_s.Count > 0)
            {
                Toast.MakeText(this, "Record Will not deleted as Book Exists...,", ToastLength.Short).Show();

            }
            else
            {
                var item = new Tbl_Books_Category();
                item.Id = Convert.ToInt32(txtviewid.Text);
                var data = db.Delete(item);
                Toast.MakeText(this, "Record Deleted Successfully...,", ToastLength.Short).Show();
                txt_category.Text = "";
                load_spiner_category();

            }







        }

        private void spinner_show_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {

            Spinner spinner = (Spinner)sender;
            var id = this.List_Category.ElementAt(e.Position).Id;
            var masteraccountname = this.List_Category.ElementAt(e.Position).BooksCategory;
            txtviewid.Text = Convert.ToString(id);
            // txt_category.Text = masteraccountname;
            btn_delete_category.Enabled = true;

        }

        private void btn_save_category_Click(object sender, EventArgs e)
        {
            string dpPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "books.sqlite");
            var db = new SQLiteConnection(dpPath);
            db.CreateTable<Tbl_Books_Category>();
            Tbl_Books_Category tbl = new Tbl_Books_Category();
            tbl.BooksCategory = txt_category.Text;
            db.Insert(tbl);
            Toast.MakeText(this, "Record Added Successfully...,", ToastLength.Short).Show();
            txt_category.Text = "";
            load_spiner_category();

        }

        private void load_spiner_category()
        {
            string dpPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "books.sqlite");
            var db = new SQLiteConnection(dpPath);
            var data_s = db.Query<Tbl_Books_Category>("select *  from Tbl_Books_Category");
            List_Category = data_s;
            Agile_Books_2.Resources.Adpter_Books_Category_List da = new Resources.Adpter_Books_Category_List(this, List_Category);
            spinner.Adapter = da;

        }
    }
}