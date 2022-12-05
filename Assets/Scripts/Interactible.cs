using UnityEngine;
using UnityEngine.Events;   // Cette ligne est requise pour déclarer les variables de type UnityEvent

public class Interactible : MonoBehaviour
{
    #region VARIABLES
    public enum Contact {
        Any, Trigger, Collision
    }
    public Contact contactWanted = Contact.Any;    // A régler dans l'Inspector selon le type de contact voulu ou non
    public LayerMask layerFilter;                   // A régler dans l'Inspector pour filtrer les contacts selon les layers
    public GameObject specificTarget;               // Possibilité de préciser une cible précise plutôt qu'un layer
    public UnityEvent eventsOnEnter, eventsOnStay, eventsOnExit;    // A régler dans l'Inspector selon les évènements désirés
    #endregion

    #region VERIFICATION & EXECUTION
    void ExecuteEvent(Contact contactFound, GameObject go, UnityEvent evtWanted)
    {
        // Si le contact détecté est bien celui désiré et sur le bon layer...
        if ((contactFound == contactWanted || contactWanted == Contact.Any) && (layerFilter.value & 1 << go.layer) > 0 && (!specificTarget ? true : go == specificTarget))
        {
            // ...Alors on éxécute la chaine d'évènement
            evtWanted.Invoke();
        }
    }
    #endregion

    // Fonctions de base déclenchées lors d'un contact avec un collider2D en mode "is Trigger = true" (traverse l'objet)
    #region TRIGGER
    void OnTriggerEnter2D(Collider2D other)
    {
        ExecuteEvent(Contact.Trigger, other.gameObject, eventsOnEnter);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        ExecuteEvent(Contact.Trigger, other.gameObject, eventsOnStay);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        ExecuteEvent(Contact.Trigger, other.gameObject, eventsOnExit);
    }
    #endregion

    // Fonctions de base déclenchées lors d'un contact avec un collider2D en mode "is Trigger = false" (cogne l'objet)
    #region COLLISION
    void OnCollisionEnter2D(Collision2D other)
    {
        ExecuteEvent(Contact.Collision, other.gameObject, eventsOnEnter);
    }

    void OnCollisionStay2D(Collision2D other)
    {
        ExecuteEvent(Contact.Collision, other.gameObject, eventsOnStay);
    }

    void OnCollisionExit2D(Collision2D other)
    {
        ExecuteEvent(Contact.Collision, other.gameObject, eventsOnExit);
    }
    #endregion
}
