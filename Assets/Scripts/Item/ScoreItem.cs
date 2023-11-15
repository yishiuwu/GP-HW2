using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreItem : MonoBehaviour
{
    public int addScore = 20;
    public event System.Action modifyScore;

    // Start is called before the first frame update
    void Start()
    {
        modifyScore += () => {
            ScoreControl.AddScore(addScore);
        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.tag=="Player"){
            Debug.Log("item");
            modifyScore?.Invoke();
            Destroy(gameObject);
        }
    }
}
