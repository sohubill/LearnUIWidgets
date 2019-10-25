using System;
using System.Collections.Generic;
using RSG;
using Unity.UIWidgets.gestures;
using Unity.UIWidgets.material;
using Unity.UIWidgets.painting;
using Unity.UIWidgets.ui;
using Unity.UIWidgets.widgets;
using UnityEngine;
using Image = Unity.UIWidgets.widgets.Image;

namespace LearnUIWidgets
{
    /// <summary>
    /// UIWidgets 没找到相关内容
    /// </summary>
    public class AppLifecyclePage : StatefulWidget
    {
        //当我们构建statefulwidgey时，会立刻调用createState()方法
        //这个方法必须被重构
        public override State createState()
        {
            return new _AppLifecyclePageState();
        }
    }

    public class _AppLifecyclePageState : State<AppLifecyclePage>
    {
        public override Widget build(BuildContext context)
        {
            return new MaterialApp(
                title: "App生命周期学习",
                theme: new ThemeData(
                    primaryColor: Colors.blue
                    ),
                home: new Scaffold(
                    appBar: new AppBar(
                        title: new Text("App生命周期"),
                        leading: new GestureDetector(
                            child: new Icon(Icons.arrow_back),
                            onTap: () => { Navigator.pop(context: context); }
                        )
                        ),
                    body: new Column(
                        children: new List<Widget>()
                        {
                            Image.asset(
                                name:"backpack",
                                width:50,
                                height:50
                                ),
                            new RaisedButton(
                                child:new Text("点我"),
                                padding:EdgeInsets.all(60),
                                color:Colors.blueAccent,
                                onPressed: () =>
                                {
                                    setState();
                                }

                                )
                        }
                        )
                    )
                );


        }
    }
}