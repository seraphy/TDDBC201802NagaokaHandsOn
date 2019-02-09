using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SampleLibrary.Test
{
    [TestClass]
    public class SampleTest
    {
        [TestClass]
        public class 商品名が軽減税率対象ならばTrue
        {
            private Sample sample;

            [TestInitialize]
            public void Init()
            {
                sample = new Sample();
            }
            [TestMethod]
            public void 商品からあげ棒はtrueを返す()
            {
                Assert.AreEqual(true, sample.TaxCheck("からあげ棒"));
            }

            [TestMethod]
            public void 商品オロナミンCはtrueを返す()
            {
                Assert.AreEqual(true, sample.TaxCheck("オロナミンC"));
            }

            [TestMethod]
            public void 商品リポビタンDはfalseを返す()
            {
                Assert.AreEqual(false, sample.TaxCheck("リポビタンD"));
            }
        }


        [TestClass]
        public class 分類が軽減税率対象ならばTrue
        {
            private Sample sample;

            [TestInitialize]
            public void Init()
            {
                sample = new Sample();
            }

            [TestMethod]
            public void 分類が食料品ならばTrueを返す()
            {
                Assert.AreEqual(true, sample.TaxCategory("食料品"));
            }

            [TestMethod]
            public void 分類が酒類ならばFalse()
            {
                Assert.AreEqual(false, sample.TaxCategory("酒類"));
            }

            [TestMethod]
            public void 分類が飲料品ならばTrue()
            {
                Assert.AreEqual(true, sample.TaxCategory("飲料品"));
            }
        }


        [TestClass]
        public class 商品名から分類を調べる
        {
            private Sample sample;

            [TestInitialize]
            public void Init()
            {
                sample = new Sample();
            }
            [TestMethod]
            public void からあげ棒は食料品()
            {
                Assert.AreEqual("食料品", sample.GetCategory("からあげ棒"));
            }

            [TestMethod]
            public void オロナミンCは飲料品()
            {
                Assert.AreEqual("飲料品", sample.GetCategory("オロナミンC"));
            }

            [TestMethod]
            public void リポビタンDは医薬部外品()
            {
                Assert.AreEqual("医薬部外品", sample.GetCategory("リポビタンD"));
            }
        }

        [TestClass]
        public class 商品名と値段を渡すと税込金額を返す
        {
            private Sample sample;

            [TestInitialize]
            public void Init()
            {
                sample = new Sample();
            }
            [TestMethod]
            public void オロナミンCと105円を与えると113円を返す()
            {
                Assert.AreEqual(113, sample.TaxInclusivePrice("オロナミンC", 105));
            }
            [TestMethod]
            public void リポビタンDと146を与えると161を返す()
            {
                Assert.AreEqual(161, sample.TaxInclusivePrice("リポビタンD", 146));
            }
            [TestMethod]
            public void キリン酎ハイ氷結グレープフルーツと141を与えると155を返す()
            {
                Assert.AreEqual(155, sample.TaxInclusivePrice("キリン酎ハイ氷結グレープフルーツ", 141));
            }
            [TestMethod]
            public void オロナミンCと105とリポビタンDと146を与えると274を返す()
            {
                var items = new List<ProductPrice> {
                    new ProductPrice("オロナミンC", 105),
                    new ProductPrice("リポビタンD", 146)
                };
                Assert.AreEqual(274, sample.TaxInclusivePrice(items));
            }
        }
    }
}
