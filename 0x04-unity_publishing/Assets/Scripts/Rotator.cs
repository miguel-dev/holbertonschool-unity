using UnityEngine;

public class Rotator : MonoBehaviour
{   
    float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = 45.0f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.right * speed * Time.deltaTime);
    }
}
