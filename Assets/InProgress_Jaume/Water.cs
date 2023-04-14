using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    public Material defaultMaterial;
    public Material newMaterial;
    public GameObject waterCollider;

    [SerializeField] private TextureAnimator textureAnimator;

    private bool isUsingDefaultMaterial = true;

    void Start()
    {
        waterCollider.SetActive(true);
    }

    void OnTriggerStay(Collider other)
    {
        if ((other.gameObject.CompareTag("Ruhe") || other.gameObject.CompareTag("Hangin")) && Input.GetKeyUp(KeyCode.F))
        {
            Renderer iceRenderer = other.gameObject.GetComponent<Renderer>();
            if (iceRenderer != null)
            {
                if (isUsingDefaultMaterial)
                {
                    iceRenderer.material = newMaterial;
                    isUsingDefaultMaterial = false;
                }
            }

            if (other.transform.root.gameObject == transform.root.gameObject) // Check if the collider is attached to the same game object as the script
            {
                Collider collider = GetComponent<Collider>();
                if (collider != null)
                {
                    collider.enabled = false; // Disable the collider attached to this game object
                }
            }

            waterCollider.SetActive(false);
            textureAnimator.enabled = false; // Disable the Texture Animator script
        }
    }

    void OnTriggerExit(Collider other)
    {
        waterCollider.SetActive(true);
        textureAnimator.enabled = true; // Enable the Texture Animator script
    }
}