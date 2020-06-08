using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
        GUIObject gUIObject;
        HyperLink hyperLink;
        Label label;
        List list;
        ListItem listItem1, listItem2, listItem3, listItem4;
        Menu menu;
        //MenuItem menuItem;
        RadioButton radioButton1, radioButton2;
        Slider slider;
        Tab tab;
        Tree tree;
        TreeItem treeItem;
        static Window window;
        static List<TestObjectBase> objects = new List<TestObjectBase>();

        [ClassInitialize]
        public static void LaunchApp(TestContext testContext)
        {
            //Launch Application
            GUITesting.LaunchApplication("C:\\Users\\ptrcg\\source\\repos\\WinFormsTestApp\\bin\\Release\\WinFormsTestApp.exe");

            //Finding the test objects and adding them to a list to execute the common methods in bulk

            window = UIRoot.Find(name: "GUI Objects For Testing");
            objects.Add(window);

            button = window.Find(GUIElementType.Button, name: "button1", automationId: "button1");
            objects.Add(button);

            editor = window.Find(GUIElementType.Editor, automationId: "textBox1");
            objects.Add(editor);

            checkBox = window.Find(GUIElementType.CheckBox, automationId: "checkBox1", name: "checkBox1");
            objects.Add(checkBox);

            dataGrid = window.Find(GUIElementType.Table, automationId: "dataGridView1", name: "DataGridView");
            objects.Add(dataGrid);

            //dataGridItem1 = dataGrid.Find(GUIElementType.TableItem, name: "Column1 Row 0");
            //dataGridItem2 = dataGrid.Find(GUIElementType.TableItem, name: "Column2 Row 1");
            //dataGridItem3 = dataGrid.Find(GUIElementType.TableItem, name: "Column3 Row 2");
            //dataGridItem4 = dataGrid.Find(GUIElementType.TableItem, name: "Column1 Row 4");
            //objects.Add(dataGridItem1);
            //objects.Add(dataGridItem2);
            //objects.Add(dataGridItem3);
            //objects.Add(dataGridItem4);

            //label = window.Find(GUIElementType.Label, automationId: "label1");
            //objects.Add(label);

            //list = window.Find(GUIElementType.List, automationId: "listBox1");
            //objects.Add(list);
        }


        [TestMethod]
        public void TestFocus()
        {

            foreach (TestObjectBase item in objects)
            {
                item.Focus();
            }
        }

        [TestMethod]
        public void TestClick()
        {

            foreach (TestObjectBase item in objects)
            {
                item.Click();
            }
        }

        [TestMethod]
        public void TestHover()
        {

            foreach (TestObjectBase item in objects)
            {
                item.Hover();
            }
        }

        [ClassCleanup]
        public static void cleanup()
        {
            GUITesting.CloseApplication();
        }
    }

}
