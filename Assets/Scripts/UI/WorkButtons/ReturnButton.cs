using UnityEngine;

class ReturnButton : SceneLoadButton 
{
    [SerializeField] private HubLevel _hub;

    private void Start()
    {
        Initialize(_hub);
    }
}