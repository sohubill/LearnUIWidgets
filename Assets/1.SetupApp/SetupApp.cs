
using Unity.UIWidgets.engine;
using Unity.UIWidgets.widgets;
using Unity.UIWidgets.painting;
using Unity.UIWidgets.ui;

namespace LearnUIWidgets
{
    public class SetupApp : UIWidgetsPanel
    {
        protected override Widget createWidget()
        {
            return new Text(data: "hello World",style:new TextStyle(color:Color.white,fontSize:30) );
        }
    }
}
