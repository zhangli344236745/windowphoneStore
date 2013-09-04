using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace PhoneApp2
{
    public partial class MainPage : PhoneApplicationPage
    {
        private  static string connStr = "Data Source='isostore:/file.sdf'";
        // 构造函数
        public MainPage()
        {
            InitializeComponent();
        }
        private void CreateDatabase(string name)
        {
            using (WpContext context = new WpContext(connStr))
            {
                if (!context.DatabaseExists())
                {
                    context.CreateDatabase();
                }
                Country model = new Country { CountryName = name };
                context.Countrys.InsertOnSubmit(model);
                context.SubmitChanges();

            }
        }

        private void SearchCountry(string name="")
        { 
             using (WpContext context = new WpContext(connStr))
            {
                if (!context.DatabaseExists())
                {
                    context.CreateDatabase();
                }
                IQueryable<Country> query;
                if (!string.IsNullOrEmpty(name))
                {
                    query = from c in context.Countrys where c.CountryName.Contains(name) select c;
                }
                else
                {
                    query = from c in context.Countrys select c;
                }
                List<Country> list = query.ToList<Country>();
                listBox1.ItemsSource=list;

            }
         
        }

        private void DeleteCountry(int id)
        {
            using (WpContext context = new WpContext(connStr))
            {
                if (!context.DatabaseExists())
                {
                    context.CreateDatabase();
                }
                IQueryable<Country> query = from c in context.Countrys where c.CountryID == id select c;
                Country count = query.FirstOrDefault();
                context.Countrys.DeleteOnSubmit(count);
                context.SubmitChanges();

            }
         
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            string name = this.textBox1.Text.Trim();
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("请输入...");
                return;
            }
            CreateDatabase(name);
            SearchCountry();
            textBox1.Text = "";
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            string name = this.textBox1.Text.Trim();
            SearchCountry(name);
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            Country item =(Country)this.listBox1.SelectedItem;
            if (null == item)
            {
                MessageBox.Show("请选择....");
                return;
            }
            DeleteCountry(item.CountryID);
            SearchCountry();
        }
    }
}