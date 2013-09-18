using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Plateso2;
using Plateso2.Modules;

namespace Plateso2.Modules.Comparison
{
    public class ComparisonTestResult : ITestResult
    {
        string test_name = null;
        Dictionary<DocData, List<ComparisonData>> dicComparison;
        List<DocData> listDocs;
        int limit;

        public ComparisonTestResult(ComparisonTester tester)
        {
            limit = tester.Limit;

            listDocs = new List<DocData>();
            dicComparison = new Dictionary<DocData, List<ComparisonData>>();

            foreach (DocumentClass document in tester.ListDocuments)
            {
                DocData docData = new DocData(document);
                listDocs.Add(docData);
                dicComparison.Add(docData, tester.DicComparison[document]);
            }
        }

        public ComparisonTestResult(string test_name, int limit, Dictionary<DocData, List<ComparisonData>> dicComparison)
        {
            this.test_name = test_name;
            this.limit = limit;
            this.dicComparison = dicComparison;

            listDocs = new List<DocData>();

            foreach (DocData docData in dicComparison.Keys)
            {
                listDocs.Add(docData);
            }
        }

        public int Limit
        {
            get { return limit; }
        }
        public List<DocData> ListDocs
        {
            get { return listDocs; }
        }
        public Dictionary<DocData, List<ComparisonData>> DicComparison
        {
            get { return dicComparison; }
        }
        public TestType TestType
        {
            get { return TestType.Comparison; }
        }
        public string TestName
        {
            get { return test_name; }
            set { test_name = value; }
        }
    }
}
