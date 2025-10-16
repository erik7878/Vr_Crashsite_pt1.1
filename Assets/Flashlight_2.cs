using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FlashlightController : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;
    private Light flashlight;

    void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        flashlight = GetComponentInChildren<Light>();

        // Ensure flashlight starts off
        if (flashlight != null)
            flashlight.enabled = false;

        // Subscribe to grab events
        grabInteractable.selectEntered.AddListener(OnPickedUp);
        grabInteractable.selectExited.AddListener(OnReleased);
    }

    private void OnPickedUp(SelectEnterEventArgs args)
    {
        if (flashlight != null)
            flashlight.enabled = true;
    }

    private void OnReleased(SelectExitEventArgs args)
    {
        if (flashlight != null)
            flashlight.enabled = false;
    }

    void OnDestroy()
    {
        // Unsubscribe to prevent memory leaks
        grabInteractable.selectEntered.RemoveListener(OnPickedUp);
        grabInteractable.selectExited.RemoveListener(OnReleased);
    }
}

