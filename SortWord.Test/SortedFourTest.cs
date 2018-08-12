using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using SortedWord;

namespace SortWord.Test
{
    [TestClass]
    public class SortedFourTest
    {
        //private string input = "Alpha Delta Golf Indigo Beta Echo Hotel Juliet Charlie Foxtrot";

        [TestMethod]
        public void Test_Add_Duplicate_Success()
        {
            var set = new SortedFour<string>();
            set.Add("aaa");
            set.Add("aaa");

            var expectedCount = 1;
            Assert.IsTrue(set.Count == expectedCount);
        }

        [TestMethod]
        public void Test_Add_Success()
        {
            // Arrange
            var words = new SortedFour<string>();
            var str = "Alpha Delta Golf Indigo Beta Echo Hotel Juliet Charlie Foxtrot";
            var lst = str.Split(' ');

            // Act
            words.AddAll(lst);
            var expectedNumberOfRow = 3;

            // Assert
            Assert.IsTrue(words.RowCount == expectedNumberOfRow);
            var expectedRow1 = new List<String>() { "Beta", "Echo", "Hotel", "Juliet" };
            for (int i = 0; i < words[1].Count; i++)
            {
                Assert.AreEqual(expectedRow1[i], words[1][i]);
            }
        }

        [TestMethod]
        public void Test_Remove_Success()
        {
            var set = new SortedFour<int>();
            Assert.IsTrue(set.Count == 0);

            var expectdNumRow = 3;
            set.AddAll(Enumerable.Range(0, 10).ToList());
            Assert.IsTrue(set.RowCount == expectdNumRow);
            Assert.IsTrue(set[2][0] == 2);

            // Remove '2' - The element at [2,0] should be 3
            set.Remove(2);
            Console.WriteLine(set.ToString());
            Assert.IsTrue(set[2][0] == 3);
        }
    }
}
