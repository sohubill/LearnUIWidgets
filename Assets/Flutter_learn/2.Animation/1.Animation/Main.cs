using System;
using System.Collections.Generic;
using Unity.UIWidgets.animation;
using Unity.UIWidgets.engine;
using Unity.UIWidgets.painting;
using Unity.UIWidgets.scheduler;
using Unity.UIWidgets.widgets;

namespace LearnUIWidgets
{
    public class Main : UIWidgetsPanel
    {
        protected override Widget createWidget()
        {
            return new LogoApp();
        }
    }
    
    public class LogoApp : StatefulWidget
    {
        public override State createState()
        {
            return new LogoAppState();
        }
    }
    public class LogoAppState : State<LogoApp>, TickerProvider
    {
        Animation<float> animation;
        AnimationController animationController;
        AnimationStatus animationStatus;
        float animationValue;
        public override void initState()
        {
            base.initState();
            animationController = new AnimationController(vsync: this, duration: TimeSpan.FromSeconds(3));
            //animation = animationController.drive(new FloatTween(begin: 0, end: 300));
            animation = new FloatTween(begin: 0, end: 300).animate(animationController);
            animation.addListener(() => { setState(()=>animationValue = animation.value); });
            animation.addStatusListener((state) => { animationStatus = animation.status; });

        }
        public override Widget build(BuildContext context)
        {
            return new Container(
                child:new Column(
                    children:new List<Widget>()
                    {
                        new GestureDetector(
                            onTap: () =>
                            {
                                animationController.reset();
                                animationController.forward();
                            },
                            child:new Text("Start",style:new TextStyle(fontSize:20))
                            ),
                        new Text("State"+animationStatus.ToString()),
                        new Text("Value"+animationValue),
                        new Container(
                            height:animation.value,
                            width:animation.value,
                            child:Image.asset("unity-white"))
                    }
                    ));
        }
        public override void dispose()
        {
            base.dispose();
            animationController.dispose();
        }
        
        public Ticker createTicker(TickerCallback onTick)
        {
            return new Ticker(onTick);
        }
        
    }
}