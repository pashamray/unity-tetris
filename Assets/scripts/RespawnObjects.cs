using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RespawnObjects : MonoBehaviour {

    public GameObject objI;
    public GameObject objJ;
    public GameObject objO;
    public GameObject objT;
    public GameObject objS;

    private GameObject currObject;
    private Rigidbody currObjectRb;

    private IList<GameObject> objsArray = new List<GameObject>();
    // Use this for initialization
    void Start()
    {
        objsArray.Add(objI);
        objsArray.Add(objJ);
        objsArray.Add(objO);
        objsArray.Add(objT);
        objsArray.Add(objS);

        MakeRandomObject();
    }

    void FixedUpdate()
    {
        if ((currObjectRb == null) || ((currObjectRb.transform.position.y != transform.position.y) && (currObjectRb.velocity.sqrMagnitude == 0)))
        {
            MakeRandomObject();
        }
    }

    private void MakeRandomObject()
    {
        int random = Mathf.CeilToInt(Random.value * objsArray.Count) - 1;
        currObject = MakeObject(random);
        currObjectRb = currObject.GetComponent<Rigidbody>();
    }

    private GameObject MakeObject(int index) //Корутина должна возвращать IEnumerator 
    {
        GameObject co = (GameObject) Instantiate(objsArray[index], transform.position, transform.rotation);
        
        return co;        
    }
}
