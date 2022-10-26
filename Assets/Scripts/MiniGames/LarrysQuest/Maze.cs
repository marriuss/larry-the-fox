using UnityEngine;

public class Maze : ResetableMonoBehaviour
{
    [SerializeField] private Transform _playerSpawn;

    private Fox _fox;

    public override void ResetState()
    {
        _fox.transform.position = _playerSpawn.position;
    }

    public void Initialize(Fox fox) 
    {
        _fox = fox;
        ResetState();
    }
}