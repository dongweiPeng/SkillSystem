using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Skill
{
    public partial class Attribute
    {
        /// <summary>
        /// 释放的挂点
        /// </summary>
        private Transform m_Effect_EmitParent;
        /// <summary>
        /// 受击的挂点
        /// </summary>
        private Transform m_Effect_HitParent;
        /// <summary>
        /// 释放特效名字
        /// </summary>
        private string m_Effect_EmitName;
        /// <summary>
        /// 受击特效名字
        /// </summary>
        private string m_Effect_HitName;

        public string Effect_EmitName
        {
            get
            {
                return m_Effect_EmitName;
            }

            set
            {
                m_Effect_EmitName = value;
            }
        }

        public string Effect_HitName
        {
            get
            {
                return m_Effect_HitName;
            }

            set
            {
                m_Effect_HitName = value;
            }
        }

        public Transform Effect_EmitParent
        {
            get
            {
                return m_Effect_EmitParent;
            }

            set
            {
                m_Effect_EmitParent = value;
            }
        }

        public Transform Effect_HitParent
        {
            get
            {
                return m_Effect_HitParent;
            }

            set
            {
                m_Effect_HitParent = value;
            }
        }
    }
}
