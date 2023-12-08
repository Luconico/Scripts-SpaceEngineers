List<IMyInteriorLight> lights = new List<IMyInteriorLight>();
int currentLightIndex = 0;
int stepCounter = 0;

public Program()
{
    Runtime.UpdateFrequency = UpdateFrequency.Update10; 

    List<IMyInteriorLight> allLights = new List<IMyInteriorLight>();
    GridTerminalSystem.GetBlocksOfType(allLights, light => light.CustomName.StartsWith("luz"));

    foreach (var light in allLights)
    {
        if (light.IsFunctional)
        {
            lights.Add(light);
            light.Enabled = false; 
        }
    }
}

public void Main(string argument, UpdateType updateSource)
{
    if (lights.Count == 0)
    {
        Echo("No ligths.");
        return;
    }

    if (stepCounter % 10 == 0)
    {
        if (currentLightIndex < lights.Count)
        {
            lights[currentLightIndex].Enabled = false;
        }

        currentLightIndex = (currentLightIndex + 1) % lights.Count;

        lights[currentLightIndex].Enabled = true;
    }

    stepCounter++;
}