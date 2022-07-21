using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuntimePurchaseQuest : RuntimeGameQuest
{

    private ItemPurchaseQuest purchaseQuest = new ItemPurchaseQuest();

    public override void GameStart()
    {
        purchaseQuest = new ItemPurchaseQuest();
        this.current = purchaseQuest.GetEntity();
        if (!PlayerPrefs.HasKey("itempurchasename"))
        {
            PlayerPrefs.SetString("itempurchasename", this.current.Get<string>("item"));
        }
        if (!PlayerPrefs.HasKey("itempurchasecnt"))
        {
            PlayerPrefs.SetInt("itempurchasecnt", 0);
        }

        if (PlayerPrefs.GetInt("itempurchasecnt") < this.current.Get<int>("content"))
        {
            this.runtimeGerm_action += this.IncreaseCnt;
        }

    }


    public override void IncreaseCnt(string itemname)
    {
        if (PlayerPrefs.GetString("itempurchasename") == itemname)
        {
            int cnt = PlayerPrefs.GetInt("itempurchasecnt");
            cnt++;
            PlayerPrefs.SetInt("itempurchasecnt", cnt);
        }
    }


}
