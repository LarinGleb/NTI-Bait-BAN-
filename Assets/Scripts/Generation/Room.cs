using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    private int[] size;

    public int[] Size {
        get {return size;}
        set {size = value;}
    }

    private Dictionary<int, List<GameObject>> Floors = new Dictionary<int, List<GameObject>>();

    public int GetSize() {
        return Size[0] * Size[1];
    }

    public void AddFloor(int i, GameObject Floor) {
        if(Floors.ContainsKey(i)) {
            List<GameObject> listObjects = Floors[i];
            listObjects.Add(Floor);
            Floors[i] = listObjects;
        }
        else {
            List<GameObject> listObjects = new List<GameObject>();
            listObjects.Add(Floor);
            Floors.Add(i, listObjects);
        }
        
    }


    public List<GameObject> GetFloors() {
        List<GameObject> floors = new List<GameObject>();

        foreach(KeyValuePair<int, List<GameObject>> pair in Floors) {
            foreach (GameObject floor in pair.Value) {
                floors.Add(floor);
            }
        }
        return floors;
    }


}
