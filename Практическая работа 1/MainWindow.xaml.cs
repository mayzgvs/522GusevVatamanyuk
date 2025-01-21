using System;
using System.Windows;

namespace Практическая_работа_1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void calculateButton_Click(object sender, RoutedEventArgs e)
        {
            double x, y;

            if (double.TryParse(xInput.Text, out x) && double.TryParse(yInput.Text, out y))
            {
                double f_x = 0;

                if (shRadioButton.IsChecked == true)
                {
                    f_x = Math.Sinh(x);
                }
                else if (x2RadioButton.IsChecked == true)
                {
                    f_x = Math.Pow(x, 2);
                }
                else if (expRadioButton.IsChecked == true)
                {
                    f_x = Math.Exp(x);
                }

                double result = 0;

                if (x > y)
                {
                    result = Math.Pow(f_x - y, 3) + Math.Atan(f_x);
                }
                else if (y > x)
                {
                    result = Math.Pow(y - f_x, 3) + Math.Atan(f_x);
                }
                else if (y == x)
                {
                    result = Math.Pow(y + f_x, 3) + 0.5;
                }

                resultTextBox.Text = result.ToString();
            }
            else
            {
                MessageBox.Show("Пожалуйста, введите правильные значения для x и y.");
            }
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            xInput.Clear();
            yInput.Clear();
            resultTextBox.Clear();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var result = MessageBox.Show("Вы уверены, что хотите закрыть приложение?", "Подтверждение", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
