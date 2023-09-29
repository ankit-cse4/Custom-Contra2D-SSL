using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerAudioManager : MonoBehaviour
{
    public AudioSource death;
    public AudioSource damage;
    // Start is called before the first frame update
    void Start()
    {
        death = gameObject.AddComponent<AudioSource>();
        damage = gameObject.AddComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
