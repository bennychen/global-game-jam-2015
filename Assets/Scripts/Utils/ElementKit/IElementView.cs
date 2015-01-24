using UnityEngine;

public interface IElementView<T>
{
    T Context { get; }
    void Activate();
    void Deactivate();
}