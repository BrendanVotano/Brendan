using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineFun : MonoBehaviour {

    public GameObject cube;
    public bool isMoving = false;
	// Update is called once per frame
	void Update () {
        //if i press the button and isMoving is false
        //set is moving to be true
        if (Input.GetKeyDown(KeyCode.Space) && isMoving == false)
            StartCoroutine(MyRoutine(100));
        
    }

    public int counter = 0;
    IEnumerator MyRoutine(int amount)
    {
        isMoving = true;

        for (int i = 0; i < amount; i++)
        {
            cube.transform.Translate(Vector3.forward * Time.deltaTime);
            yield return null;
        }

        //wait 3 seconds then move cube again
        //yield return new WaitForSeconds(1);

        for (int i = 0; i < amount; i++)
        {
            cube.transform.Translate(Vector3.left * Time.deltaTime);
            yield return null;
        }

        //yield return new WaitForSeconds(1);

        for (int i = 0; i < amount; i++)
        {
            cube.transform.Translate(Vector3.back * Time.deltaTime);
            yield return null;
        }

        //yield return new WaitForSeconds(1);

        for (int i = 0; i < amount; i++)
        {
            cube.transform.Translate(Vector3.right * Time.deltaTime);
            yield return null;
        }

        isMoving = false;
        counter++;
        if(counter < 3)
            StartCoroutine(MyRoutine(100));
    }
}
