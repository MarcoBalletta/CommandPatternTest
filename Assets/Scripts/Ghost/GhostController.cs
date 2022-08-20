using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostController : BaseCharacter
{
    /*[SerializeField] private float speed;
    [SerializeField] private float jumpForce;*/
    public SortedList<float, List<CommandType>> listCommands = new SortedList<float, List<CommandType>>();
    private float timer = 0f;
    private PlayerController originalPlayer;
    //private Rigidbody2D rb;
    private List<CommandType> currentCommands = new List<CommandType>();
    
    public PlayerController OriginalPlayer { get => originalPlayer; set => originalPlayer = value; }

    public void Init(float speedValue, float force, SortedList<float, List<CommandType>> list, PlayerController player)
    {
        Speed = speedValue;
        JumpForce = force;
        listCommands = list;
        Rb = GetComponent<Rigidbody2D>();
        originalPlayer = player;
    }

    private void Start()
    {
        StartCoroutine(RepeatActions());
    }

    private IEnumerator RepeatActions()
    {
        var indexActions = 0;
        while(indexActions < listCommands.Count)
        {
            //contains key troppo preciso, delta time diverso ogni volta
            if (timer>= listCommands.Keys[indexActions])
            {
                if(listCommands.Values[indexActions].Contains(CommandType.jump))
                {
                    originalPlayer.JumpCommand.Execute(this);
                }
                else
                {
                    currentCommands = listCommands.Values[indexActions];
                }
                indexActions++;
            }
            timer += Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
        }
        Destroy(this.gameObject, 3f);
    }

    private void FixedUpdate()
    {
        if(currentCommands.Contains(CommandType.moveLeft))
        {
            Rb.velocity = new Vector2(Vector2.right.x * -Speed * Time.deltaTime, Rb.velocity.y);
        }
        if(currentCommands.Contains(CommandType.moveRight))
        {
            Rb.velocity = new Vector2(Vector2.right.x * Speed * Time.deltaTime, Rb.velocity.y);
        }
    }
}
