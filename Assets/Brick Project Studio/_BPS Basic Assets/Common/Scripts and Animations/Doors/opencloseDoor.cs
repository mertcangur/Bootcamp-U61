using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
	public class opencloseDoor : MonoBehaviour
	{

		public Animator openandclose;
		public Animator screwing;
		public Transform Player;
		public Collider doorColl;
		public bool open = false;
		public TMP_Text fButton;
		public Collider frameColl;

		void Start()
		{
			fButton.enabled = false;
			openandclose.SetBool("Click", open);
			doorColl.enabled = !enabled;
		}
		void Update(){
			float dist = Vector3.Distance(Player.position, transform.position);
			if(Player){
				if( dist < 5f){
					fButton.enabled = true;
					if(Input.GetKeyDown(KeyCode.F)){
					screwing.SetBool("Screwing", true);
					StartCoroutine(Wait());

				}
			}
			
			}
		}

		void OnMouseDown()
		{	
			open = !open;
			openandclose.SetBool("Click", open);
			}
			IEnumerator Wait() {
				yield return new WaitForSeconds (3);
				doorColl.enabled = enabled;
				fButton.enabled = !enabled;
				frameColl.enabled = !enabled;
			}


	}