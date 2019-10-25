using System.Collections;
using System.Collections.Generic;
using Unity.UIWidgets.material;
using Unity.UIWidgets.widgets;


public class HomePage : StatefulWidget
{
    public override State createState()
    {
        return new HomePageState();
    }

}
public class HomePageState : State<HomePage>
{

    public override Widget build(BuildContext context)
    {
        return new Scaffold(
            body: new Text("HomePage")
            );
    }
}

