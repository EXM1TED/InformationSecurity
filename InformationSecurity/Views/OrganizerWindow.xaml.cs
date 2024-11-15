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

namespace InformationSecurity.Views
{
    /// <summary>
    /// Логика взаимодействия для OrganizerWindow.xaml
    /// </summary>
    public partial class OrganizerWindow : Window
    {
        private TimeOnly _currentTime { get; set; } = new(DateTime.Now.TimeOfDay.Hours, DateTime.Now.TimeOfDay.Minutes);
        public OrganizerWindow()
        {
            InitializeComponent();
            SetDayInHeader();
        }

        private void SetDayInHeader()
        {
            TimeOnly morning = new TimeOnly(11, 0);
            TimeOnly afternoonStart = new TimeOnly(11, 01);
            TimeOnly afternoonEnd = new TimeOnly(18, 0);
            TimeOnly evening = new(18, 1);

            if (_currentTime <= morning)
            {
                this.TxtBlockGoodDay.Text = "Доброе утро!";
            }
            else if (_currentTime >= afternoonStart && _currentTime <= afternoonEnd)
            {
                this.TxtBlockGoodDay.Text = "Добрый день!";
            }
            else if(_currentTime < evening)
            {
                this.TxtBlockGoodDay.Text = "Добрый вечер!";
            }
        }

        private void JuryButton_Click(object sender, RoutedEventArgs e)
        {
            JuryRegistrationWidnow juryRegistrationWidnow = new();
            juryRegistrationWidnow.Show();
        }
    }
}
