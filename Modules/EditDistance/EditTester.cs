using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Plateso2;
using Plateso2.Modules;
using Plateso2.Modules.EditDistance;

namespace Plateso2.Modules.EditDistance
{
    #region EditTester

    public class EditTester : ITest
    {
        Dictionary<DocumentClass, List<EditData>> dicEdit;        
        List<DocumentClass> listDocs;
        bool tested = false;

        public EditTester(List<DocumentClass> listDocs)
        {
            dicEdit = new Dictionary<DocumentClass, List<EditData>>();            
            this.listDocs = listDocs;

            foreach (DocumentClass doc in listDocs)
            {                
                dicEdit.Add(doc, new List<EditData>());                
            }
        }

        public void BeginTest()
        {
            for (int i = 0; i < listDocs.Count; i++)
            {
                for (int j = i + 1; j < listDocs.Count; j++)
                {
                    EditTest test = new EditTest(listDocs[i], listDocs[j]);
                    test.ComputeEditDistance();
                    
                    EditData editData = new EditData(listDocs[j], test.EditDistance);
                    dicEdit[listDocs[i]].Add(editData);

                    EditTest test2 = new EditTest(listDocs[j], listDocs[i]);
                    test2.ComputeEditDistance();

                    EditData editData2 = new EditData(listDocs[i], test2.EditDistance);
                    dicEdit[listDocs[j]].Add(editData2);
                }
            }
        }

        public bool Tested
        {
            get { return tested; }
        }
        public Dictionary<DocumentClass, List<EditData>> DicEdit
        {
            get { return dicEdit; }
        }               
        public TestType TestType
        {
            get { return TestType.EditDistance; }
        }
    }

    #endregion

    #region EditTestResult

    public class EditTestResult : ITestResult
    {
        string testName = null;
        Dictionary<DocData, List<EditData>> dicEdit;

        public EditTestResult(EditTester tester)
        {
            dicEdit = new Dictionary<DocData, List<EditData>>();
            
            foreach (DocumentClass doc in tester.DicEdit.Keys)
            {
                DocData docData = new DocData(doc);
                dicEdit.Add(docData, tester.DicEdit[doc]);
            }
        }

        public EditTestResult(Dictionary<DocData, List<EditData>> dicEdit, string testName)
        {
            this.dicEdit = dicEdit;
            this.testName = testName;
        }

        public Dictionary<DocData, List<EditData>> DicEdit
        {
            get { return dicEdit; }
        }
        public string TestName
        {
            get { return this.testName; }
            set { this.testName = value; }
        }
        public TestType TestType
        {
            get { return TestType.EditDistance; }
        }
    }

    #endregion
}
