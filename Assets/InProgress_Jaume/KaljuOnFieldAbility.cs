using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KaljuOnFieldAbility : MonoBehaviour
{
    private Animator anim;
    private AudioSource audio;

    [SerializeField] private GameObject kalju;
     [SerializeField] private GameObject abilityIcon;
    [SerializeField] private AudioClip AbilityiconSound;
    [SerializeField] private AudioClip rockSound;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();

        audio = GetComponentInChildren<AudioSource>();
    }

    void OnTriggerEnter(Collider collider)
{
    if(collider.gameObject.CompareTag("Rock"))
    {
        abilityIcon.SetActive(true);
        audio.PlayOneShot(AbilityiconSound);
    }
}

    void OnTriggerStay(Collider collider)
{
    if (collider.gameObject.CompareTag("Rock") && Input.GetKeyDown(KeyCode.F) && (kalju.activeSelf == true))
    {
        abilityIcon.SetActive(false);
        
        audio.PlayOneShot(rockSound);
    }
}

void OnTriggerExit(Collider collider)
{
    if(collider.gameObject.CompareTag("Rock"))
    {
        abilityIcon.SetActive(false);
    }
}

}