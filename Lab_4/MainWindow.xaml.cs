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
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace Lab_4
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
        List<String> list = new List<String>();
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "текстовые файлы|*.txt";

            if (fileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Stopwatch t = new Stopwatch();
                t.Start();

                //Чтение файла в виде строки
                string text = File.ReadAllText(fileDialog.FileName);

                //Разделительные символы для чтения из файла
                char[] separators = new char[] { ' ', '.', ',', '!', '?', '/', '\t', '\n' };

                string[] textArray = text.Split(separators);
                StringBuilder b = new StringBuilder();
                foreach (string strTemp in textArray)
                {
                    //Удаление пробелов в начале и конце строки
                    string str = strTemp.Trim();
                    //Добавление строки в список, если строка не содержится в списке
                    if (!list.Contains(str))
                    {
                        list.Add(str);
                        b.Append(str + " ");
                    };
                }

                t.Stop();
                this.timeLabel.Content = t.Elapsed.ToString();
                //this.textBox.Text = list.Count.ToString();
                this.textBox.AppendText(b.ToString());
            }
            else
            {
                System.Windows.MessageBox.Show("Необходимо выбрать файл");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string find = findBox.Text;
            Stopwatch t = new Stopwatch();
            t.Start();
            if (list.Contains(find))
            {
                //System.Windows.MessageBox.Show("Слово найдено"); ;
                this.listBox.Items.Add(find);
            }
            else
            {
                System.Windows.MessageBox.Show("Такого слова нет"); ;
            };
            t.Stop();
            this.findTime.Content = t.Elapsed.ToString();
        }




    }
}
