using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{

    [SerializeField] private GameObject kalju;
    [SerializeField] private GameObject particleExplosion;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    void OnTriggerStay(Collider collider)
{
    if (collider.gameObject.CompareTag("Kalju") && Input.GetKeyDown(KeyCode.F) && (kalju.activeSelf == true))
    {
        this.gameObject.SetActive(false);

        particleExplosion.gameObject.SetActive(true);

    }
}
}
