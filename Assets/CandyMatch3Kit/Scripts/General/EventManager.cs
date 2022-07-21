using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class EventManager : SingltonGeneral<EventManager>
{
    private Dictionary<string, List<Action<object>>> eventDatabase;

    private void Awake()
    {
        eventDatabase = new Dictionary<string, List<Action<object>>>();
    }


    public void On(string event_name , Action<object> act)
    {
        if (!eventDatabase.ContainsKey(event_name))
        {
            eventDatabase.Add(event_name, new List<Action<object>>());
        }
        eventDatabase[event_name].Add(act);
    }


    public void Emit(string event_name  , object parameter)
    {

        if (!eventDatabase.ContainsKey(event_name))
        {
            Debug.LogError($"NoExitKey -> {event_name}");
            return;
        }



        foreach(var event_act in eventDatabase[event_name])
        {
            event_act(parameter);

        }


    }



}
