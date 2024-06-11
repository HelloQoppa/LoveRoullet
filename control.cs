using Godot;
using System;

public partial class control : Control
{
    public void _on_button_pressed_aquecendo()
    {
        // Carregar a cena principal
        GetTree().ChangeSceneToFile("res://main.tscn");
    }

    public void _on_button_pressed_quente()
    {
        // Carregar a cena principal
        GetTree().ChangeSceneToFile("res://mainardente.tscn");
    }
}
