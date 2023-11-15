using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public float addHP = 20;

    public event System.Action modifyPlayerHP;

    // Start is called before the first frame update
    void Start()
    {
        modifyPlayerHP += () => {
            PlayerStateControl.AddPlayerHP(addHP);
        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.tag=="player"){
            Debug.Log("item");
            modifyPlayerHP.Invoke();
            Destroy(gameObject);
        }
    }

}
