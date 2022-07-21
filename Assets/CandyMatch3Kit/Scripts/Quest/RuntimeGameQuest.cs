using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BansheeGz.BGDatabase;
using System;



public class RuntimeGameQuest : MonoBehaviour
{
    protected BGEntity current;
    public Action<string> runtimeGerm_action; // GameBord에서 호출

    public virtual void GameStart()
    {

    }

    public virtual void IncreaseCnt(string element)
    {

    }
}
