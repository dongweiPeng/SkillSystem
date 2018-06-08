using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 普通攻击
/// </summary>
namespace Skill
{
    public class NormalAttack : IDamage
    {
        public int Handle(Skill skill)
        {
            return 0;

        }
    }
}