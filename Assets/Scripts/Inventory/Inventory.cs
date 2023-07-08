using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI; 

public class Inventory : MonoBehaviour
{
    public ItemDataBase database;
    int sloteAmount = 9;
   public GameObject slot;
   public GameObject hotbarPanel;
   public GameObject invItem;

   public List<GameObject> slots = new List<GameObject>();
   public List<Item> items = new List<Item>();
    void Start()
    {
        database = gameObject.GetComponent<ItemDataBase>();
        for(int i =0; i<sloteAmount; i++){
            items.Add(database.GetItemByID(-1));
            slots.Add(Instantiate(slot));
            slots[i].GetComponent<SlotScripts>().slotNumber = i;
            slots[i].transform.SetParent(hotbarPanel.transform);
            slots[i].GetComponent<RectTransform>().transform.localScale = Vector3.one;
        }
        
      
        
    }
    private void Update(){
        if(Input.GetKeyDown(KeyCode.Tab)){
            ToggleInventory();
        }
    }

    public void AddItem(int id){
        Item itemToAdd = database.GetItemByID(id);
        if (itemToAdd.Stackable && CheckInventory(itemToAdd)) {
            for(int i = 0; i < items.Count; i++){
                if(items[i].ID == id){
                    ItemData data = slots[i].transform.GetChild(0).GetComponent<ItemData>();
                    data.amount++;
                    data.transform.GetChild(0).GetComponent<TMP_Text>().text = data.amount.ToString();
                }
            }
            
            
        }else{
            for(int i = 0; i < items.Count; i++){
                if(items[i].ID == -1){
                    items[i] = itemToAdd;
                    GameObject itemObj = Instantiate(invItem);
                    itemObj.GetComponent<ItemData>().item = itemToAdd;
                    itemObj.GetComponent<ItemData>().curSlot = i;
                    itemObj.transform.SetParent(slots[i].transform);
                    itemObj.name = itemToAdd.Name;
                    itemObj.transform.localScale = Vector3.one;
                    itemObj.GetComponent<Image>().sprite = itemToAdd.Sprite;
                    break;
                
            }
        }
    }
}
    bool CheckInventory(Item item){
        for(int i = 0; i < items.Count; i++){
            if(items[i].ID == item.ID){
                return true;
            }
        }
        return false;
    }
    public void ToggleInventory(){
        hotbarPanel.SetActive(!hotbarPanel.active);
    }
}
