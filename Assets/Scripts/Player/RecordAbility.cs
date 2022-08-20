using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RecordAbility : MonoBehaviour
{
    public bool IsRecording = false;
    private float recordingTime;
    private InputManager input;
    private PlayerController player;
    private Vector3 recordingPosition;
    public SortedList<float, List<CommandType>> listCommands = new SortedList<float, List<CommandType>>();

    public Vector3 RecordingPosition { get => recordingPosition; }
    public float RecordingTime { get => recordingTime; }

    private void Awake()
    {
        player = GetComponent<PlayerController>();
        input = player.Input;
    }

    private void OnEnable()
    {
        input.onStartRecording += StartRecording;
        input.onSpawnGhost += SpawnGhost;
    }

    private void StartRecording(InputAction.CallbackContext context)
    {
        if (IsRecording)
        {
            recordingTime = 0f;
            IsRecording = false;
        }
        else
        {
            IsRecording = true;
            recordingPosition = transform.position;
            StartCoroutine(TimerRecording());
            listCommands.Clear();
        }
    }

    public void AddCommand(CommandType command, float time)
    {
        if(!listCommands.Keys.Contains(time))
        {
            //create a list in order to insert the first command
            var list = new List<CommandType>();
            list.Add(command);
            listCommands.Add(time, list);
        }
        else
        {
            listCommands[time].Add(command);
        }
    }

    private IEnumerator TimerRecording()
    {
        while (IsRecording)
        {
            yield return new WaitForSeconds(Time.deltaTime);
            recordingTime += Time.deltaTime;
        }
    }

    private void SpawnGhost(InputAction.CallbackContext context)
    {
        GameObject ghost = Instantiate(player.Ghost, recordingPosition, transform.rotation);
        ghost.GetComponent<GhostController>().Init(player.Speed, player.JumpForce, listCommands, player);
    }
}
