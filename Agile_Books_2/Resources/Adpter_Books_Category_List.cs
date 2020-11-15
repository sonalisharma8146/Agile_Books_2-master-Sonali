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
   public  class Adpter_Books_Category_List : BaseAdapter<Tbl_Books_Category>
    {
        private readonly Activity context;
        private readonly List<Tbl_Books_Category> mItems;

        public Adpter_Books_Category_List(Activity context, List<Tbl_Books_Category> items)
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

        public override Tbl_Books_Category this[int position]
        {
            get { return mItems[position]; }
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {

            var row = convertView;


            if (row == null)
            {
                row = LayoutInflater.From(context).Inflate(Resource.Layout.List_Category , null, false);
            }

            // Set the txtRowName.Text which is in the listview_row layout to the Players Name
            TextView txtRowName = row.FindViewById<TextView>(Resource.Id.txtRowName);
            txtRowName.Text = mItems[position].BooksCategory ;



            return row;


        }
    }
}