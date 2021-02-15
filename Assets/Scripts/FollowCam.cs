using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public float boundryPercent;
    public float easing;

    private float leftBoundry;
    private float rightBoundry;
    private float topBoundry;
    private float bottomBoundry;
    void Start()
    {
        leftBoundry = boundryPercent * Camera.main.pixelWidth;
        rightBoundry = Camera.main.pixelWidth - leftBoundry;

        bottomBoundry = boundryPercent * Camera.main.pixelHeight;
        topBoundry = Camera.main.pixelHeight - bottomBoundry;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 spriteLocation = Camera.main.WorldToScreenPoint(player.transform.position);

        Vector3 pos = transform.position;

        if (player) {
            if (spriteLocation.x < leftBoundry)
            {
                pos.x -= leftBoundry - spriteLocation.x;
            }
            else if (spriteLocation.x > rightBoundry)
            {
                pos.x += spriteLocation.x - rightBoundry;
            }

            if (spriteLocation.y < bottomBoundry)
            {
                pos.y -= bottomBoundry - spriteLocation.y;
            }
            else if (spriteLocation.y > topBoundry)
            {
                pos.y += spriteLocation.y - topBoundry;
            }

            transform.position = Vector3.Lerp(transform.position,pos, easing);
        }
        
    }
}
