using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using GameVanilla.Game.Common;
using GameVanilla.Game.UI;
public class QuestManager : SingltonGeneral<QuestManager>
{

    public List<Quest> quest_list = new List<Quest>();
    private StageQuest stage_quest = new StageQuest();
    private DeleteElementQuest de_quest = new DeleteElementQuest();
    private AccrueStarcntQuest as_quest = new AccrueStarcntQuest();
    private ItemPurchaseQuest ip_quest = new ItemPurchaseQuest();
    private ItemUseQuest iu_quest = new ItemUseQuest();

    public Action UiAction;
    public Action rewardAdAction;
    public Action rewardFinishAction;

    private int reward;


    public enum QuestKinds{

        Stage,
        DeleteElement,
        AccrureStarcnt,
        ItemPurchase,
        ItemUse

    }

    public void Start()
    {
        rewardAdAction = () => {

            var numLives = PlayerPrefs.GetInt("num_lives");
            var maxLives = PuzzleMatchManager.instance.gameConfig.maxLives;
                         
            numLives += this.reward;
            if (numLives > maxLives)
            {
                numLives = maxLives;

            }
            PlayerPrefs.SetInt("num_lives", numLives);
            
        };


        rewardFinishAction = () =>
        {
            FindObjectOfType<BuyLivesBar>().TextUpdate();
        };
        
    }


    public void InitializedQuest()
    {
        quest_list.Add(stage_quest);
        quest_list.Add(de_quest);
        quest_list.Add(as_quest);
        quest_list.Add(ip_quest);
        quest_list.Add(iu_quest);
        QuestSettings();
    }


    public void QuestSettings()
    {
        foreach (var quest in quest_list)
        {
            quest.QuestGet();
           
        }


    }

    private void QuestLevelUp_stage(bool ad)
    {

        HartReward(ad, stage_quest.GetEntity().Get<int>("reward"), PuzzleMatchManager.instance.gameConfig.maxLives);
        var level = PlayerPrefs.GetInt(stage_quest.GetKey);
        
        level++;
        PlayerPrefs.SetInt(stage_quest.GetKey, level);

        UiAction();


        //텍스트 수정
        //ui livebar 업데이트 , 퀘스트 창 업데이트 
        if (!ad)
        {
            FindObjectOfType<BuyLivesBar>().TextUpdate();
        }
    }

    private void QuestLevelUp_DeleteElementQuest(bool ad )
    {

        HartReward(ad, de_quest.GetEntity().Get<int>("reward"), de_quest.GetEntity().Get<int>("AD"));
        var level = PlayerPrefs.GetInt(de_quest.GetKey);             
        level++;         
        PlayerPrefs.SetInt(de_quest.GetKey, level);
    

        UiAction();

        if (!ad)
        {
            //텍스트 수정
            //ui livebar 업데이트 , 퀘스트 창 업데이트 
            FindObjectOfType<BuyLivesBar>().TextUpdate();
        }
    }


    private void QuestLevelUp_AccrueStarcntQuest(bool ad )
    {
        // 보상
        HartReward(ad, as_quest.GetEntity().Get<int>("reward"), PuzzleMatchManager.instance.gameConfig.maxLives);
        var level = PlayerPrefs.GetInt(as_quest.GetKey);
        level++;
        PlayerPrefs.SetInt(as_quest.GetKey, level);
        //초기화
        UiAction();
        if (!ad)
        {
            //텍스트 수정
            //ui livebar 업데이트 , 퀘스트 창 업데이트 
            FindObjectOfType<BuyLivesBar>().TextUpdate();
        }
    }

    private void QuestLevelUp_ItemPurchaseQuest(bool ad)
    {
        HartReward(ad, ip_quest.GetEntity().Get<int>("reward"), ip_quest.GetEntity().Get<int>("AD"));
        var level = PlayerPrefs.GetInt(ip_quest.Getkey);
        level++;
        PlayerPrefs.SetInt(ip_quest.Getkey, level);
        //초기화
        UiAction();
        if (!ad)
        {
            //텍스트 수정
            //ui livebar 업데이트 , 퀘스트 창 업데이트 
            FindObjectOfType<BuyLivesBar>().TextUpdate();
        }
    }


    private void QuestLevelUp_ItemUseQuest(bool ad)
    {
        HartReward(ad, iu_quest.GetEntity().Get<int>("reward"), iu_quest.GetEntity().Get<int>("AD"));
        var level = PlayerPrefs.GetInt(iu_quest.Getkey);
        level++;
        PlayerPrefs.SetInt(iu_quest.Getkey, level);
        //초기화
        UiAction();
        if (!ad)
        {
            //텍스트 수정
            //ui livebar 업데이트 , 퀘스트 창 업데이트 
            FindObjectOfType<BuyLivesBar>().TextUpdate();
        }


    }



    /// <summary>
    /// 퀘스트 완료버튼을 누르면 호출
    /// </summary>
    /// <param name="kind"></param>
    public void QuestComplete(QuestKinds kind  , bool ad )
    {
        //보상후 
        //레벨업
        //

        if(kind == QuestKinds.AccrureStarcnt && 
            PlayerPrefs.GetInt(as_quest.GetKey) < as_quest.Max && as_quest.QuestCompleteCompare())
        {
            QuestLevelUp_AccrueStarcntQuest(ad);
            
        }
        else if(kind == QuestKinds.DeleteElement && 
            PlayerPrefs.GetInt(de_quest.GetKey) < de_quest.Max && de_quest.QuestCompleteCompare())
        {
            QuestLevelUp_DeleteElementQuest(ad);
            
        }
        else if(kind == QuestKinds.Stage && 
            PlayerPrefs.GetInt(stage_quest.GetKey) < stage_quest.Max && stage_quest.QuestCompleteCompare())
        {
            QuestLevelUp_stage(ad);
            
        }
        else if(kind == QuestKinds.ItemPurchase && 
            PlayerPrefs.GetInt(ip_quest.Getkey) < ip_quest.Max && ip_quest.QuestCompleteCompare())
        {
            QuestLevelUp_ItemPurchaseQuest(ad);
        }
        else if (kind == QuestKinds.ItemUse &&
           PlayerPrefs.GetInt(iu_quest.Getkey) < iu_quest.Max && iu_quest.QuestCompleteCompare())
        {
            QuestLevelUp_ItemUseQuest(ad);
        }


    }


    /// <summary>
    /// 퀘스트 오픈시 비교후 이벤트 처리
    /// </summary>
    public void QuestCompare( Quest quest , Action _event )
    {
        
            if (_event !=null)
            {
                _event();

            }
        
    }


    public void QuestInfomationSetting(out string _current , out string _script , out QuestKinds _questKinds , Quest quest  , Action after = null)
    {
        if (quest is StageQuest)
        {
            _script = "stage: " + quest.LevelValue();
            var stage = quest as StageQuest;
            _current = stage.StageValue();
            _questKinds = QuestKinds.Stage;



        }
        else if (quest is DeleteElementQuest)
        {
            _script = "color: " + quest.LevelValue();
            var de = quest as DeleteElementQuest;
            _current = de.ElementValue() + ": " + de.GermCnt();
            _questKinds = QuestKinds.DeleteElement;


        }
        else if (quest is AccrueStarcntQuest)
        {
            _script = "star: " + quest.LevelValue();
            var a_s = quest as AccrueStarcntQuest;
            _current = a_s.TotalStarValue();
            _questKinds = QuestKinds.AccrureStarcnt;



        }
        else if(quest is ItemPurchaseQuest)
        {
            _script = "itemPurchase: " + quest.LevelValue();
            var ip = quest as ItemPurchaseQuest;
            _current =SetItemName(ip.ItemValue()) + ": " + ip.ItemPurchaseCnt();
            _questKinds = QuestKinds.ItemPurchase;
        }
        else
        {
            _script = "itemUse: " + quest.LevelValue();
            var iu = quest as ItemUseQuest;
            _current = SetItemName(iu.ItemValue()) + ": " +  iu.ItemUseCnt();
            _questKinds = QuestKinds.ItemUse;


        }

        
        if(after != null)
        {
            after();
        }



    }
 
    private void AdReward()
    {

        FindObjectOfType<GoogleMobileAdsDemoScript>().UserChoseToWatchAd();

    }


    
    private void HartReward(bool ad , int reward , int ad_reward)
    {
        var numLives = PlayerPrefs.GetInt("num_lives");
        var maxLives = PuzzleMatchManager.instance.gameConfig.maxLives;
        if (ad)
        {

            this.reward = ad_reward;
            AdReward();
            return;            
        }
        else
        {
            numLives += reward;
        }


        if (numLives > maxLives)
        {
            numLives = maxLives;

        }


        

         PlayerPrefs.SetInt("num_lives", numLives);
        

    }


    public string SetItemName(string name)
    {
        string changename = null;
        switch (name)
        {
            case "BoosterSwitch":
                changename =  "BoosterSyringe";
                break;
            case "BoosterBomb":
                changename = "BoosterSoap";
                break;
            case "BoosterColorBomb":
                changename = "BoosterFirstAidKit";
                break;
            case "BoosterLollipop":
                changename =  "BoosterRinger";
                break;
        }

        if(changename == null)
        {
            Debug.LogError("Can't found name");
        }



        return changename;
    }




}

