using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 按钮触发任务类型
/// </summary>
namespace Task
{
    public class TirggerCondition:ITaskCondition
    {
        private bool m_IsTrigger;
        public TirggerCondition(Button btn) {
            if (btn == null) {
                Debug.LogError("触发任务条件失败，请重新检查下你的按钮是否为null");
                return;
            }
            m_IsTrigger = false;
            btn.onClick.AddListener(delegate() {
                Handle();
            });
        }

        public void Handle()
        {
            m_IsTrigger = true;
        }

        public bool IsFinish()
        {
            return m_IsTrigger;
        }

        public string Name()
        {
            return this.ToString();
        }

        public void Start()
        {
        }
    }
}
