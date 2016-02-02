using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RespawnObjects : MonoBehaviour {

    public GameObject objI;
    public GameObject objJ;
    public GameObject objO;
    public GameObject objT;
    public GameObject objS;

    private IList<GameObject> objsArray = new List<GameObject>();
    // Use this for initialization
    void Start()
    {

    }

    void Update()
    {
        
    }

    void Awake()
    {
        objsArray.Add(objI);
        objsArray.Add(objJ);
        objsArray.Add(objO);
        objsArray.Add(objT);
        objsArray.Add(objS);
    }


    public GameObject MakeObject() //Корутина должна возвращать IEnumerator 
    {
        int random = Mathf.CeilToInt(Random.value * objsArray.Count) - 1;

        GameObject cl = (GameObject) Instantiate(objsArray[random], transform.position, transform.rotation);
        cl.transform.rotation = new Quaternion(0, (Random.value > 0.5) ? 180 : 0, 0, 0);

        return cl;        
    }
}
