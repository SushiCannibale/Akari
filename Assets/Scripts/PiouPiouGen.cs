using UnityEngine;
using Random = System.Random;

public class PiouPiouGen : MonoBehaviour
{
    // Start is called before the first frame update
    public int threshold;
    public GameObject toSpawn;

    private Random rng = new Random();
    // private int timeelapsed
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Time.realtimeSinceStartup);
        Instantiate(toSpawn, gameObject.transform.position + new Vector3(rng.Next(threshold), 0, rng.Next(threshold)), Quaternion.identity);
    }
}
