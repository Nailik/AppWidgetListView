using System;
using System.Collections.Generic;
using Android.Content;
using Android.Widget;

namespace AppWidgetListView
{
    public class ListProvider : Java.Lang.Object, RemoteViewsService.IRemoteViewsFactory
    {
        private List<ListItem> listItemList = new List<ListItem>();
        private Context context;
       

        public ListProvider(Context contextNew) 

        {
            context = contextNew;
   
            populateListItem();
        }



        private void populateListItem()
        {
            for (int i = 0; i < 10; i++)
            {
                ListItem listItem = new ListItem();
                listItem.heading = "Heading" + i;
                listItem.content = i + "This is the content of the app widget listview. Nice content though";
                listItemList.Add(listItem);
            }
        }

        public int Count { get { return listItemList.Count; } }


        public long GetItemId(int position)
        {
            return position;
        }



        public RemoteViews GetViewAt(int position)
        {
            RemoteViews remoteView = new RemoteViews(
             context.PackageName, Resource.Layout.list_row);
            ListItem listItem = listItemList[position];
            remoteView.SetTextViewText(Resource.Id.heading, listItem.heading);
            remoteView.SetTextViewText(Resource.Id.content, listItem.content);

            return remoteView;

        }


        public RemoteViews LoadingView { get { return null; } }

        public int ViewTypeCount { get { return 1; } }

        public bool HasStableIds { get { return true; } }


        public void OnCreate()
        {
           // throw new NotImplementedException();
        }

        public void OnDataSetChanged()
        {
           // throw new NotImplementedException();
        }

        public void OnDestroy()
        {
           // throw new NotImplementedException();
        }



       

        

        
       
        
       
    }
}