

using System.Collections.Generic;
using Unity.UIWidgets.painting;
using Unity.UIWidgets.widgets;

namespace GFramework.UIWidgets
{
    public class ListViewBuilder
    {
        private List<Widget> mChildren = new List<Widget>();
        private EdgeInsets mPadding;
        public static ListViewBuilder GetBuilder()
        {
            return new ListViewBuilder();
        }
        public ListView EndListView()
        {
            return new ListView(children:mChildren,padding:mPadding);
        }
        public ListViewBuilder Children(params Widget[] children)
        {
            mChildren.AddRange(children);
            return this;
        }
        public ListViewBuilder Child(Widget child)
        {
            mChildren.Add(child);
            return this;
        }
        public ListViewBuilder Padding(EdgeInsets padding)
        {
            mPadding = padding;
            return this;
        }
    }
}
