using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Plateso2;
using Plateso2.Modules;

namespace Plateso2.Modules.KMP
{
    #region KMPTester
    public class KMPTester : ITest
    {
        bool tested = false;
        string pattern;
        string clearpattern;
        List<DocumentClass> listDocuments;
        Dictionary<DocumentClass, List<int>> dicPositions;

        public KMPTester(string pattern, List<DocumentClass> listDocuments)
        {
            this.pattern = pattern;
            this.clearpattern = Constants.GetClearPattern(pattern);
            this.listDocuments = listDocuments;
            dicPositions = new Dictionary<DocumentClass, List<int>>();
        }

        public void BeginTest()
        {
            foreach (DocumentClass document in listDocuments)
            {
                KMPTest test = new KMPTest(document, this.clearpattern);
                test.PerformTest();
                dicPositions.Add(document, test.Positions);
            }
            tested = true;
        }

        public TestType TestType
        {
            get { return TestType.KMP; }
        }
        public string Pattern
        {
            get { return this.pattern; }
        }
        public List<DocumentClass> ListDocuments
        {
            get { return this.listDocuments; }
        }
        public bool Tested
        {
            get { return this.tested; }
        }
        public Dictionary<DocumentClass, List<int>> DicPositions
        {
            get { return this.dicPositions; }
        }
        public string ClearPattern
        {
            get { return this.clearpattern; }
        }
    }
    #endregion    

    #region KMPTestResult
    public class KMPTestResult : ITestResult
    {
        string pattern;
        string clearpattern;
        string testName;
        Dictionary<DocData, List<int>> dicPositions;

        public KMPTestResult(KMPTester tester)
        {
            this.pattern = tester.Pattern;
            this.clearpattern = tester.ClearPattern;
            dicPositions = new Dictionary<DocData, List<int>>();
            foreach (DocumentClass document in tester.ListDocuments)
            {                
                dicPositions.Add(new DocData(document), tester.DicPositions[document]);
            }
        }
        public KMPTestResult(string pattern, string testName, Dictionary<DocData, List<int>> dicPositions)
        {
            this.pattern = pattern;
            this.testName = testName;
            this.clearpattern = Constants.GetClearPattern(pattern);
            this.dicPositions = dicPositions;
        }

        public TestType TestType
        {
            get { return TestType.KMP; }
        }
        public string TestName
        {
            get { return this.testName; }
            set { this.testName = value; }
        }
        public string Pattern
        {
            get { return this.pattern; }
        }
        public Dictionary<DocData, List<int>> DicPositions
        {
            get { return this.dicPositions; }
        }
        public string ClearPattern
        {
            get { return this.clearpattern; }
        }
    }
    #endregion
}