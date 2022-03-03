using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Items;

public class InventoryCell : MonoBehaviour
{
    [SerializeField] Item _ItemInCell;
    [SerializeField] bool _IsBusy;
    [SerializeField] bool _IsFull;
    [SerializeField] int _CountItemInCell;

    public Item ItemInCell {
        get {return this._ItemInCell;}
        set {_ItemInCell = value;}
    } 

    public bool IsBusy {
        get {return this._IsBusy;}
        set {_IsBusy = value;}
    } 
    public bool IsFull {
        get {return this._IsFull;}
        set {_IsFull = value;}
    } 
    public int CountItemInCell {
        get {return this._CountItemInCell;}
        set {_CountItemInCell = value;}
    } 

}
