using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Open : MonoBehaviour
{

    private bool isPlayerInRange;
    Animator anim;
    [SerializeField] private GameObject doorMark;
    private SFXManager sfxManager;
    private string doorStateKey;
    private bool isDoorOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        sfxManager = GameObject.Find("SFXManager").GetComponent<SFXManager>();
        doorStateKey = SceneManager.GetActiveScene().name + gameObject.name;
        // Load the door state from PlayerPrefs
        isDoorOpen = PlayerPrefs.GetInt(doorStateKey, 0) == 1;
        if (isDoorOpen)
        {
            anim.SetBool("Open", true);
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (isPlayerInRange && Input.GetButtonDown("Submit"))
        {
            anim.SetBool("Open", true);
            sfxManager.DoorSound();
            isDoorOpen = true;
            // Save the door state to PlayerPrefs
            PlayerPrefs.SetInt(doorStateKey, 1);
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

    private void OnDestroy()
    {
        // Save the door state to PlayerPrefs when the object is destroyed
        PlayerPrefs.SetInt(doorStateKey, isDoorOpen ? 1 : 0);
    }
}

