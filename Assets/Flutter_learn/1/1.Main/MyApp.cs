using System;
using System.Collections;
using System.Collections.Generic;
using Unity.UIWidgets.engine;
using Unity.UIWidgets.material;
using Unity.UIWidgets.painting;
using Unity.UIWidgets.ui;
using Unity.UIWidgets.widgets;
using UnityEngine;

namespace LearnUIWidgets
{
    public class MyApp : UIWidgetsPanel
    {
        private Dictionary<string, WidgetBuilder> mRoute { get; set; } = new Dictionary<string, WidgetBuilder>();//路由配置字典
        protected override Widget createWidget()
        {
            mRoute.Add("less", (context) => new LessGroupPage());
            mRoute.Add("ful", (context) => new StatefulGroupPage());
            mRoute.Add("layout", (context) => new LayoutPage());
            mRoute.Add("gesture", (context) => new GestureDetectorPage());
            mRoute.Add("res", (context) => new ResourcesPage());
            mRoute.Add("Life", (context) => new LifecyclePage());
            FontManager.instance.addFont(Resources.Load<Font>("MaterialIcons-Regular"), familyName: "Material Icons");
            FontManager.instance.addFont(Resources.Load<Font>("SF-Pro-Text-Bold"), familyName: "sf_bold");
            return new MaterialApp(
                title: "MyApp",
                theme: new ThemeData(
                    primaryColor: Colors.blue),
                home:new Scaffold(
                    appBar:new AppBar(                        
                        title:new Text("使用路由和导航两种方式跳转页面")
                            ),
                    body: new mainPage()),
                routes: mRoute
                );;
        }
    }
    public class mainPage : StatefulWidget
    {
        public override State createState()
        {
            return new mainPageState();
        }
    }
    public class mainPageState : State<mainPage>
    {
        private bool? byName=false;
        public override Widget build(BuildContext context)
        {
            return new Container(
                child:new Column(
                    
                    children:new List<Widget>()
                    {
                        new ListTile(
                            title:new Text(data:(byName??false?"":"不")+"通过路由名跳转"),
                            trailing:new Switch(
                                value:byName,
                                onChanged:(value)=>
                                {
                                   setState(()=>byName=value);
                                }
                                )
                            ),
                        _Item("StatelessPage",new LessGroupPage(),"less"),
                        _Item("StatefulPage",new StatefulGroupPage(),"ful"),
                        _Item("LayoutPage",new LayoutPage(),"layout"),
                        _Item("GesturePage",new GestureDetectorPage(),"gesture"),
                        _Item("ResoucesPage",new ResourcesPage(),"res"),
                        _Item("LifecyclePage",new LifecyclePage(),"life")
                    }                   
                    ));
        }

        private Widget _Item(string title, Widget page, string routeName)
        {
            return new Container(
                margin:EdgeInsets.only(top:10,bottom:10),
                child: new RaisedButton(
                    child: new Text(title),
                    onPressed: () =>
                    {
                        if (byName??false)
                        {
                            Navigator.pushNamed(context, routeName);//用navigator根据路由名字跳转
                        }
                        else
                        {
                            Navigator.push(context, new MaterialPageRoute(builder: (context) => page));//不根据路由名跳转
                        }
                    }
                    )
                );
        }
    }
}
