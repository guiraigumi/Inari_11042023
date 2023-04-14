using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KaljuOnFieldAbility : MonoBehaviour
{
    private Animator anim;
    private AudioSource audio;
    [SerializeField] private AudioClip rockSound;

    [SerializeField] private GameObject kalju;
    [SerializeField] private GameObject particleExplosion;
     [SerializeField] private GameObject abilityIcon;
    [SerializeField] private AudioClip AbilityiconSound;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();

        audio = GetComponent<AudioSource>();
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
        collider.gameObject.SetActive(false);

        particleExplosion.gameObject.SetActive(true);

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