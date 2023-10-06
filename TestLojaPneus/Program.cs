using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.WriteLine(@"
████████╗░█████╗░██████╗░  ██████╗░██████╗░██╗██╗░░░██╗███████╗
╚══██╔══╝██╔══██╗██╔══██╗  ██╔══██╗██╔══██╗██║██║░░░██║██╔════╝
░░░██║░░░██║░░██║██████╔╝  ██║░░██║██████╔╝██║╚██╗░██╔╝█████╗░░
░░░██║░░░██║░░██║██╔═══╝░  ██║░░██║██╔══██╗██║░╚████╔╝░██╔══╝░░
░░░██║░░░╚█████╔╝██║░░░░░  ██████╔╝██║░░██║██║░░╚██╔╝░░███████╗
░░░╚═╝░░░░╚════╝░╚═╝░░░░░  ╚═════╝░╚═╝░░╚═╝╚═╝░░░╚═╝░░░╚══════╝");

        // Produtos disponíveis na loja
        Dictionary<int, string> produtos = new Dictionary<int, string>
        {
            { 1, "Troca de Oleo - R$450" },
            { 2, "Troca de Pneu - R$300" },
            { 3, "Balanceamento - R$250" },
            { 4, "Limpeza de cabecote - R$900" },
            { 5, "Troca de cambio - R$800" },
            { 6, "Bateria - R$190" },
            { 7, "Aditivo - R$40" },
            { 8, "Insul-film - R$120" },
            { 9, "Revisao Ar-condicionado - R$350" },
            { 10, "Parte eletrica - R$500" },
            { 11, "Alinhamento de Direção - R$200" },
            { 12, "Troca de Filtros de Ar e Óleo - R$700" },
            { 13, "Troca de Velas de Ignição - R$80" },
            { 14, "Pintura de Rodas - R$150" },
            { 15, "Reparo do Sistema de Freios - R$350" }
        };

        // Preços dos produtos
        Dictionary<int, decimal> precos = new Dictionary<int, decimal>
        {
            { 1, 450.0m },
            { 2, 300.0m },
            { 3, 250.0m },
            { 4, 900.0m },
            { 5, 800.0m },
            { 6, 190.0m },
            { 7, 40.0m },
            { 8, 120.0m },
            { 9, 350.0m },
            { 10, 500.0m },
            { 11, 200.0m },
            { 12, 700.0m },
            { 13, 80.0m },
            { 14, 150.0m },
            { 15, 350.0m }

        };

        // Cupom promocional
        string cupomPromocional = "TOPDRIVE10";
        decimal descontoCupom = 0.10m;

        List<int> carrinho = new List<int>();
        decimal totalCompra = 0.0m;

        Console.WriteLine("\nBem-vindo à Top Drive!!\n");
        Console.WriteLine("Vamos realizar seu cadastro:\n");
        Console.WriteLine("Digite Seu nome:");
        var nome = Console.ReadLine();

        Console.WriteLine("Informe seu endereço: ");
        var endereco = Console.ReadLine();

        Console.WriteLine("Digite o numero da sua casa: ");
        var numero = Console.ReadLine();

        Console.WriteLine("Digite seu bairro: ");
        var bairro = Console.ReadLine();

        Console.WriteLine("Digite seu CEP: ");
        var cep = Console.ReadLine();

        Console.WriteLine("Digite seu cidade: ");
        var cidade = Console.ReadLine();

        Console.WriteLine("Digite seu telefone:");
        var telefone = Console.ReadLine();

        Console.Clear();  
        
        Console.WriteLine(nome);

        Console.WriteLine("Conheça nossos produtos disponíveis:");

        foreach (var produto in produtos)
        {
            Console.WriteLine($"{produto.Key}. {produto.Value}");
        }

        while (true)
        {
            Console.WriteLine("\nDigite o número do produto que deseja adicionar ao carrinho (ou 0 para sair):");
            int escolhaProduto = Convert.ToInt32(Console.ReadLine());

            if (escolhaProduto == 0)
                break;

            if (produtos.ContainsKey(escolhaProduto))
            {
                carrinho.Add(escolhaProduto);
                totalCompra += precos[escolhaProduto];
                Console.WriteLine($"{produtos[escolhaProduto]} adicionado ao carrinho.");
            }
            else
            {
                Console.WriteLine("Produto não encontrado. Tente novamente.");
            }
        }

        //Variavel data de compra.
        var date = DateTime.Now;

        Console.WriteLine("\nObrigado pela escolha Sr(a):" + nome);
        Console.WriteLine("\nCarrinho de Compras:");
        Console.WriteLine("Data da compra:" + date);
        foreach (var item in carrinho)
        {
            Console.WriteLine($"{produtos[item]}");
        }

        Console.WriteLine($"\nTotal da compra: R${totalCompra}");

        Console.WriteLine("\nDigite o código do cupom promocional (ou deixe em branco se não tiver):");
        string codigoCupom = Console.ReadLine();

        if (codigoCupom == cupomPromocional)
        {
            totalCompra *= (1 - descontoCupom);
            Console.WriteLine($"Cupom aplicado! Total com desconto: R${totalCompra}");
        }

        Console.WriteLine("\nSelecione o método de pagamento (1 - Cartão de Crédito, 2 - PayPal, 3 - Transferência Bancária):");
        int metodoPagamento = Convert.ToInt32(Console.ReadLine());

        //Variavel  data de entrega
        var servico = date.AddDays(+2);

        switch (metodoPagamento)
        {
            case 1:
                Console.WriteLine("\nPagamento com Cartão de Crédito bem-sucedido!\n");
                Console.WriteLine("Obrigado por comprar conosco!");
                Console.WriteLine("\nPrevisão de Serviço: " + servico);
                Console.WriteLine("Telefone para contato: " + telefone);
                Console.WriteLine("Endereço:" + endereco + " N°" + numero);
                Console.WriteLine("Bairro: " + bairro);
                Console.WriteLine("Cidade: " + cidade);
                break;
            case 2:
                Console.WriteLine("\nPagamento com PayPal bem-sucedido!\n");
                Console.WriteLine("Obrigado por comprar conosco!");
                Console.WriteLine("\nPrevisão de Serviço: " + servico);
                Console.WriteLine("Telefone para contato: " + telefone);
                Console.WriteLine("Endereço: " + endereco + " N°" + numero);
                Console.WriteLine("Bairro: " + bairro);
                Console.WriteLine("Cidade: " + cidade);
                break;
            case 3:
                Console.WriteLine("\nPagamento com Transferência Bancária bem-sucedido!\n");
                Console.WriteLine("Obrigado por comprar conosco!");
                Console.WriteLine("\nPrevisão de Serviço: " + servico);
                Console.WriteLine("Telefone para contato: " + telefone);
                Console.WriteLine("Endereço:" + endereco + " N°" + numero);
                Console.WriteLine("Bairro: " + bairro);
                Console.WriteLine("Cidade: " + cidade);
                break;
            default:
                Console.WriteLine("\nMétodo de pagamento inválido.\n");
                Console.WriteLine("Obrigado, mas houve uma falha com o pagamento, pedido cancelado!");
                break;
        }



    }
}