using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    public Transform[] point = new Transform[3];

    private LineRenderer lineRenderer;

    public float speed = 2.0f;

    private int nextPos;

    Vector2 dir;
    float angle;

    
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.SetWidth(0.05f, 0.05f);

        for (int i = 0; i < point.Length; ++i)
        {
            point[i] = GameObject.Find("Point" + i).transform;
        }

        nextPos = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Draw();
    }

    private void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, point[nextPos].position, speed * Time.deltaTime);


        dir = point[nextPos].position - transform.position;
        angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 5f * Time.deltaTime);

        if (Vector2.Distance(transform.position, point[nextPos].position) < 0.0002f && nextPos != 2)
        {
            Destroy(point[nextPos].gameObject);
            nextPos++; 
        }
    }

    private void Draw()
    {
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, point[nextPos].position);
    }
}
