using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreControl : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI scoreText;
    // public TextMeshProUGUI scoreText;
    
    public int score;

    void Awake(){
        int scoreSingleton = FindObjectsOfType<ScoreControl>().Length;
        if(scoreSingleton > 1){
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else{
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = score.ToString();
    }

    public void ResetScore(){
        score = 0;
        scoreText.text = score.ToString();;
    }

    public void AddScore(int add){
        score += add;
        scoreText.text = score.ToString();;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void testGetScore10(){
        score += 10;
        scoreText.text = score.ToString();;
    }

    public void testReLoad(){
        SceneManager.LoadScene("CameraTestScene");
    }
}
