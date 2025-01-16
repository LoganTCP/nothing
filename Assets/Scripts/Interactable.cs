using UnityEngine;

public class Interactable : MonoBehaviour
{
    public enum InteractionType
    {
        OpenDoor,
        CollectItem,
        ActivateSwitch
    }

    public InteractionType interactionType; // Dropdown in Inspector
    public Animator objectAnimationController; // Select Door Animator
    public Transform objectTansform; // Select Door Transform
    private bool isOpen = false;

    public void Interact()
    {
        switch (interactionType)
        {
            case InteractionType.OpenDoor:
                OpenDoor();
                break;

            case InteractionType.CollectItem:
                CollectItem();
                break;

            case InteractionType.ActivateSwitch:
                ActivateSwitch();
                break;

            default:
                Debug.LogWarning("Unhandled interaction type.");
                break;
        }
    }

    private void OpenDoor()
    {
        if (isOpen == false)
        {
            //Debug.Log("Door opened!");
            // Add door-opening logic here
            objectTansform.rotation = Quaternion.Euler(0, 180, 0);
            objectAnimationController.enabled = true;
            objectAnimationController.Play("doorOpen");
            isOpen = true;
        }
        else if (isOpen == true)
        {
            //Debug.Log("Door Closed!");
            objectTansform.rotation = Quaternion.Euler(0, 75, 0);
            objectAnimationController.enabled = true;
            objectAnimationController.Play("doorClose");
            isOpen = false;
        }
    }

    private void CollectItem()
    {
        Debug.Log("Item collected!");
        // Add item collection logic here
    }

    private void ActivateSwitch()
    {
        Debug.Log("Switch activated!");
        // Add switch activation logic here
    }
}
