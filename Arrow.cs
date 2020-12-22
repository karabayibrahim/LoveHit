using UnityEngine;

public class Arrow : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject target;
    public float arrowSpeed;
    void Start()
    {

        //target = GameObject.FindGameObjectWithTag("arrowTarget");

    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 dir = target.transform.position - transform.position;
        //float distanceThisFrame = arrowSpeed * Time.deltaTime; //her bir kare boyunca yapacağı hareket

        //if (dir.magnitude <= distanceThisFrame) // çarptı demek
        //{
        //    hitTarget();
        //    return;
        //}

        //transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    void hitTarget()
    {
        Debug.Log("Hit");
    }
}
