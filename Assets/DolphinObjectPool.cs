using System;
using System.Linq;
using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;

public class DolphinObjectPool : MonoBehaviour
{
    private GameObject[] _dolphins = null;
    private const float MinDolphinDistance = 0.1f;

    public int NumberOfDolphinsInPool = 2;
    
	void Start () {
	    _dolphins = new GameObject[NumberOfDolphinsInPool];
	    InstantiateDolphins();
	}

    void FixedUpdate()
    {
        ActivateDolphin();
    }

    private void InstantiateDolphins()
    {
        for (var i = 0; i < NumberOfDolphinsInPool; i++)
        {
            _dolphins[i] = Instantiate(Resources.Load("Prefabs/Dolphin")) as GameObject;
            _dolphins[i].SetActive(false);
        }
    }

    private void ActivateDolphin()
    {
        for (var i = 0; i < NumberOfDolphinsInPool; i++)
        {
            if (_dolphins[i].activeInHierarchy == false)
            {
                _dolphins[i].SetActive(true);
                var offset = Random.Range(2f, 3.5f);
                _dolphins[i].GetComponent<DolphinScript>().Activate(offset + i);
                return;
            }
        }
    }

    private float PreventOverlappingDolphins(float offset)
    {
        while (_dolphins.Any(b => Math.Abs(offset - b.transform.position.x) < MinDolphinDistance))
        {
            Debug.Log("Delay Boat offset");
            offset += 0.03f;
        }
        return offset;
    }
}
