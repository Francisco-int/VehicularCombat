using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVehicleController : MonoBehaviour
{
    public Transform[] wheelMeshes; // Asigna las mallas de las ruedas del modelo
    public WheelCollider[] wheelColliders; // Asigna los Wheel Colliders correspondientes
    public float maxMotorTorque = 1500f;
    public float maxSteeringAngle = 30f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Actualiza la posición y rotación de las ruedas
        for (int i = 0; i < wheelColliders.Length; i++)
        {
            UpdateWheelPose(wheelColliders[i], wheelMeshes[i]);
        }
    }

    void FixedUpdate()
    {
        // Controla el movimiento del enemigo
        MoveEnemy();
    }

    void UpdateWheelPose(WheelCollider collider, Transform transform)
    {
        Vector3 pos;
        Quaternion quat;
        collider.GetWorldPose(out pos, out quat);
        transform.position = pos;
        transform.rotation = quat;
    }

    void MoveEnemy()
    {
        // Lógica para mover el vehículo enemigo
        // Ejemplo básico de movimiento
        foreach (WheelCollider wheel in wheelColliders)
        {
            wheel.motorTorque = maxMotorTorque;
            if (wheel.transform.localPosition.z > 0)
            {
                wheel.steerAngle = maxSteeringAngle;
            }
        }
    }
}
