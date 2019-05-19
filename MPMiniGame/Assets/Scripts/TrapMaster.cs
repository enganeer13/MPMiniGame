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

    public List<float> maxCooldowns;
    public float[] cooldowns;
    
    private Rigidbody2D body;
    private Camera cam;
    private float leftBound, rightBound;

    //TrapSelection related variable - Trinidad
    private TrapSelection trapSelection;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        cam = FindObjectOfType<Camera>();
        //reference script -Trinidad
        trapSelection = GetComponentInChildren<TrapSelection>();

        spawnIndex = 0;

        Debug.Assert(spawnable.Count == maxCooldowns.Count, "Cooldown list must be same length as spawnable list.");
        cooldowns = new float[maxCooldowns.Count];
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
            transform.position = new Vector2(leftBound + clampOffset, 5f);
            body.velocity = -body.velocity * bounciness;
        }
        if(transform.position.x > rightBound - clampOffset)
        {
            transform.position = new Vector2(rightBound - clampOffset, 5f);
            body.velocity = -body.velocity * bounciness;
        }

        //Decrease cooldowns
        for (int i = 0; i < cooldowns.Length; i++)
            cooldowns[i] = Mathf.Max(0f, cooldowns[i] - Time.deltaTime);

        //Drop Spawnable
        if(Input.GetButtonDown("Fire1") && cooldowns[spawnIndex] <= 0f)
        {
            GameObject g = ObjectPooler.Instance.SpawnFromPool(spawnable[spawnIndex].name, transform.position, Quaternion.identity);
            cooldowns[spawnIndex] = maxCooldowns[spawnIndex];
        }

        //Cycle Spawnable
        if(Input.GetButtonDown("SelectorMinus"))
        {
            spawnIndex = (spawnIndex <= 0) ? spawnable.Count - 1 : spawnIndex - 1;
            //call change from TrapSelection - Trinidad
            trapSelection.ChangeTrap(spawnable[spawnIndex]);
        }

        if (Input.GetButtonDown("SelectorPlus"))
        {
            spawnIndex = (spawnIndex < spawnable.Count - 1) ? spawnIndex + 1 : 0;
            //call change from TrapSelection -Trinidad
            trapSelection.ChangeTrap(spawnable[spawnIndex]);
        }

        //Trigger Active trap
        if (Input.GetButtonDown("shift"))
        {
            RaycastHit2D[] rays = Physics2D.BoxCastAll(transform.position, new Vector2(1, 1), 0, Vector2.down);
            foreach(RaycastHit2D ray in rays)
            {
                if (ray.collider.GetComponent<Trap>() != null)
                {
                    ray.collider.GetComponent<Trap>().activate();
                }
            }
        }
    }
}
