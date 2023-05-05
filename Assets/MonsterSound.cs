using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSound : MonoBehaviour
{
    
    public AudioSource audioSource;
    public static MonsterSound sound_instance;
    // Start is called before the first frame update
    void Start()
    {
        if(sound_instance == null)
        {
            sound_instance = this;
            DontDestroyOnLoad(gameObject);
        }   
        else
        {
            Destroy(gameObject);
        }

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlaySound()
    {
        audioSource.Play();
    }
}
