using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuaOnFieldAbility : MonoBehaviour
{
    public static LuaOnFieldAbility Instance;
    private Animator anim;
    public GameObject fireLua;
    public bool fire = false;
   

    //[SerializeField] private Transform particleSpawn

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        float z = Input.GetAxisRaw("Vertical");
        anim.SetFloat("VelZ", z);
        
        float x = Input.GetAxisRaw("Horizontal");
        anim.SetFloat("VelX", x);
       

        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

        Ability();
    }

    public void Ability()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            if(!anim.GetBool("Lua_ability"))
            {
                anim.SetBool("Lua_ability", true);
                fireLua.gameObject.SetActive(true);
                fire = true;

            }
            else
            {
                anim.SetBool("Lua_ability", false);
                fireLua.gameObject.SetActive(false);
                fire = false;
            }

        }
            
    }

    


}

