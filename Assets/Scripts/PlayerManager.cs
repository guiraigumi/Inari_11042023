using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
[SerializeField] private GameObject lua;
[SerializeField] private GameObject ruhe;
[SerializeField] private GameObject hangin;
[SerializeField] private GameObject kalju;

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
    else if (Input.GetKeyDown(KeyCode.Escape))
    {
        activeCharacter.GetComponentInChildren<Animator>().enabled = true;

        radialMenu.SetActive(false);

        Time.timeScale = 1f;
    }

    // Check for character change input
    if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
    {
        SwitchCharacter(lua);
    }
    else if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
    {
        SwitchCharacter(ruhe);
    }
    else if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))
    {
        SwitchCharacter(hangin);
    }
    else if (Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad4))
    {
        SwitchCharacter(kalju);
    }
}

private void SwitchCharacter(GameObject newCharacter)
{
    lastPosition = activeCharacter.transform.position;
    newCharacter.transform.position = lastPosition;

    activeCharacter.SetActive(false);
    newCharacter.SetActive(true);

    activeCharacter = newCharacter;
    activeCharacter.GetComponentInChildren<Animator>().enabled = true;

    radialMenu.SetActive(false);
    Time.timeScale = 1f;
}


}

