using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager_3players : MonoBehaviour
{
    [SerializeField] private GameObject lua;
    [SerializeField] private GameObject ruhe;
    [SerializeField] private GameObject hangin;

    private GameObject activeCharacter;
    private Vector3 lastPosition;

    [SerializeField] private GameObject radialMenu;

    // Start is called before the first frame update
    void Start()
    {
        activeCharacter = lua;
        lastPosition = lua.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Q))
    {
        // Disable the animator component on the active character
        activeCharacter.GetComponentInChildren<Animator>().enabled = false;

        // Show the radial menu and pause the game
        radialMenu.SetActive(true);
        Time.timeScale = 0f;
    }

        else
        {
            if((Input.GetKeyDown(KeyCode.Escape)))
            {
                
                activeCharacter.GetComponentInChildren<Animator>().enabled = true;

                radialMenu.SetActive(false);

                Time.timeScale = 1f;
            }
        }

            if((radialMenu.activeInHierarchy == true) && Input.GetKeyDown(KeyCode.Alpha1))
        {
            lastPosition = activeCharacter.transform.position;
            lua.transform.position = lastPosition;
            lua.SetActive(true);
            ruhe.SetActive(false);
            hangin.SetActive(false);
            activeCharacter = lua;
            radialMenu.SetActive(false);
            Time.timeScale = 1f;
            activeCharacter.GetComponentInChildren<Animator>().enabled = true;
        }

        if((radialMenu.activeInHierarchy == true) && Input.GetKeyDown(KeyCode.Alpha2))
        {
            lastPosition = activeCharacter.transform.position;
            ruhe.transform.position = lastPosition;
            lua.SetActive(false);
            ruhe.SetActive(true);
            hangin.SetActive(false);
            activeCharacter = ruhe;
            radialMenu.SetActive(false);
            Time.timeScale = 1f;
            activeCharacter.GetComponentInChildren<Animator>().enabled = true;
        }

        if ((radialMenu.activeInHierarchy == true) && Input.GetKeyDown(KeyCode.Alpha3))
        {
            lastPosition = activeCharacter.transform.position;
            ruhe.transform.position = lastPosition;
            lua.SetActive(false);
            ruhe.SetActive(false);
            hangin.SetActive(true);
            activeCharacter = ruhe;
            radialMenu.SetActive(false);
            Time.timeScale = 1f;
            activeCharacter.GetComponentInChildren<Animator>().enabled = true;
        }

    }
}

