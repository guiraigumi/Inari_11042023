using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Dialogue : MonoBehaviour
{

    public static Dialogue Instance;
    private bool isPlayerInRange;
    private bool didDialogueStart;
    public bool isTalking;
    private int lineIndex;
    GameObject target;

    Player player; 

    private float typingTime = 0.05f;

    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private GameObject dialogueMark;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField, TextArea(4, 6)] private string[] dialogueLines;

    void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }


    void Update()
    {
        if(isPlayerInRange && Input.GetButtonDown("Submit"))
        {
            if(!didDialogueStart)
            {
                StartDialogue();
            }
            else if(dialogueText.text == dialogueLines[lineIndex])
            {
                NextDialogueLine();
            }
            else
            {
                StopAllCoroutines();

                dialogueText.text = dialogueLines[lineIndex];
            }
            
            /*else if(transform.gameObject.layer == 10)
            {

            }
            else if(transform.gameObject.layer == 10)
            {
                
            }*/
        }
        
    }

    private void StartDialogue()
    {
        didDialogueStart = true;
        dialoguePanel.SetActive(true);
        lineIndex = 0;
        
        StartCoroutine(ShowLine());
        target = GameObject.Find("Front");
        Vector3 targetPosition = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);

        player.isplayerTalking = true;
    }

    private void NextDialogueLine()
    {
        lineIndex++;
        if(lineIndex < dialogueLines.Length)
        {
            StartCoroutine(ShowLine());
        }
        else
        {
            didDialogueStart = false;
            dialoguePanel.SetActive(false);


            player.isplayerTalking = false;
            //Time.timeScale = 1f;
        }
    }

    private IEnumerator ShowLine()
    {
        dialogueText.text = string.Empty;

        foreach(char ch in dialogueLines[lineIndex])
        {
            dialogueText.text += ch;

            yield return new WaitForSecondsRealtime(typingTime);
        }
    }

    private void OnTriggerEnter(Collider collision )
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = true;
            dialogueMark.SetActive(true);
            Debug.Log("Inicio dialogo");
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = false;
            dialogueMark.SetActive(false);
            Debug.Log("Fin del dialogo");
        }
    }

}
