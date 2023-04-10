using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touch : MonoBehaviour
{

    [SerializeField] GameObject[] shapes;
    [SerializeField] Transform spawnPos;
    Vector2 activePos;
    public int shapeIndicator;
    void Start()
    {
        shapes[shapeIndicator].transform.position = spawnPos.position;
        ChangeShape();
    }
    void Update()
    {
        HandleTouch();
    }
    void HandleTouch()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                ChangeShape();
            }
        }
    }
    void ChangeShape()
    {
        activePos = shapes[shapeIndicator].transform.position;
        shapeIndicator++;
        if (shapeIndicator >= 3) shapeIndicator = 0;
        foreach (var shape in shapes)
        {
            shape.SetActive(false);
        }
        shapes[shapeIndicator].SetActive(true);
        shapes[shapeIndicator].transform.position = activePos;
    }
}
