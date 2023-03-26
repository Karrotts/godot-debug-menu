using Godot;

public class Debug {

    private DebugMenu debugMenu;

    public Debug(DebugMenu debugMenu) {
        this.debugMenu = debugMenu;
    }

    /// <summary>
    /// Prints information message to the debug menu and GD log
    /// </summary>
    /// <param name="message">Message to print</param>
    public void Info(string message) => Custom(new Color("#ecf0f1"), "INFO", message);

    /// <summary>
    /// Prints warning message to the debug menu and GD log
    /// </summary>
    /// <param name="message">Message to print</param>
    public void Warn(string message) => Custom(new Color("#f1c40f"), "WARN", message);

    /// <summary>
    /// Prints error message to the debug menu and GD log
    /// </summary>
    /// <param name="message">Message to print</param>
    public void Error(string message) => Custom(new Color("#e74c3c"), "ERROR", message);

    /// <summary>
    /// Prints success message to the debug menu and GD log
    /// </summary>
    /// <param name="message">Message to print</param>
    public void Success(string message) => Custom(new Color("#2ecc71"), "SUCCESS", message);

    /// <summary>
    /// Prints a custom log message to the debug menu and GD log
    /// </summary>
    /// <param name="color">Color of the message</param>
    /// <param name="tag">Tag type for the message, this appears before the message in brackets.</param>
    /// <param name="message">Message to print</param>
    public void Custom(Color color, string tag, string message) {
        GD.Print(message);
        Print($"[color={colorToHex(color)}][ {tag.ToUpper()} ]  {message}[/color]");
    }

    /// <summary>
    /// Prints a message directly to the debug menu
    /// </summary>
    /// <param name="message">Message to print</param>
    public void Print(string message) {
        if (debugMenu != null) {
            debugMenu.GetNode<RichTextLabel>("Panel/RichTextLabel").Text += $"{message}\n";
        }
        else {
            GD.PrintErr("Debug was not set to a valid DebugMenu Scene.");
        }
    }

    /// <summary>
    /// Clears the debug menu
    /// </summary>
    public void Clear() {
        if (debugMenu != null) {
            debugMenu.GetNode<RichTextLabel>("Panel/RichTextLabel").Text = "";
        }
        else {
            GD.PrintErr("Debug was not set to a valid DebugMenu Scene.");
        }
    }

    private string colorToHex(Color color) { 
        return "#" + color.R8.ToString("X2") + color.G8.ToString("X2") + color.B8.ToString("X2");
    }
}