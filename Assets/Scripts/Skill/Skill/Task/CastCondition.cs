using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Task;
namespace Skill
{
    public class CastCondition : TimeCondition
    {
        private Skill m_Skill;
        public CastCondition(Skill skill, float duration) : base(duration)
        {
            this.m_Skill = skill;
        }

        public override void Start()
        {
            base.Start();
            //TO-DO 创建特效
        }
    }
}