using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellStack : MonoBehaviour {

    // Use this for initialization
    public Transform[] shellPrefabs;
    private List<Transform> children;
    private List<int> shellId;
    public float yOffset;
    public float firstYOffset;
    public float rngAngle;
    private float rotationDirection;
    private float shellTimer;
    private ShellList shellList;
	void Awake () {
        shellList = GameObject.FindGameObjectWithTag("ShellData").GetComponent<ShellList>();
        rotationDirection = 1;
        children = new List<Transform>();
        shellId = new List<int>();
        
    }

    // Update is called once per frame
    void Update () {
        for(int i = 0; i < children.Count; i++)
        {
            children[i].position = transform.position + firstYOffset*transform.up + transform.up * i* yOffset;
        }
       
	}
    public void addShell(int addType)
    {
        int shellType = (int)Random.Range(0, shellPrefabs.Length);
        Transform newShell = Instantiate(shellPrefabs[shellType], transform.position,Quaternion.identity);
        randomizeAngle(newShell);
        newShell.parent = transform;
        newShell.GetComponent<SpriteRenderer>().sprite = shellList.getShellSprite(addType);
        children.Add(newShell);
        shellId.Add(addType);
    }
    public void removeShell()
    {
        if (children.Count > 0)
        {
            int childrenCount = children.Count;
            Destroy(children[childrenCount - 1].gameObject);
            children.RemoveAt(childrenCount - 1);
            shellId.RemoveAt(childrenCount - 1);
        }
    }
    private void randomizeAngle(Transform shell)
    {
        shell.localRotation = Quaternion.Euler(0, 0,(Random.value * rngAngle*rotationDirection));
        rotationDirection *= -1;
    }
    public int shellCount()
    {
        return children.Count;
    }
    public int getId(int x)
    {
        return shellId[x];
    }
    public int getTopShellId()
    {
        return shellId[shellId.Count-1];
    }
}
