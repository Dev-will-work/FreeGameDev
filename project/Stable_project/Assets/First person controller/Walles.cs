using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walles : MonoBehaviour
{
    public int max_x = 2500;
    public int max_y = 650;
    public int max_z = 2500;
    public int min_x = 0;
    public int min_y = 0;
    public int min_z = 0;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (this.transform.position.x > max_x)
            this.transform.position = new Vector3(max_x, this.transform.position.y, this.transform.position.z);
        if (this.transform.position.x < min_x)
            this.transform.position = new Vector3(min_x, this.transform.position.y, this.transform.position.z);

        if (this.transform.position.y > max_y)
            this.transform.position = new Vector3(this.transform.position.y, max_y, this.transform.position.z);
        if (this.transform.position.y < min_y)
            this.transform.position = new Vector3(this.transform.position.y, min_y, this.transform.position.z);

        if (this.transform.position.z > max_z)
            this.transform.position = new Vector3(this.transform.position.y, this.transform.position.y, max_z);
        if (this.transform.position.z < min_z)
            this.transform.position = new Vector3(this.transform.position.y, this.transform.position.y, min_z);
    }
}
