using UnityEngine;

public class Follow : MonoBehaviour
{
    [Header("Cas 1: suivre une cible")]
    public Transform followOneTarget;
    public bool isInstantaneous = false;
    public float speedToTarget = 1f;
    Rigidbody2D body2d;
    
    [Header("Cas 2: suivre un chemin")]
    public Transform[] followPath;
    public float speed = 5f;
    public float precision = 0.2f;
    public bool pathIsOpen;

    int currentPath = 0;
    bool loopingBack = false;
    Vector3 vFollow = Vector3.zero;

    void Start()
    {
        if (followOneTarget)
            body2d = GetComponent<Rigidbody2D>();
        else if (followPath.Length > 0)
            transform.position = followPath[currentPath].position;
            
    }

    void Update()
    {
        if (followOneTarget)
        {

            if (isInstantaneous)
            {
                Vector3 newPos = followOneTarget.position;
                newPos.z = transform.position.z;
                if (body2d)
                    body2d.MovePosition(newPos);
                else
                    transform.position = newPos;
            } else {
                Vector3 vFollow = followOneTarget.position - transform.position;
                vFollow.z = 0f;
                if (body2d)
                    body2d.velocity = vFollow.normalized * speedToTarget;
                else
                    transform.position += vFollow * speedToTarget * Time.deltaTime;
            }

        }
        else if (followPath.Length > 0)
        {
            if (Vector2.Distance(followPath[currentPath].position, transform.position) <= precision)
            {
                currentPath += loopingBack ? -1 : 1;

                if (!loopingBack && currentPath > followPath.Length - 1)
                {
                    currentPath = pathIsOpen ? currentPath - 1 : 0;
                    loopingBack = pathIsOpen ? !loopingBack : false;
                }
                else if (loopingBack && currentPath < 0)
                {
                    currentPath = 1;
                    loopingBack = false;
                }

                vFollow = (followPath[currentPath].position - transform.position).normalized;
                vFollow.z = 0f;
            }
            transform.position += vFollow * speed * Time.deltaTime;
        }
    }

    public void ChangeOneTarget(Transform newTarget)
    {
        followOneTarget = newTarget;
        body2d = GetComponent<Rigidbody2D>();
    }
}
