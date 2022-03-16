using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowControl : MonoBehaviour
{
    [SerializeField]
    GameObject arrowPrefab;
    [SerializeField]
    GameObject arrowPrefabHuman;
    [SerializeField]
    GameObject arrow;
    public List<GameObject> listArrow = new List<GameObject>();
    [HideInInspector]
    public float countArrrow1 = 0;
    [HideInInspector]
    public float scorArrow = 0;
    [SerializeField]
    float radius = 0.05f;
    GameObject arrowClone;
    float checkHuman;
    float checkHumanFinish;
    float timeCheck = 2f;
    [SerializeField]
    Collider collider;
    [SerializeField]
    GameManager gameManager;
    [SerializeField]
    ArrowMove arrowMove;
    [SerializeField]
    CameraControl cameraControl;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        arrowClone = GameObject.FindGameObjectWithTag("arrow1");
        if (countArrrow1 > 0)
        {
            //Instantiate(arrow, transform.position + new Vector3(x, y, 0), transform.rotation);
            //listArrow.Add(Instantiate(arrowPrefab, transform.localPosition, arrow.transform.rotation));
            /*GameObject addedPlayer = Instantiate(arrowPrefab, arrow.transform);
            addedPlayer.transform.localPosition = new Vector3(Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f), transform.localPosition.z);*/
            GameObject addedArrow = Instantiate(arrowPrefab, transform);
            //addedArrow.transform.localPosition = new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f), transform.localPosition.z);
            listArrow.Add(addedArrow);
            countArrrow1--;


        }

        Arrow();
        if (countArrrow1 < 0)
        {
            if (arrowClone != null)
            {
                listArrow.Remove(arrowClone);
                arrowClone.SetActive(false);
                countArrrow1++;
            }
            if (arrowClone == null)
            {

                gameObject.SetActive(false);
                gameManager.btRestart.SetActive(true);
                countArrrow1++;
            }
        }
        if (checkHuman > 0)
        {
            Debug.LogWarning(checkHuman);
            //listArrow.Remove(arrowClone);
            //arrowClone.SetActive(false);
            //arrowClone.GetComponent<ArrowFollow>().enabled = false;
            if (arrowClone != null)
            {

                checkHuman--;

                listArrow.Remove(arrowClone);
                arrowClone.SetActive(false);
                //countArrrow++;

            }
            if (arrowClone == null)
            {
                //Debug.Log("dv");
                gameObject.SetActive(false);
                //countArrrow++;
                /*if (arrowMove.checkFinish)
                {
                    gameManager.btWin.SetActive(true);
                }
                else*/
                gameManager.btRestart.SetActive(true);
                checkHuman--;
            }


        }
        if (checkHumanFinish > 0)
        {
            timeCheck -= Time.deltaTime;
            if (timeCheck < 0)
            {

                gameManager.btWin.SetActive(true);

            }

        }



    }
    void MoveObjects(Transform objectsTransform, float degree)
    {
        Vector3 pos = Vector3.zero;
        pos.x = Mathf.Cos(degree * Mathf.Deg2Rad);
        pos.y = Mathf.Sin(degree * Mathf.Deg2Rad);
        objectsTransform.localPosition = pos * radius;
    }
    void Arrow()
    {
        float angle = 1f;
        float arrowCount = listArrow.Count;
        angle = 360 / arrowCount;
        for (int i = 0; i < arrowCount; i++)
        {
            MoveObjects(listArrow[i].transform, i * angle);

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "human")
        {

            checkHuman = 3;
            Instantiate(arrowPrefabHuman, other.gameObject.transform.position, arrow.transform.rotation);
            gameManager.coin++;

        }
        if (other.tag == "humanfinish")
        {

            checkHumanFinish = listArrow.Count + 1;
            arrowMove.speedArrow = 0;

            Instantiate(arrowPrefabHuman, other.gameObject.transform.position, arrow.transform.rotation);

        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "humanfinish")
        {

            checkHumanFinish = listArrow.Count + 1;
            arrowMove.speedArrow = 0;

            Instantiate(arrowPrefabHuman, collision.gameObject.transform.position, arrow.transform.rotation);
            cameraControl.TransitionSpeed = 2f;
            cameraControl.Offset = new Vector3(cameraControl.Offset.x, 0.5f, -1.98f);
            gameManager.coin += listArrow.Count + 1;

        }
    }

}
