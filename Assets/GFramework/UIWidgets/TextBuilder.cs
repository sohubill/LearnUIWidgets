﻿using System.Collections;
using System.Collections.Generic;
using Unity.UIWidgets.painting;
using Unity.UIWidgets.ui;
using Unity.UIWidgets.widgets;

namespace GFramework.UIWidgets
{
    public class TextBuilder
    {
        private string mData { get; set; }
        private int mFontSize { get; set; } = 0;
        private FontWeight mFontWeight { get; set; }

        public static TextBuilder GetBuiler()
        {
            return new TextBuilder();
        }
        public TextBuilder Data(string data)
        {
            mData = data;
            return this;
        }
        public TextBuilder FontSize(int fontSize)
        {
            mFontSize = fontSize;
            return this;
        }
        public TextBuilder FontBold()
        {
            mFontWeight = FontWeight.bold;
            return this;
        }
        public Text EndText()
        {
            if (mFontSize==0)
            {
                return new Text(data: mData);
            }
            else
            {
                return new Text(data: mData, style: new TextStyle(fontSize: mFontSize,fontWeight:mFontWeight));
            }

        }


    }
}