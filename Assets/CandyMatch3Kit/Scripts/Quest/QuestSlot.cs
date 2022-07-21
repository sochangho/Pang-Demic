using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using GameVanilla.Core;
using GameVanilla.Game.Popups;
public class QuestSlot : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI script;
    [SerializeField]
    private TextMeshProUGUI current;
    [SerializeField]
    private TextMeshProUGUI goal;

    [SerializeField]
    private GameObject completeButton;

    [SerializeField]
    private GameObject completePopup;
   
    public void QuestSlotSet(string _script ,string _current ,string _goal ,
        bool _check , QuestManager.QuestKinds questKinds ,Quest quest)
    {
        script.text = _script;
        current.text = _current;
        goal.text = _goal;


        completeButton.GetComponent<AnimatedButton>().onClick.RemoveAllListeners();


        if (_check)
        {

            Debug.Log(questKinds);
            completeButton.GetComponent<AnimatedButton>()
                .onClick.AddListener(() => {
                     FindObjectOfType<QuestPopup>().CompletePopupCreate(questKinds);
                   
                });


            SlotUpdate(quest);
        }
        else
        {
            Debug.Log("사운드");
            completeButton.GetComponent<AnimatedButton>().onClick.AddListener(() => { //사운드 호출
                                                                                      });
        }


    }


    public void SlotUpdate(Quest quest)
    {

        QuestManager.instance.UiAction =() => {

            quest.QuestUpdate();

            if (quest is DeleteElementQuest)
            {
                var entity = quest.GetEntity();
                PlayerPrefs.SetString("germcolor", entity.Get<string>("element"));
                PlayerPrefs.SetInt("germcnt", 0);
            }
            else if(quest is ItemPurchaseQuest)
            {
                var entity = quest.GetEntity();
                PlayerPrefs.SetString("itempurchasename", entity.Get<string>("item"));
                PlayerPrefs.SetInt("itempurchasecnt", 0);
            }
            else if(quest is ItemUseQuest)
            {
                var entity = quest.GetEntity();
                PlayerPrefs.SetString("itemusename", entity.Get<string>("item"));
                PlayerPrefs.SetInt("itemusecnt", 0);

            }
            
            string current;
            string script;
            QuestManager.QuestKinds questKinds;

            QuestManager.instance.QuestInfomationSetting(out current, out script, out questKinds, quest);

            QuestSlotSet(script, current, quest.Content(),
                quest.QuestCompleteCompare(), questKinds ,quest);


        };
     
     

    }
}
