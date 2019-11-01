
using System;
using System.Collections.Generic;
using UIWidgets.Runtime.material;
using Unity.UIWidgets.material;
using Unity.UIWidgets.painting;
using Unity.UIWidgets.ui;
using Unity.UIWidgets.widgets;

public class LoginPage : StatefulWidget
{
    public override State createState()
    {
        return new LoginPageState();
    }
}
public class LoginPageState : State<LoginPage>
{
    private TextEditingController nameController = new TextEditingController();
    private TextEditingController passwordController = new TextEditingController();
    TextStyle labelStyle = new TextStyle(fontSize: 15, color: Colors.white);
    TextStyle inputStyle = new TextStyle(fontSize: 22, color: Colors.white);
    bool obscureText;
    public override void initState()
    {
        base.initState();
        nameController.addListener(() => { setState(); });
        passwordController.addListener(() => { setState(); });
    }
    public override Widget build(BuildContext context)
    {
        return new MaterialApp(
            home:new Scaffold(
                body: new TextField(
                decoration: new InputDecoration(
                    contentPadding: EdgeInsets.fromLTRB(5, 0, 0, 0),
                    hintText: "请输入"
                    )
                )
                )
            
            );
            
    }
}
    