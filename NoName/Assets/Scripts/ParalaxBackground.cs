using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParalaxBackground : MonoBehaviour
{
    [SerializeField] private Vector2 parallaxEffectMultiplier = new Vector2(0.5f,0.5f);
    
    private Transform cameraTransform;
    private Vector3 lastCameraPoistion;
    private float textureUnitSizeX;
    // private float textureUnitSizeY; // incase we want to use inf. cave upwards
    
    void Start()
    {
        cameraTransform = Camera.main.transform;
        lastCameraPoistion = cameraTransform.position;
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Texture2D texture = sprite.texture;
        textureUnitSizeX = texture.width / sprite.pixelsPerUnit;
        // textureUnitSizeY = texture.height / sprite.pixelsPerUnit;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 deltaMove = cameraTransform.position - lastCameraPoistion;
        transform.position += new Vector3(deltaMove.x * parallaxEffectMultiplier.x, deltaMove
            .y * parallaxEffectMultiplier.y, 0);
        lastCameraPoistion = cameraTransform.position;
        if (Mathf.Abs(cameraTransform.position.x - transform.position.x) >= textureUnitSizeX)
        {
            float offsetPositionX = (cameraTransform.position.x - transform.position.x) % textureUnitSizeX;
            transform.position = new Vector3(cameraTransform.position.x + offsetPositionX, transform.position.y);
        }
        
        // if (Mathf.Abs(cameraTransform.position.x - transform.position.x) >= textureUnitSizeX)
        // {
        //     float offsetPositionY = (cameraTransform.position.y - transform.position.y) % textureUnitSizeY;
        //     transform.position = new Vector3(cameraTransform.position.x , transform.position.y + offsetPositionY);
        // }
    }
}
