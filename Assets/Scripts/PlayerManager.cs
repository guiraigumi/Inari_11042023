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

    public GameObject librarian;

public GameObject fireLua;

private GameObject activeCharacter;
private Vector3 lastPosition;



[SerializeField] private GameObject radialMenu;
private bool isRadialMenuOpen;

// Start is called before the first frame update
void Start()
{
    activeCharacter = lua;
    lastPosition = lua.transform.position;
    librarian = GameObject.Find("Librarian");
    }

// Update is called once per frame
void Update()
{
    // Check if the active character is not moving before opening the radial menu
    if (Input.GetKeyDown(KeyCode.Q) && Vector3.Distance(activeCharacter.transform.position, lastPosition) < 0.001f)
    {
        // Disable the animator component on the active character
        activeCharacter.GetComponentInChildren<Animator>().enabled = false;

        // Show the radial menu and pause the game
        radialMenu.SetActive(true);
        Time.timeScale = 0f;

        isRadialMenuOpen = true;
    }
    else if (Input.GetKeyDown(KeyCode.Escape))
    {
        activeCharacter.GetComponentInChildren<Animator>().enabled = true;

        radialMenu.SetActive(false);

        Time.timeScale = 1f;

        isRadialMenuOpen = false;
    }

    // Call RadialMenuUpdate() method to check for character change input if the radial menu is open
    if (isRadialMenuOpen)
    {
        RadialMenuUpdate();
    }

    // Update the last position of the character
    lastPosition = activeCharacter.transform.position;
}



// Update is called once per frame for the radial menu
void RadialMenuUpdate()
{
    // Check for character change input
    if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
    {
        SwitchCharacter(lua);
        fireLua.gameObject.SetActive(false);
    }
    else if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
    {
        SwitchCharacter(ruhe);
        fireLua.gameObject.SetActive(false);
    }
    else if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))
    {
        SwitchCharacter(hangin);
        fireLua.gameObject.SetActive(false);
    }
    else if (Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad4))
    {
        SwitchCharacter(kalju);
        fireLua.gameObject.SetActive(false);
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

    isRadialMenuOpen = false;

        if (activeCharacter == lua)
        {
            // Activate the script on the Librarian character
            librarian.GetComponent<Dialogue_Libraria_Lua>().enabled = true;
            // Deactivate the other script on the Librarian character
            librarian.GetComponent<Dialogue_Libraria_Ruhe>().enabled = false;
        }
        else
        {
            // Deactivate the script on the Librarian character
            librarian.GetComponent<Dialogue_Libraria_Lua>().enabled = false;
            // Activate the other script on the Librarian character
            librarian.GetComponent<Dialogue_Libraria_Ruhe>().enabled = true;
        }

        if (activeCharacter == ruhe)
        {
            // Activate the script on the Librarian character
            librarian.GetComponent<Dialogue_Libraria_Ruhe>().enabled = true;
            // Deactivate the other script on the Librarian character
            librarian.GetComponent<Dialogue_Libraria_Lua>().enabled = false;
        }
        else
        {
            // Deactivate the script on the Librarian character
            librarian.GetComponent<Dialogue_Libraria_Ruhe>().enabled = false;
            // Activate the other script on the Librarian character
            librarian.GetComponent<Dialogue_Libraria_Lua>().enabled = true;
        }
    }

}
