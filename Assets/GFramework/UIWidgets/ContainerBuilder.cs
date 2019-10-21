
using Unity.UIWidgets.painting;
using Unity.UIWidgets.widgets;

namespace GFramework.UIWidgets
{
    public class ContainerBuilder 
    {
        private Widget mChild { get; set; }
        private Alignment mAlignment { get; set; }
        public static ContainerBuilder GetBuilder()
        {
            return new ContainerBuilder();
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
        public Container EndContainer()
        {
            return new Container(child: mChild, alignment: mAlignment);
        }

    }
}
