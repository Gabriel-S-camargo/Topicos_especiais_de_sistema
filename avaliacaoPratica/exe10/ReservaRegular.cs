public class ReservaRegular : IReserva
{
    public string nomeDaReserva { get; set; }

    public string tipoDaReserva { set; get; }
    public bool statusReserva { set; get; }

    public ReservaRegular(string nomeDaReserva)
    {
        this.nomeDaReserva = nomeDaReserva;
        this.statusReserva = false;
        this.tipoDaReserva = "Regular";
    }

    public bool reservarVoo()
    {
        return this.statusReserva = true;
    }

    public bool cancelarVoo()
    {
        return this.statusReserva = false;
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