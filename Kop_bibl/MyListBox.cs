using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace Kop_bibl
    {
        public partial class MyListBox : UserControl
        {
            public MyListBox()
            {
                InitializeComponent();
            }
            public int SelectedIndex
            {
                set { if (value > -1 && value < listBox.Items.Count) listBox.SelectedIndex = value; }
                get { return listBox.SelectedIndex; }
            }

            public string layout = "Name - {Name}, Age - {Age}";
            public char preValue = '{';
            public char postValue = '}';

            public void SetLayout(string value)
            {
                layout = value;
            }

            public void SetPreValue(string value)
            {
                if (value.Length == 1)
                {
                    Char.TryParse(value, out char symb);
                    if (symb != postValue) preValue = symb;
                }
            }

            public void SetPostValue(string value)
            {
                if (value.Length == 1)
                {
                    Char.TryParse(value, out char symb);
                    if (symb != preValue) postValue = symb;
                }
            }

            public T GetSelected<T>() where T : class, new()
            {
                T item = new T();

                string selected = listBox.SelectedItem.ToString();

                string[] layoutWords = layout.Split(new char[] { preValue, postValue });
                selected = selected.Replace(layoutWords[0], "");
                for (int i = 2; i < layoutWords.Length; i = i + 2) if (layoutWords[i].Length > 0) selected = selected.Replace(layoutWords[i], ";");
                string[] selectedValues = selected.Split(';');

                for (int i = 0; i < selectedValues.Length; i++)
                {
                    string value = selectedValues[i];
                    string propertyName = layoutWords[(i * 2) + 1];

                    PropertyInfo property = item.GetType().GetProperty(propertyName);
                    property.SetValue(item, value);
                }

                return item;
            }

            public void AddItem<T>(T value, int stroka, string pole)
            {
                Type type = value.GetType();
                var pole1 = type.GetField(pole);
                var svoistvo = type.GetProperty(pole);
                string[] words = layout.Split(new char[] { preValue, postValue });
                string str = "";
                for (int i = 0; i < words.Length; i++)
                {
                if (i % 2 == 1)
                {
                    if (pole1.Name.Equals(words[i]) && pole1 != null)
                    {
                        str += pole1.GetValue(value);
                        break;
                    }
                    if (svoistvo.Name.Equals(words[i]) && svoistvo != null)
                    {
                        str += svoistvo.GetValue(value);
                        break;
                    }
                }
                else str += words[i];
                }
                if (listBox.Items[stroka] != null && listBox.Items[stroka].ToString() != str)
                {
                    listBox.Items[stroka] = str;
                }
                if (listBox.Items[stroka] == null)
                {
                    listBox.Items.Add(str);
                }
        }
    }
}

