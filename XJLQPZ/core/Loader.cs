using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Markup;
using System.Xml.Linq;
using System.Windows;
using System.CodeDom;

namespace XJLQPZ.core
{
    internal class Loader<T>
    {
        public  List<T> LoadFile(string filename, Func<string[], T> parseFunction)
        {
            List<T> list = new();
            using (var reader = new StreamReader(filename))
            {
                while (!reader.EndOfStream)
                {
                   list.Add(parseFunction(reader.ReadLine().Split(';')));
                }
                reader.Close();
            }
            
            return list;
        }
    }
}