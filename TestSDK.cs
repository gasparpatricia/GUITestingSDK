using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GUITestingSDK.TestObjects;

namespace GUITestingSDK
{


    [TestClass]
    public class TestSDK
    {

        static Button button;
        static Editor editor;
        static CheckBox checkBox;
        static Table dataGrid;
        static TableItem dataGridItem1, dataGridItem2, dataGridItem3, dataGridItem4;
        static GUIObject gUIObject;
        static HyperLink hyperLink;
        static Label label;
        static List list;
        static ListItem listItem1, listItem2, listItem3, listItem4;
        static Menu menu;
        //MenuItem menuItem;
        static GUIObject radioBox;
        static RadioButton radioButton1, radioButton2, radioButton3;
        static Slider slider;
        static Tab tab;
        static Tree tree;
        static TreeItem treeItem;
        static Window window;
        static List<TestObjectBase> objects = new List<TestObjectBase>();

        [ClassInitialize]
        public static void LaunchApp(TestContext testContext)
        {
            //Launch Application
            GUITesting.LaunchApplication("..\\..\\TestApplications\\WinFormsTestApp.exe");

            //Find the window inside the UIRoot (Desktop)

            window = UIRoot.Find(name: "GUI Objects For Testing");

            //editor = window.Find(GUIElementType.Editor, automationId: "textBox1");
            //objects.Add(editor);

            //checkBox = window.Find(GUIElementType.CheckBox, automationId: "checkBox1", name: "checkBox1");

            //dataGrid = window.Find(GUIElementType.Table, automationId: "dataGridView1", name: "DataGridView");

            ////dataGridItem1 = dataGrid.Find(GUIElementType.TableItem, name: "Column1 Row 0");
            ////dataGridItem2 = dataGrid.Find(GUIElementType.TableItem, name: "Column2 Row 1");
            ////dataGridItem3 = dataGrid.Find(GUIElementType.TableItem, name: "Column3 Row 2");
            ////dataGridItem4 = dataGrid.Find(GUIElementType.TableItem, name: "Column1 Row 4");

        }

        [TestMethod]
        public void TestButton()
        {
            button = window.Find(GUIElementType.Button, name: "button1", automationId: "button1");

            TestCommonMethods(button);

            button.Invoke();
            
        }

        [TestMethod]
        public void TestTab()
        {
            tab = window.Find(GUIElementType.Tab, automationId: "tabControl1");
            TestCommonMethods(tab);
            tab.Select(0);
            tab.Select(1);
            tab.Select(0);

            tab.Select("Tree");
            tab.Select("HyperLink");
            tab.Select("Tree");

        }

        [TestMethod]
        public void TestRadioButton()
        {
            //radioBox = window.Find(GUIElementType.GUIObject, automationId: "groupBox1", name: "Selection");

            radioButton1 = window.Find(GUIElementType.RadioButton, automationId: "radioButton1", name: "Single");
            radioButton2 = window.Find(GUIElementType.RadioButton, automationId: "radioButton2", name: "Multiple");
            radioButton3 = window.Find(GUIElementType.RadioButton, automationId: "radioButton3", name: "Multiple Extended");

            TestCommonMethods(radioButton1);
            TestCommonMethods(radioButton2);
            TestCommonMethods(radioButton3);

        }

        [TestMethod]
        public void TestCheckBox()
        {
            checkBox = window.Find(GUIElementType.CheckBox, automationId: "checkBox1", name: "checkBox1");

            TestCommonMethods(checkBox);

            checkBox.Invoke();
            checkBox.Toggle();
            checkBox.Toggle();
        }

        [TestMethod]
        public void TestList()
        {
            list = window.Find(GUIElementType.List, automationId: "listBox1");

            TestCommonMethods(list);

            list.Select(0);
            list.Select(1);
            list.Select(2);
            list.Select(3);

            list.Select("item1");
            list.Select("item2");
            list.Select("item3");
            list.Select("item4");

        }

        [TestMethod]
        public void TestListItem()
        {
            list = window.Find(GUIElementType.List, automationId: "listBox1");
            listItem1 = list.Find(GUIElementType.ListItem, name: "item1");
            listItem2 = list.Find(GUIElementType.ListItem, name: "item2");
            listItem3 = list.Find(GUIElementType.ListItem, name: "item3");

            TestCommonMethods(listItem1);
            TestCommonMethods(listItem2);
            TestCommonMethods(listItem3);

            listItem1.Select();
            listItem2.Select();
            listItem3.Select();

            listItem1.Deselect();
            listItem2.Deselect();
            listItem3.Deselect();

        }


        [TestMethod]
        public void TestDataGrid()
        {
            dataGrid = window.Find(GUIElementType.Table, automationId: "dataGridView1", name: "DataGridView");

            TestCommonMethods(dataGrid);

            //No supported patterns in WinForms
            //string[] expectedRowHeaders = { "Row 0", "Row 1", "Row 2", "Row 3", "Row 4", "Row 5"};
            //string[] expectedColumnHeaders = { "Column1", "Column2", "Column3"};
            //string[] actualRowHeaders = dataGrid.GetRowHeaders();
            //string[] actualColumnHeaders = dataGrid.GetColumnHeaders();

            //Assert.IsTrue(expectedColumnHeaders.Equals(actualColumnHeaders));
            //Assert.IsTrue(expectedRowHeaders.Equals(actualRowHeaders));

            //int expectedRowCount = 5;
            //int expectedColumnCount = 3;
            //int actualRowCount = dataGrid.GetRowCount();
            //int actualColumnCount = dataGrid.GetColumnCount();

            //Assert.AreEqual(expectedRowCount, actualRowCount);
            //Assert.AreEqual(expectedColumnCount, actualColumnCount);
            
        }


        [TestMethod]
        public void TestLabel()
        {
            label = window.Find(GUIElementType.Label, automationId: "label1");
            TestCommonMethods(label);

            button = window.Find(GUIElementType.Button, name: "button1", automationId: "button1");
            button.Click();

            string expectedValue = "Button state changed.";
            string actualValue = label.GetValue();
            Assert.AreEqual(expectedValue, actualValue);
        }



        public void TestCommonMethods(TestObjectBase testObject)
        {
            testObject.Hover(100);
            testObject.Click();
            testObject.DoubleClick();
            testObject.Focus();   
        }



        [ClassCleanup]
        public static void cleanup()
        {
            Thread.Sleep(1000);
            GUITesting.CloseApplication();
        }
    }

}
