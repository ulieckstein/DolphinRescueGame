using UnityEngine;
using System.Collections;

public class DolphinObjectPool : MonoBehaviour
{
    private GameObject[] _dolphins = null;

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
                var offset = Random.Range(-1f, 1.5f);
                _dolphins[i].GetComponent<DolphinScript>().Activate(offset + i);
                return;
            }
        }
    }
}
