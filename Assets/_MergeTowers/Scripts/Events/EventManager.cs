using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;
using System.Collections;

public class EventManager : MonoBehaviourSingleton<EventManager>
{
    private readonly Dictionary<CustomEventType, CustomEvent> eventDictionary = new Dictionary<CustomEventType, CustomEvent>();

    public static void AddListener(CustomEventType type, UnityAction<Hashtable> listener)
    {
        if (Instance == null)
            return;

        CustomEvent thisEvent = null;
        if (!Instance.eventDictionary.TryGetValue(type, out thisEvent))
        {
            thisEvent = new CustomEvent();
            Instance.eventDictionary.Add(type, thisEvent);
        }

        thisEvent.AddListener(listener);
    }

    public static void RemoveListener(CustomEventType type, UnityAction<Hashtable> listener)
    {
        if (Instance == null)
            return;

        CustomEvent thisEvent = null;
        if (Instance.eventDictionary.TryGetValue(type, out thisEvent))
        {
            thisEvent.RemoveListener(listener);
        }
    }

    public static void TriggerEvent(CustomEventType type, Hashtable param)
    {
        if (Instance == null)
            return;

        CustomEvent thisEvent = null;
        if (Instance.eventDictionary.TryGetValue(type, out thisEvent))
        {
            thisEvent.Invoke(param);
        }
    }
}