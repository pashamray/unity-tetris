using UnityEngine;
using System.Collections;

public class TetrisObject : MonoBehaviour {

    //private Rigidbody rb;

    private bool update = true;

	// Use this for initialization
	void Start () {
        //rb = GetComponent<Rigidbody>();
        transform.rotation = new Quaternion(0, (Random.value > 0.5) ? 180 : 0, 0, 0);
    }
	
	// Update is called once per frame
	void Update () {

    }

    void FixedUpdate()
    {
        if (update)
        {
            bool moveRight = Input.GetButtonDown("Right");
            bool moveLeft = Input.GetButtonDown("Left");
            bool moveVertical = Input.GetButtonDown("Rotate");

            Vector3 movement = new Vector3(0.0f, 0.0f, (float)((moveRight) ? 1.0f : ((moveLeft) ? -1.0f : 0.0f)));

            transform.Rotate((moveVertical) ? 90 : 0, 0, 0);
            transform.position += (movement);

            if (transform.position.y < 0)
            {
                Destroy(gameObject);
            }
        }
    }

    void OnCollisionEnter(Collision theCollision)
    {
        update = false;
        Debug.Log(theCollision.gameObject.name);
    }
}
