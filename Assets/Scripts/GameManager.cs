using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static event Action onGameWin;
    public static event Action onGameLose;
    public Player player;
    public static SceneTransition sceneTransition;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
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
    }
    public static void Lose() {
        onGameLose?.Invoke();
    }
    public static void End() {
        sceneTransition.outColor = Color.black;
        sceneTransition.ChangeScene("MainMenu");
    }

}
