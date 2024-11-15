using InformationSecurity.Models;
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
    /// Логика взаимодействия для JuryRegistrationWidnow.xaml
    /// </summary>
    public partial class JuryRegistrationWidnow : Window
    {
        private readonly string[] Roles = ["Модератор", "Жюри"];
        private readonly string[] Gender = ["Мужской", "Женский"];
        private readonly string[] Event = ["Конференция", "Засидание"];
        public JuryRegistrationWidnow()
        {
            InitializeComponent();
            CmbBoxGender.ItemsSource = Gender;
            CmbBoxRole.ItemsSource = Roles;
            CmbBoxEvent.ItemsSource = Event;
        }

        private void ChkBoxEventVisible_Checked(object sender, RoutedEventArgs e)
        {
            StcPanelEvent.Visibility = Visibility.Visible;
        }

        private void ChkBoxEventVisible_Unchecked(object sender, RoutedEventArgs e)
        {
            StcPanelEvent.Visibility = Visibility.Hidden;
            CmbBoxEvent.SelectedItem = null;
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            int id = 0;
            string fio = string.Empty;
            string gender = string.Empty;
            string role = string.Empty;
            string email = string.Empty;
            string phone = string.Empty;
            string direction = string.Empty;
            string? eventOrg = string.Empty;
            string password = string.Empty;

            if (!CheckInputFieldIsEmpty(this.TxtBoxIdNumber, "IdNumber"))
                return;

            if (!int.TryParse(this.TxtBoxIdNumber.Text, out id))
                MessageBox.Show(@"Пожалуйста, укажите конкретный номер в поле ""NumberId""",
                    "Ошибка",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);

            if (!CheckInputFieldIsEmpty(this.TxtBoxFIO, "ФИО"))
                return;
            fio = TxtBoxFIO.Text;
            if (!CheckInputFieldIsEmpty(this.CmbBoxGender, "Пол"))
                return;
            gender = CmbBoxGender.SelectedItem.ToString()!;
            if (!CheckInputFieldIsEmpty(this.CmbBoxRole, "Роль"))
                return;
            role = this.CmbBoxRole.SelectedItem.ToString()!;
            if (!CheckInputFieldIsEmpty(this.TxtBoxEmail, "Email")) 
                return;
            email = this.TxtBoxEmail.Text;
            if (!CheckInputFieldIsEmpty(this.TxtBoxMobilePhone, "Телефон"))
                return;
            phone = this.TxtBoxMobilePhone.Text;
            if (!CheckInputFieldIsEmpty(this.TxtBoxDirecion, "Направление"))
                return;
            direction = this.TxtBoxDirecion.Text;
            if (!CheckInputFieldIsEmpty(this.TxtBoxPassword.Password, "Пароль"))
                return;
            if (!CheckPassword(this.TxtBoxPassword.Password))
                return;
            password = this.TxtBoxPassword.Password;

            Jury newJury = new(id, fio,
                gender, role,
                email, phone,
                direction, eventOrg, password);

             newJury.AddNewJury();
        }

        /// <summary>
        /// Данный метод проверяет, что поле TextBox пустое 
        /// </summary>
        /// <param name="txtBoxValue"></param>
        /// <param name="nameOfTxtBox"></param>
        /// <returns></returns>
        private bool CheckInputFieldIsEmpty(TextBox txtBoxValue, string nameOfTxtBox)
        {
            string messageBoxMessage = string.Format(@"Поле ""{0}"" не должно быть пустым", nameOfTxtBox);
            if (txtBoxValue.Text == string.Empty)
            {
                MessageBox.Show(messageBoxMessage,
                    "Ошибка",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Данный метод проверяет, что текстовое поле TextBox пустое и выдает ошибку
        /// </summary>
        /// <param name="txtBoxValue"></param>
        /// <param name="nameOfTxtBox"></param>
        /// <returns></returns>
        private bool CheckInputFieldIsEmpty(string txtBoxValue, string nameOfTxtBox)
        {
            string messageBoxMessage = string.Format(@"Поле ""{0}"" не должно быть пустым", nameOfTxtBox);
            if (txtBoxValue == string.Empty)
            {
                MessageBox.Show(messageBoxMessage,
                    "Ошибка",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Данный метод проверяет, что ComboBox пустой
        /// </summary>
        /// <param name="comboBox"></param>
        /// <param name="nameOfTxtBox"></param>
        /// <returns></returns>
        private bool CheckInputFieldIsEmpty(ComboBox comboBox,string nameOfTxtBox)
        {
            string messageBoxMessage = string.Format(@"Поле ""{0}"" не должно быть пустым", nameOfTxtBox);
            if (comboBox.SelectedItem == null)
            {
                MessageBox.Show(messageBoxMessage,
                    "Ошибка",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Данный проверяет пароль по 3-ем параеметрам: содержит ли пароль спец. символы, длина пароля должна быть больше
        /// или равна восьми, парол должен совпадать с полем "Повтор пароля"
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        private bool CheckPassword(string password)
        {
            char[] specChars = ['#', '!', '@', '*', '%', '^', '+', '-', '№'];
            bool isPasswordHasSpecChars = false;
            bool isPasswordHasCorrectLenght;
            bool isPasswordIsChecked;

            foreach (char c in specChars)
            {
                if (!password.Contains(c))
                {
                    isPasswordHasSpecChars = false;
                    break;
                }
                else
                {
                    isPasswordHasSpecChars = true;
                    break;
                }
            }

            isPasswordHasCorrectLenght = password.Length >= 8;

            isPasswordIsChecked = password == TxtBoxPasswordRepeat.Password ? true : false;


            if (!isPasswordHasCorrectLenght)
            {
                MessageBox.Show("Длина пароля меньше 8 символов",
                    "Ошибка",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                return false;
            }
            else if (!isPasswordHasSpecChars)
            {
                MessageBox.Show("Пароль не содержит специальных символов",
                    "Ошибка",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                return false;
            }
            else if (!isPasswordIsChecked)
            {
                MessageBox.Show("Пароли не совпадают",
                    "Ошибка",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
