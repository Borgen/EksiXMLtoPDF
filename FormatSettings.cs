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
    class FormatSettings
    {
        public static BaseFont FontBase = iTextSharp.text.pdf.BaseFont.CreateFont("Helvetica", "Cp1254", iTextSharp.text.pdf.BaseFont.NOT_EMBEDDED);
        public static Font fontNormal = new Font(FontBase, 12, Font.NORMAL, BaseColor.DARK_GRAY);
        public static Font fontHeading = new Font(FontBase, 18, Font.UNDERLINE | Font.BOLD, BaseColor.BLACK);
        public static Font fontInfo = new Font(FontBase, 8, Font.ITALIC, BaseColor.GRAY);

    }
}
