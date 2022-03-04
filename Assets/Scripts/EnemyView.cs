using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class EnemyView : MonoBehaviour
{
    [SerializeField] private int _Count = 16;
    [SerializeField] private float _Distance = 100;

    [SerializeField] private float _FOV;

    
    [SerializeField] private Transform Head;

    [SerializeField] private Transform Eye;

    [SerializeField] private Transform[] Me;

    private void Update() {
        float[] Distanses = GetDistance(GetAroundHits(_Distance));
        string[] Tags = GetTags(GetAroundHits(_Distance));
        
    }

    private float[] GetDistance(RaycastHit2D[] hits)
    {
        float[] distanses = new float[_Count];
        for (int i = 0; i < _Count; i++) {
            if (hits[i].collider == null) {
                distanses[i] = -1f;
            }
            else {
                distanses[i] = hits[i].distance;
            }
        }
        return distanses;
    }

    private string[] GetTags(RaycastHit2D[] hits)
    {
        string[] tags = new string[_Count];
        for (int i = 0; i < _Count; i++) {
            if (hits[i].collider == null) {
                tags[i] = "";
            }
            else {
                tags[i] = hits[i].collider.gameObject.tag;
            }
        }
        return tags;
    }


    private RaycastHit2D[] GetAroundHits (float distance)
    {
        float angleStep = _FOV/(float)_Count;
        RaycastHit2D[] hits = new RaycastHit2D[_Count];
        
        for (int i = 0; i < _Count; i++) 
        {   
            
            float angle = i * angleStep + Head.rotation.eulerAngles.z - 90;
            float radian = angle * Mathf.Deg2Rad;

            Vector2 direction = new Vector2(Mathf.Cos(radian), Mathf.Sin(radian));

            Debug.DrawRay(Eye.position, direction);

            hits[i] = Physics2D.Raycast(Eye.position, direction, distance);

        }
        return hits;
    }
}
