using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Dev.Event
{
    public class GameEvent
    {
        public delegate void CallBack(BaseEventData data);

        public static void AddGameEvent ( GameObject target, EventTriggerType type, CallBack callback)
        {
            UnityAction<BaseEventData> click = new UnityAction<BaseEventData>(callback);
            EventTrigger.Entry onEvent = new EventTrigger.Entry();
            onEvent.eventID = type;
            onEvent.callback.AddListener(click);
            EventTrigger trigger = target.GetComponent<EventTrigger>();
            if (trigger == null)
                trigger = target.AddComponent<EventTrigger>();
            trigger.triggers.Add(onEvent);
        }

        public static void RmvGameEvent ( GameObject target, EventTriggerType type )
        {
            EventTrigger trigger = target.GetComponent<EventTrigger>();
            foreach (var onEvent in trigger.triggers)
            {
                if (onEvent.eventID == type)
                {
                    onEvent.callback.RemoveAllListeners();
                    trigger.triggers.Remove(onEvent);
                }
            }
        }
    }
}

