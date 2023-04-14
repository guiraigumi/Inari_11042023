using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour
{
    public int torchNumber;

    public GameObject fireParticles;
    public GameObject torchLight;
    [SerializeField] private GameObject abilityIcon;
    [SerializeField] private AudioClip AbilityiconSound;
    [SerializeField] private AudioClip torchSound;

    public bool istorchOn;

    private AudioSource audio;

    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!istorchOn)
            {
                abilityIcon.SetActive(true);
                audio.PlayOneShot(AbilityiconSound);
            }
        }

        /*if (collision.gameObject.CompareTag("Player") && istorchOn == false && LuaOnFieldAbility.Instance.fire == true)
        {
            audio.PlayOneShot(torchSound);
            abilityIcon.SetActive(false);
            torchLight.gameObject.SetActive(true);
            fireParticles.gameObject.SetActive(true);

            for(int i = 0; i < TorchManager.Instance.torchesLit.Length; i++)
            {
                if(TorchManager.Instance.torchesLit[i] == 0)
                {
                    TorchManager.Instance.torchesLit[i] = torchNumber;
                    return;
                }
            }
        }*/
    }

    void OnTriggerStay(Collider collision)
    {

        if (collision.gameObject.CompareTag("Player") && LuaOnFieldAbility.Instance.fire == true && istorchOn == false)
        {
            torchLight.gameObject.SetActive(true);

            fireParticles.gameObject.SetActive(true);

            abilityIcon.SetActive(false);

            istorchOn = true;

            audio.PlayOneShot(torchSound);


            for(int i = 0; i < TorchManager.Instance.torchesLit.Length; i++)
            {
                if(TorchManager.Instance.torchesLit[i] == 0)
                {
                    TorchManager.Instance.torchesLit[i] = torchNumber;
                    break;
                }
            }

            if(TorchManager.Instance.torchesLit[3] != 0)
            {
                TorchManager.Instance.CheckOrder();
            }
        }
    }

    void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!istorchOn)
            {
                abilityIcon.SetActive(false);
            }
        }
    }
}










