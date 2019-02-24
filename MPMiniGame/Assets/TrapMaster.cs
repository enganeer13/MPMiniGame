using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapMaster : MonoBehaviour
{
    public float speed = 10f;
    public float clampOffset = 10f;
    public float bounciness = .5f;
    private Rigidbody2D body;
    private Camera cam;
    private float leftBound, rightBound;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        cam = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        //Get left and right bounds of the camera
        leftBound = cam.ViewportToWorldPoint(new Vector3(0, 1, -10)).x;
        rightBound = cam.ViewportToWorldPoint(new Vector3(1, 1, -10)).x;

        //Apply Horizontal force to RB
        float xMove = Input.GetAxis("Horizontal2") * speed * Time.deltaTime;
        body.AddForce(new Vector2(xMove, 0));

        //Clamp x position between camera bounds and add bounce
        if(transform.position.x < leftBound + clampOffset )
        {
            transform.position = new Vector2(leftBound + clampOffset, 3f);
            body.velocity = -body.velocity * bounciness;
        }
        if(transform.position.x > rightBound - clampOffset)
        {
            transform.position = new Vector2(rightBound - clampOffset, 3f);
            body.velocity = -body.velocity * bounciness;
        }

        //Drop Box
        if(Input.GetButtonDown("down"))
        {
            ObjectPooler.Instance.SpawnFromPool("Box", transform.position, Quaternion.identity);
        }
    }
}
