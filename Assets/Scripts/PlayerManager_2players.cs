using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager_2players : MonoBehaviour
{
    [SerializeField] private GameObject lua;
    [SerializeField] private GameObject ruhe;

    private GameObject activeCharacter;
    private Vector3 lastPosition;

    public GameObject librarian;

    [SerializeField] private GameObject radialMenu;

    // Start is called before the first frame update
    void Start()
    {
        activeCharacter = lua;
        lastPosition = lua.transform.position;
        librarian = GameObject.Find("Bibliotecaria");
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
            if ((Input.GetKeyDown(KeyCode.Escape)))
            {

                activeCharacter.GetComponentInChildren<Animator>().enabled = true;

                radialMenu.SetActive(false);

                Time.timeScale = 1f;
            }
        }

        if ((radialMenu.activeInHierarchy == true) && Input.GetKeyDown(KeyCode.Alpha1))
        {
            lastPosition = activeCharacter.transform.position;
            lua.transform.position = lastPosition;
            lua.SetActive(true);
            ruhe.SetActive(false);
            activeCharacter = lua;
            radialMenu.SetActive(false);
            Time.timeScale = 1f;
            activeCharacter.GetComponentInChildren<Animator>().enabled = true;
            librarian.GetComponent<Dialogue_Libraria_Lua>().enabled = true;
            librarian.GetComponent<Dialogue_Libraria_Ruhe>().enabled = false;
        }

        if ((radialMenu.activeInHierarchy == true) && Input.GetKeyDown(KeyCode.Alpha2))
        {
            lastPosition = activeCharacter.transform.position;
            ruhe.transform.position = lastPosition;
            lua.SetActive(false);
            ruhe.SetActive(true);
            activeCharacter = ruhe;
            radialMenu.SetActive(false);
            Time.timeScale = 1f;
            activeCharacter.GetComponentInChildren<Animator>().enabled = true;
            librarian.GetComponent<Dialogue_Libraria_Ruhe>().enabled = true;
            librarian.GetComponent<Dialogue_Libraria_Lua>().enabled = false;
        }

    }
}

