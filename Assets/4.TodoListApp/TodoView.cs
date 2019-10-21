

using GFramework.UIWidgets;
using Unity.UIWidgets.widgets;

namespace LearnUIWidgets
{
    public class TodoView : StatelessWidget
    {
        public override Widget build(BuildContext context)
        {
            return GF.Container.Child(GF.Text.Data("Hello").FontSize(30).EndText()).AlignmentCenter().EndContainer();
        }

    }
}
