using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Generation : MonoBehaviour
{
    private GameObject EmptyRoom;
    [SerializeField] GameObject Wall;
    [SerializeField] GameObject FloorLevel1;
    [SerializeField] GameObject FloorLefel2;
    [SerializeField] GameObject Boss;
    [SerializeField] List<GameObject> AroundObjects;
    [SerializeField] List<GameObject> OnWall;
     //[SerializeField] bool NeedVisual = true;

    struct Rib {
        Vector2 start;
        public Vector2 Start {
            get {return start;}
        }

        Vector2 end;
        public Vector2 End {
            get {return end;}
        }

        int deltaX;
        public int DeltaX {
            get {return deltaX;}
        }

        int deltaY;
        public int DeltaY {
            get {return deltaY;}
        }


        public Rib(Vector2 startPos, Vector2 endPos) {
            this.start = startPos;
            this.end = endPos;

            if (startPos.x < endPos.x)  {
                this.deltaX = 1;
            } else {this.deltaX = -1;}
            
            if (startPos.y < endPos.y)  {
                this.deltaY = 1;
            } else {this.deltaY = -1;}
        }

        public float Distance() {
            return Vector3.Distance(start, end);
        }
        
    };
    
    private List<Rib> ribs = new List<Rib>() {};
    private List<GameObject> RoomsAccesable = new List<GameObject>() {};
    
    private List<Vector2> possibleWalls = new List<Vector2>(4) {new Vector2(-0.161f, -0.16f), new Vector2(0.16f, 0.161f), new Vector2(0.481f, -0.16f), new Vector2(0.16f, -0.481f)};
    private const float floorSize = 0.32f;
    private int countCells = 10;
    private int radiusSize = 10;
    private bool endGeneration = false;
    private List<GameObject> Floors = new List<GameObject>() {};
    
    private void Start() {
        
        EmptyRoom = new GameObject();
        StartGeneration(1);
    }
    private void FillRoom(GameObject Room, int[] Size, GameObject Floor) {
        Collider2D collider = Room.GetComponent<Collider2D>();
        Vector2 roomPosition = new Vector2(collider.bounds.min.x, collider.bounds.max.y);
        
        for (int i = 0; i < Size[0]; i ++) {
            for (int j = 0; j < Size[1]; j ++) {
                GameObject floor = Instantiate(Floor, new Vector2(roomPosition.x, roomPosition.y) + new Vector2(i, -j) * floorSize, Quaternion.identity);
                floor.transform.parent = Room.transform;
                Room.GetComponent<Room>().AddFloor(i, floor);
                Floors.Add(floor);
            }
        }

        collider.isTrigger = true;


    }

    private IEnumerator DrawHitBox(Collider2D coll) {
        float minX = coll.bounds.min.x;
        float minY = coll.bounds.min.y;

        float maxX = coll.bounds.max.x;
        float maxY = coll.bounds.max.y;

        Debug.DrawLine(new Vector2(minX, maxY), new Vector2(maxX, maxY), Color.green, 5, false);
        Debug.DrawLine(new Vector2(maxX, maxY), new Vector2(maxX, minY), Color.green, 5, false);
        Debug.DrawLine(new Vector2(maxX, minY), new Vector2(minX, minY), Color.green, 5, false);
        Debug.DrawLine(new Vector2(minX, minY), new Vector2(minX, maxY), Color.green, 5, false);
        yield return new WaitForSeconds(0.05f);
    }

    private IEnumerator DrawMassiveLines(List<Rib> ribs, Color color, float waitSecond) {
        foreach(Rib rib1 in ribs) {
            Debug.DrawLine(rib1.Start, rib1.End, color, waitSecond, false);
            yield return new WaitForSeconds(0.2f);
        }
        
        
    }   
    private static int GenerateRandomEvenNumber(int leftSide, int rightSide)
        {
 
            int number = 0;
            do
            {
                number = Random.Range(leftSide, rightSide);
            }
            while(number % 2 != 0);
 
        return number;
    }
        
    
    private Vector2 GetEndPoint(Collider2D coll, Rib rib) {
        float x = 0;
        float y = 0;
        switch (rib.DeltaX)
        {
            case 1: x = coll.bounds.max.x; break;
            case -1: x = coll.bounds.min.x; break;

        }

        switch (rib.DeltaY)
        {
            
            case -1: y = coll.bounds.max.y; break;
            case 1: y = coll.bounds.min.y; break;
        }

        return new Vector2(x, y) - new Vector2(rib.DeltaX, -rib.DeltaY) * floorSize;

    }

    public GameObject StartGeneration(int Level) {

        GameObject Floor = null;
        switch (Level) {
            case 1: Floor = FloorLevel1; break;
            case 2: Floor = FloorLefel2; break;
        }
        for (int i = 0; i < countCells; i ++) {
            Vector2 position = new Vector2(GenerateRandomEvenNumber(2, 40), GenerateRandomEvenNumber(2, 40));
            int[] SizeRoom = new int[] {GenerateRandomEvenNumber(4, radiusSize), GenerateRandomEvenNumber(4, radiusSize)};
            position *= floorSize;
            GameObject Room = Instantiate(EmptyRoom, position, Quaternion.identity);
            BoxCollider2D roomColl = Room.AddComponent<BoxCollider2D>();
            roomColl.size = new Vector2(SizeRoom[0], SizeRoom[1]) * floorSize;
            Room RoomScript = Room.AddComponent<Room>();
            RoomScript.Size = SizeRoom;
            Room.name = "" + i;
            RoomsAccesable.Add(Room);
            List<GameObject> newRooms = new List<GameObject>(RoomsAccesable);
            //if (NeedVisual) {yield return new WaitForSeconds(0.1f);}
            
        }

        //if (NeedVisual)  {yield return new WaitForSeconds(3f);}
        List<GameObject> Rooms = new List<GameObject>(RoomsAccesable) {};
        foreach(GameObject Room in Rooms) {
            Collider2D roomColl = Room.GetComponent<Collider2D>();
            //if (NeedVisual) {StartCoroutine(DrawHitBox(roomColl));}
            foreach (GameObject inserts in Rooms)
            {
                Collider2D coll = inserts.GetComponent<Collider2D>();
                
                if (roomColl.bounds.Intersects(coll.bounds) && inserts != Room) {    
                    Destroy(inserts);
                    RoomsAccesable.Remove(inserts);
                        
                }

            }
            
        }
        
        foreach(GameObject Room in RoomsAccesable) {FillRoom(Room, Room.GetComponent<Room>().Size, Floor);}
        RoomsAccesable = RoomsAccesable.OrderBy(m => m.GetComponent<Room>().GetSize()).ToList();

        int countVertex = RoomsAccesable.Count;
        Dictionary<Vector2, List<Vector2>> ribsDict = new Dictionary<Vector2, List<Vector2>>();
        for (int i = 0; i < countVertex; i ++) {
            for (int j = 0; j < countVertex; j ++) {
                Vector2 pointToCheck = RoomsAccesable[j].transform.position;
                Vector2 mainPoint = RoomsAccesable[i].transform.position;
                if (pointToCheck != mainPoint) {
                    if (!ribsDict.ContainsKey(mainPoint) ) {
                        List<Vector2> points = new List<Vector2>() {pointToCheck};
                        ribsDict.Add(mainPoint, points);
                    }
                    
                    else {
                        List<Vector2> points = ribsDict[mainPoint];
                        points.Add(pointToCheck);
                        ribsDict[mainPoint] = points;
                    }
                }
            }
        }

        
        List<Rib> hallways = new List<Rib> () {};
        foreach(GameObject Room in RoomsAccesable) {
            Vector2 positionRoom = Room.transform.position;
            List<Vector2> possibleRibs = ribsDict[positionRoom];
            List<Rib> ribs = new List<Rib>() {};
            foreach(Vector2 positionPoint in possibleRibs) {
                ribs.Add(new Rib(positionRoom, positionPoint));
            }

            
            ribs = ribs.OrderBy(rib => rib.Distance()).ToList();
            //if (NeedVisual) {StartCoroutine(DrawMassiveLines(ribs, Color.green, 2f)); yield return new WaitForSeconds(2f);}
            int minOutToDelete = 0;
            int maxOutToDelete = 0;
            if (ribs.Count > 1) {
                maxOutToDelete = 3;
                minOutToDelete = 1;
            }
            else {
                hallways.Add(ribs[0]);
                continue;
            }

            int countToDelete = Random.Range(minOutToDelete, maxOutToDelete);
            for (int i = 0; i < countToDelete; i ++) {
                hallways.Add(ribs[i]);
            }

            
        }


        //if (NeedVisual) {StartCoroutine(DrawMassiveLines(hallways, Color.yellow, 2f)); yield return new WaitForSeconds(3f);}
        for (int i = 0; i < hallways.Count; i ++) {
            Rib reverseRib = new Rib(hallways[i].End, hallways[i].Start);
            if (hallways.Contains(reverseRib)) {
                hallways.Remove(reverseRib);
                i +=1;
            }
        }
        
        
        foreach (Rib hallway in hallways)
        {
            GameObject StartRoomGeneration = null; 
            GameObject EndRoomGeneration = null;

            foreach (GameObject Room in RoomsAccesable)
            {
                if (Room.transform.position == new Vector3(hallway.Start.x, hallway.Start.y, 0f)) {
                    StartRoomGeneration = Room;
                    
                }
                else if(Room.transform.position == new Vector3(hallway.End.x, hallway.End.y, 0f)) {
                    EndRoomGeneration = Room;
                    
                }
            }

            

            Vector2 StartEdge = GetEndPoint(StartRoomGeneration.GetComponent<Collider2D>(), hallway);
            Vector2 EndEdge = GetEndPoint(EndRoomGeneration.GetComponent<Collider2D>(), hallway) ;
            

            int distanceX = (int)(Mathf.Abs(StartEdge.x - EndEdge.x) / floorSize);
            int distanceY = (int)(Mathf.Abs(StartEdge.y - EndEdge.y) / floorSize);

            Vector2 positionFloor = new Vector2(0f, 0f);
            for (int i = 0; i < distanceX + 1; i ++) {
                positionFloor = StartEdge + new Vector2(i, 0f) * floorSize * hallway.DeltaX;
                GameObject floor = Instantiate(Floor, positionFloor, Quaternion.identity);
                Floors.Add(floor);
            }

            Vector2 StartPos = positionFloor;
            for (int i = 0; i < distanceY + 1; i ++) {
                positionFloor = StartPos + new Vector2(0f, i) * floorSize * hallway.DeltaY;
                GameObject floor = Instantiate(Floor, positionFloor, Quaternion.identity);
                Floors.Add(floor);
            }

        }
        int angle;
        foreach (GameObject floor in Floors)
        {
            angle = 0;
            Vector2 position = floor.transform.position;
            
            for (int i = 0; i < 4; i++) {
                GameObject wall = Instantiate(Wall, position + possibleWalls[i], Quaternion.identity);
                wall.transform.Rotate(0, 0, angle);
                foreach (GameObject possibleFloor in Floors)
                {
                    if (possibleFloor.GetComponent<Collider2D>().bounds.Intersects(wall.GetComponent<Collider2D>().bounds)) {
                        Destroy(wall);
                    }
                }
                angle -= 90;
            }
        }

        foreach (GameObject floor in Floors)
        {
            floor.GetComponent<BoxCollider2D>().isTrigger = true;
        }

        foreach (GameObject Room in RoomsAccesable) {
            Room roomScript = Room.GetComponent<Room>();
            List<GameObject> Floors = roomScript.GetFloors();
            for (int i = 0; i < Random.Range(0, (roomScript.Size[0] + roomScript.Size[1]) / 2); i ++) {
                GameObject floor = Floors[Random.Range(0, Floors.Count)];
                Floors.Remove(floor);
                Vector3 center = floor.GetComponent<Collider2D>().bounds.center;
                Vector3 position = new Vector3(center.x, center.y, -2f);
                GameObject objectAround = Instantiate(AroundObjects[Random.Range(0, AroundObjects.Count)], position, Quaternion.identity);

            }
            

        }
        
        GameObject BossRoom = RoomsAccesable[RoomsAccesable.Count - 1];
        Vector3 positionBoss = new Vector3(BossRoom.transform.position.x, BossRoom.transform.position.y, -2f);
        GameObject boss = Instantiate(Boss, positionBoss, Quaternion.identity);

        RoomsAccesable.Remove(BossRoom);    
        return RoomsAccesable[Random.Range(0, RoomsAccesable.Count)];

    }




}
