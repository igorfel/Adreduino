using UnityEngine;
using System.Collections;

public class Rotaciona : MonoBehaviour {

	float speed = 0.5f;
	public Transform Objeto;
	public Transform Target;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.eulerAngles += new Vector3(0,0,Target.transform.position.z);
	}
}
