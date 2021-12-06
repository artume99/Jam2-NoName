using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityTemplateProjects;

namespace GameJam2
{
    public class TaskElement : MonoBehaviour
    {
        [SerializeField] private ElementAction elementAction;
        private List<FrequencyRange> _frequencyRangeList;

        private void Start()
        {
            elementAction.InitializeFrequencyRange();
            _frequencyRangeList = elementAction.GetFrequencyRangeList();
        }

        private void Update()
        {
            if (CheckDistance())
            {
                elementAction.ShowDistanceFeedback(true);
                if (CheckFrequencies())
                {
                    elementAction.ShowFrequencyFeedback(true);
                    elementAction.Action();
                }
            }
            else
                elementAction.ShowDistanceFeedback(false);
        }

        private bool CheckDistance()
        {
            return Mathf.Abs(transform.position.x - BatMovement.Instance.GetBatPosition().x) < elementAction.minDistance;
        }

        private bool CheckFrequencies()
        {
            foreach (var frequencyRange in _frequencyRangeList)
            {
                var avg = MicTest.Instance.CheckPitchSamples(frequencyRange.GetStartValue(), frequencyRange.GetEndValue(), elementAction.samplesNum);
                /*Debug.Log("--avg: " + avg + " ---------------------");*/
                if (frequencyRange.GetStartValue() <= avg && avg <= frequencyRange.GetEndValue())
                    return true;
            }

            return false;
        }
    }
}