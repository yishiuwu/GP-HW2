using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public event System.Action OnGameWin;
    public event System.Action OnGameLose;
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
    // public static void Win() {

    // }
    // public static void Lose() {

    // }
    public static void End() {
        sceneTransition.outColor = Color.black;
        sceneTransition.ChangeScene("MainMenu");
    }

}
