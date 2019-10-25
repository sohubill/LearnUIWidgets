using System.Collections;
using System.Collections.Generic;
using Unity.UIWidgets.animation;
using Unity.UIWidgets.engine;
using Unity.UIWidgets.gestures;
using Unity.UIWidgets.material;
using Unity.UIWidgets.painting;
using Unity.UIWidgets.ui;
using Unity.UIWidgets.widgets;
using Image = Unity.UIWidgets.widgets.Image;
using Unity.UIWidgets.scheduler;

public class Hero_AniApp : UIWidgetsPanel
{
    protected override Widget createWidget()
    {
        return new MaterialApp(home: new HeroAnimation());
    }
    
}
public class Hero_AniPage : StatefulWidget 
{
    public override State createState()
    {
        return new Hero_AniPageState();
    }
}
public class Hero_AniPageState : State<Hero_AniPage>
{
    public override Widget build(BuildContext context)
    {
        return null;
    }
}
public class PhotoHero : StatelessWidget
{
    private string photo;
    private GestureTapCallback onTap;
    private float width;
    public PhotoHero(string tag,GestureTapCallback onTap,float width)
    {
        photo = tag;
        this.onTap = onTap;
        this.width = width;
    }
    public override Widget build(BuildContext context)
    {
        SchedulerBinding.instance.timeDilation = 10;//设置时间长短
        return new SizedBox(
            width: width,
            child: new Hero(
                tag: photo,
                child: new Material(
                    color: Colors.transparent,
                    child: new Material(
                        color: Colors.transparent,
                        child: new InkWell(//水波纹效果
                            onTap: onTap,
                            child: Image.asset(photo, fit: BoxFit.contain)
                        )
                    )
                )
            )
            );
    }

}
public class HeroAnimation : StatelessWidget
{
    
    public override Widget build(BuildContext context)
    {
        return new Container(
            child:new Scaffold(
                appBar: new AppBar(
                    title: new Text("hero动画")
                    ),
                body: new Center(
                    child: new PhotoHero(
                        width:300,
                        tag: "unity-black",
                        onTap: ()=>
                        {
                            Navigator.of(context).push(new MaterialPageRoute(
                                builder: (sd) => new Scaffold(
                                     appBar: new AppBar(
                                         title: new Text("跳转的页面")
                                         ),
                                     body: new Container(
                                         color: Colors.lightBlue,
                                         padding: EdgeInsets.all(20),
                                         alignment: Alignment.topRight,
                                         child: new PhotoHero(
                                             tag: "unity-black",
                                             onTap: () => { Navigator.of(context).pop(); },
                                             width: 100
                                             )
                                         )
                                     )
                                )
                                );
                        }
                        )
                    )
                )
            );
    }
}

