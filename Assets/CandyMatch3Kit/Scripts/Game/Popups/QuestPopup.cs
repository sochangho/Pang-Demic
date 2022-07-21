using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameVanilla.Core;


namespace GameVanilla.Game.Popups
{
    public class QuestPopup : Popup
    {        
        public List<QuestSlot> questSlots = new List<QuestSlot>();

        public GameObject completePopup;

        public GameObject background;

        public void Start()
        {
            var quest_manager = QuestManager.instance;
            quest_manager.InitializedQuest();
            for(int i = 0; i < quest_manager.quest_list.Count; i++)
            {
                string current;
                string script;
                QuestManager.QuestKinds questKinds;
                quest_manager.QuestInfomationSetting(out current, out script, out questKinds, quest_manager.quest_list[i]);

                questSlots[i].QuestSlotSet(script, current,
                    quest_manager.quest_list[i].Content(), quest_manager.quest_list[i].QuestCompleteCompare()
                    , questKinds, quest_manager.quest_list[i]
                    );

            }


        }



        public void CompletePopupCreate(QuestManager.QuestKinds kinds)
        {
            completePopup.GetComponent<CompletePopup>().questKinds = kinds;
            var go = Instantiate(completePopup);
            go.transform.parent = background.transform;
            go.GetComponent<RectTransform>().anchorMin = new Vector2(0, 0);
            go.GetComponent<RectTransform>().anchorMax = new Vector2(1, 1);
            go.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);
            go.GetComponent<RectTransform>().offsetMin = new Vector2(-471.6431f, -592.5731f);
            go.GetComponent<RectTransform>().offsetMax = new Vector2(476.0432f, 408.5731f);

           
        }


    }
}