using GFramework.UIWidgets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.UIWidgets.material;
using Unity.UIWidgets.rendering;
using Unity.UIWidgets.ui;
using Unity.UIWidgets.widgets;
using UnityEngine;
using Color = Unity.UIWidgets.ui.Color;

namespace LearnUIWidgets
{
    public class TodoInputView:StatelessWidget
    {
        private readonly Action<string> mOnAdd;
        private string mInputContent = string.Empty;
        public TodoInputView(Action<string> onAdd)
        {
            mOnAdd = onAdd;
        }
        void AddTodo()
        {
            if (!string.IsNullOrWhiteSpace(mInputContent))
            {
                mOnAdd(mInputContent);
            }
        }
        public override Widget build(BuildContext context)
        {
            return
                new Container(child:
                    new Row(children: new List<Widget>()
                    {
                        GF.Container
                        //.Color(Colors.grey)
                        .Width(300)
                        .MarginLeftRight(100,0)
                        .Child(GF.EditableText
                        .FontSize(30)
                        .OnValueChanged(
                            (inputVal) =>
                            {
                                mInputContent=inputVal;
                            }
                            )
                        .OnSubmitted(
                            (inputVal) =>
                            {
                                AddTodo();
                            }
                            )
                        .EndEditableText())
                        .BorderColor(Color.black)
                        .EndContainer(),
                         GF.Container
                        .Child(
                            new IconButton(icon:new Icon(Icons.add_box,color:new Color(0xFF81C784)),iconSize:50,onPressed:AddTodo)
                            )
                        .MarginLeftRight(0,0)
                        .EndContainer()
                    }
                    , mainAxisAlignment: MainAxisAlignment.start
                    )

              );
        }
    }
}
