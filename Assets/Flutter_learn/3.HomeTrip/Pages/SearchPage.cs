using System.Collections;
using System.Collections.Generic;
using Unity.UIWidgets.material;
using Unity.UIWidgets.widgets;


public class SearchPage : StatefulWidget
{
    public override State createState()
    {
        return new SearchPageState();
    }

}
public class SearchPageState : State<SearchPage>
{
    private PageController page_controller = new PageController(
        initialPage: 0
        );
    public override Widget build(BuildContext context)
    {
        return new Scaffold(
            body: new Text("SearchPage")
            );
    }
}

