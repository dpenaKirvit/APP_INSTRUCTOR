namespace Electronica.Simulacion
{
    public interface IVariableHardware
    {
        int Id { get; set; }
        bool CambioVariable { get; }
        string Nombre { get; set; }
        int PosicionTrama { get; set; }
    }
}
