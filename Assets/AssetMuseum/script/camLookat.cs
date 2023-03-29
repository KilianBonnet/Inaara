using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camLookat : MonoBehaviour
{
    public Transform player, cameraTrans;
	
	void Update(){
		cameraTrans.LookAt(player);
	}
}