using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Task;
using System;

namespace Task
{
    public class LogicCondition : ITaskCondition
    {
        protected bool m_IsFinish;
        public void Handle()
        {
        }

        public bool IsFinish()
        {
            return m_IsFinish;
        }

        public string Name()
        {
            return this.ToString();
        }

        public virtual void Start()
        {
        }
    }
}