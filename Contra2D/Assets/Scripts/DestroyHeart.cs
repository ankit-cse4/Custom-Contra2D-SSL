using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyHeart : MonoBehaviour {

    public int health;
    public GameObject player;
    private int playerHealth;
    
    
	
	void Start () {
       
        // int number = player.GetComponent<PlayerManager>().life;

     
	}
	
	// Update is called once per frame
	void Update () {
        playerHealth = player.GetComponent<PlayerManager>().life;
        Debug.Log("DestroyHearts");
        Debug.Log(playerHealth);
        
        if(health == playerHealth )
        {
            gameObject.SetActive(false);
        }
        if(health > playerHealth  )
        {
            
            gameObject.SetActive(false);
            
        }
        if (health < playerHealth ){

            gameObject.SetActive(true);
            Debug.Log("check");
        }
        
    }

}
