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
    [Activity(Label = "Create_Book_Activity")]
    public class Create_Book_Activity : Activity
    {
        List<Tbl_Books> List_All_Books;
        List<Tbl_Books_Category > List_All_Category;
        EditText txtbookname;
        Button btnsavebook;
        Button btndeletebook;
        Button btnupdatebook;
        Button btnnewbook;
        ListView ListView1;
        Spinner spinnershowcategory;
        Spinner spinnershowbook;
        TextView txt_price;
        TextView txtbookid;
        TextView txtcategoryid;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Create_Book_Layout );
            btnnewbook = FindViewById<Button>(Resource.Id.btn_new_book);

            btnsavebook = FindViewById<Button>(Resource.Id.btn_save_book);

            btndeletebook = FindViewById<Button>(Resource.Id.btn_delete_book);
            btnupdatebook = FindViewById<Button>(Resource.Id.btn_update_book);
            txtbookname = FindViewById<EditText>(Resource.Id.txt_book);
            spinnershowcategory = FindViewById<Spinner>(Resource.Id.spinner_show_category);
            spinnershowbook = FindViewById<Spinner>(Resource.Id.spinner_show_book);
            txt_price = FindViewById<TextView>(Resource.Id.txt_price);

            txtbookid = FindViewById<TextView>(Resource.Id.txt_v_book_id);
            txtcategoryid = FindViewById<TextView>(Resource.Id.txt_category_id);
            ListView1= FindViewById<ListView>(Resource.Id.listView1);

            string dpPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "books.sqlite");
            var db = new SQLiteConnection(dpPath);

            db.CreateTable<Tbl_Books>();






            load_spiner_category();
            load_spiner_books();


            spinnershowcategory.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_show_Category_ItemSelected);
            spinnershowbook.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_show_Book_ItemSelected);
            btnsavebook.Click += Btnsavebook_Click;
            btndeletebook.Click += Btndeletebook_Click;
            btnupdatebook.Click += Btnupdatebook_Click;
          //  ListView1.Click += ListView1_Click;

        }

       // private void ListView1_Click(object sender, EventArgs e)
       // {
           

       // }

        private void Btnupdatebook_Click(object sender, EventArgs e)
        {
            var item_book = new Tbl_Books();
            item_book.Id = Convert.ToInt32(txtbookid .Text);
            item_book.Books_Title  = txtbookname.Text;
            item_book .Price = Convert.ToInt32(txt_price.Text);
            string dpPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "books.sqlite");
            var db = new SQLiteConnection(dpPath);

            //db.Update(item_book);

            Toast.MakeText(this, "Record Updated Successfully...,", ToastLength.Short).Show();

            load_spiner_category();
            load_spiner_books();
        }

        private void Btndeletebook_Click(object sender, EventArgs e)
        {
            var item = new Tbl_Books();
            item.Id = Convert.ToInt32(txtbookid .Text);

            string dpPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "books.sqlite");
            var db = new SQLiteConnection(dpPath);
            var data = db.Delete(item);
            Toast.MakeText(this, "Record Deleted Successfully...,", ToastLength.Short).Show();
            txtbookname.Text = "";
            load_spiner_category();
            load_spiner_books();
        }

        private void Btnsavebook_Click(object sender, EventArgs e)
        {
            string dpPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "books.sqlite");
            var db = new SQLiteConnection(dpPath);
            db.CreateTable<Tbl_Books>();
            Tbl_Books tbl = new Tbl_Books();
            tbl.Books_Title  = Convert.ToString(txtbookname.Text);
            tbl.Cid = Convert.ToInt32(txtcategoryid .Text);
            tbl.Price= Convert.ToInt32(txt_price.Text);
            db.Insert(tbl);
            Toast.MakeText(this, "Record Added Successfully...,", ToastLength.Short).Show();
            txtbookname.Text = "";
            load_spiner_category();
            load_spiner_books();

        }

        private void spinner_show_Book_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;
            var id = this.List_All_Books.ElementAt(e.Position).Id;
            var bookname = this.List_All_Books.ElementAt(e.Position).Books_Title ;
            var price = this.List_All_Books.ElementAt(e.Position).Price;
            txtbookid.Text = Convert.ToString(id);
           
            txtbookname.Text = bookname;
            txt_price .Text = Convert.ToString(price);

        }

        private void spinner_show_Category_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {

            Spinner spinner = (Spinner)sender;
            var id = this.List_All_Category.ElementAt(e.Position).Id;

            txtcategoryid  .Text = Convert.ToString(id);

            load_spiner_books();
        }

        private void load_spiner_category()
        {
            string dpPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "books.sqlite");
            var db = new SQLiteConnection(dpPath);
            var data_s = db.Query<Tbl_Books_Category >("select *  from Tbl_Books_Category");
            List_All_Category = data_s;
            Agile_Books_2.Resources.Adpter_Books_Category_List  da = new Resources.Adpter_Books_Category_List(this, List_All_Category);
            spinnershowcategory.Adapter = da;

        }

        private void load_spiner_books()
        {
            string dpPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "books.sqlite");
            var db = new SQLiteConnection(dpPath);
            var data_s = db.Query<Tbl_Books>("select *  from Tbl_Books where Cid=" + txtcategoryid .Text);
            List_All_Books = data_s;
            Agile_Books_2.Resources.Adpter_Books  da = new Resources.Adpter_Books(this, List_All_Books);
            spinnershowbook.Adapter = da;
            ListView1.Adapter = da;
        }
    }
}