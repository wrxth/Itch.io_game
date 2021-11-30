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
    private bool rechargeStage = false;

    [SerializeField] private float staminaDrain;

    public bool canWalk;

    public int playerHealth;

    private Slider staminaBar;

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

        if (staminaCount > 0 && Input.GetKey(KeyCode.LeftShift) && !rechargeStage)
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
            }
            staminaCount += staminaDrain/3 * Time.deltaTime;
            StaminaUI();
            currentMoveSpeed = minMoveSpeed;
        }
        if(staminaCount == maxStamina)
        {
            rechargeStage = false;
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
    }


    public void StaminaUI()
    {
        staminaBar.maxValue = maxStamina;
        staminaBar.value = staminaCount;
    }
}
