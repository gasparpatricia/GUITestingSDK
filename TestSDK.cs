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

            //Finding the test objects and adding them to a list to execute the common methods in bulk

            window = UIRoot.Find(name: "GUI Objects For Testing");
            objects.Add(window);

            //button = window.Find(GUIElementType.Button, name: "button1", automationId: "button1");
            //objects.Add(button);

            //editor = window.Find(GUIElementType.Editor, automationId: "textBox1");
            //objects.Add(editor);

            //checkBox = window.Find(GUIElementType.CheckBox, automationId: "checkBox1", name: "checkBox1");
            //objects.Add(checkBox);

            //dataGrid = window.Find(GUIElementType.Table, automationId: "dataGridView1", name: "DataGridView");
            //objects.Add(dataGrid);

            ////dataGridItem1 = dataGrid.Find(GUIElementType.TableItem, name: "Column1 Row 0");
            ////dataGridItem2 = dataGrid.Find(GUIElementType.TableItem, name: "Column2 Row 1");
            ////dataGridItem3 = dataGrid.Find(GUIElementType.TableItem, name: "Column3 Row 2");
            ////dataGridItem4 = dataGrid.Find(GUIElementType.TableItem, name: "Column1 Row 4");
            ////objects.Add(dataGridItem1);
            ////objects.Add(dataGridItem2);
            ////objects.Add(dataGridItem3);
            ////objects.Add(dataGridItem4); does not find them

            //label = window.Find(GUIElementType.Label, automationId: "label1");
            //objects.Add(label);

            //list = window.Find(GUIElementType.List, automationId: "listBox1");
            //objects.Add(list);

            //radioBox = window.Find(GUIElementType.GUIObject, automationId: "groupBox1", name: "Selection");

            //radioButton1 = radioBox.Find(GUIElementType.RadioButton, automationId: "radioButton1", name: "Single");
            //radioButton2 = radioBox.Find(GUIElementType.RadioButton, automationId: "radioButton2", name: "Multiple");
            //radioButton3 = radioBox.Find(GUIElementType.RadioButton, automationId: "radioButton3", name: "Multiple Extended");

            //objects.Add(radioBox);
            //objects.Add(radioButton1);
            //objects.Add(radioButton2);
            //objects.Add(radioButton3);
        }

        [TestMethod]
        public void TestButton()
        {
            button = window.Find(GUIElementType.Button, name: "button1", automationId: "button1");
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

        public void TestCommonMethods(TestObjectBase testObject)
        {
            testObject.Hover(100);
            testObject.Click();
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
