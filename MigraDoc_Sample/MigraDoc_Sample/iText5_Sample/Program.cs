using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;

namespace iText5_Sample
{
    class Program
    {
        static readonly ReportRecord Rr = new ReportRecord();
        public static readonly string Dest = @"Data\PdfTest.pdf";

        
        public static void Main(string[] args)
        {
            Document document = CreateDocument();
            const string filename = @"Data\PdfTest.pdf";

            
            document.Open(filename);
            
        }

        public static Document CreateDocument()
        {
            // Create a new iTextSharp Document
            
            Document document = new Document();

            // Turn page into landscape
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(filename, FileMode.Create));
            document.Open();
            PdfPTable table = new PdfPTable(6);

            //Rotate rotateEvent = new Rotate();
            //writer.setPageEvent(rotateEvent);
            table.WidthPercentage = 100f;



            return document;

        }
    }
}
