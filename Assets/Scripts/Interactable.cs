using UnityEngine;

public class Interactable : MonoBehaviour
{
    public enum InteractionType
    {
        OpenDoor,
        CollectItem,
        ActivateSwitch
    }

    [Tooltip("What action to perform on the target GameObject")]
    public InteractionType interactionType; // Dropdown in Inspector
    [Tooltip("Select the animator component for the target GameObject (if applicable) Note: Make sure the animator is disabled on initialization")]
    public Animator objectAnimationController; // Select GameObject Animator
    [Tooltip("Select the audio source component for the target GameObject (if applicable)")]
    public AudioSource objectAudioSource; // Select GameObject Audio Source
    [Tooltip("Select the open animation clip (if applicable)")]
    public AnimationClip openAnimation; // Select Open Animation Clip
    [Tooltip("Select the Open Audio clip for this object (if applicable)")]
    public AudioClip openSound; // Select Open Audio Clip
    [Tooltip("Select the close animation clip (if applicable)")]
    public AnimationClip closeAnimation; // Select Close Animation Clip
    [Tooltip("Select the Close Audio clip for this object (if applicable)")]
    public AudioClip closeSound; // Select Close Audio Clip
    [Tooltip("Select the transform component for the target GameObject (if applicable)")]
    public Transform objectTransform; // Select GameObject Transform
    [Tooltip("The rotation of the fully opened position on the GameObject's transform (if applicable)")]
    public Vector3 openedRotation; // Set Fully Opened Rotation in objectTransform, used to reset rotation before animation to prevent the GameObj from moving outside of rotation range
    [Tooltip("The rotation of the fully closed position on the GameObject's transform (if applicable)")]
    public Vector3 closedRotation; // Set Fully Closed Rotation in objectTransform, used to reset rotation before animation to prevent the GameObj from moving outside of rotation range
    [Tooltip("Specifies if the GameObject is locked (closed position) Useful for using with keys")]
    public bool locked = false; // Allows locking the GameObject from being interacted with
    [Tooltip("Specifies if the target GameObject is allowed to be closed (if applicable)")]
    public bool canClose = true; // Allows setting to prevent the door from being closed again
    [Tooltip("Specifies if the target GameObject is currently opened (if applicable)")]
    public bool isOpen = false; // Tells the script if the GameObject is open

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
        if (isOpen == false && locked == false)
        {
            if (objectTransform != null)
            {
                objectTransform.rotation = Quaternion.Euler(openedRotation);
            }
            objectAnimationController.enabled = true;
            objectAnimationController.Play(openAnimation.name);
            if (objectAudioSource != null && openSound != null)
            {
                objectAudioSource.clip = openSound;
                objectAudioSource.Play();
            }
            isOpen = true;
        }
        else if (isOpen == true && canClose == true && locked == false)
        {
            if (objectTransform != null)
            {
                objectTransform.rotation = Quaternion.Euler(closedRotation);
            }
            objectAnimationController.enabled = true;
            objectAnimationController.Play(closeAnimation.name);
            if (objectAudioSource != null && closeSound != null)
            {
                objectAudioSource.clip = closeSound;
                objectAudioSource.Play();
                isOpen = false;
            }
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
