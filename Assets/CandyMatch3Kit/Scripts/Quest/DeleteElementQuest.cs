using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using BansheeGz.BGDatabase;
public class DeleteElementQuest : Quest
{

    private int ad;
    private string questKey_str = "DeleteElementQuestIndex";
    private string element;
    public string GetKey{get{return "DeleteElementQuestIndex"; }}
    public string Element{get{return element;}}
    public int Max { get { return maxCnt; } }
    public int Min { get { return minCnt; } }



    public override void QuestGet()
    {
        if (!PlayerPrefs.HasKey("germcolor"))
        {

            PlayerPrefs.SetString("germcolor", "red");
        }


        this.QuestUpdate();
        maxCnt = BGRepo.I["DeleteElementQuest"].CountEntities - 1;
        minCnt = 0;
    }

    public override void QuestUpdate()
    {
        var row = BGRepo.I["DeleteElementQuest"][PlayerPrefs.GetInt(questKey_str)];
        level = row.Get<int>("level");
        content = row.Get<int>("content");
        reward = row.Get<int>("reward");
        complete = row.Get<bool>("complete");
        element = row.Get<string>("element");
        ad = row.Get<int>("AD");
    }

    public override bool QuestCompleteCompare()
    {
        if(PlayerPrefs.GetInt("germcnt") >= content)
        {
            return true;
        }


        return false;
    }

    public string ElementValue()
    {
        return element;
    }

    public string GermCnt()
    {
        return PlayerPrefs.GetInt("germcnt").ToString();
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
        return base.GetEntity("DeleteElementQuest", questKey_str);
    }
}
