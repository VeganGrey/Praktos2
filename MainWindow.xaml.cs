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
using LibMas;
using lib_13;
using Microsoft.Win32;

namespace Praktos2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int[] mas;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Random_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Int32.TryParse(NizhPred.Text, out int min); //Получение нижнего значения рандома
                Int32.TryParse(VerhPred.Text, out int max); //Получение верхнего значения рандома значения рандома
                Int32.TryParse(Lengt.Text, out int lent); //Получение значения массива
                mas = Masssiv.Zapol(min, max, lent); //Использование функции для заполнения массива
                dataGrid.ItemsSource = VisualArray.ToDataTable(mas).DefaultView;
                //Вывод массива
            }
            catch (OverflowException)
            {
                MessageBox.Show("Введите допустимое значение размера массива");
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Введите минимальное значение рандома меньше максимального");
            }
        }

        private void Clear_Ckick(object sender, RoutedEventArgs e)
        {
            Masssiv.Clear(mas); //Функция очистки массива
            dataGrid.ItemsSource = null; //Обнуление таблицы
        }

        private void Chet_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                itogovoe.Text = $"{Resh.Rezu(mas)}";
            }
            catch(NullReferenceException)
            {
                MessageBox.Show("Сначала заполните массив");
            }
        }

        private void Spravka_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Калитин С.А. ИСП-31\n Ввести n целых чисел. Найти произведение чисел > 2. Результат вывести на экран"); 
        }

        private void Quit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SaveFile_Click(object sender, RoutedEventArgs e) //Для патча
        {
            try
            {
            LibMas.Masssiv.SaveMassiv(mas); //Функция на сохранения массива в файл
            }
            catch(NullReferenceException)
            {
                MessageBox.Show("Массив не может быть пустой");
            }
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                LibMas.Masssiv.OpenMassiv(ref mas); //Функция на чтение массива из файла и вывода в таблицу
                dataGrid.ItemsSource = VisualArray.ToDataTable(mas).DefaultView; //Вывод значений массива в таблицу
            }
            catch(NullReferenceException)
            {
                MessageBox.Show("Введите не пустой массив");
            }
        }
    }
}
