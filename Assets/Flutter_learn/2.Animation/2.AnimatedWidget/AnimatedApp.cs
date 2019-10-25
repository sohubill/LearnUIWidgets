using System;
using System.Collections;
using System.Collections.Generic;
using Unity.UIWidgets.animation;
using Unity.UIWidgets.engine;
using Unity.UIWidgets.painting;
using Unity.UIWidgets.scheduler;
using Unity.UIWidgets.widgets;
using UnityEngine;

namespace LearnUIWidgets
{
    public class AnimatedApp : UIWidgetsPanel
    {
        protected override Widget createWidget()
        {
            return new AnimatedPage();
        }
    }
    
    public class AnimatedPage : StatefulWidget
    {
        public override State createState()
        {
            return new AnimatedState();
        }
    }
    
    public class AnimatedImage : AnimatedWidget
    {
        public AnimatedImage(Animation<float> animation) : base(listenable: animation)
        {

        }
        protected override Widget build(BuildContext context)
        {
            Animation<float> animation = listenable as Animation<float>;
            return new Center(
                child: new Container(
                    margin: EdgeInsets.symmetric(vertical: 10),
                    width: animation.value,
                    height: animation.value,
                    child: Image.asset("unity-white")
                    )
                );

        }
    }
    public class AnimatedState : State<AnimatedPage>, TickerProvider
    {
        Animation<float> animation;
        AnimationController animationController;

        public override void initState()
        {
            base.initState();
            animationController = new AnimationController(vsync: this, duration: TimeSpan.FromSeconds(3));
            animation = new FloatTween(begin: 0, end: 300).animate(animationController);
            animationController.forward();

        }
        public override Widget build(BuildContext context)
        {
            return new Container(
                    child: new Column(
                        children: new List<Widget>()
                        {
                        new GestureDetector(
                            onTap: () =>
                            {
                                animationController.reset();
                                animationController.forward();
                            },
                            child:new Text("Start",style:new TextStyle(fontSize:20))
                            ),
                        //new Text("State"+animationStatus.ToString()),
                        //new Text("Value"+animationValue),
                        new AnimatedImage(animation)
                        }
                        ));
        }

        public Ticker createTicker(TickerCallback onTick)
        {
            return new Ticker(onTick);
        }
    }
    
}
