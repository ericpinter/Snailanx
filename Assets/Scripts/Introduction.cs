using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Introduction : MonoBehaviour
{

    private SanailTalk st;
    private bool introOver;
    public GameObject introNarration;
    public GameObject otherSnail;
    public GameObject transporter;


    // Start is called before the first frame update
    void Start()
    {
        st = GetComponent<SanailTalk>();
        introOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (!introOver && st.talkedTo)
        {
            introNarration.SetActive(true);
            otherSnail.GetComponent<SanailTalk>().snailwords = "You're leaving Snailtopia? Good luck. You'll need it.";
            transporter.SetActive(true);
            introOver = true;
        }
    }
    
}
