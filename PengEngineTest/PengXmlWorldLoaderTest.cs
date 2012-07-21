using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PengEngine.Internal;
using PengEngine;
using System.Xml;
using System.IO;
using System.Xml.Linq;

namespace PengEngineTest
{
    public class PengObjectExample : PengObject
    {
        public PengObjectExample(string name, PengWorld world, int test1, float test2, string test3)
            : base(name, world)
        {
            Test1 = test1;
            Test2 = test2;
            Test3 = test3;
        }

        public override void Load(string content)
        {
            var doc = XDocument.Load(new StringReader(content));
            var root = doc.Root;
            Test4 = root.Element("test4").Value;
        }

        public int Test1 { get; set; }
        public float Test2 { get; set; }
        public string Test3 { get; set; }
        public string Test4 { get; set; }
        public float Test5 { get; set; }
    }


    /// <summary>
    /// Summary description for PengXmlWorldLoaderTest
    /// </summary>
    [TestClass]
    public class PengXmlWorldLoaderTest
    {
        public PengXmlWorldLoaderTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        public void TestSetObjectPropertyValue()
        {
            PengXmlWorldLoader_Accessor loader = new PengXmlWorldLoader_Accessor();
            PengObjectExample obj = new PengObjectExample("obj1", null, 0, 0, "");
            var prop = new PengPropertyInfo();
            prop.Name = "Test4";
            prop.Value = "Hi, Bill";
            loader.SetObjectPropertyValue(obj, prop, null);
            Assert.AreEqual("Hi, Bill", obj.Test4);
        }

        [TestMethod]
        public void TestToObjectArg()
        {
            PengXmlWorldLoader_Accessor loader = new PengXmlWorldLoader_Accessor();
            var argInfo1 = new PengObjectArgumentInfo();
            argInfo1.Type = "System.Int32";
            argInfo1.Value = "45";
            var arg1 = loader.ToObjectArg(argInfo1, x => Type.GetType(x));
            Assert.AreEqual(typeof(int), arg1.Type);
            Assert.AreEqual(45, arg1.Value);

            var argInfo2 = new PengObjectArgumentInfo();
            argInfo2.Type = "System.Single";
            argInfo2.Value = "36.36";
            var arg2 = loader.ToObjectArg(argInfo2, x => Type.GetType(x));
            Assert.AreEqual(typeof(float), arg2.Type);
            Assert.AreEqual(36.36f, arg2.Value);


        }

        [TestMethod]
        public void TestGetObjectArgs()
        {
            PengXmlWorldLoader_Accessor loader = new PengXmlWorldLoader_Accessor();
            PengObjectInfo objInfo = new PengObjectInfo();
            objInfo.Name = "obj1";
            objInfo.TypeName = "PengEngineTest.PengObject";
            objInfo.Arguments = new PengObjectArgumentInfo[]
            {
                new PengObjectArgumentInfo("System.Int32", "56"),
                new PengObjectArgumentInfo("System.Single", "57.61"),
                new PengObjectArgumentInfo("System.String", "Hello, World!"),
            };
            var args = loader.GetObjectArgs(objInfo, null, x=>Type.GetType(x));
            Assert.AreEqual(5, args.Length);
            Assert.AreEqual(typeof(string), args[0].Type);
            Assert.AreEqual("obj1", args[0].Value);
            Assert.AreEqual(typeof(PengWorld), args[1].Type);
            Assert.AreEqual(null, args[1].Value);
            Assert.AreEqual(typeof(int), args[2].Type);
            Assert.AreEqual(56, args[2].Value);
            Assert.AreEqual(typeof(float), args[3].Type);
            Assert.AreEqual(57.61f, args[3].Value);
            Assert.AreEqual(typeof(string), args[4].Type);
            Assert.AreEqual("Hello, World!", args[4].Value);

        }

        [TestMethod]
        public void TestLoad()
        {
            PengWorld world = new PengWorld();
            string worldXml = @"<world>
    <objects>
        <object name='obj1' type='PengEngineTest.PengObjectExample'>
            <arguments>
                <argument type='System.Int32'>
                    <value>45</value>
                </argument>
                <argument type='System.Single'>
                    <value>56.34</value>
                </argument>
                <argument type='System.String'>
                    <value>Hello, World!</value>
                </argument>
            </arguments>
            <properties>
                <property name='Test5'>
                    <value>76.2</value>
                </property>
            </properties>
            <content>
<![CDATA[
<root>
    <test4>Test4</test4>
</root>
]]>
            </content>
        </object>
    </objects>
</world>";
            PengXmlWorldLoader.Instance.Load(world, XmlReader.Create(new StringReader(worldXml)), x => Type.GetType(x));
            var obj1 = (PengObjectExample)world.Objects["obj1"];
            Assert.AreEqual(45, obj1.Test1);
            Assert.AreEqual(56.34f, obj1.Test2);
            Assert.AreEqual("Hello, World!", obj1.Test3);
            Assert.AreEqual("Test4", obj1.Test4);
            Assert.AreEqual(76.2f, obj1.Test5);
        }

    }
}
