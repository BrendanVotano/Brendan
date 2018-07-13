using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public static float speed = 10;

	void Update ()
    {
        transform.Rotate(speed * Time.deltaTime, 0, 0);
	}
}
