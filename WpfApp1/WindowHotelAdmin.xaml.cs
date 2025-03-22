using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для WindowHotelAdmin.xaml
    /// </summary>
    public partial class WindowHotelAdmin : Window
    {
        public WindowHotelAdmin()
        {
            InitializeComponent();
            LoadReservation();
            LoadLudishki();
            LoadNumbers();
            LoadCleaning();
            LoadCleaners();
        }

        private void LoadReservation()
        {
            using (var context = new ITAcademy1Entities())
            {
                var booking = context.Reservations
                    .Include("Guests")
                    .Include("Rooms")
                    .ToList();

                var SelectedBookings = booking.Select(r => new
                {
                    fullname = $"{r.Guests.last_name} {r.Guests.first_name}",
                    r.check_in_date,
                    r.check_out_date,
                    r.Rooms,
                }).ToList();

                var reservation = SelectedBookings;
                Reservation.ItemsSource = reservation;
            }
        }

        private void LoadLudishki()
        {
            using (var context = new ITAcademy1Entities())
            {
                var Guests = context.Guests
                    .ToList();

                var guests = Guests.Select(g => new
                {
                    fullname = $"{g.last_name} {g.first_name}",
                    g.email,
                    g.phone,
                    g.document_number,
                }).ToList();

                GuestsDataGrid.ItemsSource = guests;
            }    
        }

        private void LoadNumbers()
        {
            using (var context = new ITAcademy1Entities())
            {
                var Rooms = context.Rooms
                    .ToList();

                var rooms = Rooms.Select(r => new
                {
                    r.floor,
                    r.number,
                    r.category,
                    r.status,
                }).ToList();

                Numbers.ItemsSource = rooms;
            }
        }

        private void LoadCleaning()
        {
            using (var context = new ITAcademy1Entities())
            {
                var Cleaning = context.Cleaning_Schedule
                    .ToList();

                var cleaning = Cleaning.Select(c => new
                {
                    c.id,
                    c.cleaning_date,
                    cleaner_id = $"{c.Users.firstname} {c.Users.lastname}",
                    number_room = c.Rooms.number,
                }).ToList();

                Cleaners.ItemsSource = cleaning;
            }
        }

        private void LoadCleaners()
        {
            using (var context = new ITAcademy1Entities())
            {
                //var cleaners = context.Users
                //    .Where(c => c.role == 4 )
                //    .ToList();

                //var v_cl = cleaners.Select(v => $"{v.firstname} {v.lastname}").ToList();

                var cleaners = context.Users
                    .Include("Roles")
                    .ToList()
                    .Where(c => c.role == 4)
                    .Select( c => new
                    {
                        FullName = $"{c.lastname} {c.firstname}"
                    }).ToList();

                CleanerName.ItemsSource = cleaners;
                CleanerName.DisplayMemberPath = "FullName";
            }
        }

        private void LoadRoomNumbers()
        {
            using (var context = new ITAcademy1Entities())
            {
                var Rooms = context.Rooms
                     .ToList();

                var rooms = Rooms.Select(r => new
                {
                    r.floor,
                    r.number,
                    r.category,
                    r.status,
                }).ToList();

                Numbers.ItemsSource = rooms;
            }
        }

        private void AppointCleaner_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
