public void Main(string argument, UpdateType updateSource)
{
    IMyTextPanel lcd = GridTerminalSystem.GetBlockWithName("MiLCD") as IMyTextPanel;

    if (lcd == null)
    {
        Echo("LCD no encontrado.");
        return;
    }

    List<IMyBatteryBlock> batteries = new List<IMyBatteryBlock>();
    GridTerminalSystem.GetBlocksOfType(batteries);

    float energiaTotal = 0.0f;
    float energiaMaxima = 0.0f;

    foreach (var battery in batteries)
    {
        energiaTotal += battery.CurrentStoredPower;
        energiaMaxima += battery.MaxStoredPower;
    }

    float porcentajeEnergia = energiaMaxima > 0 ? energiaTotal / energiaMaxima : 0.0f;

    string texto = "Nivel de Baterías:\n";
    int largoBarra = 30;
    int posProgreso = (int)(porcentajeEnergia * largoBarra);
    string barraProgreso = "[" + new String('|', posProgreso) + new String(' ', largoBarra - posProgreso) + "]";

    lcd.ContentType = ContentType.TEXT_AND_IMAGE;
    lcd.FontSize = 2.0f;
    lcd.WriteText(texto + barraProgreso);
}