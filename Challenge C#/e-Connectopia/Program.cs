using System;


class Program
{
    static void Main(string[] args)
    {

        Console.Write("Seja Bem-Vindo á E-Connectopia! \n");

        int produtoEscolhido;
        do
        {
            Console.WriteLine("============================================");
            Console.WriteLine("Escolha um dos seguintes produtos:");
            Console.WriteLine("(1) Apple iPhone 12 Pro Max R$3.799");
            Console.WriteLine("(2) Samsung Galaxy S20 Ultra R$2.499");
            Console.WriteLine("(3) ASUS ROG Phone 5 R$4.200");
            Console.WriteLine("(4) Apple iPhone XR R$1.780");
            Console.WriteLine("(5) Samsung Galaxy S20 FE R$2.099");
            Console.WriteLine("(6) Google Pixel 6 Pro R$699");
            Console.WriteLine("(7) Xiaomi Redmi Note 11 R$2.099");
            Console.WriteLine("(8) Samsung Galaxy A22 R$2.899");
            Console.WriteLine("(9) Motorola Moto E7 Power R$899");
            Console.WriteLine("(10) LG K41S R$855");

            Console.Write("Escolha o número do produto(1 a 10): \n");
            Console.WriteLine("============================================");

        } while (!int.TryParse(Console.ReadLine(), out produtoEscolhido) || produtoEscolhido < 1 || produtoEscolhido > 10);

        Console.Clear();

        int metodoPagamento;
        do
        {
            Console.WriteLine("============================================");
            Console.WriteLine("Escolha o método de pagamento:");
            Console.WriteLine("(1) PIX (Código disponivel no Final da Compra");
            Console.WriteLine("(2) Cartão de Crédito");
            Console.WriteLine("============================================");

        } while (!int.TryParse(Console.ReadLine(), out metodoPagamento) || (metodoPagamento != 1 && metodoPagamento != 2));


        if (metodoPagamento == 2)
        {
            Console.WriteLine("============================================");
            Console.Write("Digite o número do cartão de crédito(NNNN-NNNN-NNNN-NNNN): ");
            string numeroCartao = Console.ReadLine();

            Console.Write("Digite a data de validade (MM/AA): ");
            string dataValidade = Console.ReadLine();

            Console.Write("Digite o código de segurança (CVV): ");
            string cvv = Console.ReadLine();

            Console.WriteLine("============================================");
            Console.WriteLine("Dados do cartão de crédito registrados com sucesso!");
        }

        int parcelas = 1;
        if (metodoPagamento == 2)
        {
            do
            {
                Console.WriteLine("============================================");
                Console.Write("Escolha o número de parcelas (até 10x sem juros): ");
            } while (!int.TryParse(Console.ReadLine(), out parcelas) || parcelas < 1 || parcelas > 10);

            Console.Clear();
        }

        double precoProduto = 0.0;
        switch (produtoEscolhido)
        {
            case 1:
                precoProduto = 3799.0;
                break;
            case 2:
                precoProduto = 2499.0;
                break;
            case 3:
                precoProduto = 4200.0;
                break;
            case 4:
                precoProduto = 1780.0;
                break;
            case 5:
                precoProduto = 2099.0;
                break;
            case 6:
                precoProduto = 699.0;
                break;
            case 7:
                precoProduto = 2099.0;
                break;
            case 8:
                precoProduto = 2899.0;
                break;
            case 9:
                precoProduto = 899.0;
                break;
            case 10:
                precoProduto = 855.0;
                break;
            default:
                Console.WriteLine("Opção de produto inválida.");
                return;
        }

        double desconto = 0.0;
        Console.WriteLine("============================================");
        Console.Write("Insira Cupom de Desconto(Deixe em Branco caso Não Tenha): \n");
        Console.WriteLine("============================================");
        string possuiCupom = Console.ReadLine();
        if (possuiCupom.Equals("CRUZEIRO10"))
        {
            desconto = 10.0; // 10% de desconto
        }
        else if (possuiCupom.Equals("CRUZEIRO5"))
        {

            desconto = 5.0; // 5% de Desconto
        }

        double precoTotal = (precoProduto * (1 - (desconto / 100.0)));


        Console.WriteLine("Escolha o método de entrega:");
        Console.WriteLine("(1) Retirada em nossa loja física");
        Console.WriteLine("(2) Entrega");

        int metodoEntrega = int.Parse(Console.ReadLine());

        double precoFrete = 0.0;
        string enderecoEntrega = "";

        if (metodoEntrega == 2)
        {
            Console.WriteLine("============================================");
            Console.Write("Digite a Rua - Número - Bairro - Cidade - UF: ");
            enderecoEntrega = Console.ReadLine();

            precoFrete = 20.0;

            Console.Clear();
        }

        double precoTotalComFrete = precoTotal + precoFrete;
        double precoParcela = precoTotalComFrete / parcelas;

        Console.WriteLine("============================================");
        Console.WriteLine("\nResumo da compra:");
        Console.WriteLine("Produto escolhido: " + GetNomeProduto(produtoEscolhido));
        Console.WriteLine("Método de pagamento: " + (metodoPagamento == 1 ? "PIX. Copie esse código no aplicativo de banco: cbf85269-a3b4-4544-9352-5a22cc02a2f3" : "Cartão de Crédito"));
        Console.WriteLine("Número de parcelas: " + parcelas);
        Console.WriteLine("Desconto aplicado: " + desconto + "%");
        Console.WriteLine("Preço do produto: R$" + precoProduto.ToString("F2"));
        Console.WriteLine("Preço do frete: R$" + precoFrete.ToString("F2"));
        Console.WriteLine("Preço total da compra: R$" + precoTotalComFrete.ToString("F2"));
        Console.WriteLine("Preço por Parcela: R$" + precoParcela.ToString("F2"));


        if (metodoEntrega == 2)
        {
            Console.WriteLine("Endereço de entrega: " + enderecoEntrega + " Prazo de Chegada: 4 Dias");
            Console.WriteLine("============================================");
        }
        else
        {
            Console.WriteLine("Seu Produto está te Esperando! Loja mais próxima para retirada: Av. Giovanni Gronchi 5819 (Vila Andrade), São Paulo, SP, 05724-003");
            Console.WriteLine("============================================");
        }

        Console.WriteLine("\nDeseja confirmar a compra? (SIM/NAO): ");
        string confirmacao = Console.ReadLine();

        if (confirmacao.Equals("SIM", StringComparison.OrdinalIgnoreCase))
        {
            Console.WriteLine("Compra confirmada! Obrigado por sua compra.");
        }
        else
        {
            Console.WriteLine("Compra cancelada. Refaça o carrinho se desejar.");
        }




        static string GetNomeProduto(int produtoEscolhido)
        {
            switch (produtoEscolhido)
            {
                case 1:
                    return "Apple iPhone 12 Pro Max";
                case 2:
                    return "Samsung Galaxy S20 Ultra";
                case 3:
                    return "ASUS ROG Phone 5";
                case 4:
                    return "Apple iPhone XR";
                case 5:
                    return "Samsung Galaxy S20 FE";
                case 6:
                    return "Google Pixel 6 Pro";
                case 7:
                    return "Xiaomi Redmi Note 11";
                case 8:
                    return "Samsung Galaxy A22";
                case 9:
                    return "Motorola Moto E7 Power";
                case 10:
                    return "LG K41S";
                default:
                    return "Produto Desconhecido";
            }
        }
    }
}