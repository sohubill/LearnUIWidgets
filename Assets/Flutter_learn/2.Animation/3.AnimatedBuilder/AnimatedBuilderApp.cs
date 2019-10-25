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
    public class AnimatedBuilderApp : UIWidgetsPanel
    {
        protected override Widget createWidget()
        {
            return new AnimatedBuilderPage();
        }
    }
    public class AnimatedBuilderPage : StatefulWidget
    {
        public override State createState()
        {
            return new AnimatedBuilderState();
        }
    }

    public class AnimatedBuilderState : State<AnimatedBuilderPage>, TickerProvider
    {
        Animation<float> animation;
        AnimationController animationController;

        public override void initState()
        {
            base.initState();
            animationController = new AnimationController(vsync: this, duration: TimeSpan.FromSeconds(3));
            animation = new FloatTween(begin: 0, end: 300).animate(animationController);
            animationController.stop();

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
                        new GrowTransition(animation:animation,child:new LogoPage())
                        }
                        ));
        }

        public Ticker createTicker(TickerCallback onTick)
        {
            return new Ticker(onTick);
        }
    }
    public class GrowTransition : StatelessWidget
    {
        private Widget child;
        private Animation<float> animation;
        public GrowTransition(Widget child, Animation<float> animation)
        {
            this.child = child;
            this.animation = animation;
        }

        public override Widget build(BuildContext context)
        {
            return new AnimatedBuilder(
                animation: this.animation,
                builder: (con, child) => new Container(
                    child: child,
                    height: animation.value,
                    width: animation.value
                    ),
                child: child
                );

        }
    }

    public class LogoPage : StatelessWidget
    {
        public override Widget build(BuildContext context)
        {
            return new Container(
                child: Image.asset("unity-white"));
        }
    }
}