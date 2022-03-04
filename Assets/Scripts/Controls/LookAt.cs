
using UnityEngine;

namespace Looking
{
    public class LookAt 
    {

        public static Transform LookingAt(Vector3 Position, Transform ObjectTransform)
        {
            float angle = Vector2.Angle(Vector2.right, Position - ObjectTransform.position);//угол между вектором от объекта к мыше и осью х
            ObjectTransform.eulerAngles = new Vector3(0f, 0f, ObjectTransform.position.y < Position.y ? angle : -angle); //немного магии на последок
            return ObjectTransform;
        }
    }

}
