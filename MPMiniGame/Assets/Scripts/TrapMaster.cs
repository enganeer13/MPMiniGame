using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapMaster : MonoBehaviour
{
    public float speed = 10f;
    public float clampOffset = 10f;
    public float bounciness = .5f;

    public List<GameObject> spawnable;
    private int spawnIndex;
    
    private Rigidbody2D body;
    private Camera cam;
    private float leftBound, rightBound;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        cam = FindObjectOfType<Camera>();

        spawnIndex = 0;
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

        //Drop Spawnable
        if(Input.GetButtonDown("Vertical2"))
        {
            ObjectPooler.Instance.SpawnFromPool(spawnable[spawnIndex].name, transform.position, Quaternion.identity);
        }

        //Cycle Spawnable
        if(Input.GetButtonDown("SelectorMinus"))
        {
            spawnIndex = (spawnIndex <= 0) ? spawnable.Count - 1 : spawnIndex - 1;
        }

        if (Input.GetButtonDown("SelectorPlus"))
        {
            spawnIndex = (spawnIndex < spawnable.Count - 1) ? spawnIndex + 1 : 0;
        }

        //Trigger Active trap
        if (Input.GetButtonDown("shift"))
        {
            RaycastHit2D ray = Physics2D.Raycast(transform.position, Vector2.down);
            if(ray.collider.GetComponent<Trap>() != null)
            {
                ray.collider.GetComponent<Trap>().activate();
            }
        }
    }
}
