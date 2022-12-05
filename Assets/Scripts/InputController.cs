using UnityEngine;
using UnityEngine.Events;

public class InputController : MonoBehaviour
{
    public KeyCode onKey;
    public enum PressType {
        pressed, held, released
    }
    public PressType pressType;
    public UnityEvent eventsOnKeyPress;

    void Update()
    {
        if ((pressType == PressType.pressed && Input.GetKeyDown(onKey)) ||
            (pressType == PressType.held && Input.GetKey(onKey)) ||
            (pressType == PressType.released && Input.GetKeyUp(onKey)))
            eventsOnKeyPress.Invoke();
    }
}
