using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField] int[] size;

    public int[] Size {
        get {return size;}
        set {size = value;}
    }
}
