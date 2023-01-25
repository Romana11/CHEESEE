using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CHEESEE
{
    /// <summary>
    /// Логика взаимодействия для Applications.xaml
    /// </summary>
    public partial class Applications : Window
    {
        public ObservableCollection<Applications1> applications { get; set; } = new ObservableCollection<Applications1>();

        public Applications()
        {
            InitializeComponent();

            applications.Add(new Applications1 { Person = "ПобежЪимов", WhatYouWant = "отжать настроение", Class = 1, DataTime = 01.08, Valuta = " 10 улыбок" });
            applications.Add(new Applications1 { Person = "Вишьньевский", WhatYouWant = "отжать сигареты", Class = 6, DataTime = 21.01, Valuta = " 2 пачки сигарет" });
            applications.Add(new Applications1 { Person = "Михайльюк", WhatYouWant = "отжать еду", Class = 306, DataTime = 20.01, Valuta = " шавуха и сендвич" });
            applications.Add(new Applications1 { Person = "Варабэй", WhatYouWant = "отжать работу", Class = 4, DataTime = 29.09, Valuta = "преподаватель высшей категории" });
            applications.Add(new Applications1 { Person = "ГореНачайьник", WhatYouWant = "отжать кабинет", Class = 3, DataTime = 11.01, Valuta = "1 помещение" });
            listApplication.ItemsSource = applications;

            DataContext = this;
        }
    }
}
