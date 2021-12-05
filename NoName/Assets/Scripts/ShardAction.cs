using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJam2
{
    public class ShardAction : ElementAction
    {
        [SerializeField] private Animator fallAnimator;
        [SerializeField] private Vector2 range;

        private bool actionDone;
        

        public override void InitializeFrequencyRange()
        {
            normFreqRange.Add(new FrequencyRange(range.x, range.y));
        }

        public override void Action()
        {
            fallAnimator.SetTrigger("Fall");
        }

        public override void ShowDistanceFeedback(bool nearObject)
        {
            if (actionDone)
                return;
            
            
        }

        public override void ShowFrequencyFeedback(bool rightFrequency)
        {
            if (!rightFrequency)
                return;
            
            actionDone = true;
            
        }
    }
}