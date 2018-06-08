using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Skill
{
    public interface IBuff
    {
        void AddBuff(Skill skill, int round = 0);

        void Disperse(List<int> disperseList);

        bool IsInvencible();
    }
}
