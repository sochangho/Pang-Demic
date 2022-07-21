using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BansheeGz.BGDatabase;



public class Quest : MonoBehaviour
{
    protected int level;
    protected int content;
    protected int reward;
    protected bool complete;
    protected int maxCnt;
    protected int minCnt;
    


    public virtual void QuestGet()
    {

    }

    public virtual void QuestUpdate()
    {

    }

    public virtual string LevelValue(){

        return level.ToString();

    }

    public virtual string Content()
    {
        return content.ToString();
    }
    public virtual bool QuestCompleteCompare()
    {
        return false;
    }

    public virtual BGEntity GetEntity(string entityname  = null, string indexname = null)
    {

        return BGRepo.I[entityname][PlayerPrefs.GetInt(indexname)];
    }
}
