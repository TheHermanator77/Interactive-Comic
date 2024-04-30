using UnityEngine;

public class DeactivateChildren : MonoBehaviour
{
    public GameObject objectToDeactivate;

    public void DeactivateAllChildren()
    {
        if (objectToDeactivate != null)
        {
            // Loop through all children of the specified GameObject
            foreach (Transform child in objectToDeactivate.transform)
            {
                // Deactivate the child GameObject
                child.gameObject.SetActive(false);
            }
        }
        else
        {
            Debug.LogError("Object to deactivate is not assigned!");
        }
    }
}
