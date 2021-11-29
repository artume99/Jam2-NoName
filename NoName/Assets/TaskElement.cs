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
        [SerializeField] private float minDistance;
        private List<FrequencyRange> normFreqRange = new List<FrequencyRange>();


        private void Start()
        {
            normFreqRange.Add(new FrequencyRange(0.2f, 0.4f));
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
            return Mathf.Abs(transform.position.x - BatMovement.Instance.GetBatPosition().x) < minDistance;
        }

        private bool CheckFrequencies()
        {
            foreach (var frequencyRange in normFreqRange)
            {
                if (frequencyRange.GetStartValue() <= MicTest.Instance.pitchVal &&
                    MicTest.Instance.pitchVal <= frequencyRange.GetEndValue())
                    return true;
            }

            return false;
        }
    }
}