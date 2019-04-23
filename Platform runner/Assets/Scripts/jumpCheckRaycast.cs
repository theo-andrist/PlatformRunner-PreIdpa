using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpCheckRaycast : MonoBehaviour {

	void Update (){
        if (gameObject.transform.eulerAngles.y < 45 && transform.eulerAngles.y > -45)
        {
            Debug.DrawRay(transform.position, Vector3.forward + Vector3.down * 2, Color.green);
        }
        if (gameObject.transform.eulerAngles.y > 135 && transform.eulerAngles.y < 225)
        {
            Debug.DrawRay(transform.position, -Vector3.forward + Vector3.down * 2, Color.green);
        }
        if (transform.eulerAngles.y > 45 && transform.eulerAngles.y < 135)
        {
            Debug.DrawRay(transform.position, Vector3.right + Vector3.down * 2, Color.green);
        }
        if (transform.eulerAngles.y < -45 && transform.eulerAngles.y > -135)
        {
            Debug.DrawRay(transform.position, Vector3.left + Vector3.down * 2, Color.green);
        }
	}
	public bool NeedsToJump(){

		bool ntj = false;

		if(gameObject.transform.eulerAngles.y < 45 && transform.eulerAngles.y > -45)
		{
			if(!Physics.Raycast(transform.position, Vector3.forward + Vector3.down * 2, 1.5f))
			{
				ntj = true;
			}
		}
		if (gameObject.transform.eulerAngles.y > 135 && transform.eulerAngles.y < 225)
        {
			if(!Physics.Raycast(transform.position, -Vector3.forward + Vector3.down * 2, 1.5f))
			{
				ntj = true;
			}
		}
		if(transform.eulerAngles.y > 45 && transform.eulerAngles.y < 135)
		{
			if(!Physics.Raycast(transform.position, Vector3.right + Vector3.down * 2, 1.5f))
			{
				ntj = true;
			}
		}
		if (transform.eulerAngles.y > 225 && transform.eulerAngles.y < 315)
        {
			if(!Physics.Raycast(transform.position, -Vector3.right + Vector3.down * 2, 1.5f))
			{
				ntj = true;
			}
		}
		return ntj;
	}
}
