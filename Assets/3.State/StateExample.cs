
using Unity.UIWidgets.engine;
using Unity.UIWidgets.painting;
using Unity.UIWidgets.widgets;
using Unity.UIWidgets.ui;

namespace LearnUIWidgets
{
    public class StateExample : UIWidgetsPanel
    {
        protected override Widget createWidget()
        {
            return new Counter();
        }

        class Counter:StatefulWidget
        {
            public override State createState()
            {
                return new CounterState();
            }
        }
        class CounterState : State<Counter>
        {
            private int mCount { get; set; } = 0;
            public override Widget build(BuildContext context)
            {
                return new GestureDetector(
                    child: new Text(data: "Click Count:" + mCount, style: new TextStyle(fontSize: 30, color: Color.white)),
                    onTap: () =>
                    {
                        setState(() =>
                        {
                            mCount++;
                        });
                    }
                    );
            }
        }
    }
}
