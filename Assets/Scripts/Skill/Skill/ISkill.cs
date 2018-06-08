using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Skill
{
    public delegate void SkillComplate(Skill skill);
    public interface ISkill
    {
        /// <summary>
        /// 技能的数据装载
        /// </summary>
        /// <param name="target">技能作用的目标</param>
        /// <param name="attribute">技能携带的属性</param>
        void Init<T, U>(T caster, U target, Attribute attribute = null, SkillComplate complate = null) where T : Entity where U : Entity;
        /// <summary>
        /// 是否可以通过
        /// </summary>
        /// <returns></returns>
        bool IsValid(IVerify verify);

        /// <summary>
        /// 多重验证 根据优先级决定验证数据
        /// </summary>
        /// <param name="verfiyList"></param>
        /// <returns></returns>
        bool IsValid(List<IVerify> verfiyList);
        /// <summary>
        /// 吟唱
        /// </summary>
        IEnumerator Sing(Task.Task task);
        /// <summary>
        /// 伤害计算
        /// </summary>
        int Caculate(IDamage damage);
        /// <summary>
        /// 结束
        /// </summary>
        void End();
        /// <summary>
        /// 中断
        /// </summary>
        void Interrupt(IInterrupt interrupt);

    }
}