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
using System.Windows.Threading;

namespace prakt_12._1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        DispatcherTimer timer;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            timer = new DispatcherTimer();
            timer.Tick += Timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 0, 1, 0);
            timer.IsEnabled = true;
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            DateTime d = DateTime.Now;
            time.Text = d.ToString("HH:mm");
            date.Text = d.ToString("dd.MM.yyyy");
        }

        private void Task1_Click(object sender, RoutedEventArgs e)
        {
            x1Text.Focus();
            if (double.TryParse(x1Text.Text, out double x1) && double.TryParse(y1Text.Text, out double y1) && double.TryParse(x2Text.Text, out double x2) && double.TryParse(y2Text.Text, out double y2) && double.TryParse(x3Text.Text, out double x3) && double.TryParse(y3Text.Text, out double y3))
            {
                double sideA = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
                double sideB = Math.Sqrt(Math.Pow(x3 - x2, 2) + Math.Pow(y3 - y2, 2));
                double sideC = Math.Sqrt(Math.Pow(x3 - x1, 2) + Math.Pow(y3 - y1, 2));
                double perimeter = Math.Round(sideA + sideB + sideC, 2);
                double p = perimeter / 2;
                double square = Math.Round(Math.Sqrt(p * (p - sideA) * (p - sideB) * (p - sideC)), 2);
                perimeterOut.Text = perimeter.ToString();
                squareOut.Text = square.ToString();
            }
            else
            {
               MessageBox.Show("Введены неверные координаты", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Task2_Click(object sender, RoutedEventArgs e)
        {
            numberText.Focus();
            if (int.TryParse(numberText.Text, out int number) && number < 1000 && number > 99)
            {
                int sum = (number / 100) + (number / 10 % 10) + (number % 10);
                int composition = number / 100 * (number / 10 % 10) * (number % 10);
                sumOut.Text = sum.ToString();
                compositionOut.Text = composition.ToString();
            }
            else
            {
                MessageBox.Show("Введены неверные данные", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Ad_Click(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start("https://vk.com/rznews");
        }

        private void Clear1_Click(object sender, RoutedEventArgs e)
        {
            x1Text.Clear();
            y1Text.Clear();
            x2Text.Clear();
            y2Text.Clear();
            x3Text.Clear();
            y3Text.Clear();
            perimeterOut.Clear();
            squareOut.Clear();
        }

        private void Clear2_Click(object sender, RoutedEventArgs e)
        {
            numberText.Clear();
            sumOut.Clear();
            compositionOut.Clear();
        }

        private void Info_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Савельев Дмитрий Александрович В13\nПрактическая работа №12\nРеализовать расчет задачи:\n Даны координаты трех вершин треугольника: (x1, y1), (x2, y2), (x3, y3). Найти его периметр и площадь, используя формулу для расстояния между двумя точками на плоскости (см. задание 12). Для нахождения площади треугольника со сторонами a, b, c использовать формулу Герона.\n Дано трехзначное число. Найти сумму и произведение его цифр.", "Информация о программе", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Task1_TextChanged(object sender, TextChangedEventArgs e)
        {
            perimeterOut.Clear();
            squareOut.Clear();
        }

        private void Task2_TextChanged(object sender, TextChangedEventArgs e)
        {
            sumOut.Clear();
            compositionOut.Clear();
        }
    }
}
