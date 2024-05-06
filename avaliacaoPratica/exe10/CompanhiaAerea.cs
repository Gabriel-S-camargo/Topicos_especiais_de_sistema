public class CompanhiaAerea
{

    public string nomeCompanhia { get; set; }
    public string aviaoCompanhia { get; set; }
    public bool reservado { get; set; }

    public CompanhiaAerea(string nomeCompanhia, string aviaoCompanhia)
    {
        this.nomeCompanhia = nomeCompanhia;
        this.aviaoCompanhia = aviaoCompanhia;
        this.reservado = false;
    }

    public void reservarVoo(IReserva reserva)
    {
        if (reservado == true)
        {
            Console.WriteLine("Voo ja esta reservado");
        }
        else
        {

            this.reservado = true;
            reserva.reservarVoo();
            Console.WriteLine("Voo reservado com sucesso!");
        }
    }

    public void cancelarVoo(IReserva reserva)
    {
        if (this.reservado == false)
        {
            Console.WriteLine("Este voo não possui reservas");
        }
        else
        {

            this.reservado = false;
            Console.WriteLine("Voo cancelado");
            reserva.cancelarVoo();

        }

    }
}