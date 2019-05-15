using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using iTextSharp;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace EksiXMLtoPDF
{
    class Program
    {

        static void Main(string[] args)
        {
            XDocument xdoc = XDocument.Load(args[0]);
            Document myDocument = new Document(PageSize.A4, 25, 25, 30, 30);

            try
            {
                using (Stream outStream = new FileStream(args[0].Split('.')[0] + ".pdf", FileMode.OpenOrCreate))
                {
                    PdfWriter myPDFWriter = PdfWriter.GetInstance(myDocument, outStream);
                    myDocument.Open();

                    foreach (XElement element in xdoc.Descendants("entry").OrderByDescending(e => e.Attribute("date").Value))
                    {
                        Paragraph title = new Paragraph(element.Attribute("title").Value,
                                                                FormatSettings.fontHeading);
                        title.Alignment = 0;
                        title.FirstLineIndent = 1;
                        title.SpacingAfter = 2;
                        Paragraph entry = new Paragraph(element.Value,
                                                                FormatSettings.fontNormal);
                        entry.Alignment = 0;
                        entry.FirstLineIndent = 1;
                        Paragraph info = new Paragraph("id: " + element.Attribute("id").Value +
                                                                " tarih: " + element.Attribute("date").Value,
                                                                FormatSettings.fontInfo);
                        info.Alignment = 2;
                        info.SpacingAfter = 2;

                        myDocument.Add(title);
                        myDocument.Add(entry);
                        myDocument.Add(info);
                    }


                    myDocument.Close();
                    myPDFWriter.Close();

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }






        }

    }
}


