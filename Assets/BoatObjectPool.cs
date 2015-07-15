using System.Collections;
using UnityEngine;

public class BoatObjectPool : MonoBehaviour
{
    private GameObject[] _boats = null;

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
                Debug.Log(string.Format("Activate Boat {0}", i));
                _boats[i].SetActive(true);
                var offset = Random.Range(-1f, 1.5f);
                _boats[i].GetComponent<BoatScript>().Activate(offset + i); 
                return;
            }
        }
    }

    IEnumerator DelayedActivation()
    {
        var waitSeconds = Random.Range(5.0f, 20.0f);
        Debug.Log("waiting " + waitSeconds);
        yield return new WaitForSeconds(waitSeconds);
        ActivateBoat();
    }
}
