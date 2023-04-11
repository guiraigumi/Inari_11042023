using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapCamera : MonoBehaviour
{
    public Transform lua;
    [SerializeField] private GameObject player1;

    public Transform ruhe;
    [SerializeField] private GameObject player2;

    public Transform hangin;
    [SerializeField] private GameObject player3;

    public Transform kalju;
    [SerializeField] private GameObject player4;

    // Update is called once per frame
    void LateUpdate()
    { 

        if((player1.activeInHierarchy == true))
        {
            transform.position = new Vector3(lua.position.x, transform.position.y, lua.position.z);

            //transform.rotation = Quaternion.Euler(90, lua.eulerAngles.y, 0);  
        }

        if((player2.activeInHierarchy == true))
        {
            transform.position = new Vector3(ruhe.position.x, transform.position.y, ruhe.position.z);

            //transform.rotation = Quaternion.Euler(90, ruhe.eulerAngles.y, 0);  
        }

        if((player3.activeInHierarchy == true))
        {
            transform.position = new Vector3(hangin.position.x, transform.position.y, hangin.position.z);

            //transform.rotation = Quaternion.Euler(90, hangin.eulerAngles.y, 0);  
        }

        if((player4.activeInHierarchy == true))
        {
            transform.position = new Vector3(kalju.position.x, transform.position.y, kalju.position.z);

            //transform.rotation = Quaternion.Euler(90, kalju.eulerAngles.y, 0);  
        }






    }

}