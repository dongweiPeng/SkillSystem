using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 技能表，根据需要初始化技能原生数据，一般情况是excel
/// </summary>
namespace Skill
{
    public class SkillTable 
    {
        private int m_Id;
        private int m_Cost;

        public int Id
        {
            get
            {
                return m_Id;
            }

            set
            {
                m_Id = value;
            }
        }

        public int Cost
        {
            get
            {
                return m_Cost;
            }

            set
            {
                m_Cost = value;
            }
        }
    }
}
