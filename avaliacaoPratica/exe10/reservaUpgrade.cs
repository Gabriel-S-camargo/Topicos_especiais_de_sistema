public class ReservaUpgrade : IReserva
{
    public string nomeDaReserva { get; set; }
    public string tipoDaReserva { set; get; }
    public bool statusReserva { get; set; }

    public ReservaUpgrade(string nomeDaReserva, string tipoDaReserva)
    {
        this.nomeDaReserva = nomeDaReserva;
        this.tipoDaReserva = tipoDaReserva;
        this.statusReserva = false;
    }

    public bool reservarVoo()
    {
        return this.statusReserva = true;
    }

    public bool cancelarVoo()
    {
        return this.statusReserva = false;
    }

    public string upgradeDeClasse(string novoTipoReserva)
    {
        return this.tipoDaReserva = novoTipoReserva;
    }

    public void mostrarInfo()
    {
        Console.WriteLine("Nome que esta reservado: " + this.nomeDaReserva);
        Console.WriteLine("Tipo da reserva: " + this.tipoDaReserva);
        string statusTemp = "teste";
        if (this.statusReserva == true)
        {
            statusTemp = "reservado";
        }
        else
        {
            statusTemp = "não reservado";
        }
        Console.WriteLine("Status da reserva: " + statusTemp);
    }
}