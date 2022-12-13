using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [field: SerializeField] public GameController Game { get; private set; }
    [field: SerializeField] public Transform HeadPos { get; private set; }
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
            print(name + " " + Controller.isGrounded);
            ApplyPhysics();
            ResetToCenter();
        }
    }

    private CharacterConfig config
    {
        get
        {
            return Game.CharacterConfig[configRef];
        }
    }

    private void ApplyPhysics()
    {
        //gravity
        if (verticalVelocity < 0f && Controller.isGrounded)
        {
            verticalVelocity = Physics.gravity.y * Time.deltaTime;
        }
        else
        {
            verticalVelocity += Physics.gravity.y * Time.deltaTime;
        }

        Animator?.SetBool("IsGrounded", Controller.isGrounded);

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

        Helmet = Instantiate(Game.HelmentPrefabs[config.helmetRef], HeadPos);
        Helmet.transform.parent = HeadPos;
        Helmet.transform.localEulerAngles = Vector3.zero;
        Helmet.transform.localPosition = Vector3.zero;
    }

    private void ApplyHelmetColor()
    {
        MeshRenderer HelmentRenderer = Helmet.GetComponent<MeshRenderer>();

        switch (config.helmetRef)
        {
            case 1:
                HelmentRenderer.material = Game.Helmet1Colors[config.armourColourRef];
                break;

            case 2:
                HelmentRenderer.material = Game.Helmet2Colors[config.armourColourRef];
                break;

            case 3:
                HelmentRenderer.material = Game.Helmet3Colors[config.armourColourRef];
                break;
        }
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
            Vector3 position = new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z);

            Ray ray = new Ray(position, transform.up);
            Debug.DrawLine(ray.origin, transform.up * -0.5f);
            RaycastHit[] hits = Physics.SphereCastAll(ray, 0.5f, Game.GroundLayer.value);
            
            if (hits.Length > 0)
            {
                foreach (RaycastHit hit in hits)
                {
                    //if (((1 << hit.collider.gameObject.layer) & Game.InteractableLayer) != 0) return true;
                    if (((1 << hit.collider.gameObject.layer) & Game.GroundLayer) != 0)
                    {
                        print(hit.collider.gameObject.name);
                        return true;
                    }
                }
            }
            
            
            return false;
        }
    }

/*    private void OnDrawGizmos()
    {
        Vector3 position = new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z);
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(position, 0.5f);
    }*/

}
