
using Unity.UIWidgets.painting;
using Unity.UIWidgets.ui;
using Unity.UIWidgets.widgets;

namespace GFramework.UIWidgets
{
    public class ContainerBuilder 
    {
        private Widget mChild { get; set; }
        private Alignment mAlignment { get; set; }
        private Color mColor { get; set; } = null;
        private EdgeInsets mMargin { get; set; }
        private float? mWidth=null;
        private Color mBorderColor = null;
        public static ContainerBuilder GetBuilder()
        {
            return new ContainerBuilder();
        }
        public Container EndContainer()
        {
            return new Container(
                child: mChild, 
                alignment: mAlignment,
                color:mColor,
                margin:mMargin,
                width:mWidth,
                decoration:(mBorderColor != null && mColor==null) ? new BoxDecoration(border:Border.all(color:mBorderColor,width:2)) : null
                );
        }
        public ContainerBuilder Child(Widget child)
        {
            mChild = child;
            return this;
        }
        public ContainerBuilder AlignmentCenter()
        {
            mAlignment = Alignment.center;
            return this;
        }

        public  ContainerBuilder Color(Color color)
        {
            mColor = color;
            return this;
        }
        public ContainerBuilder MarginLeftRight(int left,int right)
        {
            mMargin = EdgeInsets.only(left: left, right: right);
            return this;
        }
        public ContainerBuilder Width(float width)
        {
            mWidth = width;
            return this;
        }
        public ContainerBuilder BorderColor(Color color)
        {
            mBorderColor = color;
            return this;
        }

    }
}
