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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Ferienhaus {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        private MeetingProcessor proc;
        private List<Meeting> meetings; 
        
        public MainWindow() {
            proc = new MeetingProcessor();
            InitializeComponent();
            updateCalender();
            start.BlackoutDates.AddDatesInPast();
            end.BlackoutDates.AddDatesInPast();
        }

        private void Button_OnClick(object sender, RoutedEventArgs e) {
            if (DateTime.TryParse(start.Text, out DateTime Dstart) &&
                DateTime.TryParse(end.Text, out DateTime Dend) && Dstart <= Dend) {
                proc.addMeeting(DateOnly.FromDateTime(Dstart), DateOnly.FromDateTime(Dend));
                CalendarDateRange range = new CalendarDateRange(Dstart, Dend);
                start.SelectedDate = DateTime.MaxValue;
                end.SelectedDate = DateTime.MaxValue;
                start.BlackoutDates.Add(range);
                end.BlackoutDates.Add(range);
                message.Content = "Wurde gebucht";
            }else {
                message.Content = "Falsche Eingabe";
            }
        }

        private void updateCalender() {
            meetings = proc.getMeetings;
            foreach (var m in meetings) {
                DateTime timeOne = DateTime.Parse(m.Start.ToLongDateString());
                DateTime timeTwo = DateTime.Parse(m.End.ToLongDateString());
                start.BlackoutDates.Add(new CalendarDateRange(timeOne,timeTwo));
                end.BlackoutDates.Add(new CalendarDateRange(DateTime.Parse(m.Start.ToLongDateString()),DateTime.Parse(m.End.ToLongDateString())));
            }
        }
    }
}