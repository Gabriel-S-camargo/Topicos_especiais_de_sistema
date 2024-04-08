public class Cliente{
    public string cpf;
    public string nomeCliente;

    public cliente(string cpf){
        this.cpf = cpf;

        if(cpf == "888"){
            this.nomeCliente = "Pedro Lara";
        }
        else if(cpf == "999"){
            this.nomeCliente = "Araci de almeida";
        }
    }
    public cliente(){
        
    }

}
