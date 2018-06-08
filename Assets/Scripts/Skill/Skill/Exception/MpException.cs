using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace Skill
{
    public class MpException : Exception
    {

        public MpException(Entity entity, Attribute attribute)
        {
            Debug.Log(string.Format("{0}：【蓝量不足, 或者处于禁魔】当前的蓝量:{1}, 消耗的蓝量:{2}", entity.Name, entity.Mp, attribute.CostMp));
        }
    }
}