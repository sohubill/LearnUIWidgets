using System;
using System.Collections.Generic;
using Unity.UIWidgets.gestures;
using Unity.UIWidgets.material;
using Unity.UIWidgets.painting;
using Unity.UIWidgets.widgets;
using UnityEngine;

namespace LearnUIWidgets
{
    public class LifecyclePage : StatefulWidget
    {
        //当我们构建statefulwidgey时，会立刻调用createState()方法
        //这个方法必须被重构
        public override State createState()
        {
            return new _LifecyclePageState();
        }
    }

    public class _LifecyclePageState : State<LifecyclePage>
    {
        //这是创建widget时调用的除了构造方法外的第一个方法
        //类似于Android的：onCreate()和IOS的viewDidLoad()
        //这个方法中通常做一些初始化工作，比如channel初始化，监听器初始化等
        public override void initState()
        {
            base.initState();
            Debug.Log("---------initestate----------");
        }
        //这个方法会在所以来的state所改变的时候调用
        //1、在第一次构建widget时，在initState（）之后立即调用这个方法
        //2、如果StatefulWidget依赖于InheritedWidget，那么当当前State所依赖的InheritedWidget中的变量改变时会再次调用它
        public override void didChangeDependencies()
        {
            base.didChangeDependencies();
            Debug.Log("-----------didChangeDependencies-----------");
        }
        //这个方法是必须实现的方法，这里呈现需要呈现的页面内容
        //它会在didChangedDependencies（）之后立即调用
        //当调用setState（）方法之后也会再次调用该方法
        public override Widget build(BuildContext context)
        {
            Debug.Log("-----------build-----------");
            return new MaterialApp(
                title: "生命周期学习",
                theme: new ThemeData(
                    primaryColor: Colors.blue
                    ),
                home: new Scaffold(
                    appBar: new AppBar(
                        title: new Text("生命周期"),
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
        //这是一个不常用的生命周期方法，当父组件需要重绘时才会调用
        //调用该方法会携带一个oldWidget参数，可以将其与当前widget进行对比以便执行一些额外的逻辑
        public override void didUpdateWidget(StatefulWidget oldWidget)
        {
            Debug.Log("-----------didUpdateWidget-----------");
            base.didUpdateWidget(oldWidget);
        }
        //不常用的方法，在组件被移除时调用，在dispose（）之前调用
        public override void deactivate()
        {
            Debug.Log("-----------deactivate-----------");
            base.deactivate();
        }
        //常用，组件销毁时调用
        //通常在该方法中执行一些资源释放工作，如监听器卸载，channel销毁等
        public override void dispose()
        {
            Debug.Log("-----------dispose-----------");
            base.dispose();
        }

    }
}