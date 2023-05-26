using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Player : AbstractLivingEntity, IPersistentData
{
    [SerializeField] private PlayerCamera playerCam;

    public Vector3 hitOffset;
    public float hitRange = 0.5f;
    public LayerMask hitLayer;

    public float rotationSmoothness;
    public float jumpStrength;
    public float gravity = -9.81f;
    
    private float yVel;
    private bool canJump;

    private CharacterController controller;
    private Sword sword;
    
    private List<GameObject> withinBounds;

    public int coins;
    
    private void Awake()
    {
        Initialize(true);
        controller = GetComponent<CharacterController>();
        sword = GetComponentInChildren<Sword>();
        withinBounds = new List<GameObject>();
    }

    protected void Update()
    {
        Transform camT = playerCam.transform;
        Vector3 fwd = camT.forward;
        Vector3 side = camT.right;

        fwd *= Input.GetAxis("Vertical") * Speed;
        side *= Input.GetAxis("Horizontal") * Speed;

        Vector3 planeDir = fwd + side;
        planeDir.y = 0;

        Vector3 yDir = new Vector3(0, 0, 0);
        
        if (Input.GetButtonDown("Fire1"))
            HandleAttack();

        if (Input.GetKeyDown(Util.Keys.INSTAKILL))
            HandleInstaKill();
        
        HandleMove(ref yDir);

        if (Input.GetKeyDown(Util.Keys.INTERACT))
        {
            if (withinBounds.Count == 0)
                return;
            Interact(Util.Math.CloserTo(withinBounds, gameObject));
        }

        if (CanMove)
        {
            controller.Move((planeDir + yDir) * Time.deltaTime);
        
            /* Le joueur regarde dans la direction de son mouvement */
            if (planeDir != Vector3.zero)
            {
                Quaternion toRot = Quaternion.LookRotation(-planeDir, Vector3.up);
                controller.transform.rotation = Quaternion.RotateTowards(controller.transform.rotation, toRot, rotationSmoothness * Time.fixedDeltaTime);
            }
        }
    }

    private void HandleMove(ref Vector3 yDir)
    {
        if (controller.isGrounded)
        {
            yVel = 0;
            canJump = true;
        }
        
        if (Input.GetButtonDown("Jump") && canJump)
        {
            yVel += jumpStrength;
            canJump = false;
        }
        
        yVel += gravity * Time.deltaTime;
        yDir.y += yVel;
    }

    private void HandleAttack()
    {
        sword.Swing();
        Collider[] hits = Physics.OverlapSphere(transform.position + hitOffset, hitRange, hitLayer);
        
        foreach (Collider coll in hits)
        {
            if (coll.gameObject.TryGetComponent(out IDamageable hitable))
            {
                hitable.Hurt(BaseDamage);
            }
        }
    }

    private void HandleInstaKill()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position + hitOffset, hitRange, hitLayer);
        
        foreach (Collider coll in hits)
        {
            if (coll.gameObject.TryGetComponent(out IDamageable hitable))
            {
                hitable.Hurt(float.MaxValue);
            }
        }
    }

    private void Interact(GameObject gameObject)
    {
        if (gameObject.TryGetComponent(out IInteractible clickable))
            clickable.Interact(this);
    }

    public override void Kill()
    {
        // transform.position = new Vector3(-1, 1, 4);
        // SceneManager.LoadScene(Util.Scenes.MainTitle);
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Interactible"))
            withinBounds.Add(other.gameObject);

        if (other.gameObject.TryGetComponent(out ICollectible collectible))
        {
            collectible.Collect(this);
        }

        if (other.gameObject.TryGetComponent(out IDamageProvider dmgProvider))
        {
            if (dmgProvider.IsLethal())
                Hurt(dmgProvider.DamageAmount());
        }

        if (other.gameObject.TryGetComponent(out IBossFightTriggerer triggerer))
        {
            triggerer.TriggerBossFight(this);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Interactible"))
            withinBounds.Remove(other.gameObject);
    }

    /* Called before the first frame when scene loaded ! */
    public void LoadFrom(GameData data)
    {
        controller.enabled = false;
        controller.transform.position = data.playerPosition;
        controller.enabled = true;
    }

    public void SaveTo(GameData data)
    {
        data.playerPosition = controller.transform.position;
    }
}