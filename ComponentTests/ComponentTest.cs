using System;
using DesignPatterns1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ComponentTests
{
    [TestClass]
    public class ComponentTest
    {
        [TestMethod]
        public void TestNot()
        {
            Source srctrue = new Source(true);
            Source srcfalse = new Source(false);
            NOT inverter = new NOT();
            NOT inverter2 = new NOT();

            inverter.addInput(srctrue);
            srctrue.Execute();
            inverter2.addInput(srcfalse);
            srcfalse.Execute();

            Assert.AreEqual(inverter.state, false);
            Assert.AreEqual(inverter2.state, true);
        }

        [TestMethod]
        public void TestAnd()
        {
            Source srctrue = new Source(true);
            Source srcfalse = new Source(false);
            AND and = new AND();
            and.addInput(srcfalse);
            and.addInput(srcfalse);
            AND and2 = new AND();
            and2.addInput(srcfalse);
            and2.addInput(srctrue);
            AND and3 = new AND();
            and3.addInput(srctrue);
            and3.addInput(srcfalse);
            AND and4 = new AND();
            and4.addInput(srctrue);
            and4.addInput(srctrue);

            srctrue.Execute();
            srcfalse.Execute();

            Assert.AreEqual(and.state, false);
            Assert.AreEqual(and2.state, false);
            Assert.AreEqual(and3.state, false);
            Assert.AreEqual(and4.state, true);
        }

        [TestMethod]
        public void TestOr()
        {
            Source srctrue = new Source(true);
            Source srcfalse = new Source(false);
            OR or = new OR();
            or.addInput(srcfalse);
            or.addInput(srcfalse);
            OR or2 = new OR();
            or2.addInput(srcfalse);
            or2.addInput(srctrue);
            OR or3 = new OR();
            or3.addInput(srctrue);
            or3.addInput(srcfalse);
            OR or4 = new OR();
            or4.addInput(srctrue);
            or4.addInput(srctrue);

            srctrue.Execute();
            srcfalse.Execute();

            Assert.AreEqual(or.state, false);
            Assert.AreEqual(or2.state, true);
            Assert.AreEqual(or3.state, true);
            Assert.AreEqual(or4.state, true);
        }

        [TestMethod]
        public void TestNor()
        {
            Source srctrue = new Source(true);
            Source srcfalse = new Source(false);
            NOR nor = new NOR();
            nor.addInput(srcfalse);
            nor.addInput(srcfalse);
            NOR nor2 = new NOR();
            nor2.addInput(srcfalse);
            nor2.addInput(srctrue);
            NOR nor3 = new NOR();
            nor3.addInput(srctrue);
            nor3.addInput(srcfalse);
            NOR nor4 = new NOR();
            nor4.addInput(srctrue);
            nor4.addInput(srctrue);

            srctrue.Execute();
            srcfalse.Execute();

            Assert.AreEqual(nor.state, true);
            Assert.AreEqual(nor2.state, false);
            Assert.AreEqual(nor3.state, false);
            Assert.AreEqual(nor4.state, false);
        }

        [TestMethod]
        public void TestNand()
        {
            Source srctrue = new Source(true);
            Source srcfalse = new Source(false);
            NAND nand = new NAND();
            nand.addInput(srcfalse);
            nand.addInput(srcfalse);
            NAND nand2 = new NAND();
            nand2.addInput(srcfalse);
            nand2.addInput(srctrue);
            NAND nand3 = new NAND();
            nand3.addInput(srctrue);
            nand3.addInput(srcfalse);
            NAND nand4 = new NAND();
            nand4.addInput(srctrue);
            nand4.addInput(srctrue);

            srctrue.Execute();
            srcfalse.Execute();

            Assert.AreEqual(nand.state, true);
            Assert.AreEqual(nand2.state, true);
            Assert.AreEqual(nand3.state, true);
            Assert.AreEqual(nand4.state, false);
        }

        [TestMethod]
        public void TestXor()
        {
            Source srctrue = new Source(true);
            Source srcfalse = new Source(false);
            XOR xor = new XOR();
            xor.addInput(srcfalse);
            xor.addInput(srcfalse);
            XOR xor2 = new XOR();
            xor2.addInput(srcfalse);
            xor2.addInput(srctrue);
            XOR xor3 = new XOR();
            xor3.addInput(srctrue);
            xor3.addInput(srcfalse);
            XOR xor4 = new XOR();
            xor4.addInput(srctrue);
            xor4.addInput(srctrue);

            srctrue.Execute();
            srcfalse.Execute();

            Assert.AreEqual(xor.state, false);
            Assert.AreEqual(xor2.state, true);
            Assert.AreEqual(xor3.state, true);
            Assert.AreEqual(xor4.state, false);
        }

        [TestMethod]
        public void TestProbe()
        {
            Source srctrue = new Source(true);
            Source srcfalse = new Source(false);
            Probe probe = new Probe();
            probe.addInput(srcfalse);
            Probe probe2 = new Probe();
            probe2.addInput(srctrue);

            srctrue.Execute();
            srcfalse.Execute();

            Assert.AreEqual(probe.state, false);
            Assert.AreEqual(probe2.state, true);
        }
    }
}
