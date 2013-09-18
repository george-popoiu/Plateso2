using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Plateso2.Modules
{
    public class DocumentClass
    {
        string text;
        string title;
        string[] splited_text;
        string concatenated_text;
        DocumentClassType documentType;
        string extension;
        int id;

        public DocumentClass(string title, string text, string extension)
        {
            this.title = title;
            this.text = text;
            this.extension = extension;

            splited_text = this.text.ToLower().Split(Constants.separators, StringSplitOptions.RemoveEmptyEntries);

            foreach (string s in splited_text)
            {
                concatenated_text += s.ToLower();
            }

            documentType = Constants.DocumentType(extension);
        }

        public DocumentClass(string title, string text, string extension, string concatenated_text,int id)
        {
            this.id = id;
            this.title = title;
            this.text = text;
            this.concatenated_text = concatenated_text;
            this.extension = extension;

            splited_text = this.text.Split(Constants.separators, StringSplitOptions.RemoveEmptyEntries);

            documentType = Constants.DocumentType(extension);
        }

        //Propreties
        public int Id
        {
            get { return this.id; }
        }
        public string Text
        {
            get { return this.text; }
        }
        public string[] SplitedText
        {
            get { return this.splited_text; }
        }
        public string Title
        {
            get { return this.title; }
        }
        public string ConcatenatedText
        {
            get { return this.concatenated_text; }
        }
        public DocumentClassType GetDocumentType
        {
            get { return this.documentType; }
        }
        public string Extension
        {
            get { return this.extension; }
        }
    }
}
