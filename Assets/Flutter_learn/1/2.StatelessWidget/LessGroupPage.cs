using System.Collections;
using System.Collections.Generic;
using Unity.UIWidgets.material;
using Unity.UIWidgets.painting;
using Unity.UIWidgets.ui;
using Unity.UIWidgets.widgets;
using UnityEngine;

namespace LearnUIWidgets
{
    public class LessGroupPage :StatelessWidget
    {
        public override Widget build(BuildContext context)
        {
            
            TextStyle textStyle = new TextStyle(fontSize: 20);
            return new MaterialApp(
                title: "StatelessWidget与基础组件",
                theme: new ThemeData(
                    primaryColor: Colors.blueGrey
                    ),
                home: new Scaffold(
                    appBar: new AppBar(
                        title: new Text("StatelessWidget与基础组件"),
                        leading: new GestureDetector(
                            child: new Icon(Icons.arrow_back),
                            onTap: () => { Navigator.pop(context: context); }
                        )),
                    body: new Container(
                        decoration: new BoxDecoration(
                            color: Colors.white),
                        child: new Column(
                            children: new List<Widget>
                            {
                                new Text("I AM A TEXT",style: new TextStyle(fontFamily:"sf_bold",fontSize:20)),
                                new Icon(Icons.android,size:50,color:Colors.red),
                                new CloseButton(),
                                new BackButton(),
                                new Chip(
                                    avatar:new Icon(Icons.people),
                                    label:new Text("这是一个Chip")),
                                new Divider(
                                    height:10,//容器高度不是线高度
                                    indent:10,//左间距
                                   
                                    color:Colors.orange
                                    ),
                                new Card(//带有圆角边框的卡片
                                    color:Colors.blue,
                                    elevation:5,
                                    margin:EdgeInsets.all(10),
                                    child: new Container(
                                        child:new Text("I AM A CARD",style:textStyle),
                                        padding:EdgeInsets.all(10)
                                        )),
                                        
                                new  AlertDialog(
                                    title:new Text("弹框"),
                                    content:new Text("学习uiwidgets"))
                                    
                            }),
                        alignment: Alignment.center)
                    )
                );
        }
    }
}
