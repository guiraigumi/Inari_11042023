using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkSteps : MonoBehaviour
{

    private AudioSource audio;
    public AudioClip Ground, Carpet, Tatami;
    public LayerMask groundLayer, carpetLayer, tatamiLayer;
    public Transform checkPoint;


    void Start()
    {
        audio = GetComponent<AudioSource>();

        
    }


    void SoundWalk()
    {
        if(Physics.Raycast(checkPoint.position, Vector3.down, 0.6f, groundLayer))
        {
            audio.PlayOneShot(Ground, 1.5f);
            audio.pitch = Random.Range(1.0f, 1.8f);
        }
        else if (Physics.Raycast(checkPoint.position, Vector3.down, 0.6f, carpetLayer))
        {
            audio.PlayOneShot(Carpet, 1.5f);
            audio.pitch = Random.Range(1.0f, 1.8f);
        }
        else if (Physics.Raycast(checkPoint.position, Vector3.down, 0.6f, tatamiLayer))
        {
            audio.PlayOneShot(Tatami, 1.5f);
            audio.pitch = Random.Range(1.0f, 1.8f);
        }


    }


}