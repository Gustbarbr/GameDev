using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip keeperAttackSound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void KeeperAttackSound()
    {
       audioSource.PlayOneShot(keeperAttackSound); 
    }
}
