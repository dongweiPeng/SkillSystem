using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 任务的抽象条件
/// </summary>

namespace Task{
    public interface ITaskCondition {
    void Start();
    bool IsFinish();
    string Name();

    void Handle();
    }
}
