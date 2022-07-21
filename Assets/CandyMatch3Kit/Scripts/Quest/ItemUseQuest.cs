using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BansheeGz.BGDatabase;
public class ItemUseQuest : Quest
{
    private int ad;
    private string questKey_str = "ItemUseQuestIndex";
    private string item;

    public string Getkey { get { return questKey_str; } }

    public string Item { get { return item; } }


    public int Max { get { return maxCnt; } }
    public int Min { get { return minCnt; } }



    public override void QuestGet()
    {
        // 저장된것이 없을 때
        if (!PlayerPrefs.HasKey("itemusename"))
        {
            PlayerPrefs.SetString("itemusename", "BoosterSwitch");
        }


        this.QuestUpdate();
        maxCnt = BGRepo.I["ItemUseQuest"].CountEntities - 1;
        minCnt = 0;
    }

    public override void QuestUpdate()
    {
        var row = BGRepo.I["ItemUseQuest"][PlayerPrefs.GetInt(questKey_str)];
        level = row.Get<int>("level");
        content = row.Get<int>("content");
        reward = row.Get<int>("reward");
        item = row.Get<string>("item");
        ad = row.Get<int>("AD");
    }

    public override bool QuestCompleteCompare()
    {


        if (PlayerPrefs.GetInt("itemusecnt") >= content)
        {
            return true;
        }


        return false;
    }
    public string ItemUseCnt()
    {
        return PlayerPrefs.GetInt("itemusecnt").ToString();
    }

    public string ItemValue()
    {
        return item;
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
        return base.GetEntity("ItemUseQuest", questKey_str);
    }
}
