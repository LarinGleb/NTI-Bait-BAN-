using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Looking;

public class LookAtCursor : MonoBehaviour
{

    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.eulerAngles = LookAt.LookingAt(mousePosition, transform).eulerAngles;
    }
}
