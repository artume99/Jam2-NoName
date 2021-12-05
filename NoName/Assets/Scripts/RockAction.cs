using System;
using UnityEngine;

namespace GameJam2
{
    public class RockAction : ElementAction
    {
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private Rigidbody2D rigidBody;
        [SerializeField] private float pushForce;
        [SerializeField] private Vector3 pushDirection;

        private Color closeDistanceColor = Color.gray;
        private Color farDistanceColor = Color.white;
        private Color hitFrequencyColor = Color.black;
        private Color currentDistanceColor;
        
        private bool actionDone;

        private void Start()
        {
            currentDistanceColor = spriteRenderer.color;
        }

        public override void InitializeFrequencyRange()
        {
            normFreqRange.Add(new FrequencyRange(0.2f, 0.4f));
        }

        public override void Action()
        {
            rigidBody.AddForce(pushDirection * pushForce);
            SoundManager.Instance.PlaySound(SoundManager.SoundType.Stone);
        }

        public override void ShowDistanceFeedback(bool nearObject)
        {
            /*if (actionDone)
                return;
            
            Color? color = null;
            if (nearObject && currentDistanceColor != closeDistanceColor)
                color = closeDistanceColor;
            else if (!nearObject && currentDistanceColor != farDistanceColor)
                color = farDistanceColor;
            if (color.HasValue && color != currentDistanceColor)
            {
                currentDistanceColor = color.Value;
                spriteRenderer.color = currentDistanceColor;
            }*/
        }

        public override void ShowFrequencyFeedback(bool rightFrequency)
        {
            /*if (!rightFrequency)
                return;
            
            actionDone = true;
            spriteRenderer.color = hitFrequencyColor;*/
        }
    }
}