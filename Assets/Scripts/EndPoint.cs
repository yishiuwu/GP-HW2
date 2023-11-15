using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class EndPoint : MonoBehaviour
{
    public ParticleSystem particleSysteml;
    public GameObject enemiesNode;
    public UnityEvent callback;
    private Collider col;
    private int enemiesCnt;

    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider>();
        enemiesCnt = enemiesNode.transform.childCount;
        particleSysteml.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        enemiesCnt = enemiesNode.transform.childCount;
        if (enemiesCnt==0 && !particleSysteml.isPlaying) {
            particleSysteml.Play();
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player" && enemiesCnt==0) {
            callback?.Invoke();
        }
    }
}
