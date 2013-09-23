/*
* Copyright (C) 2013 @JamesMontemagno http://www.montemagno.com http://www.refractored.com
*
* Licensed under the Apache License, Version 2.0 (the "License");
* you may not use this file except in compliance with the License.
* You may obtain a copy of the License at
*
*      http://www.apache.org/licenses/LICENSE-2.0
*
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an "AS IS" BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License.
*/
using System;
using System.Collections.Generic;

using Android.Content;
using Android.Graphics;
using Android.InputMethodServices;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace com.refractored.controls
{
    /// <summary>
    /// RobotoTextFactory is used to allow you to add custom roboto text to any view with the attribute:
    /// local:typeface="typeface enum" on it.
    /// 
    /// Valid classes are: TextView, Button, CheckedTextView, Chronometer, DigitalClock, EditText, TextClock 
    /// AutoCompleteTextView, CheckBox, CompoundButton, ExtractEditText, MultiAutoCompleteTextView, RadioButton, Switch, ToggleButton
    /// </summary>
    public class RobotoTextFactory : Java.Lang.Object, LayoutInflater.IFactory
    {
        private const int ROBOTO_THIN = 0;
        private const int ROBOTO_THIN_ITALIC = 1;
        private const int ROBOTO_LIGHT = 2;
        private const int ROBOTO_LIGHT_ITALIC = 3;
        private const int ROBOTO_REGULAR = 4;
        private const int ROBOTO_ITALIC = 5;
        private const int ROBOTO_MEDIUM = 6;
        private const int ROBOTO_MEDIUM_ITALIC = 7;
        private const int ROBOTO_BOLD = 8;
        private const int ROBOTO_BOLD_ITALIC = 9;
        private const int ROBOTO_BLACK = 10;
        private const int ROBOTO_BLACK_ITALIC = 11;
        private const int ROBOTO_CONDENSED = 12;
        private const int ROBOTO_CONDENSED_ITALIC = 13;
        private const int ROBOTO_CONDENSED_BOLD = 14;
        private const int ROBOTO_CONDENSED_BOLD_ITALIC = 15;

        private TypefaceStyle m_Style = TypefaceStyle.Normal;

        private static SparseArray<Typeface> m_Typefaces = new SparseArray<Typeface>(16);
        private Dictionary<string, Type> m_TypeList = new Dictionary<string,Type>();

        public View OnCreateView(string name, Context context, Android.Util.IAttributeSet attrs)
        {
            var attributeValue = attrs.GetAttributeIntValue("http://schemas.android.com/apk/res-auto", "typeface", -1);

            if (attributeValue == -1)
                return null;

            try
            {
                var view = CreateView(name, context, attrs);
                if (view == null)
                    return null;

                var font = this.ObtainTypeface(context, attributeValue);
                view.SetTypeface(font, m_Style);
                return view;

            }
            catch (Exception)
            {
            }

            return null;
        }

        private TextView CreateView(string name, Context context, Android.Util.IAttributeSet attrs)
        {
            if (!m_TypeList.ContainsKey(name))
            {
                switch (name)
                {
                    case "TextView":
                        m_TypeList.Add(name, typeof(TextView));
                        break;
                    case "Button":
                        m_TypeList.Add(name, typeof(Button));
                        break;
                    case "CheckedTextView":
                        m_TypeList.Add(name, typeof(CheckedTextView));
                        break;
                    case "Chronometer":
                        m_TypeList.Add(name, typeof(Chronometer));
                        break;
                    case "DigitalClock":
                        m_TypeList.Add(name, typeof(DigitalClock));
                        break;
                    case "EditText":
                        m_TypeList.Add(name, typeof(EditText));
                        break;
                    case "AutoCompleteTextView":
                        m_TypeList.Add(name, typeof(AutoCompleteTextView));
                        break;
                    case "CheckBox":
                        m_TypeList.Add(name, typeof(CheckBox));
                        break;
                    case "CompoundButton":
                        m_TypeList.Add(name, typeof(CompoundButton));
                        break;
                    case "ExtractEditText":
                        m_TypeList.Add(name, typeof(ExtractEditText));
                        break;
                    case "MultiAutoCompleteTextView":
                        m_TypeList.Add(name, typeof(MultiAutoCompleteTextView));
                        break;
                    case "RadioButton":
                        m_TypeList.Add(name, typeof(RadioButton));
                        break;
                    case "Switch":
                        m_TypeList.Add(name, typeof(Switch));
                        break;
                    case "ToggleButton":
                        m_TypeList.Add(name, typeof(ToggleButton));
                        break;
                    default:
                        return null;
                }
            }

            return Activator.CreateInstance(m_TypeList[name], context, attrs) as TextView;
        }

        private Typeface ObtainTypeface(Context context, int typefaceValue)
        {
            try
            {

                Typeface typeface = m_Typefaces.Get(typefaceValue);
                if (typeface == null)
                {
                    typeface = this.CreateTypeface(context, typefaceValue);
                    m_Typefaces.Put(typefaceValue, typeface);
                }
                return typeface;
            }
            catch (Exception ex)
            {

            }

            return null;
        }
        private Typeface CreateTypeface(Context context, int typefaceValue)
        {
            try
            {

                Typeface typeface;
                switch (typefaceValue)
                {
                    case ROBOTO_THIN:
                        typeface = Typeface.CreateFromAsset(context.Assets, "fonts/Roboto-Thin.ttf");
                        break;
                    case ROBOTO_THIN_ITALIC:
                        typeface = Typeface.CreateFromAsset(context.Assets, "fonts/Roboto-ThinItalic.ttf");
                        m_Style = TypefaceStyle.Italic;
                        break;
                    case ROBOTO_LIGHT:
                        typeface = Typeface.CreateFromAsset(context.Assets, "fonts/Roboto-Light.ttf");
                        break;
                    case ROBOTO_LIGHT_ITALIC:
                        typeface = Typeface.CreateFromAsset(context.Assets, "fonts/Roboto-LightItalic.ttf");
                        m_Style = TypefaceStyle.Italic;
                        break;
                    case ROBOTO_REGULAR:
                        typeface = Typeface.CreateFromAsset(context.Assets, "fonts/Roboto-Regular.ttf");
                        break;
                    case ROBOTO_ITALIC:
                        typeface = Typeface.CreateFromAsset(context.Assets, "fonts/Roboto-Italic.ttf");
                        m_Style = TypefaceStyle.Italic;
                        break;
                    case ROBOTO_MEDIUM:
                        typeface = Typeface.CreateFromAsset(context.Assets, "fonts/Roboto-Medium.ttf");
                        break;
                    case ROBOTO_MEDIUM_ITALIC:
                        typeface = Typeface.CreateFromAsset(context.Assets, "fonts/Roboto-MediumItalic.ttf");
                        m_Style = TypefaceStyle.Italic;
                        break;
                    case ROBOTO_BOLD:
                        typeface = Typeface.CreateFromAsset(context.Assets, "fonts/Roboto-Bold.ttf");
                        m_Style = TypefaceStyle.Bold;
                        break;
                    case ROBOTO_BOLD_ITALIC:
                        typeface = Typeface.CreateFromAsset(context.Assets, "fonts/Roboto-BoldItalic.ttf");
                        m_Style = TypefaceStyle.BoldItalic;
                        break;
                    case ROBOTO_BLACK:
                        typeface = Typeface.CreateFromAsset(context.Assets, "fonts/Roboto-Black.ttf");
                        break;
                    case ROBOTO_BLACK_ITALIC:
                        typeface = Typeface.CreateFromAsset(context.Assets, "fonts/Roboto-BlackItalic.ttf");
                        m_Style = TypefaceStyle.Italic;
                        break;
                    case ROBOTO_CONDENSED:
                        typeface = Typeface.CreateFromAsset(context.Assets, "fonts/Roboto-Condensed.ttf");
                        break;
                    case ROBOTO_CONDENSED_ITALIC:
                        typeface = Typeface.CreateFromAsset(context.Assets, "fonts/Roboto-CondensedItalic.ttf");
                        m_Style = TypefaceStyle.Italic;
                        break;
                    case ROBOTO_CONDENSED_BOLD:
                        typeface = Typeface.CreateFromAsset(context.Assets, "fonts/Roboto-BoldCondensed.ttf");
                        m_Style = TypefaceStyle.Bold;
                        break;
                    case ROBOTO_CONDENSED_BOLD_ITALIC:
                        typeface = Typeface.CreateFromAsset(context.Assets, "fonts/Roboto-BoldCondensedItalic.ttf");
                        m_Style = TypefaceStyle.BoldItalic;
                        break;
                    default:
                        throw new ArgumentException("Unknown typeface attribute value " + typefaceValue);
                }
                return typeface;

            }
            catch (Exception)
            {
            }

            return null;
        }
    }
}