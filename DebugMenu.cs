using Godot;
using System;

public partial class DebugMenu : CanvasLayer
{
	[Export]
	bool display = true;

	[Export]
	public int fontSize = 12;

	[Export(PropertyHint.Range, "0,1,")]
	public float opacity = 1;

	public override void _Ready()
	{
		if (OS.IsDebugBuild() && display) {
			GetNode<RichTextLabel>("Panel/RichTextLabel").Text = "";
			GetNode<Panel>("Panel").Modulate = new Color("#ffffff", opacity);
		}
		else {
			Hide();
		}
	}

	public override void _Process(double delta)
	{
	}
}
