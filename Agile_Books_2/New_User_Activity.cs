﻿using System;
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
    [Activity(Label = "New_User_Activity")]
    public class New_User_Activity : Activity
    {
        EditText txtusername;
        EditText txtPassword;
        Button btncreate;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.New_User_Layout);
            // Create your application here

            btncreate = FindViewById<Button>(Resource.Id.btn_create);
            txtusername = FindViewById<EditText>(Resource.Id.txt_username);
            txtPassword = FindViewById<EditText>(Resource.Id.txt_password);

            btncreate.Click += Btncreate_Click;
        }

        private void Btncreate_Click(object sender, EventArgs e)
        {

            try
            {
                string dpPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "books.sqlite");
                var db = new SQLiteConnection(dpPath);
                db.CreateTable<Tbl_Login>();
                Tbl_Login tbl = new Tbl_Login();
                tbl.username = txtusername.Text;
                tbl.password = txtPassword.Text;
                db.Insert(tbl);
                Toast.MakeText(this, "Record Added Successfully...,", ToastLength.Short).Show();
                SetContentView(Resource.Layout.activity_main);
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, ex.ToString(), ToastLength.Short).Show();
            }
        }
    }
}