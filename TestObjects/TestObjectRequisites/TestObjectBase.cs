using GUITestingSDK.Exceptions;
using Microsoft.Test.Input;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Automation;
using System.Windows.Forms;

namespace GUITestingSDK.TestObjects
{
    /// <summary>
    /// This class represents the base for all test objects.
    /// </summary>
    public class TestObjectBase
    {
        /// <summary>
        /// The AutomationElement that corresponds to a test object.
        /// </summary>
        public AutomationElement AutoElement { get; set; }
        
        /// <summary>
        /// The object process id that usually matches the id for the parent window.
        /// </summary>
        public int ProcessId { get; set; }

        /// <summary>
        /// The object name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The object UI Automation automation id
        /// </summary>
        public string AutomationId { get; set; }

        /// <summary>
        /// The object isEnabled property
        /// </summary>
        public bool IsEnabled { get; set; }

        /// <summary>
        /// The object frameworkId (WinForms, WPF etc.)
        /// </summary>
        public string FrameworkId { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public TestObjectBase()
        {

        }


        /// <summary>
        /// Constructor with AutomationElement parameter used on test object creation.
        /// Initializes the properties from the given AutomationElement.
        /// </summary>
        /// <param name="automationElement">UIA AutomationElement that corresponds to this instance of the class.</param>
        public TestObjectBase(AutomationElement automationElement)
        {
            AutoElement = automationElement;
            InitializeProperties();
        }

        /// <summary>
        /// This method initializes the class properties from the class AutomationElement. 
        /// </summary>
        private void InitializeProperties()
        {
            Name = AutoElement.Current.Name;
            AutomationId = AutoElement.Current.AutomationId;
            IsEnabled = AutoElement.Current.IsEnabled;
            ProcessId = AutoElement.Current.ProcessId;
            FrameworkId = AutoElement.Current.FrameworkId;
        }

        /// <summary>
        /// This method is used for finding children test objects inside the current element.
        /// </summary>
        /// <param name="controlType">The GUI control type property of the test object to find.</param>
        /// <param name="name">The name property of the test object to find.</param>
        /// <param name="automationId">The automationId property of the test object to find.</param>
        /// <param name="isEnabled">The isEnabled property of the test object to find. Default is -1. True is 1. False is 0.</param>
        /// <param name="waitSeconds">The time in seconds allowed for the test object search.</param>
        /// <returns>Returns a test object with the GUITestingSDK class that corresponds to the given GUIElementType.</returns>
        public dynamic Find(GUIElementType controlType, string name = "", string automationId = "", int isEnabled = -1, int waitSeconds = 25)
        {

            int count = 0;
            AutomationElement childTestObject = null;

            Condition[] conditions = null;

            if(isEnabled == -1) conditions = ConditionBuilder(controlType: controlType, name: name, automationId: automationId);
            else if(isEnabled == 0) conditions = ConditionBuilder(controlType: controlType, name: name, automationId: automationId, isEnabled = 0);
            else if(isEnabled == 1) conditions = ConditionBuilder(controlType: controlType, name: name, automationId: automationId, isEnabled = 1);

            AndCondition andCondition = null;

            if (conditions.Count() == 0) throw new GUITestingException("Can not find GUI element without given properties.");

            if (conditions.Count() > 1) andCondition = new AndCondition(conditions);


            do
            {
                AutoElement = AutomationElement.RootElement.FindFirst(TreeScope.Children, new PropertyCondition(AutomationProperty.LookupById(30002), ProcessId));
                if (AutoElement != null && childTestObject == null)
                {
                    AutomationElementCollection automationElementCollection;

                    if (conditions.Count() > 1)
                    {
                        automationElementCollection = AutoElement.FindAll(TreeScope.Descendants, andCondition);
                    }
                    else
                    {
                        automationElementCollection = AutoElement.FindAll(TreeScope.Descendants, conditions[0]);
                    }

                    if (automationElementCollection.Count > 1)
                    {
                        throw new MultipleObjectsFoundException("More objects with the given properties were matched. Try adding more identification properties.");
                    }
                    else if (automationElementCollection.Count > 0)
                    {
                        AutomationElement[] elements = new AutomationElement[automationElementCollection.Count];
                        automationElementCollection.CopyTo(elements, 0);
                        childTestObject = elements[0];
                    }
                }

                count++;
                Thread.Sleep(100);
            }
            while (childTestObject == null && count < 10 * waitSeconds);

            if (childTestObject != null)
            {
                return CreateByTypeName(controlType, childTestObject);
            }

            throw new GUIObjectNotFoundException("No object found with the given properties. Try changing the identification properties.");
        }

        /// <summary>
        /// This method converts the GUITestingSDK type to a UIA Automation.ControlType. Used internally to map objects.
        /// </summary>
        /// <param name="controlType"></param>
        /// <returns>Returns a UIA ControlType. </returns>
        private ControlType GetControlType(GUIElementType controlType)
        {
            switch (controlType)
            {
                case GUIElementType.Button:
                    return ControlType.Button;

                case GUIElementType.CheckBox:
                    return ControlType.CheckBox;

                case GUIElementType.Window:
                    return ControlType.Window;

                case GUIElementType.List:
                    return ControlType.List;

                case GUIElementType.ListItem:
                    return ControlType.ListItem;

                case GUIElementType.Editor:
                    return ControlType.Edit;

                case GUIElementType.Table:
                    return ControlType.Table;

                case GUIElementType.TableItem:
                    return ControlType.Edit;//must change the logic for specific frameworks

                case GUIElementType.GUIObject:
                    return null;

                case GUIElementType.HyperLink:
                    return ControlType.Hyperlink;

                case GUIElementType.Label:
                    return ControlType.Text;

                case GUIElementType.Menu:
                    return ControlType.MenuBar; //or menu, more testing needed

                case GUIElementType.Slider:
                    return ControlType.Slider;

                case GUIElementType.Tab:
                    return ControlType.Tab;

                case GUIElementType.Tree:
                    return ControlType.Tree;

                case GUIElementType.TreeItem:
                    return ControlType.TreeItem;

                case GUIElementType.RadioButton:
                    return ControlType.RadioButton;

                default:
                    return ControlType.Custom;
            }
        }

        /// <summary>
        /// This method builds an array of PropertyConditon conditions to find the objects with the given properties.
        /// </summary>
        /// <param name="controlType">The GUI control type property of the test object to find.</param>
        /// <param name="name">The name property of the test object to find.</param>
        /// <param name="automationId">The automationId property of the test object to find.</param>
        /// <param name="isEnabled">The isEnabled property of the test object to find. Default is -1. True is 1. False is 0.</param>
        /// <returns>Returns an array of UIA Condition objects used for searching inside the UIA tree. </returns>
        private Condition[] ConditionBuilder(GUIElementType controlType, string name = "", string automationId = "", int isEnabled = -1)
        {
            List<PropertyCondition> conditions = new List<PropertyCondition>();
            if (name != "")
            {
                conditions.Add(new PropertyCondition(AutomationProperty.LookupById(30005), name));
            }

            if (automationId != "")
            {
                conditions.Add(new PropertyCondition(AutomationProperty.LookupById(30011), automationId));
            }

            ControlType type = GetControlType(controlType);

            if (type != null) conditions.Add(new PropertyCondition(AutomationProperty.LookupById(30003), type));

            else if (isEnabled == 0) conditions.Add(new PropertyCondition(AutomationProperty.LookupById(30010), false));

            else if (isEnabled == 1) conditions.Add(new PropertyCondition(AutomationProperty.LookupById(30010), true));

            return conditions.ToArray();
        }

        /// <summary>
        /// This method creates an instance of the test object class corresponding with the given GUIElementType.
        /// </summary>
        /// <param name="typeName">The test object type.</param>
        /// <param name="testObject">The UIA AutomationElement for the object to be created.</param>
        /// <returns></returns>
        private static dynamic CreateByTypeName(GUIElementType typeName, AutomationElement testObject)
        {
            var type = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                        from t in assembly.GetTypes()
                        where t.Name == typeName.ToString() && t.FullName.StartsWith("GUITestingSDK")
                        select t).FirstOrDefault();

            if (type == null)
                throw new InvalidOperationException("Object type not found.");

            return Activator.CreateInstance(type, testObject);
        }

        /// <summary>
        /// This method performs a single left-click on the object.
        /// </summary>
        public void Click()
        {
            System.Windows.Rect rectangle = AutoElement.Current.BoundingRectangle;
            int x = (int)rectangle.X + (int)rectangle.Width / 2;
            int y = (int)rectangle.Y + (int)rectangle.Height / 2;
            System.Drawing.Point point = new System.Drawing.Point(x, y);
            Mouse.MoveTo(point);
            Mouse.Click(MouseButton.Left);
        }

        /// <summary>
        /// This method performs a double left-click on the object.
        /// </summary>
        public void DoubleClick()
        {
            System.Windows.Rect rectangle = AutoElement.Current.BoundingRectangle;
            int x = (int)rectangle.X + (int)rectangle.Width / 2;
            int y = (int)rectangle.Y + (int)rectangle.Height / 2;
            System.Drawing.Point point = new System.Drawing.Point(x, y);
            Mouse.MoveTo(point);
            Mouse.DoubleClick(MouseButton.Left);
        }

        /// <summary>
        /// This method performs a single right-click on the object.
        /// </summary>
        public void RightClick()
        {
            System.Windows.Rect rectangle = AutoElement.Current.BoundingRectangle;
            int x = (int)rectangle.X + (int)rectangle.Width / 2;
            int y = (int)rectangle.Y + (int)rectangle.Height / 2;
            System.Drawing.Point point = new System.Drawing.Point(x, y);
            Mouse.MoveTo(point);
            Mouse.Click(MouseButton.Right);
        }

        /// <summary>
        /// This method highlights the object in blue and brings it to focus.
        /// </summary>
        public void Focus()
        {
            if (!AutoElement.Current.ControlType.Equals(ControlType.Text)) AutoElement.SetFocus();

            System.Windows.Rect rectangle = AutoElement.Current.BoundingRectangle;
            System.Drawing.Size newSize = new System.Drawing.Size((int)rectangle.Size.Width, (int)rectangle.Size.Height);
            System.Drawing.Point newPoint = new Point((int)rectangle.X, (int)rectangle.Y);

            using (Form form = new Form())
            {

                form.AllowTransparency = true;
                form.ShowInTaskbar = false;
                form.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                form.BackColor = Color.Magenta;
                form.TransparencyKey = Color.Magenta;
                form.Height = Screen.PrimaryScreen.Bounds.Height;
                form.Width = Screen.PrimaryScreen.Bounds.Width;
                form.DesktopLocation = newPoint;
                form.TopMost = true;
                form.Show();

                Pen greenPen = new Pen(Color.FromArgb(255, 0, 0, 255), 3);
                Graphics g = form.CreateGraphics();
                System.Drawing.Rectangle drawingRectangle = new System.Drawing.Rectangle(newPoint, newSize);

                for (int i = 0; i <= 2; i++)
                {
                    g.DrawRectangle(greenPen, drawingRectangle);
                    Thread.Sleep(100);
                    g.Clear(Color.Magenta);
                    Thread.Sleep(100);
                }

                g.Dispose();

            }
            if (!AutoElement.Current.ControlType.Equals(ControlType.Text)) AutoElement.SetFocus();
        }

        /// <summary>
        /// This method moves the cursor on top of the object and hovers for a given time.
        /// </summary>
        /// <param name="waitMiliseconds">Hover time in miliseconds.</param>
        public void Hover(int waitMiliseconds = 1000)
        {
            System.Windows.Rect rectangle = AutoElement.Current.BoundingRectangle;
            int x = (int)rectangle.X + (int)rectangle.Width / 2;
            int y = (int)rectangle.Y + (int)rectangle.Height / 2;
            System.Drawing.Point point = new System.Drawing.Point(x, y);
            Mouse.MoveTo(point);
            Thread.Sleep(waitMiliseconds);
        }
    }


}
