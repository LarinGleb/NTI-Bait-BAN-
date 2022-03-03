using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
 
public class GoPlanet : MonoBehaviour {
    public GameObject Hero;
    public GameObject Spawn;
    //Detect if a click occurs
    public void OnMouseDown()
    {
        //Output to console the clicked GameObject's name and the following message. You can replace this with your own actions for when clicking the GameObject.
        Hero.transform.position = Spawn.transform.position;
        Hero.GetComponent<ControlPlayer>().OnShip = false;
        Hero.GetComponent<Rigidbody2D>().gravityScale = 0f; 
    }
}