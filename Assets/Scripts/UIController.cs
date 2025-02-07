using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class UIController : MonoBehaviour
{
    [Tooltip("List of CanvasScalers to adjust")]
    public List<CanvasScaler> canvasScalers = new List<CanvasScaler>(); // List of CanvasScalers to adjust
    [Tooltip("Extra small resolution (480p)")]
    public Vector2 extraSmallResolution; // Extra small resolution (480p)
    [Tooltip("Small resolution (720p)")]
    public Vector2 smallResolution; // Small resolution (720p)
    [Tooltip("Normal resolution (1080p)")]
    public Vector2 normalResolution; // Normal resolution (1080p)
    [Tooltip("Big resolution (1440p)")]
    public Vector2 bigResolution; // Big resolution (1440p)
    [Tooltip("Reference to the GUI scale button for 480p")]
    public GameObject guiScaleButton1; // Reference to the GUI scale button for 480p
    [Tooltip("Reference to the GUI scale button for 720p")]
    public GameObject guiScaleButton2; // Reference to the GUI scale button for 720p
    [Tooltip("Reference to the GUI scale button for 1080p")]
    public GameObject guiScaleButton3; // Reference to the GUI scale button for 1080p
    [Tooltip("Reference to the GUI scale button for 1440p")]
    public GameObject guiScaleButton4; // Reference to the GUI scale button for 1440p

    private void Start()
    {
        // Load and apply saved UI scale
        int savedScale = PlayerPrefs.GetInt("UIScale", 720); // Default to 720
        ApplyUIScale(savedScale);
    }

    private void ApplyUIScale(int resolution)
    {
        // Apply the UI scale based on the resolution saved in PlayerPrefs
        switch (resolution)
        {
            case 480:
                ScaleUI480();
                break;
            case 720:
                ScaleUI720();
                break;
            case 1080:
                ScaleUI1080();
                break;
            case 1440:
                ScaleUI1440();
                break;
        }
    }

    public void ScaleUI480()
    {
        SetResolutionForAll(extraSmallResolution); // Set the resolution for all CanvasScalers to extraSmallResolution
        guiScaleButton1.SetActive(true); // Enable the GUI scale button for 480p (on action, the button calls ScaleUI720())
        guiScaleButton2.SetActive(false); // Disable the GUI scale button for 720p
        guiScaleButton3.SetActive(false); // Disable the GUI scale button for 1080p
        guiScaleButton4.SetActive(false);  // Disable the GUI scale button for 1440p
        PlayerPrefs.SetInt("UIScale", 480); // Save the UI scale preference
        PlayerPrefs.Save(); // Save the PlayerPrefs
    }

    public void ScaleUI720()
    {
        SetResolutionForAll(smallResolution); // Set the resolution for all CanvasScalers to smallResolution
        guiScaleButton1.SetActive(false); // Disable the GUI scale button for 480p
        guiScaleButton2.SetActive(true); // Enable the GUI scale button for 720p (on action, the button calls ScaleUI1080())
        guiScaleButton3.SetActive(false); // Disable the GUI scale button for 1080p
        guiScaleButton4.SetActive(false);  // Disable the GUI scale button for 1440p
        PlayerPrefs.SetInt("UIScale", 720); // Save the UI scale preference
        PlayerPrefs.Save(); // Save the PlayerPrefs
    }

    public void ScaleUI1080()
    {
        SetResolutionForAll(normalResolution); // Set the resolution for all CanvasScalers to normalResolution
        guiScaleButton1.SetActive(false); // Disable the GUI scale button for 480p
        guiScaleButton2.SetActive(false); // Disable the GUI scale button for 720p
        guiScaleButton3.SetActive(true); // Enable the GUI scale button for 1080p (on action, the button calls ScaleUI1440())
        guiScaleButton4.SetActive(false);  // Disable the GUI scale button for 1440p
        PlayerPrefs.SetInt("UIScale", 1080); // Save the UI scale preference
        PlayerPrefs.Save(); // Save the PlayerPrefs
    }

    public void ScaleUI1440()
    {
        SetResolutionForAll(bigResolution); // Set the resolution for all CanvasScalers to bigResolution
        guiScaleButton1.SetActive(false); // Disable the GUI scale button for 480p
        guiScaleButton2.SetActive(false); // Disable the GUI scale button for 720p
        guiScaleButton3.SetActive(false); // Disable the GUI scale button for 1080p
        guiScaleButton4.SetActive(true);  // Enable the GUI scale button for 1440p (on action, the button calls ScaleUI480())
        PlayerPrefs.SetInt("UIScale", 1440); // Save the UI scale preference
        PlayerPrefs.Save(); // Save the PlayerPrefs
    }

    private void SetResolutionForAll(Vector2 resolution) // Set the reference resolution for all CanvasScalers
    {
        foreach (var scaler in canvasScalers) // For each CanvasScaler in the list
        {
            scaler.referenceResolution = resolution; // Set the reference resolution
        }
    }
}
