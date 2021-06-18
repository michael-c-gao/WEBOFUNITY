using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Moveliftcar : MonoBehaviour
{
	public GameObject Player;
	private Vector3 _angles;


	public Transform target;
	public float speed = 0.0f;

	public Vector3 forwardPos;
	public Vector3 rearPos;



	void Update()
	{




		/*Vector3 d = Player.transform.position - transform.position;
		if ((d.x > 1) && (d.y > 1) && (d.z > 1)){ 



		target.transform.localPosition = Vector3.MoveTowards(target.transform.localPosition, forwardPos, speed  * Time.deltaTime);

		}
		if ((d.x < 1) && (d.y < 1) && (d.z < 1))
		{
			target.transform.localPosition = Vector3.MoveTowards (target.transform.localPosition, rearPos, speed * Time.deltaTime);
		}
	}*/
	}
}
	