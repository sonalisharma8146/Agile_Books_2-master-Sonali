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

namespace Agile_Books_2.Resources
{
    public class Adpter_Books : BaseAdapter<Tbl_Books>
    {
        private readonly Activity context;
        private readonly List<Tbl_Books> mItems;

        public Adpter_Books(Activity context, List<Tbl_Books> items)
        {
            this.mItems = items;
            this.context = context;
        }



        public override int Count
        {
            get { return mItems.Count; }

        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override Tbl_Books this[int position]
        {
            get { return mItems[position]; }
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {

            var row = convertView;


            if (row == null)
            {
                row = LayoutInflater.From(context).Inflate(Resource.Layout.List_Books , null, false);
            }

            // Set the txtRowName.Text which is in the listview_row layout to the Book Name
            TextView txtRowName_book = row.FindViewById<TextView>(Resource.Id.txtRowName_Book);
            txtRowName_book.Text = mItems[position].Books_Title ;

            TextView txt_book_price = row.FindViewById<TextView>(Resource.Id.txt_book_price);
           
            txt_book_price.Text = "          Price : " +  Convert.ToString  (mItems[position].Price);

            return row;


        }
    }
}