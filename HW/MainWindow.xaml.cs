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

namespace HW
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

                string text = File.ReadAllText(fileDialog.FileName);
                char[] separators = new char[] { ' ', '.', ',', '!', '?', '/', '\t', '\n' };

                string[] textArray = text.Split(separators);
                StringBuilder b = new StringBuilder();
                foreach (string strTemp in textArray)
                {
                    string str = strTemp.Trim();
                    if (!list.Contains(str))
                    {
                        list.Add(str);
                        b.Append(str + " ");
                    };
                }

                t.Stop();
                this.timeLabel.Content = t.Elapsed.ToString();
                this.textBox.AppendText(b.ToString());
            }
            else
            {
                System.Windows.MessageBox.Show("Необходимо выбрать файл");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string find = findBox.Text.Trim();
            if (find == "")
            {
                System.Windows.MessageBox.Show("Введите слово для поиска");
            }
            else
            {
                int lev = (int.TryParse(LevInt.Text, out lev)) ? lev : 0;
                Stopwatch t = new Stopwatch();
                t.Start();
                bool finded = false;
                foreach (string seachword in list)
                {
                    int levn = FindLevn.Distance(find, seachword);
                    if (levn <= lev)
                        this.listBox.Items.Add(seachword); finded = true;
                }
                if (finded == false)
                    System.Windows.MessageBox.Show("Такого слова нет");
                t.Stop();

                this.findTime.Content = t.Elapsed.ToString();
            }
        }
        public static List<FindRes> ArrayThreadTask(object paramObj)
        {
            SeachInfo param = (SeachInfo)paramObj;
            string wordUpper = param.wordPattern.Trim().ToUpper();
            List<FindRes> Result = new List<FindRes>();
            foreach (string str in param.tempList)
            {
                int dist = FindLevn.Distance(str.ToUpper(), wordUpper);
                if (dist <= param.maxDist)
                {
                    FindRes temp = new FindRes()
                    {
                        word = str,
                        dist = dist,
                        ThreadNum = param.ThreadNum
                    };

                    Result.Add(temp);
                }
            }
            return Result;
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string find = this.findBox.Text.Trim();

            if (!string.IsNullOrWhiteSpace(find) && list.Count > 0)
            {
                int lev = (int.TryParse(LevInt.Text.Trim(), out lev)) ? lev : 0;

                if (lev < 0 || lev > 5)
                {
                    System.Windows.MessageBox.Show("Максимальное расстояние должно быть в диапазоне от 0 до 5?");
                    return;
                }

                int ThreadKol;
                if (!int.TryParse(kol.Text.Trim(), out ThreadKol))
                {
                    System.Windows.MessageBox.Show("Необходимо указать количество потоков");
                    return;
                }

                Stopwatch timer = new Stopwatch();
                timer.Start(); 
                List<FindRes> Result = new List<FindRes>();
                List<Range> arrayDivList = DevineList.DivideSubArrays(0, list.Count, ThreadKol);
                int count = arrayDivList.Count;
                Task<List<FindRes>>[] tasks = new Task<List<FindRes>>[count];

                for (int i = 0; i < count; i++)
                {
                    List<string> tempTaskList = list.GetRange(arrayDivList[i].Start, arrayDivList[i].End - arrayDivList[i].Start);

                    tasks[i] = new Task<List<FindRes>>(
                        ArrayThreadTask,
                        new SeachInfo()
                        {
                            tempList = tempTaskList,
                            maxDist = lev,
                            ThreadNum = i,
                            wordPattern = find
                        });
                    tasks[i].Start();
                }
                Task.WaitAll(tasks);
                timer.Stop();
                for (int i = 0; i < count; i++)
                {
                    Result.AddRange(tasks[i].Result);
                }
                timer.Stop();
                this.findTimeP.Content = timer.Elapsed.ToString();
                this.listBox.Items.Clear();
                foreach (var x in Result)
                {
                    string temp = x.word + "(расстояние=" + x.dist.ToString() + " поток=" + x.ThreadNum.ToString() + ")";
                    this.listBox.Items.Add(temp);
                }
            }
            else
            {
                System.Windows.MessageBox.Show("Необходимо выбрать файл и ввести слово для поиска");
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            string TempReportFileName = "Report_" + DateTime.Now.ToString("dd_MM_yyyy_hhmmss");

            SaveFileDialog fd = new SaveFileDialog();
            fd.FileName = TempReportFileName;
            fd.DefaultExt = ".html";
            fd.Filter = "HTML Reports|*.html";

            if (fd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string ReportFileName = fd.FileName;

                StringBuilder b = new StringBuilder();
                b.AppendLine("<html>");

                b.AppendLine("<head>");
                b.AppendLine("<meta http-equiv='Content-Type' content='text/html; charset=UTF-8'/>");
                b.AppendLine("<title>" + "Отчет: " + ReportFileName + "</title>");
                b.AppendLine("</head>");

                b.AppendLine("<body>");

                b.AppendLine("<h1>" + "Отчет: " + ReportFileName + "</h1>");
                b.AppendLine("<table border='1'>");

                b.AppendLine("<tr>");
                b.AppendLine("<td>Время чтения из файла</td>");
                b.AppendLine("<td>" + this.timeLabel.Content + "</td>");
                b.AppendLine("</tr>");

                b.AppendLine("<tr>");
                b.AppendLine("<td>Слово для поиска</td>");
                b.AppendLine("<td>" + this.findBox.Text + "</td>");
                b.AppendLine("</tr>");

                b.AppendLine("<tr>");
                b.AppendLine("<td>Максимальное расстояние для нечеткого поиска</td>");
                b.AppendLine("<td>" + this.LevInt.Text + "</td>");
                b.AppendLine("</tr>");

                b.AppendLine("<tr>");
                b.AppendLine("<td>Время четкого поиска</td>");
                b.AppendLine("<td>" + this.findTime.Content + "</td>");
                b.AppendLine("</tr>");

                b.AppendLine("<tr>");
                b.AppendLine("<td>Время нечеткого поиска</td>");
                b.AppendLine("<td>" + this.findTimeP.Content + "</td>");
                b.AppendLine("</tr>");

                b.AppendLine("<tr valign='top'>");
                b.AppendLine("<td>Результаты поиска</td>");
                b.AppendLine("<td>");
                b.AppendLine("<ul>");

                foreach (var x in this.listBox.Items)
                {
                    b.AppendLine("<li>" + x.ToString() + "</li>");
                }

                b.AppendLine("</ul>");
                b.AppendLine("</td>");
                b.AppendLine("</tr>");

                b.AppendLine("</table>");

                b.AppendLine("</body>");
                b.AppendLine("</html>");
                File.AppendAllText(ReportFileName, b.ToString());
                System.Windows.MessageBox.Show("Отчет сформирован. Файл: " + ReportFileName);
            }
        }
    }
}
