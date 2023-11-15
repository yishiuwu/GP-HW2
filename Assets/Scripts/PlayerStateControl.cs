using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerStateControl : MonoBehaviour
{
    public static float playerHP;
    public static float maxPlayerHP = 50;
    public Image greenHP;
    public Image redHP;

    Image ShowUpHP, ClosedHP;


    // Start is called before the first frame update
    void Start()
    {
        if(SceneManager.GetActiveScene().name == "scene1")
            ResetPlayerHP();
        GameManager.onGameRestart += ResetPlayerHP;
    }

    public static void ResetPlayerHP(){
        playerHP = maxPlayerHP;
    }

    public static void AddPlayerHP(float hp){
        Debug.Log(hp);
        playerHP += hp;
        if(playerHP > maxPlayerHP)
            playerHP = maxPlayerHP;
            
        if (playerHP <= 0) {
            GameManager.Lose();
        }
    }

    void ManageShowUpHP(){
        ShowUpHP = (playerHP / maxPlayerHP <= 0.2f)?redHP:greenHP;
        ClosedHP = (playerHP / maxPlayerHP <= 0.2f)?greenHP:redHP;
        ShowUpHP.enabled = true;
        ClosedHP.enabled = false;
        ShowUpHP.GetComponent<Image>().fillAmount = Mathf.Lerp(0, 1, playerHP / maxPlayerHP);
    }

    // Update is called once per frame
    void Update()
    {
        ManageShowUpHP();
    }

    public void testAddHP10(){
        AddPlayerHP(10);
    }
    public void testSubHP10(){
        AddPlayerHP(-10);
    }
}
