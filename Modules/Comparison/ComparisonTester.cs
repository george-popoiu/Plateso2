using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Plateso2;
using Plateso2.Modules;

namespace Plateso2.Modules.Comparison
{
    public class ComparisonTester
    {
        List<DocumentClass> listDocs;
        Dictionary<DocumentClass, List<ComparisonData>> dicComparison;
        int limit;

        public ComparisonTester(List<DocumentClass> listDocs, int limit)
        {
            this.listDocs = listDocs;
            this.limit = limit;

            dicComparison = new Dictionary<DocumentClass, List<ComparisonData>>();

            foreach (DocumentClass doc in listDocs)
            {
                dicComparison.Add(doc, new List<ComparisonData>());
            }
        }

        public void BeginTest()
        {
            for (int i = 0; i < listDocs.Count; i++)
            {
                for (int j = i + 1; j < listDocs.Count; j++)
                {
                    ComparisonTest test = new ComparisonTest(listDocs[i], listDocs[j], limit);
                    test.Compare();
                    ComparisonData cData = new ComparisonData(test);
                    
                    dicComparison[listDocs[i]].Add(cData);
                    dicComparison[listDocs[j]].Add(cData);
                }
            }
        }

        public int Limit
        {
            get { return limit; }
        }
        public List<DocumentClass> ListDocuments
        {
            get { return listDocs; }
        }
        public Dictionary<DocumentClass, List<ComparisonData>> DicComparison
        {
            get { return dicComparison; }
        }
    }
}
