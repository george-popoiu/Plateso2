using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Plateso2;
using Plateso2.Modules;

namespace Plateso2.Modules.EditDistance
{
    public class EditTest : ITest
    {
        DocumentClass doc1, doc2;
        string a, b;
        int n, m;
        int editDistance;
        int[,] c;
        bool tested = false;

        public EditTest(DocumentClass doc1, DocumentClass doc2)
        {
            this.doc1 = doc1;
            this.doc2 = doc2;
            this.a = this.doc1.ConcatenatedText;
            this.b = this.doc2.ConcatenatedText;

            n = this.doc1.ConcatenatedText.Length;
            m = this.doc2.ConcatenatedText.Length;

            c = new int[n + 1, m + 1];            
        }

        public void ComputeEditDistance()
        {
            Init(this.n, this.m);

            for (int i = 1; i <= this.n; i++)
            {
                for (int j = 1; j <= this.m; j++)
                {
                    c[i, j] = EditCosts.KillCost(i) + c[0, j];

                    if (a[i - 1] == b[j - 1] && EditCosts.Copy + c[i - 1, j - 1] < c[i, j]) c[i, j] = EditCosts.Copy + c[i - 1, j - 1];
                    if (EditCosts.Delete + c[i - 1, j] < c[i, j]) c[i, j] = EditCosts.Delete + c[i - 1, j];
                    if (EditCosts.Replace + c[i - 1, j - 1] < c[i, j]) c[i, j] = EditCosts.Replace + c[i - 1, j - 1];
                    if (i >= 2 && j >= 2 && a[i - 1] == b[j - 2] && a[i - 2] == b[j - 1] && EditCosts.Twiddle + c[i - 2, j - 2] < c[i, j]) c[i, j] = EditCosts.Twiddle + c[i - 2, j - 2];
                }
            }

            editDistance = c[this.n, this.m];
            tested = true;
        }        

        void Init(int n, int m)
        {
            this.c[0, 0] = 0;
            for (int i = 1; i <= n; i++) this.c[i, 0] = EditCosts.KillCost(i);
            for (int j = 1; j <= m; j++) this.c[0, j] = EditCosts.KillCost(j);
        }

        public TestType TestType
        {
            get { return TestType.EditDistance; }
        }

        public int EditDistance
        {
            get
            {
                if (!tested) return -1;
                return this.editDistance;
            }
        }
    }

    public static class EditCosts
    {
        static int copy = 0, delete = 1, insert = 1, replace = 2, twiddle = 4;

        public static int KillCost(int i) { return i; }

        public static int Copy
        {
            get { return copy; }
        }
        public static int Delete
        {
            get { return delete; }
        }
        public static int Insert
        {
            get { return insert; }
        }
        public static int Replace
        {
            get { return replace; }
        }
        public static int Twiddle
        {
            get { return twiddle; }
        }
    }

    public class EditData : IDocData
    {
        DocData docData;
        int editDistance;        

        public EditData(DocumentClass doc, int editDistance)
        {
            this.editDistance = editDistance;
            this.docData = new DocData(doc);            
        }
        public EditData(DocData docData, int editDistance)
        {
            this.editDistance = editDistance;
            this.docData = docData;            
        }
        public EditData(string title, int id, int length, int editDistance)
        {
            this.editDistance = editDistance;
            this.docData = new DocData(title, id, length);            
        }

        public int Id
        {
            get { return docData.Id; }
        }
        public string Title
        {
            get { return docData.Title; }
        }
        public int Length
        {
            get { return docData.Length; }
        }
        public DocData DocData
        {
            get { return this.docData; }
            set { this.docData = value; }
        }
        public int EditDistance
        {
            get { return this.editDistance; }
        }
    }

}
