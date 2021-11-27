using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    [SerializeField] private Rigidbody rg;

    [SerializeField] private MicInput mic;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float max_lvl = MicInput.MicLoudness * 10000;
        if (max_lvl > 100)
            rg.velocity = new Vector3(1, rg.velocity.y, 0);
        // Debug.Log(max_lvl);
    }
}
