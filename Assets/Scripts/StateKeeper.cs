using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StateKeeper : MonoBehaviour
{
    void Awake(){
        int scoreSingleton = FindObjectsOfType<StateKeeper>().Length;
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
        
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name != "CameraTestScene" && SceneManager.GetActiveScene().name != "scene1" && SceneManager.GetActiveScene().name != "scene2" && SceneManager.GetActiveScene().name != "scene3")
            Destroy(gameObject);
    }
}
