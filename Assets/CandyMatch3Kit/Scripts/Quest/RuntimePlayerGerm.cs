using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuntimePlayerGerm : RuntimeGameQuest
{

  

    private DeleteElementQuest elementQuest;

    public override void GameStart()
    {
        elementQuest = new DeleteElementQuest();
        this.current = elementQuest.GetEntity();
        if (!PlayerPrefs.HasKey("germcolor"))
        {
            PlayerPrefs.SetString("germcolor",this.current.Get<string>("element"));
        }
        if (!PlayerPrefs.HasKey("germcnt"))
        {
            PlayerPrefs.SetInt("germcnt", 0);
        }

        if (PlayerPrefs.GetInt("germcnt") < this.current.Get<int>("content"))
        {
            this.runtimeGerm_action += this.IncreaseCnt;
        }


    }

    public override void  IncreaseCnt(string element)
    {
        if (PlayerPrefs.GetString("germcolor") == element)
        {
            int cnt = PlayerPrefs.GetInt("germcnt");
            cnt++;
            PlayerPrefs.SetInt("germcnt", cnt);
        }

    }



}
