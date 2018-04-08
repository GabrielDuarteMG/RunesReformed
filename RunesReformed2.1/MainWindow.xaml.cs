using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using EasyHttp.Http;
using System.Management;
using RunesReformed1._1.Translators;
using JsonFx.Json;

namespace RunesReformed2._1
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string token;
        public static string port;
        public static HttpClient http;
        public class Champion
        {
            public int Id { get; set; }
            public string Name { get; set; }

            public Champion(int id, string name)
            {
                Id = id;
                Name = name;
            }

        }

        public class RunePage
        {
            public string _pageName { get; set; }
            public int _runeStart { get; set; }
            public int _rune1 { get; set; }
            public int _rune2 { get; set; }
            public int _rune3 { get; set; }
            public int _rune4 { get; set; }
            public int _runeSecondary { get; set; }
            public int _rune5 { get; set; }
            public int _rune6 { get; set; }

            public RunePage(string name, int start, int rune1, int rune2, int rune3, int rune4, int secondary,
                int rune5, int rune6)
            {
                _pageName = name;
                _runeStart = start;
                _rune1 = rune1;
                _rune2 = rune2;
                _rune3 = rune3;
                _rune4 = rune4;
                _runeSecondary = secondary;
                _rune5 = rune5;
                _rune6 = rune6;
            }
        }

        public List<string> ChampionList = new List<string>();
        BindingSource bs = new BindingSource();
        public List<RunePage> Pagelist = new List<RunePage>();
        public List<string> Pagenamelist = new List<string>();
        bool opening = true;
        public MainWindow()
        {
            http = new HttpClient();
            InitializeComponent();
        }
        void pictureBoxLoad(string Url, System.Windows.Controls.Image image)
        {
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(Url, UriKind.Absolute);
            bitmap.EndInit();
            image.Source = bitmap;
        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(ChampionSelectList.SelectedIndex != 0)
            {
                RunesSelectList.Items.Clear();
                string champ = ChampionSelectList.SelectedItem.ToString();
                RunesSelectList.Items.Add("Select your Rune");
                RunesSelectList.SelectedIndex = 0;
                pictureBoxLoad("http://opgg-static.akamaized.net/images/lol/champion/" + champ + ".png", ChampionImage);
                foreach (var rune in Pagenamelist)
                {
                    if (Pagenamelist.Count == 0)
                    {

                    }
                    else
                    {
                        if (rune.Contains(champ) || rune.Contains(champ.ToLower()))
                        {
                            RunesSelectList.Items.Add(rune);
                        }
                    }
                }
            }
            
        }
        public void LoadOfflinePages()
        {
            string path = Environment.CurrentDirectory + @"\Runepages.txt";
            if (!File.Exists(path))
            {
                File.CreateText(path);
            }
            else
            {
                foreach (string data in File.ReadAllLines(path))
                {
                    string[] runes = data.Split(',');
                    RunePage import = new RunePage(
                        runes[0], Convert.ToInt32(runes[1]), Convert.ToInt32(runes[2]),
                        Convert.ToInt32(runes[3]), Convert.ToInt32(runes[4]), Convert.ToInt32(runes[5]),
                        Convert.ToInt32(runes[6]), Convert.ToInt32(runes[7]), Convert.ToInt32(runes[8]));
                    Pagelist.Add(import);
                    Pagenamelist.Add(runes[0]);
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
         
            if (!(new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator)))
            {
               System.Windows.MessageBox.Show("App not running with administrator privilege. Please run this app as administrator", "RunesReformed",MessageBoxButton.OK,MessageBoxImage.Asterisk);
                this.Close();
            }
            Leagueconnect();
            ChampionSelectList.SelectedIndex = 0;
            RunesSelectList.SelectedIndex = 0;
            DeletePageCB.IsChecked = true ;

            getchamps();
            getpages();
            LoadOfflinePages();
            addComboChamps();
        }
        public void addComboChamps()
        {
            for(int x=  0; x != ChampionList.Count; x++)
            {
                ChampionSelectList.Items.Add(ChampionList[x]);
            }
        }
        public void getpages()
        {
            http.Request.Accept = HttpContentTypes.ApplicationJson;
            var response = http.Get("https://wepapirunepages.azurewebsites.net/api/values");
            var getpages = response.DynamicBody;

            foreach (var page in getpages)
            {
                RunePage ImportPageBox = new RunePage(page.PageName, page.Runestart, page.Rune1, page.Rune2, page.Rune3,
                    page.Rune4, page.RuneSecondary, page.Rune5, page.Rune6);
                Pagelist.Add(ImportPageBox);
                Pagenamelist.Add(page.PageName);
            }
        }
        public void getchamps()
        {
            http.Request.Accept = HttpContentTypes.ApplicationJson;
            var response = http.Get("https://webapichampions.azurewebsites.net/api/values");
            var getchamps = response.DynamicBody;

            foreach (var champ in getchamps)
            {
                Champion ImportChampBox = new Champion(champ._Id, champ._DisplayName);
                ChampionList.Add(ImportChampBox.Name);
                ChampionList.Sort();
            }

        }
        private void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        public void Leagueconnect()
        {
            var process = Process.GetProcessesByName("LeagueClientUx");
            if (process.Length != 0)
            {
                foreach (var getid in process)
                {
                    using (ManagementObjectSearcher mos = new ManagementObjectSearcher(
                        "SELECT CommandLine FROM Win32_Process WHERE ProcessId = " + getid.Id))
                    {
                        foreach (ManagementObject mo in mos.Get())
                        {
                            if (mo["CommandLine"] != null)
                            {
                                string data = (mo["CommandLine"].ToString());
                                string[] CommandlineArray = data.Split('"');

                                foreach (var attributes in CommandlineArray)
                                {
                                    if (attributes.Contains("token") || attributes.Contains("remoting-auth-token"))
                                    {
                                        string[] token = attributes.Split('=');
                                        MainWindow. token = token[1];
                                    }
                                    if (attributes.Contains("port") || attributes.Contains("app-port"))
                                    {
                                        string[] port = attributes.Split('=');
                                       MainWindow.port = port[1];
                                    }
                                }
                                if (string.IsNullOrWhiteSpace(MainWindow.token) || string.IsNullOrWhiteSpace(MainWindow.port))
                                {
                                   System.Windows. MessageBox.Show("League of Legends process is detected but no information can be extracted.");
                                    this.Close();
                                }
                                return;
                            }
                        }
                    }
                }
            }
            // We cannot retrieve necessary information to make the app work, can close here.
            System.Windows.MessageBox.Show("Could not find the League of Legends process, is League of Legends running?");
            this.Close();
        }

        private void Label_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void AddPageBTN_MouseDown(object sender, MouseButtonEventArgs e)
        {
            string Newpage = Microsoft.VisualBasic.Interaction.InputBox(
           "Here you can add a page, a page contains a Name and the URL of Riots RunesReforged tool",
           "RunesReformed",
           "Name of page, Riot URL");

            string[] SplitRiotpage = Newpage.Split(',');

            RiotTranslator RT = new RiotTranslator();

            int[] riotpage = RT.Translate(SplitRiotpage[1]);


            if (string.IsNullOrEmpty(Newpage))
                return;

            string CheckDupes = Pagenamelist.Find(x => x == SplitRiotpage[1]);
            if (CheckDupes != null)
             System.Windows. MessageBox.Show("Duplicate Page");
            RunePage import = new RunePage(
                SplitRiotpage[0], riotpage[0], riotpage[1],
                riotpage[2], riotpage[3], riotpage[4], riotpage[5], riotpage[6], riotpage[7]);
            Pagelist.Add(import);
            Pagenamelist.Add(SplitRiotpage[0]);


            StreamWriter sw = new StreamWriter(Environment.CurrentDirectory + @"\Runepages.txt", true);
            sw.WriteLine(SplitRiotpage[0] + "," + riotpage[0] + "," + riotpage[1] + "," + riotpage[2] + "," + riotpage[3] + "," + riotpage[4]
                + "," + riotpage[5] + "," + riotpage[6] + ',' + riotpage[7]);
            sw.Flush();
            sw.Close();


            ComboBox_SelectionChanged(ChampionSelectList,null);
        }
        public void DeletePage()
        {
            if (DeletePageCB.IsChecked == true)
            {
                http = new HttpClient();
                http.Request.Accept = HttpContentTypes.ApplicationJson;
                http.Request.ForceBasicAuth = true;
                http.Request.SetBasicAuthentication("riot", token);
                var response = http.Get("https://127.0.0.1:" + port + "/lol-perks/v1/currentpage");
                var currentpage = response.DynamicBody;

                int deleteid = currentpage.id;

                if (deleteid == 54 || deleteid == 53 || deleteid == 52 || deleteid == 51 || deleteid == 50)
                  System.Windows.MessageBox.Show("Cant Delete Pages, Looks like its only Riots default pages left, if you know this is wrong, click the page once so it gets set to current.");
                else
                {
                    http.Delete("https://127.0.0.1:" + port + "/lol-perks/v1/pages/" + deleteid);
                }
            }
        }
        public class Error
        {
            [JsonName("errorCode")]
            public string errorCode { get; set; }
            [JsonName("httpStatus")]
            public int httpStatus { get; set; }
            [JsonName("message")]
            public string message { get; set; }

        }
        private void SetPageBTN_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DeletePage();
            if (RunesSelectList.SelectedItem == null)
                RunesSelectList.SelectedIndex = 0;
            String selectedPage = RunesSelectList.SelectedItem.ToString();

            RunePage runes = Pagelist.Find(r => r._pageName == selectedPage);

            try
            {
                int Runestart = runes._runeStart;
                string name = runes._pageName;
                int rune1 = runes._rune1;
                int rune2 = runes._rune2;
                int rune3 = runes._rune3;
                int rune4 = runes._rune4;
                int rune5 = runes._rune5;
                int rune6 = runes._rune6;
                int secondary = runes._runeSecondary;

                var inputLCUx = @"{""name"":""" + name + "\",\"primaryStyleId\":" + Runestart + ",\"selectedPerkIds\": [" +
                                rune1 + "," + rune2 + "," + rune3 + "," + rune4 + "," + rune5 + "," + rune6 +
                                "],\"subStyleId\":" + secondary + "}";


                string password = token;

                http.Request.Accept = HttpContentTypes.ApplicationJson;
                http.Request.SetBasicAuthentication("riot", password);

                var response = http.Post("https://127.0.0.1:" + port + "/lol-perks/v1/pages", inputLCUx, HttpContentTypes.ApplicationJson);

                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    var error = response.StaticBody<Error>();
                    if (error.message.Equals("Max pages reached"))
                       System.Windows.MessageBox.Show("Max Pages Reached");
                }
            }
            catch (Exception exception)
            {
                System.Windows.MessageBox.Show(exception.Message);
            }
        }

        private void AddPageBTN_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            DropShadowBitmapEffect myDropShadowEffect = new DropShadowBitmapEffect();
            // Set the color of the shadow to Black.
            myDropShadowEffect.Color = (Color)ColorConverter.ConvertFromString("#FFC89F48");
            myDropShadowEffect.Direction = 0;
            myDropShadowEffect.ShadowDepth = 2;
            myDropShadowEffect.Softness = 5;

            myDropShadowEffect.Opacity = 0.5;
            AddPageBTN.BitmapEffect = myDropShadowEffect;
        }

        private void AddPageBTN_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            AddPageBTN.BitmapEffect = null;
        }

        private void SetPageBTN_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            DropShadowBitmapEffect myDropShadowEffect = new DropShadowBitmapEffect();
            // Set the color of the shadow to Black.
            myDropShadowEffect.Color = (Color)ColorConverter.ConvertFromString("#FFC89F48");
            myDropShadowEffect.Direction = 0;
            myDropShadowEffect.ShadowDepth = 2;
            myDropShadowEffect.Softness = 5;

            myDropShadowEffect.Opacity = 0.5;
            SetPageBTN.BitmapEffect = myDropShadowEffect;
        }

        private void SetPageBTN_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            SetPageBTN.BitmapEffect = null;
        }

        private void Label_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            var converter = new System.Windows.Media.BrushConverter();
            CloseBTN.Foreground = (Brush)converter.ConvertFromString("#FFBCBCBC");
        }

        private void CloseBTN_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            var converter = new System.Windows.Media.BrushConverter();
            CloseBTN.Foreground = (Brush)converter.ConvertFromString("#FF79786F");
        }

        private void DeletePageCB_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            DropShadowBitmapEffect myDropShadowEffect = new DropShadowBitmapEffect();
            // Set the color of the shadow to Black.
            myDropShadowEffect.Color = (Color)ColorConverter.ConvertFromString("#FFC89F48");
            myDropShadowEffect.Direction = 0;
            myDropShadowEffect.ShadowDepth = 2;
            myDropShadowEffect.Softness = 5;

            myDropShadowEffect.Opacity = 0.5;
            DeletePageCB.BitmapEffect = myDropShadowEffect;
        }

        private void DeletePageCB_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {

            DeletePageCB.BitmapEffect = null;
        }

        private void Label_MouseEnter_1(object sender, System.Windows.Input.MouseEventArgs e)
        {
            DropShadowBitmapEffect myDropShadowEffect = new DropShadowBitmapEffect();
            // Set the color of the shadow to Black.
            myDropShadowEffect.Color = (Color)ColorConverter.ConvertFromString("#FFC89F48");
            myDropShadowEffect.Direction = 0;
            myDropShadowEffect.ShadowDepth = 2;
            myDropShadowEffect.Softness = 5;

            myDropShadowEffect.Opacity = 0.5;
            AboutLBL.BitmapEffect = myDropShadowEffect;
        }

        private void AboutLBL_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            AboutLBL.BitmapEffect = null;
        }

        private void AboutLBL_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Process.Start("http://github.com/gabrielduartemg");
        }
    }
}
