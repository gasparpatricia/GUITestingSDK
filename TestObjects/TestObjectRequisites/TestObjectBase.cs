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

namespace GUITestingSDK
{
    
    public class TestObjectBase// : ITestObjectBase
    {
        public AutomationElement AutoElement { get; set; }
        public int ProcessId {get;set;}
        public string Name { get; set; }
        public string AutomationId { get; set; }
        public bool IsEnabled { get; set; }

        public GUIElementType guiElementType;

        public TestObjectBase()
        {
            IsEnabled = false;
            AutomationId = "";
        }

        public TestObjectBase( AutomationElement automationElement = null)
        {
            AutoElement = automationElement;
            Name = automationElement.Current.Name;
            AutomationId = automationElement.Current.AutomationId;
            IsEnabled = automationElement.Current.IsEnabled;
            ProcessId = automationElement.Current.ProcessId;
        }

        public dynamic Find(GUIElementType controlType, string name = "", string automationId = "", bool isEnabled = true,  int waitSeconds = 25)
        {
            
            int count = 0;
            AutomationElement childTestObject = null;

            Condition[] conditions = ConditionBuilder(controlType: controlType, name: name, automationId: automationId);
            
            AndCondition andCondition = new AndCondition(conditions);

            
            do
            {
                AutoElement = AutomationElement.RootElement.FindFirst(TreeScope.Children, new PropertyCondition(AutomationProperty.LookupById(30002), ProcessId));
                if (AutoElement != null && childTestObject == null)
                {
                    AutomationElementCollection automationElementCollection = AutoElement.FindAll(TreeScope.Subtree, andCondition);
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

            if(childTestObject != null)
            {
                return CreateByTypeName(controlType, childTestObject);
            }
            
            throw new GUIObjectNotFoundException("No object found with the given properties. Try changing the identification properties.");
        }
        
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
                    return ControlType.Custom;

                case GUIElementType.HyperLink:
                    return ControlType.Hyperlink;

                case GUIElementType.Label:
                    return ControlType.Text;

                case GUIElementType.Menu:
                    return ControlType.MenuBar; //or menu, more testing needed

                case GUIElementType.MenuItem:
                    return ControlType.MenuItem;

                case GUIElementType.Slider:
                    return ControlType.Slider;

                case GUIElementType.Tab:
                    return ControlType.Tab;

                case GUIElementType.Tree:
                    return ControlType.Tree;

                case GUIElementType.TreeItem:
                    return ControlType.TreeItem;

                default:
                    return ControlType.Custom;
            }
        }

        private Condition[] ConditionBuilder(GUIElementType controlType, string name = "", string automationId = "", bool isEnabled = true)
        {
            List<PropertyCondition> conditions = new List<PropertyCondition>();
            if(name != "")
            {
                conditions.Add(new PropertyCondition(AutomationProperty.LookupById(30005), name));
            }
            
            if(automationId != "")
            {
                conditions.Add(new PropertyCondition(AutomationProperty.LookupById(30011), automationId));
            }

            ControlType type = GetControlType(controlType);
                      
            conditions.Add(new PropertyCondition(AutomationProperty.LookupById(30003), type));

            conditions.Add(new PropertyCondition(AutomationProperty.LookupById(30010), isEnabled));

            return conditions.ToArray();
        }

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
        

        public void Click()
        {
            //System.Windows.Point p = AutoElement.GetClickablePoint();
            System.Windows.Rect rectangle = AutoElement.Current.BoundingRectangle;
            int x = (int)rectangle.X + (int)rectangle.Width / 2;
            int y = (int)rectangle.Y + (int)rectangle.Height / 2;
            System.Drawing.Point point = new System.Drawing.Point(x, y);
            Mouse.MoveTo(point);
            Mouse.Click(MouseButton.Left);
        }

        public void DoubleClick()
        {
            System.Windows.Rect rectangle = AutoElement.Current.BoundingRectangle;
            int x = (int)rectangle.X + (int)rectangle.Width / 2;
            int y = (int)rectangle.Y + (int)rectangle.Height / 2;
            System.Drawing.Point point = new System.Drawing.Point(x, y);
            Mouse.MoveTo(point);
            Mouse.DoubleClick(MouseButton.Left);
        }

        public void RightClick()
        {
            System.Windows.Rect rectangle = AutoElement.Current.BoundingRectangle;
            int x = (int)rectangle.X + (int)rectangle.Width / 2;
            int y = (int)rectangle.Y + (int)rectangle.Height / 2;
            System.Drawing.Point point = new System.Drawing.Point(x, y);
            Mouse.MoveTo(point);
            Mouse.Click(MouseButton.Right);
        }

        public void Focus()
        {
            if(!AutoElement.Current.ControlType.ToString().Equals("Label")) AutoElement.SetFocus();

            System.Windows.Rect rectangle = AutoElement.Current.BoundingRectangle;
            System.Drawing.Size newSize = new System.Drawing.Size((int)rectangle.Size.Width, (int)rectangle.Size.Height);
            System.Drawing.Point newPoint = new Point((int)rectangle.X, (int)rectangle.Y);
            
            using (Form form = new Form()) {

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

                for(int i = 0; i <= 2; i++)
                {
                    g.DrawRectangle(greenPen, drawingRectangle);
                    Thread.Sleep(100);
                    g.Clear(Color.Magenta);
                    Thread.Sleep(100);
                }

                g.Dispose();

            }
            if (!AutoElement.Current.ControlType.ToString().Equals("Window")) AutoElement.SetFocus();
        }

        public void Hover()
        {
            System.Windows.Rect rectangle = AutoElement.Current.BoundingRectangle;
            int x = (int)rectangle.X + (int)rectangle.Width / 2;
            int y = (int)rectangle.Y + (int)rectangle.Height / 2;
            System.Drawing.Point point = new System.Drawing.Point(x, y);
            Mouse.MoveTo(point);
        }
    }

  
}
