using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Stats")]
    public int curHP,
    maxHP,
    ScoreToGive;

    [Header ("Movement")]
    public float moveSpeed, attackRange, yPathOffset;
    private List<Vector3> path; 

    private Weapon weapon;
    private GameObject target;


    // Start is called before the first frame update
    void Start()
    {
        // Gather the Components
        weapon = GetComponent<Weapon>();
        target = FindObjectOfType<PlayerController>().gameObject;
    }

    void UpdatePath()
    {
        // Calculate Path to the Target
        NavMeshPath navMeshPath = new NavMeshPath();

        NavMesh.CalculatePath(transform.position, target.transform.position, NavMesh.AllAreas, navMeshPath);

        // Save calculated path to the list
        path = naveMeshPath.corners.ToList();
    }
    void ChaseTarget()
    {
        if(path.Count == 0)
            return;

        // Move towards the closet path
        transform.position = Vector3.MoveTowards(transform.position, path[0] + new Vector3(0, yPathOffset, 0), moveSpeed * Time.deltaTime);

        if(transform.position == path[0] + new Vector3(0,yPathOffset,0))
            path.RemoveAt(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
