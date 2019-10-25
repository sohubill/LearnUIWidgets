
using System;
using System.Collections.Generic;
using Unity.UIWidgets.gestures;
using Unity.UIWidgets.material;
using Unity.UIWidgets.painting;
using Unity.UIWidgets.widgets;

namespace LearnUIWidgets
{
    public class ResourcesPage : StatefulWidget
    {
        public override State createState()
        {
            return new _ResourcesPageState();
        }
    }

    public class _ResourcesPageState : State<ResourcesPage>
    {
        public override Widget build(BuildContext context)
        {
            return new MaterialApp(
                title: "ResourcesPage学习",
                theme: new ThemeData(
                    primaryColor: Colors.blue
                    ),
                home: new Scaffold(
                    appBar: new AppBar(
                        title: new Text("ResourcesPage"),
                        leading: new GestureDetector(
                            child: new Icon(Icons.arrow_back),
                            onTap: () => { Navigator.pop(context: context); }
                        )
                        ),
                    body:new Column(
                        children:new List<Widget>()
                        {
                            Image.asset(
                                name:"backpack",
                                width:50,
                                height:50
                                )

                        }
                        )
                    )
                );


        }

    }
}