using System.Collections;
using System.Collections.Generic;
using Unity.UIWidgets.material;
using Unity.UIWidgets.widgets;


public class TravelPage : StatefulWidget
{
    public override State createState()
    {
        return new TravelPageState();
    }

}
public class TravelPageState : State<TravelPage>
{
    private PageController page_controller = new PageController(
        initialPage: 0
        );
    public override Widget build(BuildContext context)
    {
        return new Scaffold(
            body: new Text("TravelPage")
            );
    }
}

