using UnityEngine;

public class TetrisObject : MonoBehaviour {

    private Rigidbody rb;

    private bool update = false;

    private bool btnRight = false;
    private bool btnLeft = false;
    private bool btnRotate = false;

    private float rightBtnDelta;
    private float leftBtnDelta;
    private float rotateBtnDelta;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        transform.rotation = new Quaternion(0.0f, (Random.Range(0, 1) == 1 ? 180.0f : 0.0f), 0.0f, 0.0f);
        update = true;

        rightBtnDelta = 0;
        leftBtnDelta = 0;
        rotateBtnDelta = 0;
    }
	
	// Update is called once per frame
	void Update () {
        if (update)
        {
            rightBtnDelta += Time.fixedDeltaTime;
            leftBtnDelta += Time.fixedDeltaTime;
            rotateBtnDelta += Time.fixedDeltaTime;

            if (rightBtnDelta > 0.1f)
            {
                rightBtnDelta = 0;
                btnRight = Input.GetKey(KeyCode.RightArrow);
            }
            if (leftBtnDelta > 0.1f)
            {
                leftBtnDelta = 0;
                btnLeft = Input.GetKey(KeyCode.LeftArrow);
            }

            if (rotateBtnDelta > 0.1f)
            {
                rotateBtnDelta = 0;
                btnRotate = Input.GetKey(KeyCode.UpArrow);
            }
            /*
            btnRight = Input.GetKey(KeyCode.RightArrow);
            btnLeft = Input.GetKey(KeyCode.LeftArrow);
            btnRotate = Input.GetKey(KeyCode.UpArrow);
            */
            if (btnRotate)
            {
                rb.transform.Rotate(new Vector3(0.0f, 0.0f, 90.0f));
            }

            if(btnRight || btnLeft)
            {
                rb.transform.position += new Vector3((btnRight) ? 1.0f : -1.0f, 0.0f, 0.0f);
            }            

            btnRight = false;
            btnLeft = false;
            btnRotate = false;
        }
    }

    void FixedUpdate()
    {
        //rb.transform.position
        if (transform.position.y < 0)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionStay(Collision collision)
    {
        if (update)
        {
            foreach (ContactPoint contact in collision.contacts)
            {
                /*
                //print(contact.thisCollider.name + " hit " + contact.otherCollider.name);
                Debug.DrawRay(contact.point, contact.normal, Color.white);

                print("name: " + contact.thisCollider.name + " x: " + contact.point.x + " normal x: " + contact.normal.x);
                print("name: " + contact.thisCollider.name + " y: " + contact.point.y + " normal y: " + contact.normal.y);
                print("name: " + contact.thisCollider.name + " z: " + contact.point.z + " normal z: " + contact.normal.z);
                */
                if (contact.normal.y > 0.5f)
                {
                    update = false;
                }
            }
        }
    }
}
