using Unity.UIWidgets.engine;
using Unity.UIWidgets.widgets;
using Unity.UIWidgets.painting;
using Unity.UIWidgets.ui;
using UnityEngine;
using Color = Unity.UIWidgets.ui.Color;

namespace LearnUIWidgets
{
    public class OnTapExample : UIWidgetsPanel
    {
        protected override Widget createWidget()
        {
            return new GestureDetector(child: new Text(data: "OnClick", style: new TextStyle(color: Color.white, fontSize: 30)),
                onTap: () =>
                {
                    Debug.Log("OnTap");
                }
                );
        }
    }
}
