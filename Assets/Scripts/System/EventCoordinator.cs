﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[ExecuteInEditMode]
public class EventCoordinator : Singleton<EventCoordinator>
{
    public bool enableDebugging;

    private Dictionary<string, UnityGameEvent> eventDictionary;
    private Dictionary<string, UnityGameEvent> attachmentsDictionary;
    protected override void OnInit()
    {
        if (eventDictionary == null)
        {
            eventDictionary = new Dictionary<string, UnityGameEvent>();
        }
        if (attachmentsDictionary == null)
        {
            attachmentsDictionary = new Dictionary<string, UnityGameEvent>();
        }
    }

    public static void StartListening(string eventName, UnityAction<GameMessage> listener)
    {
        UnityGameEvent thisEvent = null;
        //Debug.Log("StartListening name: "+eventName);
        if (Instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.AddListener(listener);
        }
        else
        {
            thisEvent = new UnityGameEvent();
            thisEvent.AddListener(listener);
            Instance.eventDictionary.Add(eventName, thisEvent);
        }
    }
    public static void Attach(string eventName, UnityAction<GameMessage> eventToAttach)
    {
        //use this to attach events to other events, this way making ordered event chains
        //??? or use stateMachines???
        UnityGameEvent thisEvent = null;
        if (Instance.attachmentsDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.AddListener(eventToAttach);
        }
        else
        {
            thisEvent = new UnityGameEvent();
            thisEvent.AddListener(eventToAttach);
            Instance.attachmentsDictionary.Add(eventName, thisEvent);
        }
    }
    public static void StopListening(string eventName, UnityAction<GameMessage> listener)
    {
        if (Instance == null) return;
        UnityGameEvent thisEvent = null;
        if (Instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.RemoveListener(listener);
        }
    }
    public static void Detach(string eventName, UnityAction<GameMessage> listener)
    {
        if (Instance == null) return;
        UnityGameEvent thisEvent = null;
        if (Instance.attachmentsDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.RemoveListener(listener);
        }
    }
    public static void TriggerEvent(string eventName, GameMessage message)
    {
        if (Instance == null) return;
        List<string> ignoreList = new List<string>();
        if (Instance.enableDebugging == true){
            //ignoreList.Add(EventName.System.Sheep.Roam());
            //ignoreList.Add(EventName.System.Economy.EatGrass());
            //ignoreList.Add(EventName.System.Player.PlayerCardsSorted());
            //ignoreList.Add(EventName.System.Player.ProfileUpdate());
            //ignoreList.Add(EventName.System.BaseTargetUpdate());
        }
        UnityGameEvent thisEvent = null;
        if (Instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            if (Instance.enableDebugging == true){
                if(!ignoreList.Contains(eventName))
                    Debug.LogWarning("M:"+eventName + ": " +DebugHelper.PrintGameMessage( message));
            }
            thisEvent.Invoke(message);
        }
        if (Instance.attachmentsDictionary.TryGetValue(eventName, out thisEvent))
        {
/*             if (Instance.enableDebugging == true){
                if(!ignoreList.Contains(eventName))
                    Debug.LogWarning("A:"+eventName + ": " + message);
            } */
            thisEvent.Invoke(message);
        }
    }
    public static bool HasEvent(string eventName, UnityAction<GameMessage> listener){
        UnityGameEvent thisEvent = null;
        if (Instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            Debug.Log(thisEvent.GetPersistentEventCount());
            for(int i = 0; i < thisEvent.GetPersistentEventCount(); i++){
                Debug.Log(thisEvent.GetPersistentMethodName(i)+" :eventMethodName. evnt mng listner:"+listener.GetType().Name);
                if (thisEvent.GetPersistentMethodName(i) == listener.GetType().Name){
                    return true;
                }
            }
            return false;
        }
        else return false;
    }
}