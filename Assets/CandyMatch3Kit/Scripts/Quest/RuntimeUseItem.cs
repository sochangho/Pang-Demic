using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuntimeUseItem : RuntimeGameQuest
{
    private ItemUseQuest itemUseQuest;

    public override void GameStart()
    {
        itemUseQuest = new ItemUseQuest();
        this.current = itemUseQuest.GetEntity();
        if (!PlayerPrefs.HasKey("itemusename"))
        {
            PlayerPrefs.SetString("itemusename", this.current.Get<string>("item"));
        }
        if (!PlayerPrefs.HasKey("itemusecnt"))
        {
            PlayerPrefs.SetInt("itemusecnt", 0);
        }

        if (PlayerPrefs.GetInt("itemusecnt") < this.current.Get<int>("content"))
        {
            this.runtimeGerm_action += this.IncreaseCnt;
        }

    }


    public override void IncreaseCnt(string item)
    {
        if (PlayerPrefs.GetString("itemusename") == item)
        {
            int cnt = PlayerPrefs.GetInt("itemusecnt");
            cnt++;
            PlayerPrefs.SetInt("itemusecnt", cnt);
        }

    }



}
