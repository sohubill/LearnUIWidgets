using System.Collections;
using System.Collections.Generic;
using Unity.UIWidgets.material;
using Unity.UIWidgets.painting;
using Unity.UIWidgets.ui;
using Unity.UIWidgets.widgets;


public class Tap_Navigator : StatefulWidget
{
    public override State createState()
    {
        return new Tap_NavigatorState();
    }

}
public class Tap_NavigatorState : State<Tap_Navigator>
{
    private PageController page_controller = new PageController(
        initialPage:0
        );
    private Color defaultColor = Colors.grey;
    private Color activeColor = Colors.blue;
    private int currentIndex = 0;
    public override Widget build(BuildContext context)
    {
        return new Scaffold(
            body: new PageView(
                controller: page_controller,
                children: new List<Widget>()
                {
                    new HomePage(),
                    new SearchPage(),
                    new TravelPage(),
                    new MyPage()
                },
                onPageChanged: (index) => setState(() => currentIndex = index)
                ),
            bottomNavigationBar: new BottomNavigationBar(
                currentIndex: currentIndex,
                type: BottomNavigationBarType.shifting,
                iconSize: 40,
                onTap: (index) =>
                 {
                     page_controller.jumpToPage(index);
                     setState(() => currentIndex = index);
                 },
                items: new List<BottomNavigationBarItem>()
                {
                    new BottomNavigationBarItem(
                        icon:new Icon(
                            icon:Icons.home,
                            color:defaultColor),
                        activeIcon:new Icon(
                            icon:Icons.home,
                            color:activeColor),
                        title:new Text(
                            data:"首页",
                            style:new TextStyle(
                                color:currentIndex!=0?defaultColor:activeColor)
                            )
                        ),
                     new BottomNavigationBarItem(
                        icon:new Icon(
                            icon:Icons.search,
                            color:defaultColor),
                        activeIcon:new Icon(
                            icon:Icons.search,
                            color:activeColor),
                        title:new Text(
                            data:"搜索",
                            style:new TextStyle(
                                color:currentIndex!=1?defaultColor:activeColor)
                            )
                        ),
                      new BottomNavigationBarItem(
                        icon:new Icon(
                            icon:Icons.camera,
                            color:defaultColor),
                        activeIcon:new Icon(
                            icon:Icons.camera,
                            color:activeColor),
                        title:new Text(
                            data:"旅拍",
                            style:new TextStyle(
                                color:currentIndex!=2?defaultColor:activeColor)
                            )
                        ),
                      new BottomNavigationBarItem(
                        icon:new Icon(
                            icon:Icons.account_circle,
                            color:defaultColor),
                        activeIcon:new Icon(
                            icon:Icons.account_circle,
                            color:activeColor),
                        title:new Text(
                            data:"我的",
                            style:new TextStyle(
                                color:currentIndex!=3?defaultColor:activeColor)
                            )
                        ),
                }
                )
            );
    }
}

