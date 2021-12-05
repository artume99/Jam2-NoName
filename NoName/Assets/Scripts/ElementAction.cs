using System.Collections.Generic;
using UnityEngine;

namespace GameJam2
{
    public abstract class ElementAction : MonoBehaviour
    {
        [SerializeField] internal int samplesNum = 100;
        public float minDistance;
        internal List<FrequencyRange> normFreqRange = new List<FrequencyRange>();

        public abstract void InitializeFrequencyRange();

        public abstract void Action();

        public abstract void ShowDistanceFeedback(bool nearObject);
        
        public abstract void ShowFrequencyFeedback(bool rightFrequency);
        
        public List<FrequencyRange> GetFrequencyRangeList()
        {
            return normFreqRange;
        }

    }
}