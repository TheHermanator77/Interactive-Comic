using UnityEngine;

public class Finish : MonoBehaviour
{
    public GameObject objectToActivate; // Reference to the object you want to activate
    public GameObject objectToDeactivate; // Reference to the object you want to deactivate

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Citizen")) // Check tag instead of name
        {
            ActivateObject();
            DeactivateObject();
        }
    }

    private void ActivateObject()
    {
        if (objectToActivate != null)
        {
            objectToActivate.SetActive(true); // Activate the specified game object
        }
    }

    private void DeactivateObject()
    {
        if (objectToDeactivate != null)
        {
            objectToDeactivate.SetActive(false); // Deactivate the specified game object
        }
    }
}
