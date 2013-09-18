using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Plateso2.Modules
{
    public static class Constants
    {
        public static string DbHost = "db4free.net";
        public static string DbUsername = "plateso";
        public static string DbPassword = "plateso";
        public static string DbName = "plateso";
        public static int TvImageHeight = 25;
        public static int TvImageWidth = 25;
        public static string ConnectionString = "SERVER=" + Constants.DbHost + "; DATABASE=" + Constants.DbName + "; UID=" + Constants.DbUsername + "; PASSWORD=" + Constants.DbPassword + ";";
        public static string GDocsExtension = "gdocs";
        public static string GDocsTempFileName = "temp.gdocs.txt";
        public static string GDocsAppName = "home-plateso-2";
        public static string ResultsXmlPath = AppDomain.CurrentDomain.BaseDirectory + "\\Results.xml";

        public static bool IsAllowed(char c)
        {
            int nr = (int)(c);
            if ((nr >= 97 && nr <= 122) || (nr >= 65 && nr <= 90) || (nr >= 48 && nr <= 57) ) return true;
            return false;
        }

        public static string[] separators = new string[] { " ", "\n", "\t", "\r", ",", ".", "!", "?", ":", "'", "\"", ";","\r" };

        public static DocumentClassType DocumentType(string extension)
        {
            extension = extension.ToLower();
            if (extension == "txt") return DocumentClassType.Txt;
            if (extension == "pdf") return DocumentClassType.Pdf;
            if (extension == "doc") return DocumentClassType.Doc;
            if (extension == "docx") return DocumentClassType.Docx;
            if (extension == GDocsExtension) return DocumentClassType.GDocs;
            return DocumentClassType.Odt;
        }

        public static string ImageUri(DocumentClassType documentType)
        {
            if (documentType == DocumentClassType.Doc || documentType == DocumentClassType.Docx) return TvImageUris.DocDocxImageUri;
            if (documentType == DocumentClassType.Txt) return TvImageUris.TxtImageUri;
            if (documentType == DocumentClassType.Odt) return TvImageUris.OdtImageUri;
            if (documentType == DocumentClassType.GDocs) return TvImageUris.GDocsImageUri;
            return TvImageUris.PdfImageUri;
        }

        public static string GetExt(string safeFileName)
        {
            string[] str = safeFileName.Split('.');

            string ext = str[str.Length - 1].ToLower();

            return ext;
        }

        public static string GetSafeName(string path)
        {
            string[] names = path.Split('\\');

            return names[names.Length - 1].ToLower();
        }

        public static string GetNameWithoutExt(string safeName)
        {
            string[] result = safeName.Split('.');

            return result[result.Length - 2];
        }

        public static string GetClearPattern(string pattern)
        {
            string cpattern = null;
            string[] split = pattern.Split(Constants.separators, StringSplitOptions.RemoveEmptyEntries);

            foreach (string s in split)
            {
                cpattern += s.ToLower();
            }            
            return cpattern;
        }

        public static string GetTVResultImageUri(TestType testType)
        {
            if (testType == TestType.KMP) return TvResultsImageUris.PatternSearchImageUri;
            if (testType == TestType.Comparison) return TvResultsImageUris.ComparisonImageUri;
            return TvResultsImageUris.EditDistanceImageUri;
        }
        
    }

    public static class TvImageUris
    {
        public static string DocDocxImageUri = "pack://application:,,,/Images/doc_docx_doc.png";
        public static string PdfImageUri = "pack://application:,,,/Images/pdf_doc.png";
        public static string TxtImageUri = "pack://application:,,,/Images/txt_doc.png";
        public static string OdtImageUri = "pack://application:,,,/Images/odt_doc.png";
        public static string GDocsImageUri = "pack://application:,,,/Images/google_docs.png";
    }

    public static class TvResultsImageUris
    {
        public static string PatternSearchImageUri = "pack://application:,,,/Images/pattern_search.png";
        public static string EditDistanceImageUri = "pack://application:,,,/Images/edit_distance.png";
        public static string ComparisonImageUri = "pack://application:,,,/Images/comparison.png";
    }
    
}
