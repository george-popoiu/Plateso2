using System;
using System.Text;
using System.IO;
using org.pdfbox.pdmodel;
using org.pdfbox.util;
using DocReader.OfficeFileReader;
using DocxReader;
using Plateso2.Modules;

namespace Plateso2
{
    public static class DocumentReader
    {
        public static string TxtReader(string path)
        {
            string text;
            StreamReader sr = new StreamReader(path);
            text = sr.ReadToEnd();
            sr.Close(); sr.Dispose();

            return text;
        }
        public static string DocReader(string path)
        {
            OfficeFileReader reader = new OfficeFileReader();
            string text = "";
            reader.GetText(path, ref text);
            reader = null;

            return text;
        }
        public static string DocxReader(string path)
        {
            DocxToText dtt = new DocxToText(path);
            string text = dtt.ExtractText();
            dtt = null;

            return text;
        }
        public static string PdfReader(string path)
        {
            PDDocument pdfDoc = PDDocument.load(path);
            PDFTextStripper pdfStripper = new PDFTextStripper();
            string text = pdfStripper.getText(pdfDoc);

            return text;
        }
        public static string GeneralReader(string path,string safeFileName)
        {
            string ext = Plateso2.Modules.Constants.GetExt(safeFileName);
            if (ext == "txt")
            {
                return TxtReader(path);                
            }
            if (ext == "pdf")
            {
                return PdfReader(path);                
            }
            if (ext == "doc")
            {
                return DocReader(path);                
            }            
            return DocxReader(path);            
        }
    }
}