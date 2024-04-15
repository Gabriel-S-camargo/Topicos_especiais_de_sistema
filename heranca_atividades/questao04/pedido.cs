public class Pedido{
    public string data { get; set; }
    public Cliente cliente;

    public Pedido(string data, Cliente cliente){
        this.data = data;
        this.cliente = cliente;
    }
    
    public void mostrarInfo(){
        Console.WriteLine("Data do pedido: " + this.data);
        Console.WriteLine("Nome do cliente: " + this.cliente.nomeCliente);
        Console.WriteLine("CPF do cliente: " + this.cliente.cpf);
    }
}