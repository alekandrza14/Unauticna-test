using Godot;
using System;

public class Buttonresset : Button
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}

	private void _on_Button2_button_down()
	{
		if (System.IO.Directory.Exists("unsave"))
		{
			System.IO.Directory.Delete("unsave", true);
		}
		if (System.IO.Directory.Exists("munsave"))
		{
			System.IO.Directory.Delete("munsave", true);
		}
		if (System.IO.Directory.Exists("unsavet"))
		{
			System.IO.Directory.Delete("unsavet", true);
		}
		if (System.IO.Directory.Exists("debug"))
		{
			System.IO.Directory.Delete("debug", true);
		}
		if (System.IO.Directory.Exists("world"))
		{
			System.IO.Directory.Delete("world", true);

		}
	}

	}


