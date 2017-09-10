using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        string posterPath = (@"https://image.tmdb.org/t/p/w500/");
        List<Result> resultList = new List<Result>();
        private int lastComboboxIndex = -1;
        private System.IO.StreamReader reader;
        private string lastComboBoxSearch = "OwlCatDestroyer";

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
            ComboBox combobox_search = sender as ComboBox;
     
            if (e.Key == Key.Enter)
            {
                if (combobox_search.Text.ToLower().Contains(lastComboBoxSearch.ToLower())) return;
                
               
                resultList.Clear();                                                     // Clear for each search
                combobox_search.ItemsSource = resultList;                               // Clear ComboBox
                var html = String.Format(sTvRequest + combobox_search.Text);
                int overviewIndex = 0;
                int lastIndex = 0;

                WebRequest req = HttpWebRequest.Create(html);
                req.Method = "GET";

                string source;

                using (reader = new System.IO.StreamReader(req.GetResponse().GetResponseStream()))
                {
                    source = reader.ReadToEnd();
                }

                // Remove { and } at start and end
                source.Remove(0);
                source.Remove(source.Length - 1);

                List<String> resultsArray = source.Split('{').ToList();


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



                    // Here starts Info editing:
                    foreach (var info in resultInformation)
                    {
                        //Console.WriteLine("Index:{0}: {1}", resultInformation.IndexOf(info), info);
                        if (info.Contains("overview"))
                        {
                            overviewIndex = resultInformation.IndexOf(info);
                            lastIndex = resultInformation.Count - 1;
                            break;
                        }
                    }

                    StringBuilder description = new StringBuilder();

                    // Create Description out of Elements
                    for (int i = overviewIndex; i <= lastIndex; i++)
                    {
                        description.Append(resultInformation[i]);
                        lastIndex = lastIndex - 1;
                    }

                    // restore LastIndex to current State
                    lastIndex = resultInformation.Count - 1;

                    // Remove the last Index N Times so every Description gets removed
                    int timesToRemove = resultInformation.Count - overviewIndex;
                    for (int i = 1; i <= timesToRemove; i++)
                    {
                        resultInformation.RemoveAt(resultInformation.Count - 1);
                    }

                    // Then Add description back to List as a whole
                    resultInformation.Add(description.ToString());



                    Result result = new Result();
               
                    var idFirst = resultInformation.FirstOrDefault(element => element.Contains("\"id\""));
                    if (idFirst != null) result.resultId = int.Parse(idFirst.Split(':')[1].Replace("\"", ""));

                    var nameFirst = resultInformation.FirstOrDefault(element => element.Contains("\"name\""));
                    if (nameFirst != null)result.resultName = nameFirst.Split(':')[1].Replace("\"", "");

                    var countFirst = resultInformation.FirstOrDefault(element => element.Contains("\"vote_count\""));
                    if (countFirst != null) result.resultVotes = int.Parse(countFirst.Split(':')[1].Replace("\"", ""));

                    var averageFirst = resultInformation.FirstOrDefault(element => element.Contains("\"vote_average\""));
                    if (averageFirst != null) result.resultRating = float.Parse(averageFirst.Split(':')[1].Replace("\"", ""));

                    var posterPathFirst = resultInformation.FirstOrDefault(element => element.Contains("\"poster_path\""));
                    if (posterPathFirst != null) result.resultPosterPath = posterPathFirst.Split(':')[1].Replace("\"", "");

                    var overviewFirst = resultInformation.FirstOrDefault(element => element.Contains("\"overview\""));
                    if (overviewFirst != null) result.resultDescription = overviewFirst.Split(':')[1].Replace("\"", "");

                    resultList.Add(result);
                }

                lastComboBoxSearch = combobox_search.Text;
                combobox_search.ItemsSource = resultList.Select(element => element.resultName).ToList();
                combobox_search.Focus();
                combobox_search.IsDropDownOpen = true;
            }
        }



        private void combobox_search_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            ComboBox combobox_search = sender as ComboBox;
            if (combobox_search.SelectedIndex == -1) return;
            
            string selectedItem = (string)combobox_search.SelectedItem;
            int selectedIndex = combobox_search.SelectedIndex;
            if (lastComboboxIndex == selectedIndex) return;
            lastComboboxIndex = selectedIndex;

            Result result = resultList[selectedIndex];
            int id = result.resultId;
            string name = result.resultName;
            int votes = result.resultVotes;
            float rating = result.resultRating;
            string description = result.resultDescription;
            string imagePath = result.resultPosterPath;

            label_previewname.Content = name;
            label_previewviews.Content = votes;
            label_previewrating.Content = rating.ToString();
            label_previewid.Content = id;

            textblock_previewdescription.Text = description;

            // PreviewFoto C:\Users\secto\Source\Repos\MediaWatch2\MediaWatch-master\Serienlook
            string localImagePath = @"C:\Users\secto\Source\Repos\MediaWatch2\MediaWatch-master\Serienlook\Images\" + name + ".png";
            string posterPathUrl = @"https://image.tmdb.org/t/p/w500/" + imagePath;
            using (WebClient client = new WebClient())
            {
                client.DownloadFile(posterPathUrl, localImagePath);
            }


            BitmapImage b = new BitmapImage();
            b.BeginInit();
            b.UriSource = new Uri(localImagePath);
            b.EndInit();

            image_preview.Source = b;
        }
    }
}