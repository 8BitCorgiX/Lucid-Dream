using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public float patrol_Radius = 30f;
    public float patrol_Timer = 5f;
    public float timer_Count;

    private NavMeshAgent agent;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Start is called before the first frame update
    void Start()
    {
        timer_Count = patrol_Timer;
    }

    // Update is called once per frame
    void Update()
    {
        Wander();
    }

    void Wander()
    {
        timer_Count += Time.deltaTime;

        if(timer_Count > patrol_Timer)
        {
            SetNewRandomDestination();

            timer_Count = 0f;
        }

        if(agent.velocity.sqrMagnitude == 0)
        {

        }
        else
        {

        }
    }

    void SetNewRandomDestination()
    {
        Vector3 newDestination = RandomNavSphere(transform.position, patrol_Radius, -1);
        agent.SetDestination(newDestination);
    }

    Vector3 RandomNavSphere(Vector3 originPos, float radius, int layerMask)
    {
        Vector3 randDir = Random.insideUnitSphere * radius;
        randDir += originPos;

        NavMeshHit navhit;

        NavMesh.SamplePosition(randDir, out navhit, radius, layerMask);

        return navhit.position;
    }
}
