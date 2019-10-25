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
    public class PhotoPage : StatefulWidget
    {
        public override State createState()
        {
            return new PhotoPageState();
        }
    }

    public class PhotoPageState : State<PhotoPage>
    {
        public override Widget build(BuildContext context)
        {
            return new MaterialApp(
                title: "拍照学习",
                theme: new ThemeData(
                    primaryColor: Colors.blue
                    ),
                home: new Scaffold(
                    appBar: new AppBar(
                        title: new Text("拍照学习"),
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