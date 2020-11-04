using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    private bool isActive = true;   //первый клик или нет

    public GameObject point, hero; 

    private int countPoint = 3; //кол-во точек
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && isActive)
        {
            for (int i = 0; i < countPoint; i++)
            {
                point = Instantiate(point, transform.position, Quaternion.identity);
                point.transform.position = new Vector3(Random.Range(-2.2f, 2.2f), Random.Range(-4.5f, 4.5f), 1);
                point.gameObject.name = "Point" + i;
            }
            isActive = !isActive;

            Instantiate(hero, transform.position, Quaternion.identity);
        }
    }
}
