using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class WinMenu : MonoBehaviour
{
    public TextMeshProUGUI winText;
    public bool isWinMenu;
    // Start is called before the first frame update
    void Start()
    {
        if (isWinMenu) GameManager.onGameWin += CallOnWin;
        else GameManager.onGameLose += CallOnLose;
        GameManager.onStageChange += () => {
            if (isWinMenu) GameManager.onGameWin -= CallOnWin;
            else GameManager.onGameLose -= CallOnLose;
        };
        gameObject.SetActive(false);
        // if (winText) StartCoroutine(TextColorChange());
    }

    // private void OnDestroy() {
    //     if (isWinMenu) GameManager.onGameWin -= () => {gameObject.SetActive(true);};
    //     else GameManager.onGameLose -= () => {gameObject.SetActive(true);};
    // }

    void CallOnWin() {
        gameObject.SetActive(true);
        StartCoroutine(TextColorChange());
    }
    void CallOnLose() {
        gameObject.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator TextColorChange() {
        Color color = Color.red;
        float colorChangeRate = 0.1f;
        float t = 0;
        while (true) {
            t = 0;
            while (t<=1) {
                winText.color = color;
                yield return new WaitForSeconds(0.05f);
                color = Color.Lerp(Color.red, Color.blue,t);
                t += colorChangeRate;
            }
            t = 0;
            while (t<=1) {
                winText.color = color;
                yield return new WaitForSeconds(0.05f);
                color = Color.Lerp(Color.blue, Color.green,t);
                t += colorChangeRate;
            }
            t = 0;
            while (t<=1) {
                winText.color = color;
                yield return new WaitForSeconds(0.05f);
                color = Color.Lerp(Color.green, Color.red,t);
                t += colorChangeRate;
            }
        }
    }
}
