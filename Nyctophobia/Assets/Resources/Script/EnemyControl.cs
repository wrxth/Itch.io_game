using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyControl : MonoBehaviour
{
    [SerializeField] private GameObject[] CheckPoints;
    [SerializeField] private GameObject checkPoint1;
    [SerializeField] private GameObject checkPoint2;
    [SerializeField] private GameObject player;
    [SerializeField] private Transform BackUpTarget;

    [SerializeField] private NavMeshAgent NavMesh;

    private Vector3 CurrentDes;

    [SerializeField] private enemyState es;
    [SerializeField] private bool PatrolEnemy = false;

    private NavMeshPath NavMeshPath;

    [SerializeField] private float m_RunSpeed = 16f;
    [SerializeField] private float m_WalkSpeed = 4f;
    [SerializeField] private float CurrentSpeed = 4f;
    [SerializeField] private float m_NavMeshStopDis = 5f;

    public Animator m_Animator;
    public bool m_PlayerDetected;
    public bool m_CloseToPlayer;

    private void Start()
    {
        NavMeshPath = new NavMeshPath();
        Check1();
        player = GameObject.Find("Player");
    }
    private void Update()
    {
        if (es.dead == true)
        {
            this.enabled = false;
        }
        else
        {
            if (m_PlayerDetected == true)
            {
                if (CurrentSpeed < m_RunSpeed)
                {
                    CurrentSpeed += Time.deltaTime;
                }
                chasingPlayer();
                NavMesh.speed = CurrentSpeed;
            }
            else
            {
                NavMesh.speed = m_WalkSpeed;
                CurrentSpeed = m_WalkSpeed;
            }

            if (PatrolEnemy == true)
            {
                if (Vector3.Distance(gameObject.transform.position, checkPoint1.transform.position) < 3)
                {
                    Check1();
                }
                if (Vector3.Distance(gameObject.transform.position, checkPoint2.transform.position) < 3)
                {
                    Check2();
                }

                if (Vector3.Distance(transform.position, CurrentDes) < 1 || NavMesh.isStopped == true)
                {
                    m_CloseToPlayer = true;
                    Vector3 lookAt = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
                    transform.LookAt(lookAt);
                }
                else
                {
                    m_CloseToPlayer = false;
                }
            }


            if (es.hunting == true)
            {
                chasingPlayer();

            }
            else
            {
                m_PlayerDetected = false;
                m_CloseToPlayer = false;
            }


            if (m_CloseToPlayer == true)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
            }
        }
    }
    public void Check1()
    {
        checkPoint1 = CheckPoints[Random.Range(0, CheckPoints.Length)];
        if (checkPoint2 != null)
        {
            Vector3 targetVector = checkPoint2.transform.position;
            NavMesh.SetDestination(targetVector);

        }
        else
        {
            Debug.Log("je bent vergeten de transform erin te zetten");
        }
    }

    public void Check2()
    {
        checkPoint2 = CheckPoints[Random.Range(0, CheckPoints.Length)];
        if (checkPoint1 != null)
        {
            Vector3 targetVector = checkPoint1.transform.position;
            NavMesh.SetDestination(targetVector);
        }
        else
        {
            Debug.Log("je bent vergeten de transform erin te zetten");
        }
    }

    private void chasingPlayer()
    {
        if (player != null)
        {
            Vector3 targetVector = player.transform.position;
            NavMesh.CalculatePath(targetVector, NavMeshPath);
            if (NavMeshPath.status == NavMeshPathStatus.PathComplete)
            {
                NavMesh.SetDestination(targetVector);
                CurrentDes = player.transform.position;
                if (Vector3.Distance(transform.position, targetVector) < m_NavMeshStopDis)
                {
                    NavMesh.isStopped = true;
                }
                else
                {
                    NavMesh.isStopped = false;
                }
            }
            else
            {
                NavMesh.SetDestination(BackUpTarget.position);
                CurrentDes = BackUpTarget.position;
            }
            m_PlayerDetected = true;
        }
        else
        {
            Debug.Log("je bent vergeten de transform erin te zetten");
        }
    }

    private GameObject FindPointClosetToPlayer()
    {
        float distanceToPlayer = 1000f;
        int currentclosest = 0;
        for (int i = 0; i < CheckPoints.Length; i++)
        {
            if (Vector3.Distance(player.transform.position, CheckPoints[i].transform.position) < distanceToPlayer)
            {
                currentclosest = i;
                distanceToPlayer = Vector3.Distance(player.transform.position, CheckPoints[i].transform.position);
            }
        }

        return CheckPoints[currentclosest];
    }
}