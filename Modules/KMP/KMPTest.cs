using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Plateso2;
using Plateso2.Modules;

namespace Plateso2.Modules.KMP
{
    #region KMPTest
    public class KMPTest : ITest
    {
        #region Variables
        int docId;
        string cText;
        string docTitle;
        string pattern;        
        List<int> positions;
        bool matches = false;
        #endregion

        #region Constructors
        public KMPTest(string title, string cText, int docId, string pattern)
        {
            this.docTitle = title;
            this.cText = cText;
            this.docId = docId;
            this.pattern = pattern;
            positions = new List<int>();
        }
        public KMPTest(DocumentClass document, string pattern)
        {
            this.docId = document.Id;
            this.cText = document.ConcatenatedText;
            this.docTitle = document.Title;
            this.pattern = pattern;
            positions = new List<int>();
        }
        #endregion

        #region Properties
        public string DocTitle
        {
            get { return this.docTitle; }
            set { this.docTitle = value; }
        }

        public int DocId
        {
            get { return this.docId; }
        }

        public int PatternLength
        {
            get { return this.pattern.Length; }
        }

        public string Pattern
        {
            get { return this.pattern; }
            set { this.pattern = value; }
        }

        public List<int> Positions
        {
            get { return this.positions; }
        }

        public TestType TestType
        {
            get { return TestType.KMP; }
        }

        public string CText
        {
            get { return this.cText; }
            set { this.cText = value; }
        }

        public bool Matches
        {
            get { return this.matches; }
        }
        #endregion

        #region Methods
        private int[] ComputePrefix(string pattern)
        {
            int[] urm = new int[pattern.Length];
            int k = -1;            
            urm[0] = -1;
            for (int i = 1; i < pattern.Length; i++)
            {
                while (k > 0 && pattern[k + 1] != pattern[i]) k = urm[k];
                if (pattern[k + 1] == pattern[i]) k++;
                urm[i] = k;
            }
            return urm;
        }

        public void PerformTest()
        {
            this.positions.Clear();

            int[] urm = ComputePrefix(this.pattern);
            int k = -1;
            int len = pattern.Length;
            string p = pattern + " ";            
            
            for (int i = 0; i < this.cText.Length; i++)
            {
                while (k >= 0 && p[k+1] != this.cText[i]) k = urm[k];
                if (p[k + 1] == this.cText[i])  k++;
                if (k == len-1)
                {
                    this.positions.Add(i - k);
                    matches = true;
                }
            }
        }
        #endregion
    }
    #endregion
}
