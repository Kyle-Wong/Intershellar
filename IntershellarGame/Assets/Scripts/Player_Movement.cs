using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour {

    public Transform shellProjectilePrefab;
    private ShellStack stacker;
    private Vector3 velocity;
    float crab_speed = 1f;
    float rotation_speed = 10f;
    public float timer;
    private float timing;
    public float drag;
    public float playerLeapVelocity;
    public float shellShotSpeed;
    [HideInInspector]
    public int shellCount;
    public int startingShells;
    private bool began = false;

    public Sprite nakedSprite;
    private ShellList shellList;
    private int mySpriteId = -1;
    SpriteRenderer spriteRenderer;
    public Transform projectileParticles;
    public Transform hurtParticles;
	// Use this for initialization
	void Start () {
        shellCount = 0;
        shellList = GameObject.FindGameObjectWithTag("ShellData").GetComponent<ShellList>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        velocity = new Vector3(0, 0, 0);
        timing = timer;
        stacker = GetComponent<ShellStack>();
        Gain_Shell(startingShells,-1);
	}
	
	// Update is called once per frame
	void Update () {
        /*
        float rotating = Input.GetAxis("Rotation") * rotation_speed;
        if (Input.GetButton("Rotation"))
        {
            transform.Rotate(0, 0, rotating);
        }
        */
        transform.position += velocity * Time.deltaTime;
        velocity *= drag;
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, 0, rotation_speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, 0, -rotation_speed);
        }
        if (Input.GetKeyDown(KeyCode.W) && shellCount > 0)
            ShootShell();
        NoShells();
    }
    //Activates when crab collides with detached shell. Places shell on top of stack.
    public void Gain_Shell(int worth,int shellType)
    {
        timer = timing;
        for (int i = 0; i < worth; i++)
        {
            int addType = (shellType == -1) ? (int)Random.Range(0, shellList.shellSprite.Length) : shellType;
            if(shellCount == 0)
            {
                spriteRenderer.sprite = shellList.playerShellSprite[addType];
                mySpriteId = addType;
            } else
            {
                stacker.addShell(addType);
            }
            shellCount++;
        }
        
    }
    public void Lose_Shell()
    {
        if (shellCount > 1)
        {
            shellCount--;
            stacker.removeShell();
        } else if(shellCount == 1)
        {
            shellCount--;
            spriteRenderer.sprite = nakedSprite;
        } 
    }
    public int Get_ShellCount()
    {
        return shellCount;
    }
    public void NoShells()
    {
        Debug.Log(timer);
        if (shellCount == 0)
        {
            timer -= Time.deltaTime;
        }
        if (timer <= 0)
        {
            Destroy(gameObject);
        }
    }

    public Vector3 getVelocity()
    {
        return velocity;
    }
    public void setVelocity(Vector3 v)
    {
        velocity = v;
    }
    private void ShootShell()
    {
        //if has shell...

        //calculate the direction of the player
        Vector3 playerDir = transform.up*-1;
        //project shell
        int shellType = -1;
        Vector3 shellPosition = transform.position;
        if (shellCount > 1)
        {
            shellType = stacker.getTopShellId();
            shellPosition = stacker.getTopShell().position;
        }
        else if (shellCount == 1)
        {
            if (mySpriteId != -1)
            {
                shellType = mySpriteId;
            }
        }
        Transform particles = Instantiate(projectileParticles, shellPosition, Quaternion.LookRotation(transform.forward, playerDir));
        Transform shellObject = Instantiate(shellProjectilePrefab, transform.position, Quaternion.LookRotation(transform.forward,playerDir));
        shellObject.GetComponent<Projectile>().setVelocity(-1 * playerDir * shellShotSpeed);
        velocity = playerDir * playerLeapVelocity;
        shellObject.GetComponent<SpriteRenderer>().sprite = shellList.getShellSprite(shellType);
        Lose_Shell();
        //dash self
    }
}
