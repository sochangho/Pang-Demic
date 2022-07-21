using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameVanilla.Core;


namespace GameVanilla.Game.Popups
{
    public class CompletePopup : Popup
    {
        public Button nomal_button;
        public Button ads_button;
        public QuestManager.QuestKinds questKinds;

        private void Start()
        {
            nomal_button.onClick.AddListener(() => {
                QuestManager.instance.QuestComplete(questKinds, false);
                Debug.Log(questKinds.ToString());
                Close();
            });

            ads_button.onClick.AddListener(() => {
                QuestManager.instance.QuestComplete(questKinds, true);
                Debug.Log(questKinds.ToString());
                Close();
            });


        }




    }
}
