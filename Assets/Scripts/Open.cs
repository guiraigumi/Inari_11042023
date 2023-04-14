using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open : MonoBehaviour
{

    private bool isPlayerInRange;
    Animator anim;
    [SerializeField] private GameObject doorMark;
    private SFXManager sfxManager;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        sfxManager = GameObject.Find("SFXManager").GetComponent<SFXManager>();
    }

    // Update is called once per frame
    void Update()
    {

        if (isPlayerInRange && Input.GetButtonDown("Submit"))
        {
            anim.SetBool("Open", true);
            sfxManager.DoorSound();
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = true;
            doorMark.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = false;
            doorMark.SetActive(false);
        }
    }
}
