using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class EventSystemChecker : MonoBehaviour
{
    //public GameObject eventSystem;

    // Use this for initialization
    void Awake()
    {
        if (!FindObjectOfType<EventSystem>())
        {
            //Instantiate(eventSystem);
            GameObject obj = new GameObject("EventSystem");
            obj.AddComponent<EventSystem>();
            obj.AddComponent<StandaloneInputModule>();  // Removed forceModuleActive as it's no longer needed
        }
    }
}
