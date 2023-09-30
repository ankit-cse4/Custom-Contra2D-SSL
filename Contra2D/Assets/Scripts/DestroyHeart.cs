using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyHeart : MonoBehaviour {

    public int health;
    public GameObject player;
    private int playerHealth;
    
    
	
	void Start () {
       
        // health = player.GetComponent<PlayerManager>().life;
        

     
	}
	
	// Update is called once per frame
	// void Update () {
    //     playerHealth = player.GetComponent<PlayerManager>().life;

        
    //     if(health < playerHealth )
    //     {
    //         gameObject.SetActive(true);
    //     }
    //     // if(health > playerHealth  )
    //     // {
            
    //     //     gameObject.SetActive(false);
            
    //     // }
    //     else{

    //         gameObject.SetActive(false);

    //     }
        
    // }


    void Update () {
    playerHealth = player.GetComponent<PlayerManager>().life;

    if(health < playerHealth )
    {
        gameObject.GetComponent<Image>().enabled = true; 
    }
    else
    {
        gameObject.GetComponent<Image>().enabled = false; 
    }
    }

}
