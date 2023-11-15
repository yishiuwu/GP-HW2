using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreControl : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI scoreText;
    // public TextMeshProUGUI scoreText;
    
    public static int score;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = score.ToString();
    }

    public void ResetScore(){
        score = 0;
    }

    public static void AddScore(int add){
        score += add;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString();
    }

    public void testGetScore10(){
        score += 10;
        scoreText.text = score.ToString();;
    }

    public void testReLoad(){
        FindObjectOfType<SceneTransition>().ChangeScene("ReloadTestScene");
    }
}
