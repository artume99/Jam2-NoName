using UnityEngine;

namespace GameJam2
{
    public class FrequencyRange
    {
        private float startValue;
        private float endValue;
        
        public FrequencyRange(float startValue, float endValue)
        {
            this.startValue = startValue;
            this.endValue = endValue;
            
            if(startValue is < 0 or > 1 || endValue is < 0 or > 1)
                Debug.LogError("FrequencyRange values should be normalized!");
        }

        public float GetStartValue()
        {
            return startValue * Constants.HertzSensitivity;
        }

        public float GetEndValue()
        {
            return endValue * Constants.HertzSensitivity;
        }
    }
}