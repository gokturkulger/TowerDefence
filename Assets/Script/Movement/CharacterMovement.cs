using UnityEngine;
using UnityEngine.AI;



public class CharacterMovement : MonoBehaviour, IMovable
{
    public float stoppingDistance = 1.5f;
    public CharacterData characterData;

    private NavMeshAgent navAgent;
    private GameObject currentTarget;
    private bool isApproachingTarget = true;

    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
        navAgent.stoppingDistance = stoppingDistance;

        if (characterData == null)
        {
            Debug.LogError("CharacterData ScriptableObject not found!");
        }
    }

    void Update()
    {
        // Hedefin hala geçerli olup olmadığını kontrol et
        if (currentTarget == null || !currentTarget.activeInHierarchy || !isApproachingTarget)
        {
            GameObject closestTarget = FindClosestTargetWithTag("Target");

            if (closestTarget != null)
            {
                currentTarget = closestTarget;
                isApproachingTarget = true;
                MoveTowards(currentTarget);
            }
            else
            {
                navAgent.isStopped = true;
            }
        }

        if (isApproachingTarget && currentTarget != null && currentTarget.CompareTag("Target"))
        {
            float distanceToTarget = Vector3.Distance(transform.position, currentTarget.transform.position);

            if (distanceToTarget <= stoppingDistance)
            {
                isApproachingTarget = false;
                navAgent.isStopped = true;
            }
        }
    }

    public void MoveTowards(GameObject target)
    {
        if (target == null || !target.CompareTag("Target")) return;

        navAgent.SetDestination(target.transform.position);
        navAgent.isStopped = false;
    }

    GameObject FindClosestTargetWithTag(string tag)
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag(tag);
        GameObject closestTarget = null;
        float closestDistance = Mathf.Infinity;
        Vector3 currentPosition = transform.position;

        foreach (GameObject target in targets)
        {
            // Rigidbody bileşenine sahip olup olmadığını ve aktif olup olmadığını kontrol et
            if (target.GetComponent<Rigidbody>() != null && target.activeInHierarchy)
            {
                float distance = Vector3.Distance(target.transform.position, currentPosition);
                if (distance < closestDistance)
                {
                    closestTarget = target;
                    closestDistance = distance;
                }
            }
        }

        return closestTarget;
    }
}
