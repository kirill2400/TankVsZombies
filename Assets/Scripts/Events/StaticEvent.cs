using System;

public static class StaticEvent<T> where T : EventArgs
{
    private static event Action<object, T> Event;

    public static void Subscribe(Action<object, T> obj) => Event += obj;
    public static void UnSubscribe(Action<object, T> obj) => Event -= obj;
    public static void InvokeEvent(object sender, T args) => Event?.Invoke(sender, args);
}
