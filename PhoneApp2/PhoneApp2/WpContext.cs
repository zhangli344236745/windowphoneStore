using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Data.Linq;

namespace PhoneApp2
{
    public class WpContext:DataContext
    {
        public WpContext(string connStr)
            : base(connStr)
        { }
        public Table<Country> Countrys
        {
            get
            {
                return this.GetTable<Country>();
            }
        }
    }
}
