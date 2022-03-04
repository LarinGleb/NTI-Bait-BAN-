using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
 
public class GoPlanet : MonoBehaviour {
    [SerializeField] GameObject Hero;
    [SerializeField] Dialog DManager;

    private int level = 1;
    private bool Tutorial = true;

    public void Generate()
    {
        
        if (Hero.GetComponent<DialogStart>().CanGoPlanet) {
            GameObject Spawn;
            if (Tutorial) {
                Spawn = GetComponent<Generation>().StartGeneration(level, true);
            }
            else {
                Spawn = GetComponent<Generation>().StartGeneration(level);
            }
            Hero.transform.position = new Vector3(Spawn.transform.position.x, Spawn.transform.position.y, -2f);
            Hero.GetComponent<ControlPlayer>().OnShip = false;
            Hero.GetComponent<Rigidbody2D>().gravityScale = 0f; 
            level += 1;
        }

        if(Tutorial) {
            StartCoroutine(DManager.Station());
        }
        
    }

    void Update () {
        if (Input.GetMouseButtonDown(0)) {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);
            if (hit.collider !=null) {
                if (hit.collider.gameObject == gameObject) {
                    Generate();
                }
                
            }
        }
    }
}