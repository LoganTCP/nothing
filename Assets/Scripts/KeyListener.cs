using UnityEngine;

public class KeyListener : MonoBehaviour
{
    public float interactionRange = 2f; // Range to detect interactable objects
    public LayerMask interactableLayer; // Layer for interactable objects
    public Transform PlayerCamera; // Camera's Transform

    void Start()
    {
        // Get the camera's Transform
        PlayerCamera = Camera.main.transform;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            InteractWithObject();
        }
    }

    void InteractWithObject()
    {
        // Cast a ray from the camera's position in the direction it's facing
        Ray ray = new Ray(PlayerCamera.position, PlayerCamera.forward);
        RaycastHit hit;

        // Check if the ray hits an interactable object within range
        if (Physics.Raycast(ray, out hit, interactionRange, interactableLayer))
        {
            // Try to get the Interactable script from the hit object
            Interactable interactable = hit.collider.GetComponent<Interactable>();
            if (interactable != null)
            {
                interactable.Interact(); // Trigger the interaction
            }
        }
    }
}