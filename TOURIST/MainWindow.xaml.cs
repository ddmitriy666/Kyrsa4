using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TOURIST
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public IEnumerable<AgentsT> agentsTs { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public IEnumerable<TOUR> _tOURs;
        public IEnumerable<TOUR> tOURs
        {
            get
            {
                return _tOURs;
            }
            set
            {
                _tOURs = value;
                if (PropertyChanged != null)
                    {
                    PropertyChanged(this, new PropertyChangedEventArgs("tOURs"));
                    }
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            tOURs = Core.DB.TOUR.ToArray();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var addWindow = new AddWindow(new TOUR());

            if (addWindow.ShowDialog() == true)
            {
                agentsTs = Core.DB.AgentsT.ToArray();
            }
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var DeleteTours = TOURsName.SelectedItem as TOUR;

            try
            {
                Core.DB.TOUR.Remove(DeleteTours);
                Core.DB.SaveChanges();
                tOURs = Core.DB.TOUR.ToArray();
            }
            catch
            {
                MessageBox.Show($"Ошибка");
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            var EditTourWindow = new AddWindow(TOURsName.SelectedItem as TOUR);
            if (EditTourWindow.ShowDialog() == true)
            {
                tOURs = Core.DB.TOUR.ToArray();
            }
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            var w = new MainWindow();
            w.Show();

            this.Close();
        }
    }
}
