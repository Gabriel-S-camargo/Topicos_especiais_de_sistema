BoletoBancario boletoBancario = new BoletoBancario(1000, 3);

CartaoCredito cartaoCredito= new CartaoCredito(30, 1000);

TransferenciaBancaria transferenciaBancaria = new TransferenciaBancaria(1000, 1);

SistemaPagamento contaDeLuz = new SistemaPagamento("Conta de luz", 100);

SistemaPagamento financiamentoBmw = new SistemaPagamento("Financiamento BMW", 1000);

Console.WriteLine(contaDeLuz.situacaoPagamento());

contaDeLuz.pagarConta(boletoBancario);

contaDeLuz.pagarConta(transferenciaBancaria);

contaDeLuz.pagarConta(cartaoCredito);

boletoBancario.statusPagamento();

cartaoCredito.statusPagamento();

transferenciaBancaria.statusPagamento();

financiamentoBmw.pagarConta(boletoBancario);

financiamentoBmw.pagarConta(transferenciaBancaria);

financiamentoBmw.pagarConta(cartaoCredito);