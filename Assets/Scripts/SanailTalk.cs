using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SanailTalk : MonoBehaviour
{
    public string snailwords;
    public bool talkedTo { get; private set; }
    public bool singleUse;
    public bool endsGame;

    private float timeStamp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            this.timeStamp = Time.realtimeSinceStartup;

            if (this.CompareTag("Boss"))
            {
                SendMessage("removeTrigger");
                SendMessage("setSpeed", .02);
                Camera c = FindObjectOfType<Camera>();
                c.GetComponent<FollowCam>().player = this.gameObject;
                GameManager.Instance.DialogTimeout(3f);
            }

            if (endsGame)
            {
                GameManager.Instance.ScheuldeTransport(15f,"MainMenu");
                collision.gameObject.GetComponent<Controls>().moveSpeed = 0;
                collision.gameObject.GetComponent<Controls>().turnSpeed = 0;
            }

            GameManager.Instance.HideDialog();
            GameManager.Instance.StartDialog(snailwords);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player") && !endsGame)
        {
            //if the player saw a second then we consider them as having talked to us
            if (Time.realtimeSinceStartup - this.timeStamp > 1)
            {
                talkedTo = true;
                if (singleUse)
                {
                    this.GetComponent<Collider2D>().enabled = false;
                }
            }

            print("Stopping convo ("+gameObject.name+")");
            GameManager.Instance.HideDialog();
        }
    }
}
