using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 次数作为任务条件
/// </summary>
namespace Task {
    public class TimesCondition : ITaskCondition
    {
        protected int m_times;
        private int m_curTimes; 

        public TimesCondition(int times){
            this.m_times = times;
        }

        public void Handle()
        {
            this.m_curTimes++;
        }

        public bool IsFinish()
        {
            return this.m_curTimes >= this.m_times;  
        }

        public string Name()
        {
            return this.ToString();
        }

        public virtual void Start()
        {
            this.m_curTimes = 1;
        }
    }
}

