using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LightController : MonoBehaviour
{
    [SerializeField] private Transform[] way_points;
    [SerializeField] private float speed = 2f;
    [SerializeField] private GameObject static_light;
    [SerializeField] private bool isStaticLight;
    [SerializeField] private bool isPatrolLight;
    [SerializeField] private CharacterController characterController;
    public float static_light_timer = 1f;
    private float static_light_waittimer;
    public float waitTimer = 1f;
    private float waitCounter;
    private int current_waypoint_index = 0;
    private bool static_light_active = false;
    private bool static_light_on;

    void Start()
    {
        waitCounter = waitTimer;
        static_light_waittimer = static_light_timer;
    }

    void Update()
    {
        if (isPatrolLight)
        {
            PatrolLight();
        }
        if (isStaticLight && static_light_active)
        {
            StaticLight();
        }
    }

    void PatrolLight()
    {
        if (way_points.Length > 0)
        {
            Transform targetWayPoint = way_points[current_waypoint_index];
            transform.position = Vector3.MoveTowards(transform.position, targetWayPoint.position, speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, targetWayPoint.position) < 0.1f)
            {
                if (waitCounter <= 0)
                {
                    current_waypoint_index = (current_waypoint_index + 1) % way_points.Length;
                    waitCounter = waitTimer;
                }
                else
                {
                    waitCounter -= Time.deltaTime;
                }
            }
            else
            {
                RotateTowards(targetWayPoint);
            }
        }
    }

    void StaticLight()
    {
        static_light_waittimer -= Time.deltaTime;

        if (static_light_waittimer <= 0)
        {
            static_light.SetActive(!static_light.activeInHierarchy);
            static_light_waittimer = static_light_timer;
        }
    }

    void RotateTowards(Transform target)
    {
        Vector3 direction = (target.position - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (isStaticLight)
            {
                static_light_active = true;
                static_light.SetActive(true);
                this.gameObject.GetComponent<BoxCollider2D>().enabled = false; // Disable the collider after triggering the light
                static_light_on = true;
                //characterController.HealthDecrease();
            }
            if (isPatrolLight)
            {
                //Debug.Log("Player Died");
                // Add additional death logic here for patrol light
                SoundManager.Instance.PlaySoundEffect(Sounds.HIT);
                characterController.HealthDecrease();
            }
            
        }
    }
}
