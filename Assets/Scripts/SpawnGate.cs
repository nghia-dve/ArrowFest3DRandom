using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGate : MonoBehaviour
{
    [SerializeField]
    List<GameObject> listSpawnGate = new List<GameObject>();
    [SerializeField]
    GameObject gate;
    int countSpawnGate;

    // Start is called before the first frame update
    void Start()
    {
        countSpawnGate = listSpawnGate.Count;

    }

    // Update is called once per frame
    void Update()
    {


        if (countSpawnGate > 0)
        {
            float rd = Random.Range(1, 10);
            if (rd < 6)
            {
                Instantiate(gate, listSpawnGate[listSpawnGate.Count - countSpawnGate].transform.position, listSpawnGate[1].transform.rotation);
                countSpawnGate--;
            }
            else
                if (rd < 10)
            {
                countSpawnGate--;
            }

        }

        /* for (int i = 0; i < listSpawnGate.Count; i++)
         {
             Debug.Log(listSpawnGate);
             //
         }*/
    }
}
