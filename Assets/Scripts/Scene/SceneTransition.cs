using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public bool haveTransitionEffect;
    public Color inColor;
    public float inTime = 1.0f;
    public Color outColor;
    public float outTime = 1.0f;
    ColorEffect effect;
    
    private static SceneTransition instance = null;
    void Awake()
    {
        instance = this;
        effect = GetComponent<ColorEffect>();
        // Debug.Log(instance);
        // Debug.Log(effect);
    }
    void Start() {
        if (haveTransitionEffect) {
            effect.SetColor(inColor);
            effect.StartFade(Color.clear, inTime, ()=>{
                Debug.Log("complete in scene");
            });
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeScene(String sceneName) {
        Debug.Log("Change to scene: " + sceneName);
        AsyncOperation task = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
        task.allowSceneActivation = false;
        Debug.Log(instance);
        instance.effect.StartFade(instance.outColor, instance.outTime, ()=>{task.allowSceneActivation = true;});
    }
}
