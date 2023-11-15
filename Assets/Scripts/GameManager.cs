using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static event Action onGameWin;
    public static event Action onGameLose;
    public static event Action onGameRestart;
    public UnityEngine.Object player;
    public static SceneTransition sceneTransition;
    public static bool isEnd = false;
    
    
    // Start is called before the first frame update
    void Start()
    {
        sceneTransition = FindObjectOfType<SceneTransition>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void NextStage(string stageName) {
        sceneTransition.outColor = Color.white;
        sceneTransition.ChangeScene(stageName);
    }
    public static void Win() {
        onGameWin?.Invoke();
        onGameWin = null;
        isEnd = true;
    }
    public static void Lose() {
        onGameLose?.Invoke();
        onGameLose = null;
        isEnd = true;
    }
    public static void Restart() {
        onGameRestart?.Invoke();
        // onGameRestart = null;
        sceneTransition.ChangeScene("scene1");
    }
    public static void End() {
        onGameRestart?.Invoke();
        sceneTransition.outColor = Color.black;
        sceneTransition.ChangeScene("MainMenu");
    }

}
