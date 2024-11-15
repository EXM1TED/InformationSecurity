using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace InformationSecurity.Models
{
    public class Jury
    {
        public int Id { get; set; }
        public string FIO { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public string Role { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Direction { get; set; } = null!;
        public string? Event {  get; set; }
        public string Password { get; set; } = null!;

        public Jury(int id,
                    string fio,
                    string gender,
                    string role,
                    string email,
                    string phone,
                    string direction,
                    string? eventOrganizer,
                    string password)
        {
            this.Id = id;
            this.FIO = fio;
            this.Gender = gender;
            this.Role = role;
            this.Email = email;
            this.Phone = phone;
            this.Direction = direction;
            this.Event = eventOrganizer;
            this.Password = password;
        }

        public Jury()
        {
            
        }

        public void AddNewJury()
        {
            using(ApplicationContext db = new())
            {
                db.juries.Add(this);
                db.SaveChanges();
            }
            MessageBox.Show($"Новый жюри с ФИО: {this.FIO} успешно добавлен!",
                "Добавление нового жюри",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
        }
    }
}
