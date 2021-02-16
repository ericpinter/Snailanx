using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SanailTalk : MonoBehaviour
{
    public string snailwords;
    public bool talkedTo { get; private set; }
    public bool singleUse;

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
        this.timeStamp = Time.fixedTime;
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.HideDialog();
            GameManager.Instance.StartDialog(snailwords);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            //if the player saw at least a whole second then we consider them as having talked to us
            if (Time.fixedTime - this.timeStamp > 1f)
            {
                talkedTo = true;
                if (singleUse)
                {
                    this.GetComponent<Collider2D>().enabled = false;
                }
            }
            GameManager.Instance.HideDialog();
        }
    }
}
