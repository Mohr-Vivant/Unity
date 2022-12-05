using UnityEngine;

public class FireProjectile : MonoBehaviour
{
    public enum ObjectPlacement
    {
        ProjectFiles, Scene
    }

    public GameObject balle;
    public ObjectPlacement objectFrom = ObjectPlacement.ProjectFiles;
    public float moveSpeed;
    Rigidbody2D body2D;

    
    public void Fire()
    {
        if (objectFrom == ObjectPlacement.ProjectFiles)
        {
            GameObject balleClone = Instantiate(balle, transform.position, transform.rotation);
            body2D = balleClone.GetComponent<Rigidbody2D>();
        }
        else
        {
            balle.transform.position = transform.position;
            balle.transform.parent = null;
            balle.SetActive(true);
            body2D = balle.GetComponent<Rigidbody2D>();
        }

        body2D.velocity = transform.right * moveSpeed;
    }
}
