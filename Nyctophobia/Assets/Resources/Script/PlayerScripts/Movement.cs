using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    public float currentMoveSpeed;
    private float minMoveSpeed;
    [SerializeField] private float staminaCount;
    private float maxStamina;
    [SerializeField] private bool rechargeStage = false;
    private bool canRun = true;
    [SerializeField] private float staminaDrain;

    public bool canWalk;

    public int playerHealth;

    private Slider staminaBar;

    private float idleBonus;
    [SerializeField] private GameObject exhaustedUI;

    private void Start()
    {
        staminaBar = GameObject.Find("Stamina Bar").GetComponent<Slider>();

        maxStamina = staminaCount;
        minMoveSpeed = currentMoveSpeed;
    }
    void Update()
    {
        if (playerHealth <= 0)
        {
            canWalk = false;
        }

        staminaCount = Mathf.Clamp(staminaCount, 0, maxStamina);

        //run function
        if (staminaCount > 0 && Input.GetKey(KeyCode.LeftShift) && !rechargeStage && canRun && !MoveAnimations.Instance.charAnim.GetBool("Idle"))
        {
            staminaCount -= staminaDrain * Time.deltaTime;
            StaminaUI();
            currentMoveSpeed = minMoveSpeed * 1.75f;
        }

        else if (staminaCount < maxStamina)
        {
            if(staminaCount <= 0)
            {
                rechargeStage = true;
                MoveAnimations.Instance.charAnim.Play("walking");
                exhaustedUI.SetActive(true);
            }
            staminaCount += staminaDrain / 3 * (idleBonus += Time.deltaTime);
            StaminaUI();
            currentMoveSpeed = minMoveSpeed;
        }
        if(staminaCount == maxStamina)
        {
            rechargeStage = false;
            exhaustedUI.SetActive(false);
        }

        // Makes it so that when you stand still you get stamina back faster, unless you are exhausted - Finn
        if (MoveAnimations.Instance.charAnim.GetBool("Idle") && !rechargeStage)
        {
            idleBonus = 0.05f;
        }
        else if (!MoveAnimations.Instance.charAnim.GetBool("Idle") || rechargeStage)
        {
            idleBonus = 0;
        }
    }

    private void OnCollisionStay(Collision col)
    {
        if (col.gameObject.tag == "Wall")
        {
            canRun = false;
            currentMoveSpeed = 0.5f;
        }
        else if(col.gameObject.tag != "Wall")
        {
            canRun = true;
            currentMoveSpeed = minMoveSpeed;
        }
    }

    

    void FixedUpdate()
    {
        if (canWalk)
        {
            float h = Input.GetAxisRaw("Horizontal") * Time.deltaTime;
            float v = Input.GetAxisRaw("Vertical") * Time.deltaTime;

            Vector3 movement = new Vector3(h, 0.0f, v);
            transform.Translate(movement * currentMoveSpeed, Space.World);

            if (movement != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(movement);
            }
        }


        // Checks for input and certain parameters to then enable the right animation to be played during movement - Finn
        if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D))
        {
            MoveAnimations.Instance.charAnim.Play("idle");
            MoveAnimations.Instance.charAnim.SetBool("Idle", true);
        }
        else if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) ||
                  Input.GetKey(KeyCode.D)) && !Input.GetKey(KeyCode.LeftShift))
        {
            MoveAnimations.Instance.charAnim.Play("walking");
            MoveAnimations.Instance.charAnim.SetBool("Idle", false);
        }
        else if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
                  && Input.GetKey(KeyCode.LeftShift) && !rechargeStage)
        {
            MoveAnimations.Instance.charAnim.Play("running");
            MoveAnimations.Instance.charAnim.SetBool("Idle", false);
        }
    }


    public void StaminaUI()
    {
        staminaBar.maxValue = maxStamina;
        staminaBar.value = staminaCount;
    }
}
