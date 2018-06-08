using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Task;
using SkillTask = Task.Task;
namespace Skill
{
    public delegate void TrigSkill(Skill skill);

    public class SkillManager : ISingleton<SkillManager>
    {
        /// <summary>
        /// 需要根据需要初始化技能数据
        /// </summary>
        private Dictionary<int, SkillTable> m_Skills;

        /// <summary>
        /// 技能的合法性验证， 通过TrigSkill返回触发的技能
        /// </summary>
        /// <param name="skillId"></param>
        /// <param name="caster">施法者</param>
        /// <param name="target">目标</param>
        /// <param name="trig">技能触发</param>
        /// <param name="complate">技能完成回掉</param>
        public void Verify(int skillId, Entity caster, Entity target, TrigSkill trig, SkillComplate complate)
        {
            //查阅技能
            if (!m_Skills.ContainsKey(skillId))
            {
                throw new KeyNotFoundException(string.Format("{0} 不在技能表"));
            }
            SkillTable skilldata = m_Skills[skillId];
            //根据技能表组装技能属性
            Attribute attribue = new Attribute();
            attribue.CostMp = skilldata.Cost;

            //使用技能属性初始化技能[这里后续使用对象池获取对象，暂时直接new]
            Skill skill = new Skill();
            skill.Init(caster, target, attribue, complate);

            //检查释放条件
            //蓝耗检查
            if (skilldata.Cost > 0)
            {
                if (!skill.IsValid(new MpVerify()))
                {
                    trig(null);
                    return;
                }
            }
            //to-do其他检查
            trig(skill);
        }
        public void Fire(Skill skill)
        {
            //to-do吟唱 吟唱时间可以根据表格来
            TimeCondition singCond = new TimeCondition(0.5f);
            SkillTask singTask = new SkillTask("吟唱任务", singCond);
            TaskManager.Instance().AddTask(singTask);
            //伤害计算
            DamageCondtion dmgCond = new DamageCondtion(skill, delegate (int result) { HandleCast(skill, result); }, EventsType.Skill_EndDmg);
            SkillTask dmgTask = new SkillTask("伤害检查", dmgCond);
            TaskManager.Instance().AddTask(dmgTask);
            //启动任务队列
            TaskManager.Instance().Start(">>>技能伤害计算流程");
        }

        /// <summary>
        /// 处理施法
        /// </summary>
        /// <param name="skill"></param>
        /// <param name="result"></param>
        private void HandleCast(Skill skill, int result)
        {
            //释放特效
            SkillTask emitTask = new SkillTask("释放", new CastCondition(skill, 0.5f));
            Task.TaskManager.Instance().AddTask(emitTask);

            //打击效果
            SkillTask hitTask = new SkillTask("打击效果", new HitCondition(skill, 1));
            Task.TaskManager.Instance().AddTask(hitTask);

            //启动任务队列
            TaskManager.Instance().Start(">>>技能施法流程", delegate ()
            {
                skill.End();
            });
        } 
    }
}
