using UnityEngine;

public class FramerateTarget : MonoBehaviour
{
    [Range(-1, 300)][Header("Game will TRY to match fps")]
    public int fpsTarget = -1;

    void Awake()
    {
        Application.targetFrameRate = fpsTarget;
    }
}
