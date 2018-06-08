using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Skill
{
    public partial class Entity : IBuff
    {
        private string m_Name;
        private int m_MaxHp;
        private int m_MaxMp;
        private int m_Hp;
        private int m_Mp;
        private int m_Fight;
        private int m_Defence;
        private int m_Crit;

        private List<Buff> m_BuffList;

        public int Hp
        {
            get
            {
                return m_Hp;
            }

            set
            {
                m_Hp = value;
            }
        }

        public int Mp
        {
            get
            {
                return m_Mp;
            }

            set
            {
                m_Mp = value;
            }
        }

        public int Fight
        {
            get
            {
                return m_Fight;
            }

            set
            {
                m_Fight = value;
            }
        }

        public int Defence
        {
            get
            {
                return m_Defence;
            }

            set
            {
                m_Defence = value;
            }
        }

        public int Crit
        {
            get
            {
                return m_Crit;
            }

            set
            {
                m_Crit = value;
            }
        }

        public string Name
        {
            get
            {
                return m_Name;
            }

            set
            {
                m_Name = value;
            }
        }

        public int MaxHp
        {
            get
            {
                return m_MaxHp;
            }

            set
            {
                m_MaxHp = value;
            }
        }

        public int MaxMp
        {
            get
            {
                return m_MaxMp;
            }

            set
            {
                m_MaxMp = value;
            }
        }

        public void AddBuff(Skill skill, int round = 0)
        {
            m_BuffList = m_BuffList ?? new List<Buff>();
            Buff buff = new Buff();
            buff.AtRound = round;
            m_BuffList.Add(buff);
            EventsMgr.GetInstance().TriigerEvent(EventsType.Skill_AddBuff, buff);
        }

        public void Disperse(List<int> disperseList)
        {
            List<Buff> list = new List<Buff>();
            foreach (var buff in m_BuffList)
            {
                if (disperseList.Contains(buff.Skill.Attribute.Id))
                {
                    list.Add(buff);
                }
            }
            EventsMgr.GetInstance().TriigerEvent(EventsType.Skill_Disperse, list);
        }

        public bool IsInvencible()
        {
            return false;
        }
    }
}