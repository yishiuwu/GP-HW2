using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Timer : MonoBehaviour
{
    public Image timerImage;
    public TextMeshProUGUI timerText;
    public float timer;
    public float maxTime = 300;
    public bool start_timer;
    private static bool isEnd = false;

    // Start is called before the first frame update
    void Start()
    {
        timer = maxTime;
        start_timer = true;
        StartCoroutine(TimerCoroutine());
        GameManager.onGameLose += CallOnEnd;
        GameManager.onGameWin += CallOnEnd;
        GameManager.onStageChange += ()=>{
            Debug.Log("timer destroy");
            GameManager.onGameLose -= CallOnEnd;
            GameManager.onGameWin -= CallOnEnd;
        };
        StaticStart();
    }

    static void StaticStart() {
        GameManager.onGameLose += ()=>{isEnd = true;};
        GameManager.onGameWin += ()=>{isEnd = true;};
        GameManager.onGameRestart += ()=>{isEnd = false;};
    }

    void CallOnEnd() {
        StopAllCoroutines();
    }

    // private void OnDestroy() {
    //     Debug.Log("timer destroy");
    //     GameManager.onGameLose -= ()=>{StopAllCoroutines();};
    //     GameManager.onGameWin -= ()=>{StopAllCoroutines();};
    // }

    public void ResetTimer(){
        timer = maxTime;
    }

    IEnumerator TimerCoroutine(){
        while (timer > 0) {
            timer -= 1;
            yield return new WaitForSeconds(1);
        }
        GameManager.Lose();
    }

    // Update is called once per frame
    void Update()
    {
        timerText.text = timer.ToString();
        timerImage.GetComponent<Image>().fillAmount = Mathf.Lerp(0, 1, timer / maxTime);
    }
}
