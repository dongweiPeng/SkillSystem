using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 当前生命的百分比
/// </summary>
namespace Skill
{
    public class RateAddHp : IDamage
    {
        public int Handle(Skill skill)
        {
            float rate = skill.Attribute.Value * 0.01f;
            int value = Mathf.RoundToInt((float)skill.Caster.Hp * rate);
            skill.Caster.Hp += value;
            return value;
        }
    }
}
