using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Shoot {
    GameObject Who;
    GameObject To;
    public Shoot(GameObject who, GameObject where) {
        this.Who = who;
        this.To = where;
    }
    
}
public class InspectorShooting : MonoBehaviour
{
    public List<GameObject> Deaths;

    public static List<Shoot> Inspector;
    
}
