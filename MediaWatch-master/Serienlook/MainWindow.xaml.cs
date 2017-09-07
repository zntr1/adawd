using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
using HtmlAgilityPack;
using System.Drawing;

namespace Serienlook
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        List<String> listSearchResults = new List<String>();
        string sApikey = "8d6f5e3ef9008fb0f47871820feafcec";
        string sTvRequest = string.Format(@"https://api.themoviedb.org/3/search/tv?api_key=8d6f5e3ef9008fb0f47871820feafcec&query=");


        public MainWindow()
        {
            InitializeComponent();
        }



        private void button_Click_2(object sender, RoutedEventArgs e)
        {
            string localFilename = @"C:\Users\p.pradzinski\Documents\VS2017\SerienTool\SerienTool\Images\test.png";
            using (WebClient client = new WebClient())
            {
                client.DownloadFile(
                    "https://images-na.ssl-images-amazon.com/images/M/MV5BMTQxNDEwNTE0Nl5BMl5BanBnXkFtZTgwMzQ1MTg3MDE@._V1_UY268_CR2,0,182,268_AL_.jpg",
                    localFilename);
            }


            BitmapImage b = new BitmapImage();
            b.BeginInit();
            b.UriSource = new Uri(@"C:\Users\p.pradzinski\Documents\VS2017\SerienTool\SerienTool\Images\test.png");
            b.EndInit();

            image_preview.Source = b;
        }

        private void button_Copy1_Click(object sender, RoutedEventArgs e)
        {


        }


        private void combobox_search_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                listSearchResults.Clear();
                combobox_search.ItemsSource = listSearchResults;
                var html = String.Format(sTvRequest + combobox_search.Text);

                WebRequest req = HttpWebRequest.Create(html);
                req.Method = "GET";

                string source;
                using (System.IO.StreamReader reader = new System.IO.StreamReader(req.GetResponse().GetResponseStream()))
                {
                    source = reader.ReadToEnd();
                }



                //Console.WriteLine(source);

                if (source == null)
                {
                    Console.Error.WriteLine("fehler, source == null!");
                    return;
                }

                // Remove { and } at start and end
                source.Remove(0);
                source.Remove(source.Length - 1);

                List<String> resultsArray = source.Split('{').ToList();
                List<Result> resultList = new List<Result>();

                resultsArray.RemoveRange(0, 2);      // Remove first two Elements because one is empty and one is General

                foreach (var resultString in resultsArray)
                {
                    List<String> resultInformation = resultString.Split(',').ToList();
                    resultInformation.RemoveRange(8, 2);

                    // Check if last Element is empty or null, then remove
                    if (resultInformation.ElementAt(resultInformation.Count - 1) == "" ||
                        resultInformation.ElementAt(resultInformation.Count - 1) == " " ||
                        resultInformation.ElementAt(resultInformation.Count - 1) == null)
                    {
                        resultInformation.RemoveAt(resultInformation.Count - 1);
                    }

                    // Remove "Origin Country Entry"
                    resultInformation.RemoveAt(resultInformation.Count - 1);

                    int overviewIndex = resultInformation.FindIndex(element => element.Contains("overview"));
                    StringBuilder description = new StringBuilder();

                    // Build Description from several Elements
                    for (int overViewCounter = overviewIndex; overViewCounter <= resultInformation.Count - 1; overViewCounter++)
                    {
                        description.Append(resultInformation[overViewCounter]);
                    }
                    // Then remove old, copied elemets // Irgendwo fehler
                    resultInformation.RemoveRange(overviewIndex+1, resultInformation.Count-overviewIndex);

                    resultInformation[overviewIndex] = description.ToString();


                    foreach (var item in resultInformation)
                    {
                        Console.WriteLine(resultInformation.ToList().IndexOf(item) + item);

                        if (!item.Contains(":")) { Console.WriteLine("Fehler1"); continue; }

                        Console.WriteLine("Index: " + item.IndexOf(':'));
                        // Console.WriteLine(item.Substring(item.IndexOf(':'), item.Length - 1));
                    }

                    /*
                    Result result = new Result();

                    result.resultId = int.Parse(resultInformation[1]);
                    result.resultName = resultInformation[2];
                    result.resultVotes = int.Parse(resultInformation[3]);
                    result.resultRating = float.Parse(resultInformation[4]);
                    result.resultPosterPath = resultInformation[5];
                    result.resultDescription = resultInformation[12];

                    resultList.Add(result);
                    */

                }

                //results.ToList().ForEach(element => Console.WriteLine(element));











                /////////////////////////////////
                // Mal gucken was mit Leerziechen ist, vielleicht müssen wir die ersetzen.
                // Vielleicht gucken ob das gesuchte Wort auch wirklich enthalten ist /html/body/pre

                /*
                var Webget = new HtmlWeb();
                var doc = Webget.Load(html);

                var body = doc.DocumentNode.SelectNodes("/html/body");
                
                //var body = doc.DocumentNode.SelectNodes("//*[@id=\"main\"]/div/div[2]/table/tbody/tr[1]/td[2]");
                foreach (HtmlNode node in body)
                {
                    Console.WriteLine(html);
                    Console.WriteLine(node.InnerText);
                    if (node.InnerText.ToLower().Contains("tv series") &&
                       node.InnerText.ToLower().Contains(combobox_search.Text.ToLower()))
                    {
                        listSearchResults.Add(node.InnerText);
                    }

                }
                */
                //IEnumerable<string> query = listSearchResults.Where(result => result.ToLower().Contains(("TV Series").ToLower()));
                combobox_search.ItemsSource = listSearchResults;
                combobox_search.Focus();
                combobox_search.IsDropDownOpen = true;

                //listSearchResults.ForEach(element => Console.WriteLine(listSearchResults.IndexOf(element) + ":" + element));
            }
        }


    }
}