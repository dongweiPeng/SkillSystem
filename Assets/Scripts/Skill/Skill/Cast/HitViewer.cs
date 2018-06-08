using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace Skill
{
    /// <summary>
    /// 受击特效需要绑定的脚本，用于结束受击打特效
    /// </summary>
    public class HitViewer : MonoBehaviour
    {
        private Action m_Complete;
        private float m_Time;
        public void Cast(Action recevier, float time)
        {
            this.m_Complete = recevier;
            this.m_Time = time;
            StartCoroutine(Handle());
        }

        IEnumerator Handle()
        {
            yield return new WaitForSeconds(this.m_Time);
            if (m_Complete != null)
            {
                m_Complete();
            }
        }
    }
}
