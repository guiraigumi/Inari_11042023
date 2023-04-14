using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour
{
   public GameObject fireParticles;
    public GameObject torchLight;
    [SerializeField] private GameObject abilityIcon;
    [SerializeField] private AudioClip AbilityiconSound;

    private AudioSource audio;

void Start()
{
    audio = audio = GetComponent<AudioSource>();
}

void OnTriggerEnter(Collider collision)
{
    if(collision.gameObject.CompareTag("Player"))
    {
        abilityIcon.SetActive(true);
        audio.PlayOneShot(AbilityiconSound);
    }
}

void OnTriggerStay(Collider collision)
{
    if(collision.gameObject.CompareTag("Player") && LuaOnFieldAbility.Instance.fire == true)
    {
        torchLight.gameObject.SetActive(true);
        
        fireParticles.gameObject.SetActive(true);
    }
}

void OnTriggerExit(Collider collision)
{
    if(collision.gameObject.CompareTag("Player"))
    {
        abilityIcon.SetActive(false);
    }
}

}


