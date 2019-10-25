
using System;
using System.Collections.Generic;
using Unity.UIWidgets.gestures;
using Unity.UIWidgets.material;
using Unity.UIWidgets.painting;
using Unity.UIWidgets.widgets;

namespace LearnUIWidgets
{
    public class GestureDetectorPage : StatefulWidget
    {
        public override State createState()
        {
            return new _GestureDetectorState();
        }
    }

    public class _GestureDetectorState : State<GestureDetectorPage>
    {
        private string printString = "";
        private float moveX = 0, moveY = 0;
        public override Widget build(BuildContext context)
        {
            return new MaterialApp(
                title: "GestureDetectorState学习",
                theme: new ThemeData(
                    primaryColor: Colors.blue
                    ),
                home: new Scaffold(
                    appBar: new AppBar(
                        title: new Text("GestureDetectorState"),
                        leading: new GestureDetector(
                            child: new Icon(Icons.arrow_back),
                            onTap: () => { Navigator.pop(context: context); }
                        )
                        ),
                    body: new FractionallySizedBox(
                        widthFactor: 1,
                        child: new Stack(
                            children: new List<Widget>()
                            {
                                new Column(
                                    children:new List<Widget>()
                                    {
                                        new GestureDetector(
                                            onTap:()=>PrintMsg("点击"),
                                            onDoubleTap:(e)=>PrintMsg("双击"),
                                            onLongPress:()=>PrintMsg("长按"),
                                            onTapCancel:()=>PrintMsg("点击取消"),
                                            onTapUp:(e)=>PrintMsg("松开"),
                                            onTapDown:(e)=>PrintMsg("按下"),
                                            child:new Container(
                                                child:new Text("点我"),
                                                padding:EdgeInsets.all(60),
                                                color:Colors.blueAccent
                                                )
                                            ),
                                        new Text(printString)

                                    }
                                    ),
                                new Positioned(//小球跟随
                                    left:moveX,
                                    top:moveY,
                                    child:new GestureDetector(
                                        onPanUpdate:(e)=>DoMove(e),
                                        child:new ClipOval(
                                            child: new Container(
                                                width:60,
                                                height:60,
                                                color:Colors.red
                                                )                                            
                                            )
                                        )
                                    )
                            }
                            )
                        )
                    )
                );


        }

        private void DoMove(DragUpdateDetails e)
        {
            setState(() =>
            {
                moveX += e.delta.dx;
                moveY += e.delta.dy;
            });
        }

        private void PrintMsg(string msg)
        {
            //printString = "";
            setState(() =>
            {
                printString +=  msg+"/" ;
            });
        }
    }
}