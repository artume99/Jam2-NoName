using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    [SerializeField] private float minYValue;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < minYValue)
        {
            Destroy(gameObject.transform.parent.gameObject);
        }
    }
}
