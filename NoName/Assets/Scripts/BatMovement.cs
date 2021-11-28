using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Rigidbody rg;
    [SerializeField] private float speed = 10;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var curr_position = transform.position;
        if (Input.GetKey(KeyCode.A))
        {
            rg.MovePosition(curr_position+=Vector3.left*speed*Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rg.MovePosition(curr_position+=Vector3.right*speed*Time.deltaTime);
        }
    }
}
