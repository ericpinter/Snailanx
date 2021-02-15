using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public float boundryPercent;

    private float leftBoundry;
    private float rightBoundry;
    private float topBoundry;
    private float bottomBoundry;
    void Start()
    {
        leftBoundry = boundryPercent * Camera.main.pixelWidth;
        rightBoundry = Camera.main.pixelWidth - leftBoundry;

        topBoundry = boundryPercent * Camera.main.pixelHeight;
        bottomBoundry = Camera.main.pixelHeight - topBoundry;
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
            else if (spriteLocation.y < topBoundry)
            {
                pos.y -= topBoundry - spriteLocation.y;
            }
            else if (spriteLocation.y > bottomBoundry)
            {
                pos.y += spriteLocation.y - bottomBoundry;
            }

            transform.position = Vector3.Lerp(transform.position,pos,.01f);
        }
        
    }
}
