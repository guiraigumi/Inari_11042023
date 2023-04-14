using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchManager : MonoBehaviour
{
    public static TorchManager Instance;

    public int[] torchesLit;
    public int[] torchesCorrectOrder;
    public GameObject monster;
    public GameObject fire1;
    public GameObject fire2;
    public GameObject fire3;
    public GameObject fire4;
    public GameObject lights1;
    public GameObject lights2;
    public GameObject lights3;
    public GameObject lights4;


    void Start()
    {
        Instance = this;

    }

    public void CheckOrder()
    {
        bool torch1 = false;
        bool torch2 = false;
        bool torch3 = false;
        bool torch4 = false;

        if(torchesCorrectOrder[0] == torchesLit[0])
        {
            torch1 = true;
        }

        if(torchesCorrectOrder[1] == torchesLit[1])
        {
            torch2 = true;
        }

        if(torchesCorrectOrder[2] == torchesLit[2])
        {
            torch3 = true;
        }

        if(torchesCorrectOrder[3] == torchesLit[3])
        {
            torch4 = true;
        }

        if(torch1 && torch2 && torch3 && torch4)
        {
           monster.SetActive(true);
        }
        else
        {
            fire1.SetActive(false);

            fire2.SetActive(false);

            fire3.SetActive(false);

            fire4.SetActive(false);

            lights1.SetActive(false);

            lights2.SetActive(false);

            lights3.SetActive(false);

            lights4.SetActive(false);

            //Apagar luces
            Debug.Log("Error luces");
        }

    }
}






