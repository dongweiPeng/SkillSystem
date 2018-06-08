using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Task;
using System;

/// <summary>
/// 目前只支持单任务链的管理
/// </summary>
namespace Task
{
    public class TaskManager : ISingleton<TaskManager>
    {
        private Queue<Task> m_TaskQueue = new Queue<Task>();
        /// <summary>
        /// 当前任务
        /// </summary>
        private Task m_Task;

        public Task Task
        {
            get
            {
                return m_Task;
            }
        }

        /// <summary>
        /// 是否任务已经做完了
        /// </summary>
        /// <returns></returns>
        public bool IsTaskFinish()
        {
            return (m_Task == null);

        }

        /// <summary>
        /// 添加任务
        /// </summary>
        /// <param name="task"></param>
        public void AddTask(Task task)
        {
            m_TaskQueue.Enqueue(task);
        }

        /// <summary>
        /// 执行下一个任务
        /// </summary>
        public Task Next()
        {
            if (m_TaskQueue.Count > 0)
            {
                m_Task = m_TaskQueue.Dequeue();
                m_Task.Condition.Start();
            }
            else
            {
                m_Task = null;
            }

            return m_Task;
        }

        /// <summary>
        /// 绑定taskcoroutine进行任务
        /// </summary>
        /// <param name="complate"></param>
        private GameObject m_TaskRoot;
        public void Start(string queueName="", Action complate = null) {
            m_TaskRoot = m_TaskRoot ?? new GameObject("TaskRoot");
            TaskCoroutine coroutine = m_TaskRoot.GetComponent<TaskCoroutine>() ?? m_TaskRoot.AddComponent<TaskCoroutine>();
            coroutine.HandleQueue(queueName, complate);
        }
    }
}

