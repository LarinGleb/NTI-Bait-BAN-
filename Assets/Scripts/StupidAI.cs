using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Control))]
public class StupidAI : MonoBehaviour
{
    Control control;
    [SerializeField] GameObject Player;
    [SerializeField] float FollowR;

    [SerializeField] float Randomsiation;

    [SerializeField] float TimeToNextMin;
    [SerializeField] float TimeToNextMax;

    [SerializeField] float TimeLeft;
    // Start is called before the first frame update
    void Start()
    {
        control = gameObject.GetComponent("Control") as Control;
        TimeLeft = Random.Range(TimeToNextMin, TimeToNextMax);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        TimeLeft -= Time.deltaTime;
        if(TimeLeft <= 0)
        {
            TimeLeft = Random.Range(TimeToNextMin, TimeToNextMax);

            control.Direction = new Vector3(Random.Range(-0.1f, 0.1f),
                                            Random.Range(-0.1f, 0.1f),
                                            0f);

            
        }
    }
}