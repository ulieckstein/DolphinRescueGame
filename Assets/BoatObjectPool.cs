using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class BoatObjectPool : MonoBehaviour
{
    private GameObject[] _boats = null;
    private const float MinBoatDistance = 0.3f;

    public int NumberOfBoatsInPool = 3;


    void Start()
    {
        _boats = new GameObject[NumberOfBoatsInPool];
        InstantiateBoats();
        Debug.Log("Boats Pool activated");
    }

    void FixedUpdate()
    {
        ActivateBoat();
    }

    private void InstantiateBoats()
    {
        for (var i = 0; i < NumberOfBoatsInPool; i++)
        {
            _boats[i] = Instantiate(Resources.Load("Prefabs/Boat")) as GameObject;
            _boats[i].SetActive(false);
        }
    }

    private void ActivateBoat()
    {
        for (var i = 0; i < NumberOfBoatsInPool; i++)
        {
            if (_boats[i].activeInHierarchy == false)
            {
                _boats[i].SetActive(true);
                var offset = PreventOverlappingBoats(Random.Range(2f, 3.5f));
                _boats[i].GetComponent<BoatScript>().Activate(offset); 
                Debug.Log(string.Format("Activate Boat {0} at offset {1}", i, offset));
                return;
            }
        }
    }

    private float PreventOverlappingBoats(float offset)
    {
        while (_boats.Any(b => Math.Abs(offset - b.transform.position.x) < MinBoatDistance))
        {
            Debug.Log("Delay Boat offset"); 
            offset += 0.1f;
        }
        return offset;
    }
}
