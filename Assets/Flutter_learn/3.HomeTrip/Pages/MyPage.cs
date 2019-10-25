using System.Collections;
using System.Collections.Generic;
using Unity.UIWidgets.material;
using Unity.UIWidgets.widgets;


public class MyPage : StatefulWidget
{
    public override State createState()
    {
        return new MyPageState();
    }

}
public class MyPageState : State<MyPage>
{
    public override Widget build(BuildContext context)
    {
        return new Scaffold(
            body: new Text("MyPage")
            );
    }
}

