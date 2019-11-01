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
        string mValue="";
        return new Scaffold(
            body: new Column(
                children:new List<Widget>()
                {
                    new Text("HomePage"),
                    new DropdownButton<string>(
                        hint:new Text("HomePage"),
                        items:new List<DropdownMenuItem<string>>()
                        {
                            new DropdownMenuItem<string>(
                                child: new Text("HomePage"),
                                value:"1"
                                ),new DropdownMenuItem<string>(
                                child: new Text("HomePage"),
                                value:"2"
                                ),new DropdownMenuItem<string>(
                                child: new Text("HomePage"),
                                value:"3"
                                )
                        },
                        disabledHint:new Text("home"),
                        value:mValue,
                        onChanged: (v) =>
                        {
                            setState(()=>
                            {
                                mValue=v;
                            });
                        }


                        )
                }
                ) 
            );
    }
}

