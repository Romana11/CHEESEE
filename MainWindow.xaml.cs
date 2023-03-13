using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CHEESEE;

namespace CHEESEE
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public CustomCommand SimpleCommand { get; set; }
        public CustomCommand TipleCommand { get; set; }


        public CustomCommand PipleCommand { get; set; }
        public CustomCommand GipleCommand { get; set; }
        public CustomCommand FlipCommand { get; set; }
        public Savods SelectedSavod { get; set; }
        public Savods ChangeSavod { get; set; }

       
        private Visibility visibility= Visibility.Hidden;
        public Visibility kreating
        {
            get
            {
                return visibility;
            }
            set
            {
                visibility = value;

                Fill("kreating");
            }
        }
        public Savods Selected { get => selected; set { selected = value; Fill(); } }
        public Savods Sel { get => sel; set { sel = value; Fill(); } }
        Random random = new Random();
        private Savods selected = new Savods();
        private Savods sel = new Savods();

        public ObservableCollection<Savods> savods { get; set; } = new ObservableCollection<Savods>();
       

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            TipleCommand = new CustomCommand(
                () => MessageBox.Show("Принтер отремонтировался"));


            //Добавить
            GipleCommand = new CustomCommand(
               () => { kreating = Visibility.Visible; });

            PipleCommand = new CustomCommand(
               () => {
                   savods.Add(new Savods { Print = sel.Print, Refueling = sel.Refueling, SpaceParts = sel.SpaceParts, NewCartridges = sel.NewCartridges, Cabinet = sel.Cabinet, Price = sel.Price });
                  
                   kreating = Visibility.Hidden;
                   Fill(nameof(savods));
               });



            savods.Add(new Savods { Print = "Canon голубой", SpaceParts = "отсек для бумаги", Refueling = 70, NewCartridges = "Тонер-картридж голубой Canon C-EXV54C", Cabinet = 1, Price= 10000});
            savods.Add(new Savods { Print = "Canon зелёный", SpaceParts = "отсек для бумаги", Refueling = 75, NewCartridges = "Тонер-картридж зелёный Canon C-EXV14", Cabinet = 6, Price = 9000 });
            savods.Add(new Savods { Print = "Pantum", SpaceParts = "отсек для бумаги", Refueling = 80, NewCartridges = "Заправочный комплект Pantum TN-420H", Cabinet = 306, Price = 8000 });
            savods.Add(new Savods { Print = "HP", SpaceParts = "отсек для бумаги", Refueling = 85, NewCartridges = "Тонер HP CE505A", Cabinet = 4, Price = 7000 });
            savods.Add(new Savods { Print = "Sumsung", SpaceParts = "отсек для бумаги", Refueling = 90, NewCartridges = "Тонер Sumsung SCX4200", Cabinet = 3, Price = 6000 });
            listSavod.ItemsSource = savods;

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(listSavod.ItemsSource);
            view.Filter = UserFilter;


        }
        //Поиск
        private bool UserFilter(object item)
		{
            if (String.IsNullOrEmpty(txtFilter.Text))
                return true;

            if (String.IsNullOrEmpty(txtFilter.Text))
                return ((item as Savods).Print.IndexOf(txtFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0);

            if (String.IsNullOrEmpty(txtFilter.Text))
                return ((item as Savods).SpaceParts.IndexOf(txtFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0);

            else 
                return ((item as Savods).NewCartridges.IndexOf(txtFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0);

            
        }

		private void txtFilter_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
		{
			CollectionViewSource.GetDefaultView(listSavod.ItemsSource).Refresh();
		}

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void Fill([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }


        private void Button_Click1(object sender, RoutedEventArgs a)
        {
            Applications applications = new Applications();
            applications.Show();


        }

        private void Button_Click2(object sender, RoutedEventArgs a)
        {
            

        }

        private void Button_Click3(object sender, RoutedEventArgs a)
        {
            savods.Remove(Selected);
        }



        private void Dobav_Click(object sender, RoutedEventArgs f)
        {

        }

    }
}
