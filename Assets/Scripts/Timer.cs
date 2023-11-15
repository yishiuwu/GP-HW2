using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public Image timerImage;
    public TextMeshProUGUI timerText;
    public float timer;
    public float maxTime = 300;
    public bool start_timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = maxTime;
        start_timer = true;
    }

    public void ResetTimer(){
        timer = maxTime;
    }

    IEnumerator timerCoroutine(){
        yield return new WaitForSeconds(1);
        timer -= 1;
        if(timer > 0)
            start_timer = true;
        else
            GameManager.Lose();
    }

    // Update is called once per frame
    void Update()
    {
        if(start_timer){
            StartCoroutine("timerCoroutine");
            start_timer = false;
        }
        timerText.text = timer.ToString();
        timerImage.GetComponent<Image>().fillAmount = Mathf.Lerp(0, 1, timer / maxTime);
    }
}
