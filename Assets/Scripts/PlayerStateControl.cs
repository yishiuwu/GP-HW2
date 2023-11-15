using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStateControl : MonoBehaviour
{
    public float playerHP;
    public float maxPlayerHP = 100;
    public Image greenHP;
    public Image redHP;

    Image ShowUpHP, ClosedHP;


    // Start is called before the first frame update
    void Start()
    {
        ResetPlayerHP();
    }

    public void ResetPlayerHP(){
        playerHP = maxPlayerHP;
        ShowUpHP = greenHP;
        ClosedHP = redHP;
        ManageShowUpHP();
    }

    public static void AddPlayerHP(float hp){
        playerHP += hp;
        if(playerHP / maxPlayerHP <= 0.2f){
            ShowUpHP = redHP;
            ClosedHP = greenHP;
        }
        else{
            ShowUpHP = greenHP;
            ClosedHP = redHP;
        }
        ManageShowUpHP();
    }

    void ManageShowUpHP(){
        ShowUpHP.enabled = true;
        ClosedHP.enabled = false;
        ShowUpHP.GetComponent<Image>().fillAmount = Mathf.Lerp(0, 1, playerHP / maxPlayerHP);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void testAddHP10(){
        AddPlayerHP(10);
    }
    public void testSubHP10(){
        AddPlayerHP(-10);
    }
}
