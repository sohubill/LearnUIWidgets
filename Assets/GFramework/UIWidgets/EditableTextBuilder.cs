using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.UIWidgets.foundation;
using Unity.UIWidgets.painting;
using Unity.UIWidgets.ui;
using Unity.UIWidgets.widgets;

namespace GFramework.UIWidgets
{
    public class EditableTextBuilder
    {
        private TextEditingController mController = new TextEditingController("");
        private FocusNode mFocusNode = new FocusNode();
        private Color mCursorColor = Color.black;
        private TextStyle mTextStyle;
        private ValueChanged<string> mOnValueChanged;
        private ValueChanged<string> mOnSubmitted;
        public static EditableTextBuilder GetBuilder()
        {
            return new EditableTextBuilder();
        }
        public EditableText EndEditableText()
        {
            return new EditableText(controller: mController, focusNode: mFocusNode, style: mTextStyle, cursorColor: mCursorColor,
                onChanged:mOnValueChanged,onSubmitted:mOnSubmitted);
        }
        public EditableTextBuilder FontSize(float size)
        {
            mTextStyle = new TextStyle(fontSize: size);
            return this;
        }
        public EditableTextBuilder OnValueChanged(ValueChanged<string> onValueChanged)
        {
            mOnValueChanged = onValueChanged;
            return this;
        }
        public EditableTextBuilder OnSubmitted(ValueChanged<string> onSubmitted)
        {
            mOnSubmitted = onSubmitted;
            return this;
        }
    }
}
