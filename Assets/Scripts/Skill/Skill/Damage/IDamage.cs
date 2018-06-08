using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Skill
{
    public interface IDamage
    {
        /// <summary>
        /// 伤害计算
        /// </summary>
        /// <param name="skill">当前作用的技能</param>
        /// <returns>返回技能带来的伤害数值</returns>
        int Handle(Skill skill);
    }
}