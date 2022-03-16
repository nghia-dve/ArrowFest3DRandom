using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GateType
{
    PLUS,
    MINUS,
    MULTIPLY,
    DIVIDE
}

public class Gate : MonoBehaviour
{

    public GateType Type;
    public int Figure = 1;
    Renderer renderer;
    ArrowControl arrowControl;



    private void Start()
    {
        this.renderer = GetComponent<Renderer>();
        arrowControl = GameObject.FindObjectOfType<ArrowControl>();
        float rd = Random.Range(1, 100);
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            if (rd < 40)
            {
                Type = GateType.PLUS;
                if (rd < 2)
                {
                    Figure = 100;
                }
                else
                if (rd < 4)
                {
                    Figure = 50;
                }
                else
                if (rd < 10)
                {
                    Figure = Random.Range(10, 40);
                }
                else
                {
                    Figure = Random.Range(1, 10);
                }

                this.renderer.material.color = Color.blue;
            }
            else
            if (rd < 100)
            {
                Type = GateType.MULTIPLY;

                Figure = Random.Range(2, 6);


                this.renderer.material.color = Color.blue;

            }
        }
        else
        if (SceneManager.GetActiveScene().buildIndex >= 1)
        {
            if (rd < 30)
            {
                Type = GateType.PLUS;
                if (rd < 2)
                {
                    Figure = 100;
                }
                else
                if (rd < 4)
                {
                    Figure = 50;
                }
                else
                if (rd < 10)
                {
                    Figure = Random.Range(10, 40);
                }
                else
                {
                    Figure = Random.Range(1, 10);
                }

                this.renderer.material.color = Color.blue;
            }
            else
            if (rd < 40)
            {
                Type = GateType.MULTIPLY;

                Figure = Random.Range(2, 6);


                this.renderer.material.color = Color.blue;

            }
            else
        if (rd < 80)
            {
                Type = GateType.MINUS;
                Figure = Random.Range(1, 100);
                this.renderer.material.color = Color.red;
            }
            else
        if (rd < 100)
            {
                Type = GateType.DIVIDE;
                Figure = Random.Range(1, 6);
                this.renderer.material.color = Color.red;
            }
        }



    }



    public void ExecuteLogic()
    {
        switch (Type)
        {
            case GateType.PLUS:

                arrowControl.countArrrow1 = Figure;
                break;
            case GateType.MINUS:

                arrowControl.countArrrow1 = -(Figure);
                break;
            case GateType.MULTIPLY:
                if (arrowControl.listArrow.Count == 0)
                {
                    Figure *= arrowControl.listArrow.Count + 1;
                }
                else
                    Figure *= arrowControl.listArrow.Count;
                arrowControl.countArrrow1 = Figure;
                break;
            case GateType.DIVIDE:

                float a;
                if (arrowControl.listArrow.Count < Figure)
                {
                    a = Figure;
                }
                else
                    a = (arrowControl.listArrow.Count) / Figure;
                arrowControl.countArrrow1 = -(a);
                break;

        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "arrow")
        {
            ExecuteLogic();
            gameObject.SetActive(false);
        }
    }



}
