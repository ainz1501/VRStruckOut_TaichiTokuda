using UnityEngine;
using Valve.VR;

public class HandGrab : MonoBehaviour
{
    public SteamVR_Input_Sources handType;
    public SteamVR_Action_Boolean grabAction;

    private Throwable currentThrowable;  
    
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("On Trigger");
        if (other.gameObject.TryGetComponent(out Throwable throwable))
        {
            currentThrowable = throwable;
        }
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("Exit Trigger");
        if (other.gameObject.TryGetComponent(out Throwable throwable) && currentThrowable == throwable)
        {
            currentThrowable = null;
        }
    }

    void Update()
    {
        if (grabAction.GetStateDown(handType) && currentThrowable != null)
        {
            Debug.Log("Caught ball");
            currentThrowable.PickUp(transform);
        }

        if (grabAction.GetStateDown(handType))
        {
            Debug.Log("Push trigger");
        }  

        // if (grabAction.GetState(handType) && currentThrowable != null)
        // {
        //     Debug.Log("Caught ball");
        //     currentThrowable.Helding();
        // }



        if (grabAction.GetStateUp(handType) && currentThrowable != null)
        {
            Debug.Log("Caught ball");
            currentThrowable.Release();
            currentThrowable = null;
        }

        if (grabAction.GetStateUp(handType))
        {
            Debug.Log("Release trigger");
        }
    }

    public Throwable CurrentThrowable => currentThrowable;
}
