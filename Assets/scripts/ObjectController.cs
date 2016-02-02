using UnityEngine;
using System.Collections;

public class ObjectController : MonoBehaviour {

    private RespawnObjects respObj;
    private GameObject currentObject;
    private Rigidbody currentRigidbody;

    private bool update = true;

	// Use this for initialization
	void Start () {
        respObj = gameObject.GetComponent<RespawnObjects>();
    }
	
	// Update is called once per frame
	void Update () {

    }

    private void MakeObject()
    {
        currentObject = respObj.MakeObject();
        currentRigidbody = currentObject.GetComponent<Rigidbody>();
    }

    void FixedUpdate ()
    {
        if ((update) && (currentObject))
        {
            bool moveRight = Input.GetButtonDown("Right");
            bool moveLeft = Input.GetButtonDown("Left");
            bool moveVertical = Input.GetButtonDown("Rotate");

            Debug.Log(moveRight);

            Vector3 movement = currentRigidbody.position + new Vector3(0.0f, 0.0f, ((moveRight) ? 1.0f : ((moveLeft) ? -1.0f : 0.0f)));
           // Quaternion rotate = new Quaternion(((moveVertical) ? 90.0f : 0.0f), 0.0f, 0.0f, 0.0f);

            //currentObject.transform.Rotate((moveVertical) ? 90 : 0, 0, 0);
            //currentRigidbody.transform.position += movement;
            //currentRigidbody.MoveRotation(rotate);
            currentRigidbody.MovePosition(movement);

            update = true;
        }

        if ((currentObject == null) || (currentRigidbody.velocity.sqrMagnitude == 0))
        {
            update = false;
            MakeObject();
            update = true;
        }
    }
}
