using UnityEngine;
using System.Collections;

namespace Items
{
    public struct Item
    {
        [SerializeField] int _ID;
        [SerializeField] string _Name;
        [SerializeField] int _MaxCount;
    }
}
