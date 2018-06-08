using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Skill
{
    public interface IInterrupt
    {
        void Handle(Entity entity);
    }
}