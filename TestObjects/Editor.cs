﻿using GUITestingSDK.Exceptions;
using GUITestingSDK.TestObjects.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;

namespace GUITestingSDK.TestObjects
{
    public class Editor : TestObjectBase, IValue
    {

        public Editor()
        {
        }

        public Editor(AutomationElement element) : base(element)
        {

        }

        public void SetValue(string value)
        {
            ValuePattern valuePattern = AutoElement.GetCurrentPattern(ValuePattern.Pattern) as ValuePattern;
            if (valuePattern.Current.IsReadOnly == true)
                throw new WrongOperationException("The value can not be set because the object is read only.");
            if (valuePattern != null && valuePattern.Current.IsReadOnly == false)
            {
                valuePattern.SetValue(value);
            }
            
        }

        public string GetValue()
        {
            ValuePattern valuePattern = AutoElement.GetCurrentPattern(ValuePattern.Pattern) as ValuePattern;
            if (valuePattern != null)
            {
                return valuePattern.Current.Value;
            }
            return null;
        }

        public bool IsReadOnly()
        {
            ValuePattern valuePattern = AutoElement.GetCurrentPattern(ValuePattern.Pattern) as ValuePattern;
            if (valuePattern != null)
            {
                return valuePattern.Current.IsReadOnly;
            }
            return false;
        }

    }
}
