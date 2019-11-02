using QFramework.UIWidgets.ReduxPersist;
using System.Collections;
using System.Collections.Generic;
using Unity.UIWidgets;
using Unity.UIWidgets.engine;
using Unity.UIWidgets.material;
using Unity.UIWidgets.Redux;
using Unity.UIWidgets.ui;
using Unity.UIWidgets.widgets;
using UnityEngine;

namespace TodoProApp
{
    public class App :UIWidgetsPanel
    {
        protected override void OnEnable()
        {
            base.OnEnable();
            FontManager.instance.addFont(Resources.Load<Font>("MaterialIcons-Regular"), familyName: "Material Icons");
        }
        protected override Widget createWidget()
        {
            var store = new Store<AppState>(
                reducer: AppReducer.Reduce,
                AppState.Load(),
                middleware:ReduxPersistMiddleware.create<AppState>()
                );
            return new StoreProvider<AppState>(
                store:store,
                child: new MaterialApp(
                    home:new Home()
                    )
                );
        }
    }
}
