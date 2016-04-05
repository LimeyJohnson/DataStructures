using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataStructures;
using System.Collections.Generic;

namespace DataStructuresTests
{
    [TestClass]
    public class AVLTreeTests
    {
        [TestMethod]
        public void AVLSimpleAdd()
        {
            List<Tuple<int, string>> data = new List<Tuple<int, string>>();
            var bst = new AVLTree<int, string>();
            data.Add(new Tuple<int, string>(5, "Hannah"));
            data.Add(new Tuple<int, string>(8, "Laura"));
            data.Add(new Tuple<int, string>(28, "Ashley"));
            data.Add(new Tuple<int, string>(29, "Andrew"));
            data.Add(new Tuple<int, string>(3, "Lucy"));

            foreach (var t in data) bst.Add(t.Item1, t.Item2);
            data.Sort((t1, t2) =>
            {
                return t1.Item1 - t2.Item1;
            });

            var values = bst.InOrderTraversal();
            int index = 0;
            foreach (var v in values)
            {
                Assert.AreEqual(data[index++].Item2, v);
            }
        }

        [TestMethod]
        public void AVLMinMax()
        {
            List<Tuple<int, string>> data = new List<Tuple<int, string>>();
            var bst = new AVLTree<int, string>();
            data.Add(new Tuple<int, string>(5, "Hannah"));
            data.Add(new Tuple<int, string>(8, "Laura"));
            data.Add(new Tuple<int, string>(28, "Ashley"));
            data.Add(new Tuple<int, string>(29, "Andrew"));
            data.Add(new Tuple<int, string>(3, "Lucy"));

            foreach (var t in data) bst.Add(t.Item1, t.Item2);
            Assert.AreEqual(bst.Max, "Andrew");
            Assert.AreEqual(bst.Min, "Lucy");
        }

        [TestMethod]
        public void AVLTestDelete()
        {
            List<Tuple<int, string>> data = new List<Tuple<int, string>>();
            var bst = new AVLTree<int, string>();
            data.Add(new Tuple<int, string>(5, "Hannah"));
            data.Add(new Tuple<int, string>(8, "Laura"));
            data.Add(new Tuple<int, string>(28, "Ashley"));
            data.Add(new Tuple<int, string>(29, "Andrew"));
            data.Add(new Tuple<int, string>(3, "Lucy"));

            foreach (var t in data) bst.Add(t.Item1, t.Item2);
            bst.Delete(28);
            data.Sort((t1, t2) =>
            {
                return t1.Item1 - t2.Item1;
            });
            var index = 0;
            foreach (var v in bst.InOrderTraversal())
            {
                if (data[index].Item2 == "Ashley") index++;
                Assert.AreEqual(data[index++].Item2, v);
            }
        }
        [TestMethod]
        public void AVLIndex()
        {
            List<Tuple<int, string>> data = new List<Tuple<int, string>>();
            var bst = new AVLTree<int, string>();
            data.Add(new Tuple<int, string>(5, "Hannah"));
            data.Add(new Tuple<int, string>(8, "Laura"));
            data.Add(new Tuple<int, string>(28, "Ashley"));
            data.Add(new Tuple<int, string>(29, "Andrew"));
            data.Add(new Tuple<int, string>(3, "Lucy"));

            foreach (var t in data) bst.Add(t.Item1, t.Item2);
            Assert.AreEqual(bst[29], "Andrew");
        }
        [TestMethod]
        public void AVLStringIndex()
        {
            List<Tuple<int, string>> data = new List<Tuple<int, string>>();
            var bst = new AVLTree<string, int>();
            data.Add(new Tuple<int, string>(5, "Hannah"));
            data.Add(new Tuple<int, string>(8, "Laura"));
            data.Add(new Tuple<int, string>(28, "Ashley"));
            data.Add(new Tuple<int, string>(29, "Andrew"));
            data.Add(new Tuple<int, string>(3, "Lucy"));

            foreach (var t in data) bst.Add(t.Item2, t.Item1);
            Assert.AreEqual(29, bst["Andrew"]);
        }
        [TestMethod]
        public void AVLRandomInts()
        {
            List<Tuple<int, string>> data = new List<Tuple<int, string>>();
            var bst = new AVLTree<int, string>();
            int max = 100000;
            int mid = max / 2;
            data.Add(new Tuple<int, string>(mid, mid.ToString()));
            bst.Add(mid, mid.ToString());
            for (var x = 0; x < 1000; x++)
            {
                var rand = new Random();
                var num = rand.Next(0, max);
                data.Add(new Tuple<int, string>(num, num.ToString()));
                bst.Add(num, num.ToString());
            }
            data.Sort((t1, t2) =>
            {
                return t1.Item1 - t2.Item1;
            });
            var index = 0;
            foreach (var v in bst.InOrderTraversal())
            {
                Assert.AreEqual(data[index++].Item2, v);
            }
        }
    }
}
