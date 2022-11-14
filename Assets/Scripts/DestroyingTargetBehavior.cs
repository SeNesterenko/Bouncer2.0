using DefaultNamespace;
using UnityEngine;

public class DestroyingTargetBehavior : MonoBehaviour
{
    [SerializeField] private Renderer _renderer;
    
    public DestroyHandler OnTargetDestroyed;
    
    private Color _color;

    public void Initialize(Color color)
    {
        _renderer.material.color = color;
        _color = color;
    }

    private void OnCollisionEnter(Collision collision)
    {
        var player = collision.gameObject.GetComponent<Player>();

        if (player)
        {
            if (player.Color == _color)
            {
                Destroy(gameObject);
                OnTargetDestroyed?.Invoke();
            }
        }
    }
}
