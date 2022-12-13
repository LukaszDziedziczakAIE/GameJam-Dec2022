using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [field: SerializeField] public GameController Game { get; private set; }
    [field: SerializeField] public Transform HeadPos { get; private set; }
    [field: SerializeField] public Transform RightHand { get; private set; }
    [field: SerializeField] public Transform LeftHand { get; private set; }
    [field: SerializeField] public Weapon Weapon;
    [field: SerializeField] public CharacterController Controller;
    [field: SerializeField] public Animator Animator;
    [field: SerializeField] public CharacterAudio Audio;
    [field: SerializeField] public GameObject Helmet { get; private set; }
    [field: SerializeField] public float Speed = 5;
    [field: SerializeField] public float jumpForce = 5;
    [SerializeField] SkinnedMeshRenderer Renderer;

    public int configRef;
    [SerializeField] protected float drag = 0.3f;
    protected Vector3 impact;
    protected Vector3 dampingVelocity;
    float verticalVelocity;
    public Vector3 Movement => impact + (transform.up * verticalVelocity);
    public bool inLevel = true;

    protected virtual void Awake()
    {
        if (Game == null) Game = FindObjectOfType<GameController>();
        if (Controller == null) Controller = GetComponent<CharacterController>();
        if (Animator == null) Animator = GetComponentInChildren<Animator>();
        if (Audio == null) Audio = GetComponentInChildren<CharacterAudio>();
    }

    protected virtual void Start()
    {
    }

    protected virtual void Update()
    {
        if (inLevel && !(Game.HUD.Programing.gameObject.activeSelf || Game.HUD.CharacterDesign.gameObject.activeSelf))
        {
            //print(name + " grounded = " + isGrounded);
            ApplyPhysics();
            ResetToCenter();
        }
    }

    private CharacterConfig config
    {
        get
        {
            if (Game.CharacterConfig.Length == 0) return null;
            return Game.CharacterConfig[configRef];
        }
    }

    private void ApplyPhysics()
    {
        //gravity
        if (verticalVelocity < 0f && isGrounded)
        {
            verticalVelocity = Physics.gravity.y * Time.deltaTime;
        }
        else
        {
            verticalVelocity += Physics.gravity.y * Time.deltaTime;
        }

        Animator?.SetBool("IsGrounded", isGrounded);

        impact = Vector3.SmoothDamp(impact, Vector3.zero, ref dampingVelocity, drag);

        if (impact.sqrMagnitude < 0.2f * 0.2f)
        {
            impact = Vector3.zero;
        }
    }

    private void ResetToCenter()
    {
        if (transform.position.z != Game.MapZCenter)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, Game.MapZCenter);
        }
    }

    protected void Move(Vector3 motion)
    {
        if (Controller.enabled) Controller.Move((motion + Movement) * Time.deltaTime);

    }

    protected void Move()
    {
        if (Controller.enabled) Controller.Move((Movement) * Time.deltaTime);
    }

    public CharacterConfig Config
    {
        get
        {
            return Game.CharacterConfig[configRef];
        }
    }

    public void UpdateCharacter()
    {
        ApplyArmourColors();
        ApplyHelmet();
        ApplyHelmetColor();
        ApplyWeaponConfig();
    }

    private void ApplyArmourColors()
    {
        if (Renderer == null) Renderer = GetComponentInChildren<SkinnedMeshRenderer>();
        Renderer.material = Game.ArmourColors[Game.CharacterConfig[configRef].armourColourRef];
    }

    private void ApplyHelmet()
    {
        if (Helmet != null)
        {
            Destroy(Helmet);
            Helmet = null;
        }

        if(configRef == 0) Helmet = Instantiate(Game.HelmentPrefabs[config.helmetRef], HeadPos);
        else Helmet = Instantiate(Game.GolbinHeadPrefabs[config.helmetRef], HeadPos);
    }

    private void ApplyHelmetColor()
    {
        if(configRef == 0)
        {
            MeshRenderer HelmentRenderer = Helmet.GetComponent<MeshRenderer>();

            switch (config.helmetRef)
            {
                case 0:
                    HelmentRenderer.material = Game.Helmet1Colors[config.armourColourRef];
                    break;

                case 1:
                    HelmentRenderer.material = Game.Helmet2Colors[config.armourColourRef];
                    break;

                case 2:
                    HelmentRenderer.material = Game.Helmet3Colors[config.armourColourRef];
                    break;
            }
        }
    }

    private void ApplyWeaponConfig()
    {
        if (Game.CharacterConfig.Length == 0) return;

        if (Weapon != null)
        {
            Destroy(Weapon.gameObject);
            Weapon = null;
        }

        if (Game.WeaponConfigs[config.weaponRef] == null) return;

        if (!Game.WeaponConfigs[config.weaponRef].LeftHanded)
            Weapon = Instantiate(Game.WeaponConfigs[config.weaponRef].Prefab, RightHand);
        else
            Weapon = Instantiate(Game.WeaponConfigs[config.weaponRef].Prefab, LeftHand);

    }

    protected void Attack()
    {
        Animator?.SetTrigger("Attack");
    }

    protected void Jump()
    {
        verticalVelocity += jumpForce;
    }

    protected void Interact()
    {

    }

    public void AddForce(Vector3 force)
    {
        impact += force;
    }

    private bool isGrounded
    {
        get
        {
            Vector3 position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
            //print(position);
            Vector3 down = transform.up * -1;
            Ray ray = new Ray(position, down);
            //Debug.DrawLine(ray.origin, ray.origin + transform.up * -1f * Game.GroundRaycastLength, Color.red);
            if (Physics.Raycast(ray, Game.GroundRaycastLength, Game.GroundLayer) ||
                Physics.Raycast(ray, Game.GroundRaycastLength, Game.InteractableLayer)) return true;
            return false;
        }
    }
}
