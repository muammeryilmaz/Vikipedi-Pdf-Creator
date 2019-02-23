using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Net;
using HtmlAgilityPack;
using iTextSharp.text;
using iTextSharp.text.pdf;
//using System.Web.UI;

namespace Vikipedi_PDF_Builder
{
    
    public partial class Form1 : Form
    {
        string kalinbaslik="";
        string texx="";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
            Uri uri = new Uri(textBox2.Text);
            WebClient client = new WebClient();
            client.Encoding = Encoding.UTF8;
            string html = client.DownloadString(uri);
            textBox3.Text = html;
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(html);
            HtmlNodeCollection hveriler = doc.DocumentNode.SelectNodes("//*[@id='mw-content-text']/div/p");//*[@id="mw-content-text"]/div/p[2]/a[1]
                HtmlNode baslik = doc.DocumentNode.SelectSingleNode("//*[@id='firstHeading']");

                // YASİN İŞİNE YARAYACAK KISIM BURASI
                HtmlNodeCollection yeni = doc.DocumentNode.SelectNodes("//*[@id='Soru']/div[2]/div/div/div[2]");


                var hrefs = yeni.Descendants("a")
             .Select(node => node.GetAttributeValue("href", ""))
            .ToList();
         

                //////////////////////////////////////////
                kalinbaslik = baslik.InnerText;

                //int paragraf_sayisi = 0;
                //foreach (var veri in hveriler)
                //{
                //    textBox1.Text += veri.InnerText.Replace("&#91;kaynak belirtilmeli&#93;", "");
                //    textBox1.AppendText(Environment.NewLine); textBox1.AppendText(Environment.NewLine);
                //    paragraf_sayisi++;
                //}
                //MessageBox.Show("Yazılar Düzeltiliyor Biraz Bekleyin");
                //duzenle();


            }
            catch
            { textBox2.Text = "olmadı moruk"; }


            
        }

        private void duzenle()
        {
            string teximiz = textBox1.Text;
           
            for(int i=0;i<1000;i++)
            {

            teximiz = teximiz.Replace("&#91;"+i.ToString()+"&#93;","") ;
            textBox1.Text = teximiz;

            }
            textBox1.Text = textBox1.Text.Replace("&#91;kaynak belirtilmeli&#93;", "").Replace("&#160;", "");
            teximiz = "";
        }

        public void pdfCevir(string text)
        {
            //PDF dosyamızı temsil edecek nesnemizi oluşturuyoruz
            Document doc = new Document();

            // Türkçe Karakterlerini tanımlıyoruz 
            BaseFont STF_Helvetica_Turkish = BaseFont.CreateFont("Helvetica", "CP1254", BaseFont.NOT_EMBEDDED);

            // Fontumuzu ayarlayıp , Türkçe karakter nesnesini ekliyoruz 
            iTextSharp.text.Font fontNormal = new iTextSharp.text.Font(STF_Helvetica_Turkish, 12);
            //başlık büyük haffe çevriliyor
            kalinbaslik = kalinbaslik.ToUpper();
            Paragraph baslik = new Paragraph(kalinbaslik,fontNormal);
            Paragraph icerik = new Paragraph(text, fontNormal);
            //Dosya tipini PDF olarak belirtiyoruz.
            //Response.ContentType = "application/pdf";

            //// PDF Dosya ismini belirtiyoruz.
            //Response.AddHeader("content-disposition", "attachment;filename=Örnek_PDF.pdf");

            ////Sayfamızın cache'lenmesini kapatıyoruz
            //Response.Cache.SetCacheability(HttpCacheability.NoCache);

            ////PdfWriter PDF dosyamız ile stream'i eşitleyen class'ımız.
            //PdfWriter.GetInstance(doc, Response.OutputStream);

            ////Dosya işlemleri öncesinde değişiklikler için Open() methodunu çağırıyoruz.
            //doc.Open();

            ////Add() methodu ile en basit anlamda bir metni PDF dosyamızın içerisine ekliyoruz.
            //doc.Add(head);
            //doc.Add(new Paragraph("\n")); // Alt satır ekliyoruz 
            //doc.Add(icerik);
            //doc.Add(new Paragraph("\n"));
            //doc.Add(table);
            //doc.Add(new Paragraph("\n"));

            ////Dosya işlemlerinin bittiğini belirtmek için Close() methodunu çağırıyoruz.
            //doc.Close();

            ////Dosyanın içeriğini Response içerisine aktarıyoruz.
            //Response.Write(doc);

            ////Son aşama da işlemleri bitirip, ekran çıktısına ulaşıyoruz.
            //Response.End();


        }

        private void button3_Click(object sender, EventArgs e)
        {
            texx = textBox1.Text;
            pdfCevir(texx);
        }
        
    }
}



//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;
//using System.IO;
//using System.Xml;
//using System.Net;
//using HtmlAgilityPack;
//using iTextSharp.text;
//using iTextSharp.text.pdf;
////using System.Web.UI;

//namespace Vikipedi_PDF_Builder
//{

//    public partial class Form1 : Form
//    {
//        string kalinbaslik = "";
//        string texx = "";
//        public Form1()
//        {
//            InitializeComponent();
//        }

//        private void button1_Click(object sender, EventArgs e)
//        {
//            try
//            {
//                Uri uri = new Uri(textBox2.Text);
//                WebClient client = new WebClient();
//                client.Encoding = Encoding.UTF8;
//                string html = client.DownloadString(uri);
//                textBox3.Text = html;
//                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
//                doc.LoadHtml(html);
//                HtmlNodeCollection hveriler = doc.DocumentNode.SelectNodes("//*[@id='mw-content-text']/div/p");//*[@id="mw-content-text"]/div/p[2]/a[1]
//                HtmlNode baslik = doc.DocumentNode.SelectSingleNode("//*[@id='firstHeading']");
//                kalinbaslik = baslik.InnerText;

//                int paragraf_sayisi = 0;
//                foreach (var veri in hveriler)
//                {
//                    textBox1.Text += veri.InnerText.Replace("&#91;kaynak belirtilmeli&#93;", "");
//                    textBox1.AppendText(Environment.NewLine); textBox1.AppendText(Environment.NewLine);
//                    paragraf_sayisi++;
//                }
//                MessageBox.Show("Yazılar Düzeltiliyor Biraz Bekleyin");
//                duzenle();


//            }
//            catch
//            { textBox2.Text = "olmadı moruk"; }
//        }

//        private void duzenle()
//        {
//            string teximiz = textBox1.Text;

//            for (int i = 0; i < 1000; i++)
//            {

//                teximiz = teximiz.Replace("&#91;" + i.ToString() + "&#93;", "");
//                textBox1.Text = teximiz;

//            }
//            textBox1.Text = textBox1.Text.Replace("&#91;kaynak belirtilmeli&#93;", "").Replace("&#160;", "");
//            teximiz = "";
//        }

//        public void pdfCevir(string text)
//        {
//            //PDF dosyamızı temsil edecek nesnemizi oluşturuyoruz
//            Document doc = new Document();

//            // Türkçe Karakterlerini tanımlıyoruz 
//            BaseFont STF_Helvetica_Turkish = BaseFont.CreateFont("Helvetica", "CP1254", BaseFont.NOT_EMBEDDED);

//            // Fontumuzu ayarlayıp , Türkçe karakter nesnesini ekliyoruz 
//            iTextSharp.text.Font fontNormal = new iTextSharp.text.Font(STF_Helvetica_Turkish, 12);
//            //başlık büyük haffe çevriliyor
//            kalinbaslik = kalinbaslik.ToUpper();
//            Paragraph baslik = new Paragraph(kalinbaslik, fontNormal);
//            Paragraph icerik = new Paragraph(text, fontNormal);
//            //Dosya tipini PDF olarak belirtiyoruz.
//            //Response.ContentType = "application/pdf";

//            //// PDF Dosya ismini belirtiyoruz.
//            //Response.AddHeader("content-disposition", "attachment;filename=Örnek_PDF.pdf");

//            ////Sayfamızın cache'lenmesini kapatıyoruz
//            //Response.Cache.SetCacheability(HttpCacheability.NoCache);

//            ////PdfWriter PDF dosyamız ile stream'i eşitleyen class'ımız.
//            //PdfWriter.GetInstance(doc, Response.OutputStream);

//            ////Dosya işlemleri öncesinde değişiklikler için Open() methodunu çağırıyoruz.
//            //doc.Open();

//            ////Add() methodu ile en basit anlamda bir metni PDF dosyamızın içerisine ekliyoruz.
//            //doc.Add(head);
//            //doc.Add(new Paragraph("\n")); // Alt satır ekliyoruz 
//            //doc.Add(icerik);
//            //doc.Add(new Paragraph("\n"));
//            //doc.Add(table);
//            //doc.Add(new Paragraph("\n"));

//            ////Dosya işlemlerinin bittiğini belirtmek için Close() methodunu çağırıyoruz.
//            //doc.Close();

//            ////Dosyanın içeriğini Response içerisine aktarıyoruz.
//            //Response.Write(doc);

//            ////Son aşama da işlemleri bitirip, ekran çıktısına ulaşıyoruz.
//            //Response.End();


//        }

//        private void button3_Click(object sender, EventArgs e)
//        {
//            texx = textBox1.Text;
//            pdfCevir(texx);
//        }

//    }
//}
