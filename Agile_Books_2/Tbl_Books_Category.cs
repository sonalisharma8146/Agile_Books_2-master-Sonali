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
   public  class Tbl_Books_Category
    {

        [PrimaryKey, AutoIncrement] //Column("Id")]
        public int Id { get; set; }

        [MaxLength(25)]
        public string BooksCategory { get; set; }
    }
}