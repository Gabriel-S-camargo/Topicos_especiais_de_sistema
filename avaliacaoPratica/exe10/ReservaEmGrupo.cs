public class ReservaEmGrupo : IReserva
{
    public string nomeDaReserva { get; set; }
    public string tipoDaReserva { set; get; }
    public int quantidadeDePessoas { get; set; }
    public bool statusReserva { set; get; }

    public ReservaEmGrupo(string nomeDaReserva, int quantidadeDePessoas)
    {
        this.nomeDaReserva = nomeDaReserva;
        this.statusReserva = false;
        this.tipoDaReserva = "Reserva em Grupo";
        this.quantidadeDePessoas = quantidadeDePessoas;
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
        Console.WriteLine("Quantidade de pessoas na reserva: " + this.quantidadeDePessoas);
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