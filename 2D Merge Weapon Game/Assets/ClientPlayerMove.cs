using System;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.InputSystem;

public class ClientPlayerMove : NetworkBehaviour
{
    [SerializeField] private Player_Movement m_PlayerMovement;
    [SerializeField] private Ground_Check Ground_Check;
    [SerializeField] private Weapon Weapon;

    private void Awake()
    {
        m_PlayerMovement.enabled = false;
        Ground_Check.enabled = false;
        Weapon.enabled = false;
    }

    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();

        if (IsOwner)
        {
            m_PlayerMovement.enabled = true;
            Weapon.enabled = true;
            Ground_Check.enabled = true;
        }
    }
}