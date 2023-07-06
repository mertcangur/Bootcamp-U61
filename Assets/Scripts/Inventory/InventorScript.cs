using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorScript : MonoBehaviour
{
    Inventory inv;
    public int id;
    public GameObject TheObject;
    public GameObject FoundObject;
    
    void Start()
    {
        inv = GameObject.FindGameObjectWithTag("InventoryManagement").GetComponent<Inventory>();
        
    }
    
    private void OnTriggerEnter(Collider obj)
    {
            inv.AddItem(id);
            Destroy(this.gameObject);
    }
    void OnMouseDown(){
        inv.AddItem(id);
        Destroy(this.gameObject);
    }
}
