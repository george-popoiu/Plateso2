using System;
using System.Text;
using System.ComponentModel;
using System.Collections.Generic;
using Plateso2.Modules;

namespace Plateso2
{
    public interface IDocData
    {
        int Id { get; }
        int Length { get; }
        string Title { get; }
    }

    #region DocData Class
    public class DocData : IDocData
    {
        #region Variables
        string title = null;
        int id;
        int length;
        #endregion

        #region Constructors
        public DocData() { }
        public DocData(string title, int id, int length)
        {
            this.title = title;
            this.id = id;
            this.length = length;
        }
        public DocData(DocumentClass doc)
        {
            this.title = doc.Title;
            this.id = doc.Id;
            this.length = doc.ConcatenatedText.Length;
        }
        #endregion

        #region Properties
        public string Title
        {
            get { return this.title; }
        }
        public int Id
        {
            get { return this.id; }
        }
        public int Length
        {
            get { return this.length; }
        }
        #endregion
    }
    #endregion

    public enum TestType
    {
        KMP,
        EditDistance,
        Comparison,
    }

    public interface ITest
    {
        TestType TestType { get; }
    }

    public interface ITestResult
    {
        TestType TestType { get; }
        string TestName { get; set; }
    }

}