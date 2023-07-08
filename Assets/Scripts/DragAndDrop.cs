using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DragAndDrop : MonoBehaviour {
    private GameObject selectedObject;
    private Vector3 RightPosition;
    public List<GameObject> Puzzles = new List<GameObject>();
    public Collider coll;
  
 



    void Start()
    {
        coll = GetComponent<Collider>();
        RightPosition = transform.position;
        transform.position = new Vector3(Random.Range(2.0f,6.5f), Random.Range(-1.0f,3.7f), 0.5f);
    }


    private void Update(){

         if(Vector3.Distance(transform.position,RightPosition) < 0.2f)
        {
            transform.position = RightPosition;
            Destroy(coll);
          
        }

        if(Input.GetMouseButtonDown(0)){
            if(selectedObject == null){
                RaycastHit hit = CastRay();

                if(hit.collider != null){
                    if(!hit.collider.CompareTag("Puzzle")){
                        return;
                    }

                    selectedObject = hit.collider.gameObject;
                    Cursor.visible = false;
                }

            }else{
                Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(selectedObject.transform.position).z);
                Vector3 worldPosition = Camera.main.ScreenToWorldPoint(position);
                selectedObject.transform.position = new Vector3(worldPosition.x, worldPosition.y, 0f);

                selectedObject = null;
                Cursor.visible = true;
        

            }

        }
        if(selectedObject != null){
            Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(selectedObject.transform.position).z);
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(position);
            selectedObject.transform.position = new Vector3(worldPosition.x, worldPosition.y, .25f);

        }

        
    }


    private RaycastHit CastRay(){
        Vector3 screenMousePosFar = new Vector3(
            Input.mousePosition.x,
            Input.mousePosition.y,
            Camera.main.farClipPlane);
        Vector3 screenMousePosNear = new Vector3(
            Input.mousePosition.x,
            Input.mousePosition.y,
            Camera.main.nearClipPlane);
        Vector3 worldMousePosFar = Camera.main.ScreenToWorldPoint(screenMousePosFar);
        Vector3 worldMousePosNear = Camera.main.ScreenToWorldPoint(screenMousePosNear);
        RaycastHit hit;
        Physics.Raycast(worldMousePosNear, worldMousePosFar-worldMousePosNear, out hit);

        return hit;
    }
}


