using System.Collections;
using System.Collections.Generic;
using Unity.UIWidgets.engine;
using Unity.UIWidgets.material;
using Unity.UIWidgets.ui;
using Unity.UIWidgets.widgets;
using UnityEngine;

public class HomeTrip : UIWidgetsPanel
{

    protected override Widget createWidget()
    {
        FontManager.instance.addFont(Resources.Load<Font>("MaterialIcons-Regular"), familyName: "Material Icons");
        return new MaterialApp(
            home:new Tap_Navigator()
            );
        
    }
}
