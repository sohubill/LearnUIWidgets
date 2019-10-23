using GFramework.UIWidgets;
using System;
using Unity.UIWidgets.material;
using Unity.UIWidgets.widgets;

namespace LearnUIWidgets
{
    public class TodoView : StatelessWidget
    {
        private readonly Todo mData;
        private readonly Action mOnFinish;
        private readonly Action mOnDelete;
        public TodoView(Todo data,Action onFinish,Action onDelete)
        {
            mData = data;
            mOnFinish = onFinish;
            mOnDelete = onDelete;
        }
        public override Widget build(BuildContext context)
        {
            return
                new ListTile(
                    leading: new IconButton(
                        icon:new Icon(Icons.check_box,color:Colors.lightBlue),
                        iconSize:50,
                        onPressed:()=>mOnFinish()),
                    trailing:new IconButton(
                        icon:new Icon(Icons.delete_outline,color:Colors.redAccent),
                        iconSize:50,
                        onPressed:()=>mOnDelete()),
                    subtitle: GF.Text.Data(DateTime.Now.ToString("yyyy年MM月dd日  HH:mm:ss")).EndText(),
                    title: GF.Container.Child(GF.Text.Data(mData.Content).FontSize(30).EndText()).EndContainer()
                    ); 
        }

    }
}
