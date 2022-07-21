using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using BansheeGz.BGDatabase;



public class StageQuest : Quest
{

    private bool ad;

    private string questKey_str = "StageQuestIndex";

    public string GetKey
    {

        get
        {
            return "StageQuestIndex";
        }

    }

    public int Max { get { return maxCnt; } }
    public int Min { get { return minCnt; } }



    public override void QuestGet()
    {
       if( PlayerPrefs.GetInt("next_level") == 0)
        {
            PlayerPrefs.SetInt("next_level", 1);
        }


        this.QuestUpdate();
        maxCnt = BGRepo.I["StageQuest"].CountEntities - 1;
        minCnt = 0;
    }

    public override void QuestUpdate()
    {
        var row = BGRepo.I["StageQuest"][PlayerPrefs.GetInt(questKey_str)];
        level = row.Get<int>("level");
        content = row.Get<int>("content");
        reward = row.Get<int>("reward");
        complete = row.Get<bool>("complete");
        ad = row.Get<bool>("AD");
    }

    public override bool QuestCompleteCompare()
    {
        if (PlayerPrefs.GetInt("next_level") >= content)
        {
            return true;
        }


        return false;
    }

    public string StageValue()
    {

        return PlayerPrefs.GetInt("next_level").ToString();
        
    }


    public override string LevelValue()
    {
        return level.ToString();
    }

    public override string Content()
    {
        return content.ToString();
    }

    public override BGEntity GetEntity(string entityname = null, string indexname = null)
    {
        return base.GetEntity("StageQuest", questKey_str);
    }
}



