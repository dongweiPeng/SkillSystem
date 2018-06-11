using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
/// <summary>
/// 任务携程
/// </summary>
namespace Task
{
    public class TaskCoroutine : MonoBehaviour
    {
        private Action m_Complate;
        private string m_QueueName;
        public void HandleQueue(string queueName, Action complate)
        {
            this.m_QueueName = queueName;
            this.m_Complate = complate;
            StartCoroutine(Handle());
        }

        protected IEnumerator Handle() {
            Task current = TaskManager.Instance().Next();
            while (current != null)
            {
                Debug.Log(string.Format("当前执行的任务序列{0}, 当前任务{1}", this.m_QueueName, current.m_Name));
                yield return current;
                current = TaskManager.Instance().Next();
            }
            StopAllCoroutines();
            Debug.Log(string.Format("结束: 任务序列{0}", this.m_QueueName));
            if (m_Complate != null)
            {
                m_Complate();
            }
        }
    }
}
