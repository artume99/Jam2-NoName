using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform lookAt;

    [SerializeField] private float boundX = 0.15f;
    [SerializeField] private float boundY = 0.05f;

    private void Start()
    {
    }

    // Update is called once per frame
    void LateUpdate()
    {
        var currPos = transform.position;

        /*transform.position = new Vector3(lookAt.transform.position.x, currPos.y, currPos.z);

        return;*/
        
        Vector3 delta = Vector3.zero;
        float deltaX = lookAt.position.x - currPos.x;
        if (deltaX > boundX || deltaX < -boundX)
        {
            if (currPos.x < lookAt.position.x)
            {
                delta.x = deltaX - boundX;
            }
            else
            {
                delta.x = deltaX + boundX;
            }
        }

        float deltaY = lookAt.position.y - currPos.y;
        if (deltaY > boundY || deltaY < -boundY)
        {
            if (currPos.y < lookAt.position.y)
            {
                delta.y = deltaY - boundY;
            }
            else
            {
                delta.y = deltaY + boundY;
            }
        }

        transform.position += new Vector3(delta.x, delta.y, 0);
    }
}
