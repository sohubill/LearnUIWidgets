using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GFramework.UIWidgets;
using Unity.UIWidgets;
using Unity.UIWidgets.animation;
using Unity.UIWidgets.engine;
using Unity.UIWidgets.material;
using Unity.UIWidgets.painting;
using Unity.UIWidgets.Redux;
using Unity.UIWidgets.ui;
using Unity.UIWidgets.widgets;
using UnityEngine;
using Color = Unity.UIWidgets.ui.Color;
//using UnityEngine;

namespace LearnUIWidgets
{
    public class TodoListApp : UIWidgetsPanel
    {
        protected override void OnEnable()
        {
            base.OnEnable();
            FontManager.instance.addFont(Resources.Load<Font>("MaterialIcons-Regular"), familyName: "Material Icons");
        }
        //protected virtual PageRouteFactory pageRouteBuilder
        //{
        //    get
        //    {
        //        return (RouteSettings settings, WidgetBuilder builder) =>
        //            new PageRouteBuilder(
        //                settings: settings,
        //                pageBuilder: (BuildContext context, Animation<float> animation,
        //                    Animation<float> secondaryAnimation) => builder(context)
        //            );
        //    }
        //}
        class Choice
        {
            public Choice(string title, IconData icon)
            {
                this.title = title;
                this.icon = icon;
            }

            public readonly string title;
            public readonly IconData icon;

            public static List<Choice> choices = new List<Choice> {
            new Choice("Car", Unity.UIWidgets.material.Icons.directions_car),
            new Choice("Bicycle", Unity.UIWidgets.material.Icons.directions_bike),
            new Choice("Boat", Unity.UIWidgets.material.Icons.directions_boat),
            new Choice("Bus", Unity.UIWidgets.material.Icons.directions_bus),
            new Choice("Train", Unity.UIWidgets.material.Icons.directions_railway),
            new Choice("Walk", Unity.UIWidgets.material.Icons.directions_walk)
        };
        }

        protected override Widget createWidget()
        {
            
            var app= new MaterialApp(
                home: new Scaffold(
                   appBar: new AppBar(
                       title: GF.Text.Data("TodoList").FontSize(30).FontBold().EndText(),
                       //leading: new Icon(Icons.home),
                       actions: new List<Widget>()
                        {
                            new Icon(Icons.hd),
                            new Icon(Icons.wc),
                            new PopupMenuButton<Choice>(
                            onSelected: (val)=>{Debug.Log(val.title); },
                            itemBuilder: (BuildContext subContext) => {
                                List<PopupMenuEntry<Choice>> popupItems = new List<PopupMenuEntry<Choice>>();
                                for (int i = 0; i < Choice.choices.Count; i++) {
                                    popupItems.Add(new PopupMenuItem<Choice>(
                                        value: Choice.choices[i],
                                        child: new Text(Choice.choices[i].title)));
                                }

                                return popupItems;
                            }
                        )
                        },
                       centerTitle: true
                      ),
                       drawer: new Drawer(
                           child: GF.ListView
                           .Child(new Divider())
                           .Child(new StoreConnector<TodoViewState, object>(
                               builder: (context, model, dispatcher) => new ListTile(
                                       title: GF.Text.Data("待办事项").FontBold().FontSize(30).EndText(),
                                       leading: new Icon(Icons.list, size: 30)).OnTap(
                                       () =>
                                       {
                                           dispatcher.dispatch(new ListPageModeAction());
                                       }),
                               converter: state => null)
)
                           .Child(new Divider())
                           .Child(new StoreConnector<TodoViewState,object>(
                               builder: (context,model,dispatcher)=>new ListTile(
                                       title: GF.Text.Data("已完成").FontBold().FontSize(30).EndText(),
                                       leading: new Icon(Icons.list, size: 30)).OnTap(
                                       () =>
                                       {
                                           dispatcher.dispatch(new FinishedPageModeAction());
                                       }),
                               converter:state=>null)

                                   ).EndListView()),
                        
                        floatingActionButton: new FloatingActionButton(
                            backgroundColor: Colors.redAccent,
                            child: new Icon(Icons.add_alert),
                            highlightElevation: 12f,
                            onPressed: () => { Debug.Log("pressed"); }),
                   body: new TodoListPage())
                   );
            var store = new Store<TodoViewState>(
                reducer: Reducers.Reduce,
                initialState: new TodoViewState()
                {
                    todos = Model.Load()
                },
                middleware:ReduxLogging.create<TodoViewState>()); 
            var provider = new StoreProvider<TodoViewState>(child:app,store:store);
            return provider;
        }
        
    }
}