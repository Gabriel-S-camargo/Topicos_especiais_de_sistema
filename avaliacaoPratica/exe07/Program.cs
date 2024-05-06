ContaCorrente contaCorrente01 = new ContaCorrente(1, "Marco aurelio", "123-154-123-32");

ContaEmpresarial contaEmpresarial01 = new ContaEmpresarial(2, "Microsoft", 4000);

ContaPoupanca contaPoupanca01 = new ContaPoupanca(3, "Pedro Lucas", 1);

Console.WriteLine(contaPoupanca01.deposito(1000));

Console.WriteLine(contaPoupanca01.calcularJuros());

Console.WriteLine(contaEmpresarial01.deposito(1000));

Console.WriteLine(contaEmpresarial01.saque(1000));

Console.WriteLine(contaEmpresarial01.saque(1000));

contaEmpresarial01.mostrarInfo();