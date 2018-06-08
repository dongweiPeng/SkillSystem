/// <summary>
/// 全局的事件系统
/// </summary>
using UnityEngine;
using System.Collections.Generic;
public class EventsMgr  {

    private static EventsMgr instance;
    public  static EventsMgr GetInstance()
    {
        if(instance==null)
            instance = new EventsMgr();
        return instance;
    }
    //公共委托事件
    public delegate void CommonEvent(object data);

    //事件列表
    public Dictionary<EventsType, CommonEvent> m_dicEvents = new Dictionary<EventsType, CommonEvent>();

    /// <summary>
    /// 事件触发
    /// </summary>
    public void TriigerEvent(EventsType strEventKey, object param)
    {
        if (m_dicEvents.ContainsKey(strEventKey))
        {
            m_dicEvents[strEventKey](param);
        }
        else
        {
            //CommonTools.Log("没有监听这个事件"+ strEventKey);
        }
    }

    /// <summary>
    /// 事件绑定
    /// </summary>
    public void AttachEvent(EventsType key, CommonEvent attachEvent)
    {
        if (m_dicEvents.ContainsKey(key))
        {
            m_dicEvents[key] += attachEvent;
        }
        else
        {
            m_dicEvents.Add(key, attachEvent);
        }
    }


    /// <summary>
    /// 去除事件绑定
    /// </summary>
    public void DetachEvent(EventsType strEventKey, CommonEvent attachEvent)
    {
        if (m_dicEvents.ContainsKey(strEventKey))
        {
            System.Delegate[] lst = m_dicEvents[strEventKey].GetInvocationList();
            foreach (System.Delegate d in lst)
            {
                if(attachEvent == d)
                {
                    m_dicEvents[strEventKey] -= attachEvent;
                }
            }
            //当前key没有监听对象时，移除当前key.
            if (m_dicEvents[strEventKey] == null)
            {
                m_dicEvents.Remove(strEventKey);
            }
        }
        else
        {
           // CommonTools.Log("没有这个定义的事件:" + strEventKey);
        }
    }

    /// <summary>
    /// Detach 某些没有被删除的事件，解决Unity 报错某个组件删除找不到的问题
    /// </summary>
    /// <param name="tag"> events type 注意需要根据系统添加 </param>
    /// <param name="callback">由于这里防止是异步操作，所以需要等待原子性操作完成</param>
    public void DetachAllByTag(string tag, System.Action callback) {
        List<EventsType> types = new List<EventsType>();
        List<CommonEvent> events = new List<CommonEvent>();

        foreach (var v in m_dicEvents) {
            if (v.Key.ToString().Contains(tag)) {
                types.Add(v.Key);
                events.Add(v.Value);
            }
        }

        for (int i = 0, iMax = types.Count; i < iMax; i++)
        {
            DetachEvent(types[i], events[i]);
        }

        if (callback != null) {
            callback();
        }
    } 
}
