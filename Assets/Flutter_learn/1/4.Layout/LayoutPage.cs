using System.Collections.Generic;
using Unity.UIWidgets.material;
using Unity.UIWidgets.painting;
using Unity.UIWidgets.widgets;
using RSG;
using System;
using Unity.UIWidgets.ui;
using Image = Unity.UIWidgets.widgets.Image;
using UIWidgetsGallery.gallery;

namespace LearnUIWidgets
{
    public class LayoutPage : StatefulWidget
    {
        public override State createState()
        {
            return new LayoutPageState();
        }
    }
    public class LayoutPageState : State<LayoutPage>
    {
        int _currentIndex = 0;
        public override Widget build(BuildContext context)
        {

            TextStyle textStyle = new TextStyle(fontSize: 20);
            return new MaterialApp(
                title: "LayoutPage与基础组件",
                theme: new ThemeData(
                    primaryColor: Colors.blueGrey
                    ),
                home: new Scaffold(
                    appBar: new AppBar(
                        title: new Text("LayoutPage与基础组件"),
                        leading: new GestureDetector(
                            child: new Icon(Icons.arrow_back),
                            onTap: () => { Navigator.pop(context: context); }
                        )),
                    bottomNavigationBar: new BottomNavigationBar(//底部导航栏的items至少是2个
                        currentIndex: _currentIndex,
                        onTap: index =>
                        {
                            setState(() => _currentIndex = index);
                        },
                        items: new List<BottomNavigationBarItem>()
                        {
                            new BottomNavigationBarItem(
                                icon:new Icon(Icons.home,color:Colors.grey),//图标
                                activeIcon:new Icon(Icons.home,color:Colors.blue),//激活状态下图标
                                title:new Text("主页",style:textStyle)),
                            new BottomNavigationBarItem(
                                icon:new Icon(Icons.list,color:Colors.grey),//图标
                                activeIcon:new Icon(Icons.list,color:Colors.blue),//激活状态下图标
                                title:new Text("列表",style:textStyle))
                        }
                        ),
                    floatingActionButton: new FloatingActionButton(//右下角漂浮按钮
                        onPressed: null,
                        child: new Text("点我")),
                    body: _currentIndex == 0 ? new Container(//根据currentIndex来觉得展示那个容器
                        decoration: new BoxDecoration(
                            color: Colors.white),
                        child: new Column(//按列排列
                            children: new List<Widget>
                            {
                                new Row(//按行排列
                                    children:new List<Widget>()
                                    {
                                        new ClipOval(//裁剪成圆形
                                            child:new SizedBox(//约束内部大小的
                                            width:50,
                                            height:50,
                                            child: Image.network(
                                                src:"http://www.devio.org/img/avatar.png",
                                                width:100,
                                                height:100))
                                            ),
                                        new Padding(
                                            padding:EdgeInsets.all(10),
                                            child:new ClipRRect(//把内部裁剪成带圆角方形， borderRadius:是必传参数
                                                borderRadius:BorderRadius.all(5),
                                                child:new Opacity(
                                                    opacity:0.6f,//60%透明,
                                                    child:Image.network(
                                                        src:"http://www.devio.org/img/avatar.png",
                                                        width:100,
                                                        height:100)
                                                    )
                                                )
                                            ),
                                        new Stack(//内容叠加，与Positioned结合使用可以指定分布位置
                                            children:new List<Widget>()
                                            {
                                                Image.network(
                                                    src:"http://www.devio.org/img/avatar.png",
                                                    width:100,
                                                    height:100
                                                ),
                                                new Positioned(
                                                    right:0,
                                                    top:0,
                                                    child:Image.network(
                                                        src:"http://www.devio.org/img/avatar.png",
                                                        width:40,
                                                        height:40
                                                    )                                                
                                                )
                                            }
                                            )
                                    }
                                    ),
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
                                //new  AlertDialog(
                                //    title:new Text("弹框"),
                                //    content:new Text("学习uiwidgets"))
                                Image.network(
                                    src:"http://www.devio.org/img/avatar.png",
                                    width:100,
                                    height:100),
                                new TextField(
                                    decoration:new InputDecoration(
                                        contentPadding:EdgeInsets.fromLTRB(5,0,0,0),
                                        hintText:"请输入",
                                        hintStyle:textStyle
                                        )
                                    ),
                                new Container(
                                    height:100,
                                    margin:EdgeInsets.all(10),
                                    padding:EdgeInsets.all(10),
                                    decoration:new BoxDecoration(
                                        color:Colors.yellowAccent),
                                    child:new PageView(
                                        children:new List<Widget>()
                                        {
                                            Item("第一",Colors.red),
                                            Item("第二",Colors.blue),
                                            Item("第三",Colors.pink)
                                        })
                                    ),
                                new Wrap(//创建一个从左到右布局，可以自动换行
                                    children:new List<Widget>()
                                    {
                                        _Chip("Fluttr"),
                                        _Chip("UIWidgets"),
                                        _Chip("实战"),
                                        _Chip("学习"),
                                        _Chip("练习")
                                    },
                                    spacing:50,//水平边距
                                    runSpacing:20//垂直边距
                                    )
                            }),
                        alignment: Alignment.center) :
                        new Container(
                            child:new Column(
                                children:new List<Widget>()
                                {
                                    new Text("列表"),
                                    new Expanded(
                                        child:new Container(
                                            color:Colors.red,
                                            child:new Text(
                                                "拉伸填充"))
                                        )
                                })
                        )
                )
                );

        }

        private Widget _Chip(string str)
        {
            return new Chip(
                label: new Text(str),
                avatar: new CircleAvatar(//创建圆形头像
                    child: new Text(
                        data: str.Substring(0, 1),
                        style:new TextStyle(fontSize:20))
                    )
                );
        }

        private Container Item(string title, Color color)
        {
            return new Container(
                child: new Text(
                    data: title,
                    style: new TextStyle(fontSize: 20, color: Colors.white)),
                decoration: new BoxDecoration(
                    color: color
                    ),
                alignment: Alignment.center);
        }

    }

}