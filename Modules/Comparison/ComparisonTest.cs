using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Plateso2;
using Plateso2.Modules;

namespace Plateso2.Modules.Comparison
{
    public struct PositionData
    {
        public int _start1, _start2, _length;
        public PositionData(int start1, int start2, int length)
        {
            _start1 = start1;
            _start2 = start2;
            _length = length;
        }
    }

    public class ComparisonTest : ITest
    {
        DocumentClass doc1, doc2;
        int limit;
        int n, m;
        int[,] c;
        List<PositionData> listPositions;

        public ComparisonTest(DocumentClass doc1, DocumentClass doc2, int limit)
        {
            this.doc1 = doc1;
            this.doc2 = doc2;
            this.limit = limit;

            n = doc1.SplitedText.Length;
            m = doc2.SplitedText.Length;
            c = new int[n, m];

            listPositions = new List<PositionData>();
        }

        public void Compare()
        {
            //Comparing
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (doc1.SplitedText[i] == doc2.SplitedText[j])
                    {
                        if (i == 0 || j == 0) c[i, j] = 1;
                        else c[i, j] = 1 + c[i - 1, j - 1];
                    }
                    else c[i, j] = 0;
                }
            }

            //Getting data
            bool go = true;
            while (go)
            {
                go = false;
                
                int cmax = 0;
                int lin = 0, col = 0;

                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        if (c[i, j] > limit && c[i, j] > cmax)
                        {
                            cmax = c[i, j];
                            lin = i; col = j;
                            go = true;
                        }
                    }
                }

                if (go)
                {
                    Clear(lin - cmax + 1, col - cmax + 1, cmax);
                    PositionData data = new PositionData(lin - cmax + 1, col - cmax + 1, cmax);
                    listPositions.Add(data);
                }
            }
        }

        void Clear(int start1, int start2, int length)
        {
            int i = start1, j = start2, l = 0;
            while (l < length)
            {
                c[i, j] = 0;
                i++; j++;
                l++;
            }
        }

        public List<PositionData> ListPositions
        {
            get { return listPositions; }
        }
        public DocumentClass Doc1
        {
            get { return doc1; }
        }
        public DocumentClass Doc2
        {
            get { return doc2; }
        }
        public int Limit
        {
            get { return limit; }
        }
        public TestType TestType
        {
            get { return TestType.Comparison; }
        }
    }

    public class ComparisonData
    {
        DocData doc1, doc2;
        int matches;
        List<PositionData> listPositions;

        public ComparisonData(ComparisonTest test)
        {
            doc1 = new DocData(test.Doc1);
            doc2 = new DocData(test.Doc2);

            listPositions = test.ListPositions;

            matches = listPositions.Count;
        }
       
        public ComparisonData(DocData doc1, DocData doc2, List<PositionData> listPositions)
        {
            this.doc1 = doc1;
            this.doc2 = doc2;

            this.listPositions = listPositions;

            matches = listPositions.Count;
        }

        public DocData Doc1
        {
            get { return doc1; }
        }
        public DocData Doc2
        {
            get { return doc2; }
        }
        public int Matches
        {
            get { return matches; }
        }
        public List<PositionData> ListPositions
        {
            get { return listPositions; }
        }
    }
}
