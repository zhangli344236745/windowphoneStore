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
using System.Data.Common;
using System.Data.Linq.Mapping;

namespace PhoneApp2
{
    [Table(Name = "Country")]
    public class Country
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]//指定是主键，而且是自增的
        public int CountryID
        {
            get;
            set;
        }
        [Column(CanBeNull = true, DbType = "NVarChar(100) not null")]//定义了数据类型
        public string CountryName
        {
            get;
            set;
        }
    }
}
