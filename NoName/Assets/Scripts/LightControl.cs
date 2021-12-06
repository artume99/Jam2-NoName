using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace GameJam2
{
    public class LightControl : MonoBehaviour
    {
        [SerializeField] private Light2D aura;
        [SerializeField] private float maxOuter;
        [SerializeField] private float maxInner;

        private float clapFrequencyLower = 1350;
        private float clapFrequencyUpper = 2200;
        private bool clapped;
        private bool expand = true;

        void Start()
        {
            aura.pointLightOuterRadius = 0;
            aura.pointLightInnerRadius = 0;
            
            BatMovement.Instance.Freeze(true);
        }

        // Update is called once per frame
        void Update()
        {
            if (!clapped)
            {
                CheckClap();
            }
        }

        private void CheckClap()
        {
            var avg = MicTest.Instance.CheckPitchSamples(clapFrequencyLower, clapFrequencyUpper, 20);
            if ( avg >= clapFrequencyLower&&avg <= clapFrequencyUpper)
            {
                StartCoroutine(ExpandLight());
                clapped = true;
                GameManager.Instance.TurnOffText();
                BatMovement.Instance.Freeze(false);

            }
        }

        private IEnumerator ExpandLight()
        {
            while (true)
            {
                if (expand && clapped)
                {
                    while (aura.pointLightOuterRadius < maxOuter)
                    {
                        aura.pointLightOuterRadius += 0.05f;
                        if (aura.pointLightInnerRadius < maxInner)
                            aura.pointLightInnerRadius += 0.05f;

                        yield return new WaitForSeconds(0.01f);
                    }

                    expand = false;
                }
                else // Shrink 
                {
                    while (aura.pointLightOuterRadius > 2)
                    {
                        aura.pointLightOuterRadius -= 0.01f;
                        if (aura.pointLightInnerRadius > 0)
                            aura.pointLightInnerRadius -= 0.01f;

                        yield return new WaitForSeconds(0.3f);
                    }

                    clapped = false;
                    expand = true;
                }
                yield return new WaitForSeconds(0.5f);
            }
            
        }
        
    }
}