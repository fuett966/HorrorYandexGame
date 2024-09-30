
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KinematicCharacterController;
using KinematicCharacterController.Examples;
using System;

namespace KinematicCharacterController.Examples
{
    public class PlanetManager : MonoBehaviour, IMoverController
    {
        public PhysicsMover PlanetMover;
        public SphereCollider GravityField;
        public float GravityStrength = 10;
        public Vector3 OrbitAxis = Vector3.forward;
        public float OrbitSpeed = 10;

        public List<Teleporter> OnEnterPlanetTeleportingZones;
        public List<Teleporter> OnExitPlanetTeleportingZones;

        private List<PlayerCharacterController> _characterControllersOnPlanet = new List<PlayerCharacterController>();
        private Vector3 _savedGravity;
        private Quaternion _lastRotation;

        private void Start()
        {
            foreach (Teleporter _teleporter in OnEnterPlanetTeleportingZones)
            {
                _teleporter.OnCharacterTeleport -= ControlGravity;
                _teleporter.OnCharacterTeleport += ControlGravity;
            }
            foreach (Teleporter _teleporter in OnExitPlanetTeleportingZones)
            {
                _teleporter.OnCharacterTeleport -= UnControlGravity;
                _teleporter.OnCharacterTeleport += UnControlGravity;
            }


            _lastRotation = PlanetMover.transform.rotation;

            PlanetMover.MoverController = this;
        }

        public void UpdateMovement(out Vector3 goalPosition, out Quaternion goalRotation, float deltaTime)
        {
            goalPosition = PlanetMover.Rigidbody.position;

            // Rotate
            Quaternion targetRotation = Quaternion.Euler(OrbitAxis * OrbitSpeed * deltaTime) * _lastRotation;
            goalRotation = targetRotation;
            _lastRotation = targetRotation;

            // Apply gravity to characters
            foreach (PlayerCharacterController cc in _characterControllersOnPlanet)
            {
                cc.Gravity =  (PlanetMover.transform.position - cc.transform.position).normalized * GravityStrength;
            }
        }

        void ControlGravity(PlayerCharacterController cc)
        {
            _characterControllersOnPlanet.Add(cc);
        }

        void UnControlGravity(PlayerCharacterController cc)
        {
            cc.Gravity = cc.DefaultGravity;
            _characterControllersOnPlanet.Remove(cc);
        }

        


        private void OnTriggerEnter(Collider other)
        {
            PlayerCharacterController cc = other.GetComponent<PlayerCharacterController>();
            if (cc)
            {
                ControlGravity(cc);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            PlayerCharacterController cc = other.GetComponent<PlayerCharacterController>();
            if (cc)
            {
                UnControlGravity(cc);
            }
        }
    }
    
    
}