using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJam2
{
    public class TutorialShard : ShardAction
    {
        private bool isTextShowing = false;
        
        public override void ShowDistanceFeedback(bool nearObject)
        {
            if (actionDone)
            {
                GameManager.Instance.TurnOffText();
                return;
            }

            if (isTextShowing || !nearObject)
                return;

            isTextShowing = true;
            GameManager.Instance.ShowText("Whistle");
        }
    }
}