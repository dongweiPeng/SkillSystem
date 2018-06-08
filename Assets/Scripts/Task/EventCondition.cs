using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 事件类型的任务
/// </summary>
namespace Task
{
    public class EventCondition : ITaskCondition
    {
       protected bool m_IsEventTrigger = false;
        protected EventsType m_EventType;
        public EventCondition(EventsType type) {
            m_EventType = type;
            m_IsEventTrigger = false;
            EventsMgr.GetInstance().AttachEvent(type, EventHandle);
        }

        /// <summary>
        /// 事件的处理函数
        /// </summary>
        /// <param name="go"></param>
        protected virtual void EventHandle(object go)
        {
            m_IsEventTrigger = true;
            EventsMgr.GetInstance().DetachEvent(m_EventType, EventHandle);
        }

        public void Handle()
        {
        }

        public bool IsFinish()
        {
            return m_IsEventTrigger;
        }

        public string Name()
        {
            throw new NotImplementedException();
        }

        public virtual void Start()
        {

        }
    }
}
