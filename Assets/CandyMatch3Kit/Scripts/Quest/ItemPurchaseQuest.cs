using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BansheeGz.BGDatabase;
public class ItemPurchaseQuest : Quest
{
    private int ad;
    private string questKey_str = "ItemPurchaseQuestIndex";
    private string item;

    public string Getkey { get { return questKey_str; } }

    public string Item { get { return item; } }


    public int Max { get { return maxCnt; } }
    public int Min { get { return minCnt; } }



    public override void QuestGet()
    {
        // 저장된것이 없을 때

        if (!PlayerPrefs.HasKey("itempurchasename"))
        {
            PlayerPrefs.SetString("itempurchasename", "BoosterSwitch");
        }

        this.QuestUpdate();
        maxCnt = BGRepo.I["ItemPurchaseQuest"].CountEntities - 1;
        minCnt = 0;
    }

    public override void QuestUpdate()
    {
        var row = BGRepo.I["ItemPurchaseQuest"][PlayerPrefs.GetInt(questKey_str)];
        level = row.Get<int>("level");
        content = row.Get<int>("content");
        reward = row.Get<int>("reward");        
        item = row.Get<string>("item");
        ad = row.Get<int>("AD");
    }

    public override bool QuestCompleteCompare()
    {

        
        if (PlayerPrefs.GetInt("itempurchasecnt") >= content)
        {
            return true;
        }


        return false;
    }
    public string ItemPurchaseCnt()
    {
        return PlayerPrefs.GetInt("itempurchasecnt").ToString();
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
        return base.GetEntity("ItemPurchaseQuest", questKey_str);
    }

}
