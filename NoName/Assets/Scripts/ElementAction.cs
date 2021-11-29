using UnityEngine;

namespace GameJam2
{
    public abstract class ElementAction : MonoBehaviour
    {
        public abstract void Action();

        public abstract void ShowDistanceFeedback(bool nearObject);
        
        public abstract void ShowFrequencyFeedback(bool rightFrequency);

    }
}