using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataStructures;
using System.Collections.Generic;

namespace DataStructuresTests
{
    [TestClass]
    public class BinarySearchTreeTests
    {
        [TestMethod]
        public void SimpleAdd()
        {
            List<Tuple<int, string>> data = new List<Tuple<int, string>>();
            var bst = new BinarySearchTree<int, string>();
            data.Add(new Tuple<int, string>(5, "Hannah"));
            data.Add(new Tuple<int, string>(8, "Laura"));
            data.Add(new Tuple<int, string>(28, "Ashley"));
            data.Add(new Tuple<int, string>(29, "Andrew"));
            data.Add(new Tuple<int, string>(3, "Lucy"));

            foreach (var t in data) bst.Add(t.Item1, t.Item2);
            data.Sort((t1, t2) => {
                return t1.Item1 - t2.Item1;
            });

            var values = bst.InOrderTraversal();
            int index = 0;
            foreach (var v in values)
            {
                Assert.AreEqual(data[index++].Item2, v);
            }
        }
    }
}
