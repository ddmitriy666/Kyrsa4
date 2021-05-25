using System;
using System.Collections.Generic;
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

namespace TOURIST
{
    /// <summary>
    /// Логика взаимодействия для AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        public TOUR CurrentTOUR { get; set; }
        public IEnumerable<AgentsT> agentsTs { get; set; }
        public AddWindow(TOUR TOURsss)
        {
            InitializeComponent();
            DataContext = this;
            CurrentTOUR = TOURsss;
            agentsTs = Core.DB.AgentsT.ToArray();
        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CurrentTOUR.AgentsT == null)
                    throw new Exception("Не выбран агент");

                if (CurrentTOUR.ID == 0)
                    Core.DB.TOUR.Add(CurrentTOUR);

                Core.DB.SaveChanges();

                DialogResult = true;
            }
            catch
            {
                MessageBox.Show($"ERROR");
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
