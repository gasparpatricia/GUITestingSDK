﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;

namespace GUITestingSDK
{
    public class Button : TestObjectBase
    {

        public Button()
        {
        }

        public Button(AutomationElement element) : base(element) 
        {
            
        }

        public void Invoke()
        {
            InvokePattern invokePattern = AutoElement.GetCurrentPattern(InvokePattern.Pattern) as InvokePattern;
            if (invokePattern != null)
            {
                invokePattern.Invoke();
            }
        }
    }
}