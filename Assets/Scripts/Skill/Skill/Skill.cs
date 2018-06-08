using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SkillTask = Task.Task;
namespace Skill
{
    public class Skill : ISkill
    {
        private Attribute m_Attribute;
        private SkillComplate m_Complate;
        private Entity m_Target;
        private Entity m_Caster;

        public Attribute Attribute
        {
            get
            {
                return m_Attribute;
            }

            set
            {
                m_Attribute = value;
            }
        }

        public Entity Target
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

        public Entity Caster
        {
            get
            {
                return m_Caster;
            }

            set
            {
                m_Caster = value;
            }
        }
        /// <summary>
        /// 技能结束
        /// </summary>
        public void End()
        {
            if (this.m_Complate != null)
            {
                this.m_Complate(this);
            }
        }



        public bool IsValid(IVerify verify)
        {
            if (verify != null)
            {
                bool valid = verify.Verify(this.Caster, this.Target, this.Attribute);
                if (!valid)
                {
                    Interrupt(new InterruptValid());
                }
                return false;
            }
            return true;
        }

        public bool IsValid(List<IVerify> verifyList)
        {
            if (verifyList != null && verifyList.Count > 0)
            {
                if (verifyList.Count == 1) return IsValid(verifyList[0]);
                //多余一个的验证条件需要先排序
                verifyList.Sort(delegate (IVerify x, IVerify y)
                {
                    return x.Priority().CompareTo(y.Priority());
                });
                foreach (var verify in verifyList)
                {
                    if (!IsValid(verify))
                    {
                        return false;
                    }
                }
            }
            return true;

        }

        public IEnumerator Sing(Task.Task task)
        {
            yield return task;
        }

        public void Interrupt(IInterrupt interrupt)
        {
            if (interrupt != null)
            {
                interrupt.Handle(this.Caster);
            }
            End();
        }

        public int Caculate(IDamage damage)
        {
            //驱散处理
            this.m_Caster.Disperse(this.m_Attribute.Mute);
            //处理计算后的返回值
            return damage.Handle(this);
        }

        public void Init<T, U>(T caster, U target, Attribute attribute = null, SkillComplate complate = null)
            where T : Entity
            where U : Entity
        {
            this.Target = target;
            this.Caster = caster;
            this.Attribute = Attribute ?? attribute;
            this.m_Complate = complate;
        }
    }
}