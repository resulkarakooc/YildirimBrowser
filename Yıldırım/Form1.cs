using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;



namespace Yıldırım
{
    public partial class Form1 : Form
    {

        private int tabCounter = 0;
        public Form1()
        {
            InitializeComponent();

        }
        private void AddNewTab(string url)
        {

            tabCounter++;
            TabPage yeniSekme = new TabPage("Yeni Sekme" + tabCounter);
            tabControl1.TabPages.Add(yeniSekme);
            tabControl1.SelectedTab = yeniSekme;

            WebView2 webView = new WebView2();
            webView.Source = new Uri("https://www.google.com");
            webView.Dock = DockStyle.Fill;
            yeniSekme.Controls.Add(webView);
            tabControl1.SelectedTab = yeniSekme;
            webView.EnsureCoreWebView2Async(null);
        }
        private void CoreWebView2_WebMessageReceived(object sender, CoreWebView2WebMessageReceivedEventArgs e)
        {
            // WebView2 içinde JavaScript tarafından gönderilen mesajı işleyin
            MessageBox.Show($"Web sayfasından mesaj alındı: {e.TryGetWebMessageAsString()}");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TabPage selectedTab = tabControl1.SelectedTab;
            // Eğer seçili sekme null değilse ve içinde WebView2 kontrolü varsa geri döndür
            if (selectedTab != null)
            {
                WebView2 webView = selectedTab.Controls.OfType<WebView2>().FirstOrDefault();

                try
                {
                    webView.CoreWebView2.Navigate(textBox1.Text);
                    string currentUrl = webView3.Source.AbsoluteUri;
                    textBox1.Text = currentUrl;
                }
                catch
                {
                    MessageBox.Show("URL biçimi Yanlış");
                }
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            TabPage selectedTab = tabControl1.SelectedTab;
            if (selectedTab != null)
            {
                WebView2 webView = selectedTab.Controls.OfType<WebView2>().FirstOrDefault();
                webView.CoreWebView2.GoBack();
                string currentUrl = webView3.Source.AbsoluteUri;
                textBox1.Text = currentUrl;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            webView3.CoreWebView2.GoForward();
            string currentUrl = webView3.Source.AbsoluteUri;
            textBox1.Text = currentUrl;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            webView3.CoreWebView2.Reload();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            TabPage selectedTab = tabControl1.SelectedTab;
            if (selectedTab != null)
            {
                WebView2 webView = selectedTab.Controls.OfType<WebView2>().FirstOrDefault();
                webView.CoreWebView2.Navigate($"https://www.google.com/search?q={textBox2.Text}");
                string currentUrl = webView3.Source.AbsoluteUri;
                textBox1.Text = currentUrl;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
        }
        private void button7_Click(object sender, EventArgs e)
        {
            AddNewTab("https://www.bing.com");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Rectangle workingArea = Screen.PrimaryScreen.WorkingArea;
            // Formun boyutunu ve konumunu ayarla
            this.Size = workingArea.Size;
            this.Location = workingArea.Location;
            
        }

        private void WebView_NewWindowRequested(object sender, CoreWebView2NewWindowRequestedEventArgs e)
        {
            // Yeni sekme açılacak URL'yi kaydet
            string url = e.Uri;

            // Yeni sekme açma işlevini çağırabilirsiniz
            AddNewTab(url);
        }
    }


}



