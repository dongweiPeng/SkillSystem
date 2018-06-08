using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Skill
{
    public class Buff
    {
        private int m_AtRound;
        private Skill m_Skill;

        public int AtRound
        {
            get
            {
                return m_AtRound;
            }

            set
            {
                m_AtRound = value;
            }
        }

        public Skill Skill
        {
            get
            {
                return m_Skill;
            }

            set
            {
                m_Skill = value;
            }
        }
    }
}
