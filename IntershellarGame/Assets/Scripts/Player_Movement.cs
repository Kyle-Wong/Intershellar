﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour {

    public Transform shellProjectilePrefab;
    private ShellStack stacker;
    private Vector3 velocity;
    float crab_speed = 1f;
    float rotation_speed = 10f;
    public float timer;
    [HideInInspector]
    public float timing;
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
    public Transform spawnShell;
    public float shellLossVelocity = 2;
    private Rigidbody2D rb;
    private bool isDead;
    private bool allowInput = true;
    private AudioSource source;
    public AudioClip pickupSound;
    public AudioClip dash;
    public AudioClip exposureSound;
    private float volume;
	// Use this for initialization
	public void Start () {
        source = GetComponent<AudioSource>();
        shellCount = 0;
        rb = GetComponent<Rigidbody2D>();
        shellList = GameObject.FindGameObjectWithTag("ShellData").GetComponent<ShellList>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        velocity = new Vector3(0, 0, 0);
        timing = timer;
        stacker = GetComponent<ShellStack>();
        int shellType = -1;
        int worth = startingShells;
        for (int i = 0; i < worth; i++)
        {
            int addType = (shellType == -1) ? (int)Random.Range(0, shellList.shellSprite.Length) : shellType;
            if (shellCount == 0)
            {
                spriteRenderer.sprite = shellList.playerShellSprite[addType];
                mySpriteId = addType;
            }
            else
            {
                stacker.addShell(addType);
            }
            shellCount++;
        }

    }
	
	// Update is called once per frame
	public void Update () {
        /*
        float rotating = Input.GetAxis("Rotation") * rotation_speed;
        if (Input.GetButton("Rotation"))
        {
            transform.Rotate(0, 0, rotating);
        }
        */
        if (isDead)
        {
            spriteRenderer.sprite = null;
            allowInput = false;
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        }
        if (allowInput)
        {
            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(0, 0, rotation_speed);
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(0, 0, -rotation_speed);
            }
            if (Input.GetKeyDown(KeyCode.W) && shellCount > 0)
            {
                ShootShell();
            }
        }
        NoShells();
    }

    //Changes allowInput
    public void setInput(bool isInput)
    {
        allowInput = isInput;
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
        source.PlayOneShot(pickupSound);
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
            source.PlayOneShot(exposureSound);
        } 
    }
    public void spawnLooseShell()
    {
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
        Transform shellObject = Instantiate(spawnShell, shellPosition, transform.rotation);
        shellObject.GetComponent<SpriteRenderer>().sprite = shellList.getShellSprite(shellType);
        shellObject.GetComponent<ShellPickUp>().shellType = shellType;
        float randomAngle = Random.Range(0, Mathf.PI * 2);
        shellObject.GetComponent<ConstantMove>().velocity = new Vector2(Mathf.Cos(randomAngle),Mathf.Sin(randomAngle))*shellLossVelocity;
    }
    public int Get_ShellCount()
    {
        return shellCount;
    }
    public void NoShells()
    {
        if (shellCount == 0)
        {
            timer -= Time.deltaTime;
        }
        if (timer <= 0)
        {
            isDead = true;
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
        Debug.Log("Check");
        Transform particles = Instantiate(projectileParticles, shellPosition, Quaternion.LookRotation(transform.forward, playerDir));
        Transform shellObject = Instantiate(shellProjectilePrefab, shellPosition, Quaternion.LookRotation(transform.forward,playerDir));
        shellObject.GetComponent<Projectile>().setVelocity(-1 * playerDir * shellShotSpeed);
        rb.velocity = playerDir * playerLeapVelocity;
        shellObject.GetComponent<SpriteRenderer>().sprite = shellList.getShellSprite(shellType);
        shellObject.GetComponent<Animator>().runtimeAnimatorController = shellList.getAnimation(shellType);
        Lose_Shell();
        source.PlayOneShot(dash);
        //dash self
    }
    public bool dead()
    {
        return isDead;
    }
}
