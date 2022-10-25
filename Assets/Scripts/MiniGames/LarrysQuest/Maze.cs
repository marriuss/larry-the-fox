using UnityEngine;

public class Maze : MonoBehaviour, IResetable
{
    [SerializeField] private Transform _playerSpawn;

    private Fox _fox;

    public void ResetState()
    {
        _fox.transform.position = _playerSpawn.position;
    }

    public void Initialize(Fox fox) 
    {
        _fox = fox;
        ResetState();
    }
}