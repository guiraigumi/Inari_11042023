using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hidden : MonoBehaviour
{
    [SerializeField] private MeshRenderer hiddenObject;


    void OnTriggerStay(Collider collision)
    {
        if(collision.gameObject.CompareTag("Player") && LuaOnFieldAbility.Instance.fire == true)
        {
            hiddenObject.enabled = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if(collision.gameObject.CompareTag("Player") || LuaOnFieldAbility.Instance.fire == false)
        {
            hiddenObject.enabled = false;
        }
    }
}
