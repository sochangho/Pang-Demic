using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BansheeGz.BGDatabase;

public class AccrueStarcntQuest : Quest
{
    private bool ad;
    private string questKey_str = "AccrueStarcntQuestIndex";

    public string GetKey
    {

        get
        {
            return "AccrueStarcntQuestIndex";
        }

    }
    public int Max { get { return maxCnt; } }
    public int Min { get { return minCnt; } }


    public override void QuestGet()
    {


        this.QuestUpdate();
        maxCnt = BGRepo.I["AccrueStarcntQuest"].CountEntities - 1;
        minCnt = 0;
    }

    public override void QuestUpdate()
    {
        var row = BGRepo.I["AccrueStarcntQuest"][PlayerPrefs.GetInt(questKey_str)];
        level = row.Get<int>("level");
        content = row.Get<int>("content");
        reward = row.Get<int>("reward");
        complete = row.Get<bool>("complete");
        ad = row.Get<bool>("AD");
    }


    public override bool QuestCompleteCompare()
    {
        if (PlayerPrefs.GetInt("totalstar") >= content)
        {
            return true;
        }
     
        return false;
    }

    public string TotalStarValue()
    {

        return PlayerPrefs.GetInt("totalstar").ToString();
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
        return base.GetEntity("AccrueStarcntQuest", questKey_str);
    }
}
