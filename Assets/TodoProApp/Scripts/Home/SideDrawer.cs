using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.UIWidgets.material;
using Unity.UIWidgets.Redux;
using Unity.UIWidgets.widgets;
using UnityEngine;

namespace TodoProApp
{
    public class SideDrawer:StatelessWidget
    {
        public override Widget build(BuildContext context)
        {
            return new StoreConnector<AppState, object>(
                converter: state => null,
                builder: (buildContext, model, dispatcher) =>
                {
                    return new Drawer(
                        child: new Column(
                            children: new List<Widget>()
                            {
                                new ListTile(
                                    title: new Text(data: "收件箱"),
                                    leading: new Icon(icon: Icons.inbox),
                                    onTap:()=>
                                    {
                                        dispatcher.dispatch(new ApplyFilterAcion(Filter.ByStatus(TodoStatus.Pending)));
                                        Navigator.pop(context);
                                    }
                                    ),
                                new Divider(),
                                new ListTile(
                                    title: new Text(data: "今天"),
                                    leading: new Icon(icon: Icons.today),
                                    onTap:()=>
                                    {
                                        dispatcher.dispatch(new ApplyFilterAcion(Filter.ByToday()));
                                        Navigator.pop(context);
                                    }
                                    ),
                                new Divider(),
                                new ListTile(
                                    title: new Text(data: "已完成"),
                                    leading: new Icon(icon: Icons.check),
                                    onTap:()=>
                                    {
                                        dispatcher.dispatch(new ApplyFilterAcion(Filter.ByStatus(TodoStatus.Complete)));
                                        Navigator.pop(context);
                                    }
                                    )
                            }
                        )
                    ) ;
                }
               );
        }
    }
}
