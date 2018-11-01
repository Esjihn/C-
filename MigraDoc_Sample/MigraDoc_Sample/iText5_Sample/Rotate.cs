using iTextSharp.text;
using iTextSharp.text.pdf;

namespace iText5_Sample
{
    public class Rotate : PdfPageEventHelper
    {
        protected PdfNumber orientation = PdfPage.PORTRAIT;

        public void setOrientation(PdfNumber orientation)
        {
            this.orientation = orientation;
        }

        
        public override void OnStartPage(PdfWriter writer, Document document)
        {
            writer.AddPageDictEntry(PdfName.ROTATE, orientation);
        }
    }
}