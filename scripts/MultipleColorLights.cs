Random rnd = new Random();

public Program()
{
    Runtime.UpdateFrequency = UpdateFrequency.Update10;
}


public void Main(string argument, UpdateType updateSource)
{
    IMyInteriorLight light = GridTerminalSystem.GetBlockWithName("NombreDeLaLuz") as IMyInteriorLight;
    
    if (light == null)
    {
        Echo("Luz no encontrada");
        return;
    }

    Color color = new Color(
        rnd.Next(0, 256), 
        rnd.Next(0, 256), 
        rnd.Next(0, 256)  
    );

    light.Color = color;
}