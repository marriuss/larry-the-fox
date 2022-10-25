using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    [SerializeField] private Maze[] _mazePrefabs;
    [SerializeField] private Fox _player;

    private Maze _maze;

    private void Awake()
    {
        int length = _mazePrefabs.Length;

        if (length == 0)
            return;

        Maze mazePrefab = _mazePrefabs[Random.Range(0, length)];

        _maze = Instantiate(mazePrefab, Vector3.zero, Quaternion.identity, transform);

        if (_player != null)
            _maze.Initialize(_player);
    }
}
