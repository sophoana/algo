using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SortedWord;
using SortWord.Wpf;
using System.Linq;

namespace SortWord.Test
{
    /// <summary>
    /// Summary description for MainWindowViewModelTest
    /// </summary>
    [TestClass]
    public class MainWindowViewModelTest
    {
        [TestMethod]
        public void Test_AddCommand_Success()
        {
            var set = new SortedFourMock();
            var viewModel = new MainWindowViewModel(set);

            for (int i = 0; i < 5; i++)
            {
                viewModel.AddedText = "aaa";
                viewModel.AddCommand.Execute(null);
            }

            Assert.IsTrue(viewModel.RowItems.Count == 4);
        }

        [TestMethod]
        public void Test_RemoveCommand_Success()
        {
            var set = new SortedFourMock();
            var viewModel = new MainWindowViewModel(set);
            viewModel.AddedText = "aaa";
            viewModel.AddCommand.Execute(null);
            viewModel.RemoveCommand.Execute("aaa");

            Assert.IsTrue(viewModel.RowItems.Count == 0);
        }


    }

    public class SortedFourMock : ISortedFour<string>
    {
        private int _count;
        private int _rowCount;
        private IList<string> _mockIndexer = new List<string>();
        public IList<string> this[int idx] => _mockIndexer;

        public int RowCount => _rowCount;

        public int Count => _count;

        public void Add(string val)
        {
            _count++;
            _rowCount = _count % 4 == 0 ? _count / 4 : (_count / 4) + 1;

            if (_mockIndexer.Count < _rowCount)
                _mockIndexer.Add("aaa");
        }

        public bool Remove(string val)
        {
            var success = _count != 0;
            _count = _count == 0 ? _count : _count--;

            _mockIndexer.Remove("aaa");
            return success;
        }
    }
}
