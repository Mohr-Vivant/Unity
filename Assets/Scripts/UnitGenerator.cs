using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitGenerator : MonoBehaviour
{
    public KeyCode key;
    public GameObject unit;
    public GameObject spawnPoint;
    private Vector3 spawnPosition;


    // Start is called before the first frame update
    void Start()
    {
        spawnPosition = spawnPoint.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(key))
        {
            UnitSpawn();
        }
    }

    void UnitSpawn()
    {
        Instantiate(unit, spawnPosition, Quaternion.AngleAxis(0, spawnPosition));
    }
}
