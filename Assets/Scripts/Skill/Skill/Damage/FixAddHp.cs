using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Skill
{
    public class FixAddHp : IDamage
    {
        /// <summary>
        /// 加血对象
        /// </summary>
        private List<Entity> m_Target;

        public List<Entity> Target
        {
            get
            {
                return m_Target;
            }

            set
            {
                m_Target = value;
            }
        }

        public int Handle(Skill skill)
        {
            int value = skill.Attribute.Value;
            if (m_Target != null)
            {
                foreach (var target in m_Target)
                {
                    target.Hp += value;
                }
            }
            return value;
        }
    }
}