using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJam2
{
    public class ShardAction : ElementAction
    {
        [SerializeField] private Animator fallAnimator;
        [SerializeField] private Vector2 range;

        internal bool actionDone;
        

        public override void InitializeFrequencyRange()
        {
            normFreqRange.Add(new FrequencyRange(range.x, range.y));
        }

        public override void Action()
        {
            if (actionDone)
                return;
            actionDone = true;
            fallAnimator.SetTrigger("Fall");
            SoundManager.Instance.PlaySound(SoundManager.SoundType.Stalactite);
        }

        public override void ShowDistanceFeedback(bool nearObject)
        {
        }

        public override void ShowFrequencyFeedback(bool rightFrequency)
        {
            
        }
    }
}