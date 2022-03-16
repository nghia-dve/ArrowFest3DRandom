using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHuman : MonoBehaviour
{
    [SerializeField]
    List<GameObject> listSpawnHuman = new List<GameObject>();
    [SerializeField]
    GameObject human;
    int countSpawnGate;

    // Start is called before the first frame update
    void Start()
    {
        countSpawnGate = listSpawnHuman.Count;

    }

    // Update is called once per frame
    void Update()
    {


        if (countSpawnGate > 0)
        {
            float rd = Random.Range(1, 10);
            if (rd < 4)
            {
                Instantiate(human, listSpawnHuman[listSpawnHuman.Count - countSpawnGate].transform.position, transform.rotation);
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
