using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellStack : MonoBehaviour {

    // Use this for initialization
    public Transform shellPrefab;
    private List<Transform> children;
    public float yOffset;
    public float rngAngle;
    private float rotationDirection;
    private float shellTimer;
	void Start () {
        rotationDirection = 1;
        children = new List<Transform>();
        foreach (Transform child in transform)
        {
            children.Add(child);
            randomizeAngle(child);
        }
    }

    // Update is called once per frame
    void Update () {
        for(int i = 0; i < children.Count; i++)
        {
            children[i].position = transform.position + transform.up * i* yOffset;
        }
       
	}
    public void addShell()
    {
        Transform newShell = Instantiate(shellPrefab, transform.position,Quaternion.identity);
        randomizeAngle(newShell);
        newShell.parent = transform;
        children.Add(newShell);

    }
    public void removeShell()
    {
        if (children.Count > 0)
        {
            int childrenCount = children.Count;
            Destroy(children[childrenCount - 1].gameObject);
            children.RemoveAt(childrenCount - 1);
        }
    }
    private void randomizeAngle(Transform shell)
    {
        shell.localRotation = Quaternion.Euler(0, 0,(Random.value * rngAngle*rotationDirection));
        rotationDirection *= -1;
    }
}
