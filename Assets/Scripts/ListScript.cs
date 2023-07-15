using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public struct ListItem{
    public int Id;
    public string Name;

    public ListItem(int id, string name){
        Id = id;
        Name = name;
    }
}
public class ListScript : MonoBehaviour

{
    public List<ListItem> ListData = new List<ListItem>();
    
    void Start()
    {
        GetDataBase("Assets/Resources/ListData.txt");
        
    }
    void GetDataBase(string path){
        StreamReader sr = new StreamReader(path);

        AddItem:
        ListData.Add(new ListItem(
            int.Parse(sr.ReadLine().Replace("id: ", "")),
            sr.ReadLine().Replace("name: ","")
        ));
        string c = sr.ReadLine();
        if( c == ","){
            goto AddItem;

        }else if( c == ";"){
            sr.Close();

        }else{
            Debug.LogError("Item Database does not have correct line ending");
        }

        sr.Close();
    }

}
