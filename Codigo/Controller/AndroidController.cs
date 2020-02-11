using Godot;
using System;

public class AndroidController : Node2D
{
    public override void _Ready()
    {
        //SouMobile();
    }
    private void SouMobile()
    {
        if (OS.GetName() == "Android")
            QueueFree();
    }
}
