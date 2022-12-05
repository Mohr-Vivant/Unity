using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Chrono : MonoBehaviour
{
    public float timer = 0f;
    public Text displayUI;
    public TextMesh displayTextMesh;
    public float timeBeforeEvent = 0f;
    public UnityEvent timedEvent;

    void Update()
    {
        // on incrémente le temps
        timer = timer + Time.deltaTime;

        // on affiche le temps simplifié seulement si displayUI existe (un gameobject avec component Image dans un canvas)
        if ( displayUI != null )
            displayUI.text = "" + (int)timer;

        // Même chose mais pour un gameobject hors du canvas avec le component TextMesh
        if ( displayTextMesh != null )
            displayTextMesh.text = "" + (int)timer;

        // on vérifie si on a atteint le temps d'un event
        if (timer >= timeBeforeEvent && timeBeforeEvent != 0 ){
            enabled = false;
            timedEvent.Invoke();
        }
    }

    public void ResetTimer()
    {
        timer = 0f;
        enabled = true;
    }
}
