using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMovement : MonoBehaviour
{
    public GameObject player;
    [SerializeField] float _speed;
    [SerializeField] float _speedBoost;
    bool isCatching = false;
    public Text helpText;




    void Update()
    {
        MoveCharacter();
    if (Input.GetKey(KeyCode.LeftShift))
        {
            if (!isCatching)
            {
                StartCoroutine(ArmCatcher());
            }
        }

  

    }

    

    void MoveCharacter()
    {
        float xDir = Input.GetAxis("Horizontal");
        //float zDir = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(xDir, 0f, 0f);

        transform.position += moveDirection * _speed * Time.deltaTime;

        if (isCatching)
        {
            transform.position += moveDirection * _speedBoost * Time.deltaTime;
        }
    }


    IEnumerator ArmCatcher()
    {
        isCatching = true;
        while (isCatching)
        {
        player.transform.localScale = new Vector3(5f, 1f, 0.53108f);
        yield return new WaitForSeconds(4f);
        player.transform.localScale = new Vector3(2.4214f, 1f, 0.53108f);
        yield return new WaitForSeconds(10f);
        isCatching= false;
        }
        
    }

   
}
