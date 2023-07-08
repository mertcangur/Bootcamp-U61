using System.Collections;
using System.Collections.Generic;
using UnityEngine;
	public class opencloseDoor : MonoBehaviour
	{

		public Animator openandclose;
		public Transform Player;
		public Collider doorColl;
		public bool open = false;

		void Start()
		{
			openandclose.SetBool("Click", open);
			doorColl.enabled = !enabled;
		}
		void Update(){
			if(Input.GetKeyDown(KeyCode.F)){
				StartCoroutine(Wait());
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
			}


	}