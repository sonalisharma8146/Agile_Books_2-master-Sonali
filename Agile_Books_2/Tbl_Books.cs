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
using SQLite;

namespace Agile_Books_2
{
   public class Tbl_Books
    {
        [PrimaryKey, AutoIncrement] //Column("Id")]
        public int Id { get; set; }
        public int Cid { get; set; }
        public string Books_Title { get; set; }

        public int Price { get; set; }
    }
}