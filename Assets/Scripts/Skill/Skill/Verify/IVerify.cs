using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Skill
{
    public interface IVerify
    {
        bool Verify(Entity caster, Entity target, Attribute attribute);

        /// <summary>
        /// 验证的优先级，优先级决定验证的先后顺序
        /// </summary>
        /// <returns></returns>
        int Priority();
    }
}
