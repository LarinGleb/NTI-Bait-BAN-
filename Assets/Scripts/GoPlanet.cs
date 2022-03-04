using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
 
public class GoPlanet : MonoBehaviour {
    [SerializeField] GameObject Hero;

    private int level = 1;

    public void OnMouseDown()
    {
        GameObject Spawn = GetComponent<Generation>().StartGeneration(level);
        Hero.transform.position = new Vector3(Spawn.transform.position.x, Spawn.transform.position.y, -2f);
        Hero.GetComponent<ControlPlayer>().OnShip = false;
        Hero.GetComponent<Rigidbody2D>().gravityScale = 0f; 
        level += 1;
    }
}