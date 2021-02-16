using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public GameObject dialogBox;
    public GameObject dialogText;

    public GameObject menuText;
    public GameObject startButton;
    public GameObject backgroundImage;

    public GameObject canvas;
    public GameObject events;
    
    public Coroutine dialogcor;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            DontDestroyOnLoad(canvas);
            DontDestroyOnLoad(events);
        }
        else {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void StartDialog(string text)
    {
        this.dialogBox.SetActive(true);
        dialogcor = StartCoroutine(TypeText(text));
    }

    public void HideDialog() 
    {
        this.dialogBox.SetActive(false);
        if (dialogcor != null) StopCoroutine(dialogcor);
    }

    public void DialogTimeout(float time)
    {
        StartCoroutine(waitAndTimeout(time));
    }

    IEnumerator waitAndTimeout(float time)
    {
        yield return new WaitForSecondsRealtime(time);
        HideDialog();
    }

    public void ScheuldeTransport(float time, String newArea)
    {
        StartCoroutine(waitAndTransport(time,newArea));
    }
    IEnumerator waitAndTransport(float time, String newArea)
    {
        yield return new WaitForSecondsRealtime(time);
        Transport(newArea);
    }


    IEnumerator TypeText(string text)
    {
        dialogText.GetComponent<TextMeshProUGUI>().text = "";
        foreach(char c in text.ToCharArray()){
            dialogText.GetComponent<TextMeshProUGUI>().text += c;
            yield return new WaitForSecondsRealtime(0.07f);
        }
    }
    public void StartButton()
    {
        startButton.SetActive(false);
        menuText.SetActive(false);
        Transport("Snailtopia");

    }

    public void GameOver()
    {
        startButton.SetActive(true);
        StopAllCoroutines();
        HideDialog();
        StartCoroutine(ColorLerp(new Color(1, 1, 1, 1), 1));
    }

    public void Transport(String newArea)
    {
        if (newArea == "MainMenu") GameOver();
        else StartCoroutine(LoadYourAsyncScene(newArea));
    }

    IEnumerator ColorLerp(Color endValue, float duration)
    {
        float time = 0;
        Image sprite = backgroundImage.GetComponent<Image>();
        Color startValue = sprite.color;

        while (time < duration)
        {
            sprite.color = Color.Lerp(startValue, endValue, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        sprite.color = endValue;
    }

    IEnumerator LoadYourAsyncScene(string scene)
    {
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
        // a sceneBuildIndex of 1 as shown in Build Settings.
        print("trying to load "+scene);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(scene);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        StopAllCoroutines();
        StartCoroutine(ColorLerp(new Color(1, 1, 1, 0), 2));

        HideDialog();
    }
}
