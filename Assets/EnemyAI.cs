using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform target; // Asigna el objetivo (jugador) en el Inspector
    private NavMeshAgent agent;
    private EnemyVehicleController vehicleController;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        vehicleController = GetComponent<EnemyVehicleController>();
    }

    void Update()
    {
        agent.SetDestination(target.position);
        Vector3 localTarget = transform.InverseTransformPoint(agent.steeringTarget);

        float steerAngle = Mathf.Atan2(localTarget.x, localTarget.z) * Mathf.Rad2Deg;
        steerAngle = Mathf.Clamp(steerAngle, -vehicleController.maxSteeringAngle, vehicleController.maxSteeringAngle);

        for (int i = 0; i < vehicleController.wheelColliders.Length; i++)
        {
            WheelCollider wheel = vehicleController.wheelColliders[i];
            if (wheel.transform.localPosition.z > 0)
            {
                wheel.steerAngle = steerAngle;
            }
        }

        foreach (WheelCollider wheel in vehicleController.wheelColliders)
        {
            wheel.motorTorque = vehicleController.maxMotorTorque;
        }
    }
}
